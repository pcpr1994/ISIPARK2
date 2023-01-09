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
    /// This class contains all the functions that perform actions on the admin messages
    /// </summary>
    public class AdminMessageRepository : IAdminMessageRepository
    {
        /// <summary>
        /// An instance of class MySQLConfiguration
        /// </summary>
        private MySQLConfiguration _connectionString;

        /// <summary>
        /// Initialize the instance containing the database connection information
        /// </summary>
        /// <param name="connectionString"></param>
        public AdminMessageRepository(MySQLConfiguration connectionString)
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
        /// This method gets all AdminMessages from database using a query
        /// </summary>
        /// <returns>Get all messages</returns>
        public async Task<IEnumerable<AdminMessage>> GetAllAdminMessage()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM Mensagem_admin";
            return await db.QueryAsync<AdminMessage>(sql, new { });
        }

        /// <summary>
        /// This method get one message from database
        /// </summary>
        /// <param name="id">Id message entered</param>
        /// <returns>Get the message with the same id that id entered</returns>
        public async Task<AdminMessage> GetAdminMessageDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT id_mensagem, descricao, data
                        FROM Mensagem_admin
                        WHERE id_mensagem = @Id_Mensagem";
            return await db.QueryFirstOrDefaultAsync<AdminMessage>(sql, new { Id_Mensagem = id });
        }

        /// <summary>
        /// This method insert a new message on database
        /// </summary>
        /// <param name="address">Instance of AdminMessage</param>
        /// <returns>True inserted or false</returns>
        public async Task<bool> InsertAdminMessage(AdminMessage adminMensagem)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO Mensagem_admin (descricao, data)
                        VALUES (@Descricao, @Data)";

            var result = await db.ExecuteAsync(sql, new
            {
                adminMensagem.Descricao,
                adminMensagem.Data
            });

            return result > 0;
        }

        /// <summary>
        /// This method changes data of an message
        /// </summary>
        /// <param name="address">Instance of AdminMessage</param>
        /// <returns>True Updated or false</returns>
        public async Task<bool> UpdateAdminMessage(AdminMessage adminMessage)
        {
            var db = dbConnection();
            var sql = @"UPDATE Mensagem_admin
                        SET descricao = @Descricao, data = @Data
                        WHERE @id_mensagem = Id_Mensagem";

            var result = await db.ExecuteAsync(sql, new
            {
                adminMessage.Descricao,
                adminMessage.Data,
                adminMessage.Id_Mensagem
            });

            return result > 0;
        }

        /// <summary>
        /// This method delete an message of database 
        /// </summary>
        /// <param name="address">Instance of AdminMessage</param>
        /// <returns>True deleted or false</returns>
        public async Task<bool> DeleteAdminMessage(AdminMessage adminMessage)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM Mensagem_admin
                        WHERE id_mensagem = @Id_Mensagem";
            var result = await db.ExecuteAsync(sql, new { ID = adminMessage.Id_Mensagem });
            return result > 0;
        }
    }
}
