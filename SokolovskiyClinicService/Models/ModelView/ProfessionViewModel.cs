using SokolovskiyClinicService.Models.DomainModels;

namespace SokolovskiyClinicService.Models.ModelView
{
    public class ProfessionViewModel
    {
        /// <summary>
        /// Id профессии
        /// </summary>
        public int Id { get;}
        
        /// <summary>
        /// название профессии
        /// </summary>
        public string Name { get;}

        public ProfessionViewModel(Profession profession)
        {
            Id = profession.Id;
            Name = profession.Name;
        }

        public static ProfessionViewModel GetProfessionViewModelOrNull(Profession profession)
        {
            return profession == null ? null : new ProfessionViewModel(profession);
        }
        
        public ProfessionViewModel(){}
    }
}