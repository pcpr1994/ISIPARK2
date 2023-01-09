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
    /// This interface it will be consumed by the class ContactTypeRepository
    /// </summary>
    public interface IContactTypeRepository
    {
        Task<IEnumerable<ContactType>> GetAllContactType();
        Task<ContactType> GetContactTypeDetails(int id);
        Task<bool> InsertContactType(ContactType contactType);
        Task<bool> UpdateContactType(ContactType contactType);
        Task<bool> DeleteContactType(ContactType contactType);
    }
}
