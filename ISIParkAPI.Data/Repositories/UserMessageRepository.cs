/*
 * Grupo 4
 * Trabalho II de ISI
 * Alunos
 *  Carlos Pereira nº6498
 *  Paula Rodrigues nº21133
 *  Sérgio Gonçalves nº20343
 *  
 */
using Dapper;
using ISIParkAPI.Data.Repositories.Interfaces;
using ISIParkAPI.Model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories
{
    /// <summary>
    /// This class contains all functions that perform actions on user messages
    /// </summary>
    public class UserMessageRepository : IUserMessageRepository
    {
        /// <summary>
        /// An instance of class MySQLConfiguration
        /// </summary>
        private MySQLConfiguration _connectionString;

        /// <summary>
        /// Initialize the instance containing the database connection information
        /// </summary>
        /// <param name="connectionString"></param>
        public UserMessageRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Connects to database
        /// </summary>
        /// <returns></returns>
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        /// <summary>
        /// This method gets all users/messages from the database using a query
        /// </summary>
        /// <returns>gets all the data</returns>
        public async Task<IEnumerable<UserMessage>> GetAllUserMessage()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM utilizador_Mensagem";
            return await db.QueryAsync<UserMessage>(sql, new { });
        }

        /// <summary>
        /// This method gets the ids of a user's message from the database
        /// </summary>
        /// <param name="utilizadorid">user id </param>
        /// <returns>returns id of messages</returns>
        public async Task<UserMessage> GetUserMessageID(int utilizadorid)
        {
            var db = dbConnection();
            var sql = @"SELECT utilizadorid, Mensagemid_mensagem
                        FROM utilizador_Mensagem
                        WHERE utilizadorid = @Utilizadorid";
            return await db.QueryFirstOrDefaultAsync<UserMessage>(sql, new { Utilizadorid = utilizadorid });
        }

        /// <summary>
        /// This method inserts a message assigned to a user in the database
        /// </summary>
        /// <param name="userMessage"></param>
        /// <returns>True inserted or false</returns>
        public async Task<bool> InsertUserMessage(UserMessage userMessage)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO utilizador_Mensagem (utilizadorid, Mensagemid_mensagem)
                        VALUES (@utilizadorid, @Mensagemid_mensagem)";

            var result = await db.ExecuteAsync(sql, new
            {
                userMessage.Mensagemid_mensagem,
                userMessage.Utilizadorid
            });

            return result > 0;
        }

        /// <summary>
        /// This method changes data of a user message
        /// </summary>
        /// <param name="userMessage"></param>
        /// <returns>True Updated or false</returns>
        public async Task<bool> UpdateUserMessage(UserMessage userMessage)
        {
            var db = dbConnection();
            var sql = @"UPDATE utilizador_Mensagem
                        SET Mensagemid_mensagem = @Mensagemid_mensagem
                        WHERE Utilizadorid = @utilizadorid";

            var result = await db.ExecuteAsync(sql, new
            {
                userMessage.Mensagemid_mensagem,
                userMessage.Utilizadorid
            });

            return result > 0;
        }

        /// <summary>
        /// This method deletes a message assigned to a database user
        /// </summary>
        /// <param name="userMessage"></param>
        /// <returns>True deleted or false</returns>
        public async Task<bool> DeleteUserMessage(UserMessage userMessage)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM utilizador_Mensagem
                        WHERE utilizadorid = @Utilizadorid";
            var result = await db.ExecuteAsync(sql, new { Utilizadorid = userMessage.Utilizadorid });
            return result > 0;
        }

        /// <summary>
        /// This method gets the ids of a user's message from the database
        /// </summary>
        /// <param name="utilizadorid">user id </param>
        /// <returns>returns id of messages</returns>
        public async Task<IEnumerable<AdminNotification>> GetUserMessageAdminID(int utilizadorid)
        {
            var db = dbConnection();
            var sql = @"SELECT ma.descricao, ma.data
                        FROM utilizador_Mensagem um
                        INNER JOIN Mensagem_admin ma 
                        ON um.Mensagemid_mensagem = ma.id_mensagem 
                        WHERE utilizadorid = @Utilizadorid";
            return await db.QueryAsync<AdminNotification>(sql, new { Utilizadorid = utilizadorid });
        }

    }
}
