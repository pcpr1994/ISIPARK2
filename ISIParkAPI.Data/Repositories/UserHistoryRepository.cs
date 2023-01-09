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
    /// This class contains all the functions that perform actions on the users and the type of contact
    /// </summary>
    public class UserHistoryRepository : IUserHistoryRepository
    {

        /// <summary>
        /// An instance of class MySQLConfiguration
        /// </summary>
        private MySQLConfiguration _connectionString;

        /// <summary>
        /// Initialize the instance containing the database connection information
        /// </summary>
        /// <param name="connectionString"></param>
        public UserHistoryRepository(MySQLConfiguration connectionString)
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
        /// This method gets all users/Historic from the database using a query
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserHistory>> GetAllUserHistory()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM utilizador_Historico";
            return await db.QueryAsync<UserHistory>(sql, new { });
        }

        /// <summary>
        /// This method obtains the historic the user from the database
        /// </summary>
        /// <param name="utilizadorid"></param>
        /// <returns></returns>
        public async Task<UserHistory> GetUserHistoryID(int utilizadorid)
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM utilizador_Historico
                        WHERE utilizadorid = @Utilizadorid";
            return await db.QueryFirstOrDefaultAsync<UserHistory>(sql, new { Utilizadorid = utilizadorid });
        }

        /// <summary>
        /// This method inserts a history to a user in the database
        /// </summary>
        /// <param name="userHistory"></param>
        /// <returns>True inserted or false</returns>
        public async Task<bool> InsertUserHistory(UserHistory userHistory)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO utilizador_Historico (utilizadorid, Historicoid)
                        VALUES (@utilizadorid, @Historicoid)";

            var result = await db.ExecuteAsync(sql, new
            {
                userHistory.Utilizadorid,
                userHistory.Historicoid
            });

            return result > 0;
        }

        /// <summary>
        /// This method changes the data of a user's history
        /// </summary>
        /// <param name="userHistory"></param>
        /// <returns>True Updated or false</returns>
        //public async Task<bool> UpdateUserHistory(UserHistory userHistory)
        //{
        //    var db = dbConnection();
        //    var sql = @"UPDATE utilizador_Historico
        //                SET Historicoid = @Historicoid
        //                WHERE Utilizadorid = @utilizadorid";

        //    var result = await db.ExecuteAsync(sql, new
        //    {
        //        userHistory.Utilizadorid,
        //        userHistory.Historicoid
        //    });

        //    return result > 0;
        //}

        /// <summary>
        /// This method deletes a user's history in the database
        /// </summary>
        /// <param name="userHistory"></param>
        /// <returns>True deleted or false</returns>
        public async Task<bool> DeleteUserHistory(UserHistory userHistory)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM utilizador_Historico
                        WHERE utilizadorid = @Utilizadorid";
            var result = await db.ExecuteAsync(sql, new { Utilizadorid = userHistory.Utilizadorid });
            return result > 0;
        }

    }
}
