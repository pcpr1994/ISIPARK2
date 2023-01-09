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
    /// This class contains all the functions that perform actions on history data
    /// </summary>
    public class HistoryRepository : IHistoryRepository
    {
        /// <summary>
        /// An instance of class MySQLConfiguration
        /// </summary>
        private MySQLConfiguration _connectionString;

        /// <summary>
        /// Initialize the instance containing the database connection information
        /// </summary>
        /// <param name="connectionString"></param>
        public HistoryRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Connects to a database
        /// </summary>
        /// <returns></returns>
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        /// <summary>
        /// This method gets all history data from database using a query
        /// </summary>
        /// <returns>Get all types</returns>
        public async Task<IEnumerable<History>> GetAllHistory()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM Historico";
            return await db.QueryAsync<History>(sql, new { });
        }

        /// <summary>
        /// This method gets one history data from database
        /// </summary>
        /// <param name="id">Id type entered</param>
        /// <returns>Get the type with the same id that id entered</returns>
        public async Task<History> GetHistoryDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT id, dia, hora_entrada, hora_saida, lugarnumero_lugar
                        FROM Historico
                        WHERE id = @ID";
            return await db.QueryFirstOrDefaultAsync<History>(sql, new { ID = id });
        }

        /// <summary>
        /// This method inserts a new history data on database
        /// </summary>
        /// <param name="history">Instance of History</param>
        /// <returns>True inserted or false</returns>
        public async Task<bool> InsertHistory(History history)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO Historico (dia, hora_entrada, hora_saida, lugarnumero_lugar)
                        VALUES (@dia, @hora_entrada, @hora_saida, @lugarnumero_lugar)";

            var result = await db.ExecuteAsync(sql, new
            {
                //history.Dia,
                history.Hora_entrada,
                history.Hora_saida,
                history.Lugarnumero_lugar
            });

            return result > 0;
        }

        /// <summary>
        /// This method changes data of an history
        /// </summary>
        /// <param name="~history">Instance of History</param>
        /// <returns>True Updated or false</returns>
        public async Task<bool> UpdateHistory(History history)
        {
            var db = dbConnection();
            var sql = @"UPDATE Historico
                        SET dia = @Dia, hora_entrada = @Hora_entrada, hora_saida = @Hora_saida, 
                            lugarnumero_lugar = @Lugarnumero_lugar
                        WHERE @id = ID";

            var result = await db.ExecuteAsync(sql, new
            {
                history.Dia,
                history.Hora_entrada,
                history.Hora_saida,         
                history.ID
            });

            return result > 0;
        }

        /// <summary>
        /// This method delete an history data of database 
        /// </summary>
        /// <param name="history">Instance of History</param>
        /// <returns>True deleted or false</returns>
        public async Task<bool> DeleteHistory(History history)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM Historico
                        WHERE id = @ID";
            var result = await db.ExecuteAsync(sql, new { ID = history.ID });
            return result > 0;
        }
    }
}
