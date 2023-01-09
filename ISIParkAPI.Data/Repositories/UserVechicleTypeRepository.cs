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
    /// This class contains all the functions that perform actions on the users and the type of vechicle
    /// </summary>
    public class UserVechicleTypeRepository : IUserVechicleTypeRepository
    {
        /// <summary>
        /// An instance of class MySQLConfiguration
        /// </summary>
        private MySQLConfiguration _connectionString;

        /// <summary>
        /// Initialize the instance containing the database connection information
        /// </summary>
        /// <param name="connectionString"></param>
        public UserVechicleTypeRepository(MySQLConfiguration connectionString)
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
        /// This method gets all users/ Vechicle type from the database using a query
        /// </summary>
        /// <returns>gets all the data</returns>
        public async Task<IEnumerable<UserVechicleType>> GetAllUserVechicleTypey()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM utilizador_Tipo_veiculos";
            return await db.QueryAsync<UserVechicleType>(sql, new { });
        }

        /// <summary>
        /// This method obtains a user's vehicle types from the database
        /// </summary>
        /// <param name="utilizadorid"></param>
        /// <returns></returns>
        public async Task<UserVechicleType> GetUserVechicleTypeID(int utilizadorid)
        {
            var db = dbConnection();
            var sql = @"SELECT utilizadorid, Tipo_veiculosid_veiculo, matricula
                        FROM utilizador_Tipo_veiculos
                        WHERE utilizadorid = @Utilizadorid";
            return await db.QueryFirstOrDefaultAsync<UserVechicleType>(sql, new { Utilizadorid = utilizadorid });
        }

        /// <summary>
        /// This method inserts a user's vehicle type and the car's license plate into the database
        /// </summary>
        /// <param name="userVechicleType"></param>
        /// <returns>True inserted or false</returns>
        public async Task<bool> InsertUserVechicleType(UserVechicleType userVechicleType)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO utilizador_Tipo_veiculos (utilizadorid, Tipo_veiculosid_veiculo, matricula)
                        VALUES (@utilizadorid, @Tipo_veiculosid_veiculo, @matricula)";

            var result = await db.ExecuteAsync(sql, new
            {
                userVechicleType.Utilizadorid,
                userVechicleType.Tipo_veiculosid_veiculo,
                userVechicleType.Matricula
            });

            return result > 0;
        }

        /// <summary>
        /// Este método altera os dados de uma placa de matrícula do utilizador
        /// </summary>
        /// <param name="userVechicleType"></param>
        /// <returns>True Updated or false</returns>
        public async Task<bool> UpdateUserVechicleType(UserVechicleType userVechicleType)
        {
            var db = dbConnection();
            var sql = @"UPDATE utilizador_Tipo_veiculos
                        SET Tipo_veiculosid_veiculo = @Tipo_veiculosid_veiculo, matricula = @matricula
                        WHERE Utilizadorid = @utilizadorid";

            var result = await db.ExecuteAsync(sql, new
            {
                userVechicleType.Tipo_veiculosid_veiculo,
                userVechicleType.Matricula,
                userVechicleType.Utilizadorid
            });

            return result > 0;
        }

        /// <summary>
        /// This method delete a licence plate the user of database 
        /// </summary>
        /// <param name="userVechicleType"></param>
        /// <returns>True deleted or false</returns>
        public async Task<bool> DeleteUserVechicleType(UserVechicleType userVechicleType)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM utilizador_Tipo_veiculos
                        WHERE utilizadorid = @Utilizadorid";
            var result = await db.ExecuteAsync(sql, new { Utilizadorid = userVechicleType.Utilizadorid });
            return result > 0;
        }

    }
}
