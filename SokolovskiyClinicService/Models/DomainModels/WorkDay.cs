using System;
using System.ComponentModel;
using SokolovskiyClinicService.Models.DTOModels;

namespace SokolovskiyClinicService.Models.DomainModels
{
    public class WorkDay
    {
        public int Id { get; set; }
        public TimeSpan BeginOfDay { get; set; }
        
        public TimeSpan EndOfDay { get; set; }

        public WorkDay(WorkDayDto workDayDto)
        {
            BeginOfDay = workDayDto.BeginOfDay;
            EndOfDay = workDayDto.EndOfDay;
        }
        
        public WorkDay(){}
    }
}