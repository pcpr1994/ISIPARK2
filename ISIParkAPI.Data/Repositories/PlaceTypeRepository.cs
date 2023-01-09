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
    /// This class contains all the functions that perform actions on the places type
    /// </summary>
    public class PlaceTypeRepository : IPlaceTypeRepository
    {
        /// <summary>
        /// An instance of class MySQLConfiguration
        /// </summary>
        private MySQLConfiguration _connectionString;


        /// <summary>
        /// Initialize the instance containing the database connection information
        /// </summary>
        /// <param name="connectionString"></param>
        public PlaceTypeRepository(MySQLConfiguration connectionString)
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
        /// This method gets all places type from database using a query
        /// </summary>
        /// <returns>Get all types</returns>
        public async Task<IEnumerable<PlaceType>> GetAllPlaceType()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM tipo_lugar";
            return await db.QueryAsync<PlaceType>(sql, new { });
        }

        /// <summary>
        /// This method get one type from database
        /// </summary>
        /// <param name="id">Id type entered</param>
        /// <returns>Get the type with the same id that id entered</returns>
        public async Task<PlaceType> GetPlaceTypeDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT n_tipo, descricao
                        FROM tipo_lugar
                        WHERE n_tipo = @N_Tipo";
            return await db.QueryFirstOrDefaultAsync<PlaceType>(sql, new { N_Tipo = id });
        }

        /// <summary>
        /// This method insert a new type on database
        /// </summary>
        /// <param name="address">Instance of PlaceType</param>
        /// <returns>True inserted or false</returns>
        public async Task<bool> InsertPlaceType(PlaceType placeType)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO tipo_lugar (descricao)
                        VALUES (@descricao)";

            var result = await db.ExecuteAsync(sql, new
            {
                placeType.Descricao
            });

            return result > 0;
        }

        /// <summary>
        /// This method changes data of a type
        /// </summary>
        /// <param name="address">Instance of PlaceType</param>
        /// <returns>True Updated or false</returns>
        public async Task<bool> UpdatePlaceType(PlaceType placeType)
        {
            var db = dbConnection();
            var sql = @"UPDATE tipo_lugar
                        SET descricao = @Descricao
                        WHERE N_Tipo = @n_tipo";

            var result = await db.ExecuteAsync(sql, new
            {
                placeType.Descricao,
                placeType.N_Tipo
            });

            return result > 0;
        }

        /// <summary>
        /// This method delete a type of database 
        /// </summary>
        /// <param name="address">Instance of PlaceType</param>
        /// <returns>True deleted or false</returns>
        public async Task<bool> DeletePlaceType(PlaceType placeType)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM tipo_lugar
                        WHERE n_tipo = @N_Tipo";
            var result = await db.ExecuteAsync(sql, new { N_Tipo = placeType.N_Tipo });
            return result > 0;
        }
    }
}
