/*
 * Grupo 4
 * Trabalho II de ISI
 * Alunos
 *  Carlos Pereira nº6498
 *  Paula Rodrigues nº21133
 *  Sérgio Gonçalves nº20343
 *  
 */
using ISIParkAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories.Interfaces
{
    /// <summary>
    /// This interface it will be consumed by the class PersonalDataRepository
    /// </summary>
    public interface IPersonalDataRepository
    {
        Task<IEnumerable<PersonalData>> GetAllPersonalData();
        Task<PersonalData> GetPersonalDataDetails(int numero);
        Task<bool> InsertPersonalData(PersonalData personalData);
        Task<bool> UpdatePersonalData(PersonalData personalData);
        Task<bool> DeletePersonalData(PersonalData personalData);
    }
}
