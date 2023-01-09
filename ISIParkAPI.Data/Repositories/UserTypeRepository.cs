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
    /// This class contains all the functions that perform actions on the user types
    /// </summary>
    public class UserTypeRepository : IUserTypeRepository
    {
        /// <summary>
        /// An instance of class MySQLConfiguration
        /// </summary>
        private MySQLConfiguration _connectionString;

        /// <summary>
        /// Initialize the instance containing the database connection information
        /// </summary>
        /// <param name="connectionString"></param>
        public UserTypeRepository(MySQLConfiguration connectionString)
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
        /// This method gets all types of database users using a query
        /// </summary>
        /// <returns>Get all types</returns>
        public async Task<IEnumerable<UserType>> GetAllUserType()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM tipo_utilizador";
            return await db.QueryAsync<UserType>(sql, new { });
        }

        /// <summary>
        /// Este método obtém um tipo a partir da base de dados
        /// </summary>
        /// <param name="id">Id type entered</param>
        /// <returns>Get the type with the same id that id entered</returns>
        public async Task<UserType> GetUserTypeDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT id, nome_tipo
                        FROM tipo_utilizador
                        WHERE id = @ID";
            return await db.QueryFirstOrDefaultAsync<UserType>(sql, new { ID = id });
        }

        /// <summary>
        /// This method insert a new type on database
        /// </summary>
        /// <param name="userType">Instance of UserType</param>
        /// <returns>True inserted or false</returns>
        public async Task<bool> InsertUserType(UserType userType)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO tipo_utilizador (nome_tipo)
                        VALUES (@nome_tipo)";

            var result = await db.ExecuteAsync(sql, new
            {
                userType.Nome_tipo
            });

            return result > 0;
        }

        /// <summary>
        /// This method changes data of a type
        /// </summary>
        /// <param name="userType"></param>
        /// <returns>True Updated or false</returns>
        public async Task<bool> UpdateUserType(UserType userType)
        {
            var db = dbConnection();
            var sql = @"UPDATE tipo_utilizador
                        SET nome_tipo = @Nome_tipo
                        WHERE ID = @id";

            var result = await db.ExecuteAsync(sql, new
            {
                userType.Nome_tipo,
                userType.ID
            });

            return result > 0;
        }

        /// <summary>
        /// This method delete a type of database 
        /// </summary>
        /// <param name="userType"></param>
        /// <returns>True deleted or false</returns>
        public async Task<bool> DeleteUserType(UserType userType)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM tipo_utilizador
                        WHERE id = @ID";
            var result = await db.ExecuteAsync(sql, new { ID = userType.ID });
            return result > 0;
        }
    }
}

