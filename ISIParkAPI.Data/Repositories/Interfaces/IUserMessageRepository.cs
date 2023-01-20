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
    /// This interface it will be consumed by the class UserMessageRepository
    /// </summary>
    public interface IUserMessageRepository
    {
        Task<IEnumerable<UserMessage>> GetAllUserMessage();
        Task<UserMessage> GetUserMessageID(int utilizadorid);
        Task<bool> InsertUserMessage(UserMessage userMessage);
        Task<bool> UpdateUserMessage(UserMessage userMessage);
        Task<bool> DeleteUserMessage(UserMessage userMessage);
        Task<IEnumerable<AdminNotification>> GetUserMessageAdminID(int utilizadorid);
    }
}
