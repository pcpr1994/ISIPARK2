/*
 * Grupo 4
 * Trabalho II de ISI
 * Alunos
 *  Carlos Pereira nº6498
 *  Paula Rodrigues nº21133
 *  Sérgio Gonçalves nº20343
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
    /// This class contains all the functions that perform actions on the  license plate car sensor
    /// </summary>
    public class LicensePlateSensorRepository : ILicensePlateSensorRepository
    {
        /// <summary>
        /// An instance of class MySQLConfiguration
        /// </summary>
        private MySQLConfiguration _connectionString;

        /// <summary>
        /// Initialize the instance containing the database connection information
        /// </summary>
        /// <param name="connectionString"></param>
        public LicensePlateSensorRepository(MySQLConfiguration connectionString)
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
        /// This method gets all sensor license plate car from database using a query
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<LicensePlateSensor>> GetAllPlateSensor()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM sensor_matricula";
            return await db.QueryAsync<LicensePlateSensor>(sql, new { });
        }

        /// <summary>
        /// This method obtains a car's data through the nif from a database using a query
        /// </summary>
        /// <param name="nif"></param>
        /// <returns></returns>
        public async Task<LicensePlateSensor> GetPlateSensorDetails(int nif)
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM sensor_matricula
                        WHERE nif = @NIF";
            return await db.QueryFirstOrDefaultAsync<LicensePlateSensor>(sql, new { NIF = nif });
        }

        /// <summary>
        /// This method insert a sensor license plate on database
        /// </summary>
        /// <param name="licensePlateSensor"></param>
        /// <returns>True inserted or false</returns>
        public async Task<bool> InsertVehicleSensor(LicensePlateSensor licensePlateSensor)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO sensor_matricula (nif, brand, model, licensePlate, type)
                        VALUES (@nif, @brand, @model, @licensePlate, @type)";

            var result = await db.ExecuteAsync(sql, new
            {
                licensePlateSensor.NIF,
                licensePlateSensor.Brand,
                licensePlateSensor.Model,
                licensePlateSensor.LicensePlate,
                licensePlateSensor.Type
            });

            return result > 0;
        }

        /// <summary>
        /// This method changes the data of a license plate on a parking sensor
        /// </summary>
        /// <param name="licensePlateSensor"></param>
        /// <returns>True Updated or false</returns>
        public async Task<bool> UpdateVehicleSensor(LicensePlateSensor licensePlateSensor)
        {
            var db = dbConnection();
            var sql = @"UPDATE sensor_matricula
                        SET nif = @NIF, brand = @Brand, model = @Model, licensePlate = @LicensePlate, type = @Type
                        WHERE @nif = NIF";

            var result = await db.ExecuteAsync(sql, new
            {
                licensePlateSensor.Brand,
                licensePlateSensor.Model,
                licensePlateSensor.LicensePlate,
                licensePlateSensor.Type,
                licensePlateSensor.NIF
            });

            return result > 0;
        }

        /// <summary>
        /// This method eliminates a license plate of a car from a car license plate sensor from a database
        /// </summary>
        /// <param name="licensePlateSensor"></param>
        /// <returns>True deleted or false</returns>
        public async Task<bool> DeleteVehicleSensor(LicensePlateSensor licensePlateSensor)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM sensor_matricula
                        WHERE nif = @NIF";
            var result = await db.ExecuteAsync(sql, new { NIF = licensePlateSensor.NIF });
            return result > 0;
        }
    }
}
