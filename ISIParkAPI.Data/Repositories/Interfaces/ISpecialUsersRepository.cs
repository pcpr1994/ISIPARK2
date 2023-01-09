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
    /// This interface it will be consumed by the class SpecialUsersRepository
    /// </summary>
    public interface ISpecialUsersRepository
    {
        Task<IEnumerable<SpecialUser>> GetAllSpecialUser();
        Task<SpecialUser> GetSpecialUserByID(int id);
        Task<bool> InsertSpecialUser(SpecialUser specialUser);
        Task<bool> UpdateSpecialUser(SpecialUser specialUser);
        Task<bool> DeleteSpecialUser(SpecialUser specialUser);
    }
}
