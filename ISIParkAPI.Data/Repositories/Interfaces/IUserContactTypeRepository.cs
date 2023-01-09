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
    /// This interface it will be consumed by the class UserContactTypeRepository
    /// </summary>
    public interface IUserContactTypeRepository
    {
        Task<IEnumerable<UserContactType>> GetAllUserContactType();
        Task<UserContactType> GetUserContactTypeID(int utilizadorid);
        Task<bool> InsertUserContactType(UserContactType userContactType);
        Task<bool> UpdateUserContactType(UserContactType userContactType);
        Task<bool> DeleteUserContactType(UserContactType userContactType);
    }
}
