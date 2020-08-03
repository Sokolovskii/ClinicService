namespace SokolovskiyClinicService.Models.DomainModels
{
    /// <summary>
    /// Модель професси врача
    /// </summary>
    public class Profession
    {
        /// <summary>
        /// Id профессии
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Название профессии
        /// </summary>
        public string Name { get; set; }
    }
}