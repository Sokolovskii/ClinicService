using System;
using SokolovskiyClinicService.Models.DomainModels;

namespace SokolovskiyClinicService.Entity.Repository.WorkDayRepository
{
    public interface IWorkDayRepository
    {
        int GetOrAddNewWorkDay(TimeSpan beginOfDay, TimeSpan endOfDay);

        WorkDay GetById(int workDayId);
    }
}