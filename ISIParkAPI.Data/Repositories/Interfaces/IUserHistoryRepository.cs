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
    /// This interface it will be consumed by the class UserHistoryRepository
    /// </summary>
    public interface IUserHistoryRepository
    {
        Task<IEnumerable<UserHistory>> GetAllUserHistory();
        Task<UserHistory> GetUserHistoryID(int utilizadorid);
        Task<bool> InsertUserHistory(UserHistory userHistory);
        //Task<bool> UpdateUserHistory(UserHistory userHistory);
        Task<bool> DeleteUserHistory(UserHistory userHistory);
    }
}
