using System;
using System.Runtime.Serialization;
using SokolovskiyClinicService.Models.DomainModels;

namespace SokolovskiyClinicService.Models.DTOModels
{
    [DataContract]
    public class WorkDayDto
    {
        [DataMember(Name = "beginOfDay")]
        public TimeSpan BeginOfDay { get; set; }
        
        [DataMember(Name = "endOfDay")]
        public TimeSpan EndOfDay { get; set; }

        public WorkDayDto(WorkDay workDay)
        {
            BeginOfDay = workDay.BeginOfDay;
            EndOfDay = workDay.EndOfDay;
        }

        public static WorkDayDto GetWorkDayDto(WorkDay workDay)
        {
            return workDay == null ? null : new WorkDayDto(workDay);
        }

        public WorkDayDto()
        {
            
        }
    }
}