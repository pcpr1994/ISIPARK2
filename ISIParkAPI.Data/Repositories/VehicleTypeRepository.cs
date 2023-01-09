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
    /// This class contains all the functions that perform actions on the vehicles type
    /// </summary>
    public class VehicleTypeRepository : IVehicleTypeRepository
    {
        /// <summary>
        /// An instance of class MySQLConfiguration
        /// </summary>
        private MySQLConfiguration _connectionString;

        /// <summary>
        /// Initialize the instance containing the database connection information
        /// </summary>
        /// <param name="connectionString"></param>
        public VehicleTypeRepository(MySQLConfiguration connectionString)
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
        /// This method gets all Vehicles type from database using a query
        /// </summary>
        /// <returns>Get all types</returns>
        public async Task<IEnumerable<VehicleType>> GetAllVehicleType()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                    FROM Tipo_veiculos";
            return await db.QueryAsync<VehicleType>(sql, new { });
        }

        /// <summary>
        /// This method get one type from database
        /// </summary>
        /// <param name="id">Id type entered</param>
        /// <returns>Get the type with the same id that id entered</returns>
        public async Task<VehicleType> GetVehicleTypeDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT id_veiculo, descricao
                    FROM Tipo_veiculos
                    WHERE id_veiculo = @ID_Veiculo";
            return await db.QueryFirstOrDefaultAsync<VehicleType>(sql, new { ID_Veiculo = id });
        }

        /// <summary>
        /// This method insert a new type on database
        /// </summary>
        /// <param name="vehicleType">Instance of VehicleType</param>
        /// <returns>True inserted or false</returns>
        public async Task<bool> InsertVehicleType(VehicleType vehicleType)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO Tipo_veiculos (descricao)
                    VALUES (@descricao)";

            var result = await db.ExecuteAsync(sql, new
            {
                vehicleType.Descricao
            });

            return result > 0;
        }

        /// <summary>
        /// This method changes data of a type
        /// </summary>
        /// <param name="vehicleType">Instance of VehicleType</param>
        /// <returns>True Updated or false</returns>
        public async Task<bool> UpdateVehicleType(VehicleType vehicleType)
        {
            var db = dbConnection();
            var sql = @"UPDATE Tipo_veiculos
                    SET descricao = @Descricao
                    WHERE ID_Veiculo = @id_veiculo";

            var result = await db.ExecuteAsync(sql, new
            {
                vehicleType.Descricao,
                vehicleType.ID_Veiculo
            });

            return result > 0;
        }

        /// <summary>
        /// This method delete a type of database 
        /// </summary>
        /// <param name="vehicleType">Instance of VehicleType</param>
        /// <returns>True deleted or false</returns>
        public async Task<bool> DeleteVehicleType(VehicleType vehicleType)
        {
            var db = dbConnection();
            var sql = @"DELETE
                    FROM Tipo_veiculos
                    WHERE id_veiculo = @ID_Veiculo";
            var result = await db.ExecuteAsync(sql, new { ID_Veiculo = vehicleType.ID_Veiculo });
            return result > 0;
        }
        
    }
}
