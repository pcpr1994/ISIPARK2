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
    /// This interface it will be consumed by the class AddressRepository
    /// </summary>
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAllAddress();
        Task<Address> GetAddressDetails(int id);
        Task<bool> InsertAddress(Address address);
        Task<bool> UpdateAddress(Address address);
        Task<bool> DeleteAddress(Address address);
    }
}
