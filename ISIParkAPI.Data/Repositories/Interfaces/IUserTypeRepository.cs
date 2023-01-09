/*
 * Grupo 4
 * Trabalho II de ISI
 * Alunos
 *  Carlos Pereira nº6498
 *  Paula Rodrigues nº21133
 *  Sérgio Gonçalves nº20343
 *  
 */using ISIParkAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories.Interfaces
{
    /// <summary>
    /// This interface it will be consumed by the class UserTypeRepository
    /// </summary>
    public interface IUserTypeRepository
    {
        Task<IEnumerable<UserType>> GetAllUserType();
        Task<UserType> GetUserTypeDetails(int id);
        Task<bool> InsertUserType(UserType userType);
        Task<bool> UpdateUserType(UserType userType);
        Task<bool> DeleteUserType(UserType userType);
    }
}
