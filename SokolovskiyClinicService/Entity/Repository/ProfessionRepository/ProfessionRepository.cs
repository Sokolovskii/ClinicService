using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SokolovskiyClinicService.Models.DomainModels;

namespace SokolovskiyClinicService.Entity.Repository.ProfessionRepository
{
    /// <summary>
    /// Репозиторий профессий
    /// </summary>
    /// <inheritdoc cref="IProfessionRepository"/>
    public class ProfessionRepository : IProfessionRepository
    {
        private readonly DataContext _context;

        public ProfessionRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Profession> GetAllProfessions()
        {
            return _context.Professions.ToList();
        }

        public Profession GetProfessionByName(string specialisation)
        {
            return _context.Professions.SingleOrDefault(p=>p.Name == specialisation);
        }

        public void AddNewProfession(string professionName)
        {
            var profession = new Profession
            {
                Name = professionName
            };
            _context.Entry(profession).State = EntityState.Added;
            _context.SaveChanges();
        }

        public Profession GetProfessionById(int professionId)
        {
            return _context.Professions.FirstOrDefault(p => p.Id == professionId);
        }
    }
}