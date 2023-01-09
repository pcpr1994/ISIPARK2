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
    /// This interface it will be consumed by the class UserRepository
    /// </summary>
    public interface IUserRepository
    {
        Task<IEnumerable<UserDTO>> GetAllUser();
        Task<UserDTO> GetUserByEmail(string email);
        Task<UserDTO> GetUserById(int id);
        Task<bool> InsertUser(UserDTO user);
        Task<bool> UpdateUser(UserDTO user);
        Task<bool> DeleteUser(UserDTO user);
        bool GetUserByEm(string email);
        byte[] GetUserByPasswordh(string email);
        byte[] GetUserByPasswords(string email);
        Task<bool> UpdateUserToken(UserDTO user, string token);
    }
}
