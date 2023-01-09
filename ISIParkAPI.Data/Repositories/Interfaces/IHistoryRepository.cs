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
    /// This interface it will be consumed by the class HistoryRepository
    /// </summary>
    public interface IHistoryRepository
    {
        Task<IEnumerable<History>> GetAllHistory();
        Task<History> GetHistoryDetails(int id);
        Task<bool> InsertHistory(History history);
        Task<bool> UpdateHistory(History history);
        Task<bool> DeleteHistory(History history);
    }
}
