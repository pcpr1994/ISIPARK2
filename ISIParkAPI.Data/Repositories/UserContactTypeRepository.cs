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
    public class UserContactTypeRepository : IUserContactTypeRepository
    {
        /// <summary>
        /// An instance of class MySQLConfiguration
        /// </summary>
        private MySQLConfiguration _connectionString;

        /// <summary>
        /// Initialize the instance containing the database connection information
        /// </summary>
        /// <param name="connectionString"></param>
        public UserContactTypeRepository(MySQLConfiguration connectionString)
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
        /// This method gets all users/Contact from the database using a query
        /// </summary>
        /// <returns>gets all the data</returns>
        public async Task<IEnumerable<UserContactType>> GetAllUserContactType()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM utilizador_Tipo_contacto";
            return await db.QueryAsync<UserContactType>(sql, new { });
        }

        /// <summary>
        /// This method obtains the identification of a user's contact from the database
        /// </summary>
        /// <param name="utilizadorid"></param>
        /// <returns></returns>
        public async Task<UserContactType> GetUserContactTypeID(int utilizadorid)
        {
            var db = dbConnection();
            var sql = @"SELECT utilizadorid, Tipo_contacton_contacto, contacto
                        FROM utilizador_Tipo_contacto
                        WHERE utilizadorid = @Utilizadorid";
            return await db.QueryFirstOrDefaultAsync<UserContactType>(sql, new { utilizadorid = utilizadorid });
        }

        /// <summary>
        /// This method inserts a user's contact type into the database
        /// </summary>
        /// <param name="userContactType"></param>
        /// <returns>True inserted or false</returns>
        public async Task<bool> InsertUserContactType(UserContactType userContactType)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO utilizador_Tipo_contacto (utilizadorid, Tipo_contacton_contacto, contacto)
                        VALUES (@utilizadorid, @Tipo_contacton_contacto, @contacto)";

            var result = await db.ExecuteAsync(sql, new
            {
                userContactType.Tipo_contacton_contacto,
                userContactType.Contacto,
                userContactType.Utilizadorid

            });

            return result > 0;
        }

        /// <summary>
        /// This method changes data of a user contact
        /// </summary>
        /// <param name="userContactType"></param>
        /// <returns>True Updated or false</returns>
        public async Task<bool> UpdateUserContactType(UserContactType userContactType)
        {
            var db = dbConnection();
            var sql = @"UPDATE utilizador_Tipo_contacto
                        SET Tipo_contacton_contacto = @Tipo_contacton_contacto, contacto = @contacto
                        WHERE Utilizadorid = @utilizadorid";

            var result = await db.ExecuteAsync(sql, new
            {
                userContactType.Tipo_contacton_contacto,
                userContactType.Contacto,
                userContactType.Utilizadorid

            });

            return result > 0;
        }

        /// <summary>
        /// This method delete a user contact of database 
        /// </summary>
        /// <param name="userContactType"></param>
        /// <returns>True deleted or false</returns>
        public async Task<bool> DeleteUserContactType(UserContactType userContactType)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM utilizador_Tipo_contacto
                        WHERE utilizadorid = @Utilizadorid";
            var result = await db.ExecuteAsync(sql, new { utilizadorid = userContactType.Utilizadorid });
            return result > 0;
        }

       
    }
}
