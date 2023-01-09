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
    /// This interface it will be consumed by the class AdminMessageRepository
    /// </summary>
    public interface IAdminMessageRepository
    {
        Task<IEnumerable<AdminMessage>> GetAllAdminMessage();
        Task<AdminMessage> GetAdminMessageDetails(int id);
        Task<bool> InsertAdminMessage(AdminMessage adminMessage);
        Task<bool> UpdateAdminMessage(AdminMessage adminMessage);
        Task<bool> DeleteAdminMessage(AdminMessage adminMessage);
    }
}
