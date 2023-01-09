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
    /// This class contains all the functions that perform actions on the addresses
    /// </summary>
    public class AddressRepository : IAddressRepository
    {
        /// <summary>
        /// An instance of class MySQLConfiguration
        /// </summary>
        private MySQLConfiguration _connectionString;

        /// <summary>
        /// Initialize the instance containing the database connection information
        /// </summary>
        /// <param name="connectionString"></param>
        public AddressRepository(MySQLConfiguration connectionString)
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
        /// This method gets all addresses from database using a query
        /// </summary>
        /// <returns>Get all addresses</returns>
        public async Task<IEnumerable<Address>> GetAllAddress()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM Morada";
            return await db.QueryAsync<Address>(sql, new { });
        }

        /// <summary>
        /// This method get one address from database
        /// </summary>
        /// <param name="id">Id address entered</param>
        /// <returns>Get the address with the same id that id entered</returns>
        public async Task<Address> GetAddressDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM Morada
                        WHERE id_morada = @Id_Morada";
            return await db.QueryFirstOrDefaultAsync<Address>(sql, new { Id_Morada = id });
        }

        /// <summary>
        /// This method insert a new address on database
        /// </summary>
        /// <param name="address">Instance of Address</param>
        /// <returns>True inserted or false</returns>
        public async Task<bool> InsertAddress(Address address)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO Morada (rua, nPorta, cp4, cp3, localidade, cidade)
                        VALUES (@Rua, @NPorta, @CP4, @CP3, @Localidade, @Cidade)";

            var result = await db.ExecuteAsync(sql, new
            {
                address.Rua,
                address.NPorta,
                address.CP4,
                address.CP3,
                address.Localidade,
                address.Cidade
            });

            return result > 0;
        }

        /// <summary>
        /// This method changes data of an address
        /// </summary>
        /// <param name="address">Instance of Address</param>
        /// <returns></returns>
        public async Task<bool> UpdateAddress(Address address)
        {
            var db = dbConnection();
            var sql = @"UPDATE Morada
                        SET rua = @Rua, nPorta = @NPorta, cp4 = @CP4, cp3 = @CP3, localidade = @Localidade, cidade = @Cidade
                        WHERE @id_morada = ID_Morada";

            var result = await db.ExecuteAsync(sql, new
            {
                address.NPorta,
                address.Rua,
                address.CP4,
                address.CP3,
                address.Localidade,
                address.Cidade,
                address.ID_Morada
            });

            return result > 0;
        }

        /// <summary>
        /// This method delete an address of database 
        /// </summary>
        /// <param name="address">Instance of Address</param>
        /// <returns>True deleted or false</returns>
        public async Task<bool> DeleteAddress(Address address)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM Morada
                        WHERE id_morada = @ID_Morada";
            var result = await db.ExecuteAsync(sql, new { ID_Morada = address.ID_Morada });
            return result > 0;
        }
    }
}
