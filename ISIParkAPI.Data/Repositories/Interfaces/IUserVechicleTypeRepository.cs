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
    /// This interface it will be consumed by the class UserVechicleTypeRepository
    /// </summary>
    public interface IUserVechicleTypeRepository
    {
        Task<IEnumerable<UserVechicleType>> GetAllUserVechicleTypey();
        Task<UserVechicleType> GetUserVechicleTypeID(int utilizadorid);
        Task<bool> InsertUserVechicleType(UserVechicleType userVechicleType);
        Task<bool> UpdateUserVechicleType(UserVechicleType userVechicleType);
        Task<bool> DeleteUserVechicleType(UserVechicleType userVechicleType);
    }
}
