using System.Collections.Generic;
using SokolovskiyClinicService.Models.DomainModels;

namespace SokolovskiyClinicService.Entity.Repository.ProfessionRepository
{
    /// <summary>
    /// Интерфейс репозитория профессий
    /// </summary>
    public interface IProfessionRepository
    {
        /// <summary>
        /// Возвращает список всех профессий
        /// </summary>
        IEnumerable<Profession> GetAllProfessions();

        /// <summary>
        /// Возвращает профессию по ее названию
        /// </summary>
        Profession GetProfessionByName(string specialisation);

        /// <summary>
        /// Добавляет новую специализацию в базу
        /// </summary>
        void AddNewProfession(string professionName);

        /// <summary>
        /// Возвращает профессию по ее Id
        /// </summary>
        Profession GetProfessionById(int professionId);
    }
}