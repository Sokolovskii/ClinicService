using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SokolovskiyClinicService.BusinessLogic.CommonServices;
using SokolovskiyClinicService.Models.ModelView;


namespace SokolovskiyClinicService.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICommonServices _commonServices;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="commonServices"></param>
        public HomeController(ILogger<HomeController> logger, ICommonServices commonServices)
        {
            _logger = logger;
            _commonServices = commonServices;
        }

        /// <summary>
        /// Возвращает представление базовой страницы
        /// </summary>
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return View();
            if (User.Claims.First(c => c.Type == ClaimsIdentity.DefaultRoleClaimType).Value == "Admin")
            {
                return RedirectToAction("DoctorsForAdmin");
            }
            if(User.Claims.First(c => c.Type == ClaimsIdentity.DefaultRoleClaimType).Value == "Doctor")
            {
                return RedirectToAction("DoctorPanel");
            }
            return View();
        }


        /// <summary>
        /// Возвращает страницу с расписанием врача и отмеченными сеансами
        /// </summary>
        [Route("Home/Session")]
        public IActionResult Session(int doctorId, DateTime dateTime)
        {
            try
            {
                var userId = 0;
                if (User.Identity.IsAuthenticated)
                {
                    userId = int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
                }

                var modelView = new SessionView
                {
                    Doctor = new DoctorWithScheduleAndProfessionViewModel
                    (
                        _commonServices.GetDoctorById(doctorId),
                        _commonServices.GetProfessionByDoctorId(doctorId),
                        _commonServices.ExtractWorkDayFromSchedule(
                            _commonServices.GetScheduleOnDate(doctorId, dateTime), dateTime)
                    ),
                    DateTime = dateTime,
                    Sessions = _commonServices.GetSessionsByDoctorIdAndDate(doctorId, dateTime)
                        .ToDictionary(kvp => kvp.Key, kvp => SessionViewModel.ConvertToSessionViewModel(kvp.Value)),
                    UserId = userId
                };
                return View(modelView);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        /// <summary>
        /// Возвращает страницу с таблицей врачей с указанием актуального графика для каждого из них
        /// </summary>
        [Route("Home/DoctorsForUser")]
        [Route("DoctorsForUser")]

            public IActionResult DoctorsForUser(int professionId)
        {
            try
            {
                return View(_commonServices.GetAllDoctors().Where(d => d.IsApproved)
                    .Join(_commonServices.GetAllProfessions(),
                        d => d.ProfessionId,
                        p => p.Id,
                        (doctor, profession) => new DoctorScheduleProfessionForTablesViewModel(doctor, profession))
                    .Where(d => d.Profession.Id == professionId));
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }


        /// <summary>
        /// Возвращает страницу со списком всех врачей для админа
        /// </summary>
        [Route("Home/DoctorsForAdmin")]
        public IActionResult DoctorsForAdmin()
        {
            try
            {
                return View(_commonServices.GetAllDoctors()
                    .Join(_commonServices.GetAllProfessions(),
                        d => d.ProfessionId,
                        p => p.Id,
                        (doctor, profession) => new DoctorScheduleProfessionForTablesViewModel(doctor, profession)));
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [Route("Home/DoctorPanel")]
        public IActionResult DoctorPanel()
        {
            try
            {
                var userId = 0;
                if (User.Identity.IsAuthenticated)
                {
                    userId = int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
                }

                var schedule = _commonServices.GetScheduleOnDate(userId, DateTime.Today);
                var modelView = new DoctorPanelViewModel
                {
                    DoctorView = new DoctorViewModel(_commonServices.GetDoctorById(userId)),
                    ProfessionView =
                        ProfessionViewModel.GetProfessionViewModelOrNull(
                            _commonServices.GetProfessionByDoctorId(userId)),
                    ScheduleViewModel = null
                };
                if (schedule != null)
                {
                    modelView.ScheduleViewModel = new ScheduleViewModel
                    {
                        Monday = _commonServices.GetWorkDayById(schedule.MondayId),
                        Tuesday = _commonServices.GetWorkDayById(schedule.TuesdayId),
                        Wednesday = _commonServices.GetWorkDayById(schedule.WednesdayId),
                        Thursday = _commonServices.GetWorkDayById(schedule.ThursdayId),
                        Friday = _commonServices.GetWorkDayById(schedule.FridayId),
                        Saturday = _commonServices.GetWorkDayById(schedule.SaturdayId),
                        Sunday = _commonServices.GetWorkDayById(schedule.SundayId)
                    };
                }

                return View(modelView);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}