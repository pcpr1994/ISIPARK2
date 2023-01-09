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
    /// This class contains all the functions that perform actions on the car registration sensors, in a given place in the car park
    /// </summary>
    public class ParkingSensorRepository : IParkingSensorRepository
    {
        /// <summary>
        /// An instance of class MySQLConfiguration
        /// </summary>
        private MySQLConfiguration _connectionString;

        /// <summary>
        /// Initialize the instance containing the database connection information
        /// </summary>
        /// <param name="connectionString"></param>
        public ParkingSensorRepository(MySQLConfiguration connectionString)
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
        /// This method gets all cars parked everywhere in the database park using a query
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ParkingSensor>> GetAllParkingSensor()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM sensor_estacionamento";
            return await db.QueryAsync<ParkingSensor>(sql, new { });
        }

        /// <summary>
        /// Method that returns the data of the car parked in a place
        /// </summary>
        /// <param name="lugar"></param>
        /// <returns></returns>
        public async Task<ParkingSensor> GetParkingSensorDetails(int lugar)
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM sensor_estacionamento
                        WHERE lugar = @Lugar";
            return await db.QueryFirstOrDefaultAsync<ParkingSensor>(sql, new { Lugar = lugar });
        }

        /// <summary>
        /// Method that inserts a car into a parking lot place
        /// </summary>
        /// <param name="parkingSensor"></param>
        /// <returns>True inserted or false</returns>
        public async Task<bool> InsertParkingSensor(ParkingSensor parkingSensor)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO sensor_estacionamento (brand, model, type, setor, lugar, estado, dia, 
                        hora, matricula, result_image)
                        VALUES (@brand, @model, @type, @setor, @lugar, @estado, @dia, 
                        @hora, @matricula, @result_image)";

            var result = await db.ExecuteAsync(sql, new
            {
                parkingSensor.Brand,
                parkingSensor.Model,
                parkingSensor.Type,
                parkingSensor.Setor,
                parkingSensor.Lugar,
                parkingSensor.Estado,
                parkingSensor.Dia,
                parkingSensor.Hora,
                parkingSensor.Matricula,
                parkingSensor.Result_image
            });

            return result > 0;
        }

        /// <summary>
        /// Method that updates a car's data in a parking place
        /// </summary>
        /// <param name="parkingSensor"></param>
        /// <returns></returns>
        public async Task<bool> UpdateParkingSensor(ParkingSensor parkingSensor)
        {
            var db = dbConnection();
            var sql = @"UPDATE sensor_estacionamento
                        SET brand = @Brand, model = @Model, type = @Type, setor = @Setor, estado = @Estado, 
                        dia = @Dia, hora = @Hora, matricula = @Matricula, result_image = @Result_image
                        WHERE @lugar = Lugar";

            var result = await db.ExecuteAsync(sql, new
            {
                parkingSensor.Brand,
                parkingSensor.Model,
                parkingSensor.Type,
                parkingSensor.Setor,
                parkingSensor.Estado,
                parkingSensor.Dia,
                parkingSensor.Hora,
                parkingSensor.Matricula,
                parkingSensor.Result_image,
                parkingSensor.Lugar
            });

            return result > 0;
        }

        /// <summary>
        /// Method that eliminates a car from ula parking place
        /// </summary>
        /// <param name="parkingSensor"></param>
        /// <returns></returns>
        public async Task<bool> DeleteParkingSensor(ParkingSensor parkingSensor)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM sensor_estacionamento
                        WHERE lugar = @Lugar";
            var result = await db.ExecuteAsync(sql, new { Lugar = parkingSensor.Lugar });
            return result > 0;
        }
    }
}
