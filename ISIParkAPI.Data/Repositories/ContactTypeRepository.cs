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
    /// This class contains all the functions that perform actions on the contact types
    /// </summary>
    public class ContactTypeRepository : IContactTypeRepository
    {
        /// <summary>
        /// An instance of class MySQLConfiguration
        /// </summary>
        private MySQLConfiguration _connectionString;

        /// <summary>
        /// Initialize the instance containing the database connection information
        /// </summary>
        /// <param name="connectionString"></param>
        public ContactTypeRepository(MySQLConfiguration connectionString)
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
        /// This method gets all contacts types from database using a query
        /// </summary>
        /// <returns>Get all types</returns>
        public async Task<IEnumerable<ContactType>> GetAllContactType()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM Tipo_contacto";
            return await db.QueryAsync<ContactType>(sql, new { });
        }

        /// <summary>
        /// This method get one type from database
        /// </summary>
        /// <param name="id">Id type entered</param>
        /// <returns>Get the type with the same id that id entered</returns>
        public async Task<ContactType> GetContactTypeDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT id, descricao
                        FROM Tipo_contacto
                        WHERE id = @ID";
            return await db.QueryFirstOrDefaultAsync<ContactType>(sql, new { ID = id });
        }

        /// <summary>
        /// This method insert a new type on database
        /// </summary>
        /// <param name="address">Instance of ContactType</param>
        /// <returns>True inserted or false</returns>
        public async Task<bool> InsertContactType(ContactType contactoType)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO Tipo_contacto (descricao)
                        VALUES (@descricao)";

            var result = await db.ExecuteAsync(sql, new
            {
                contactoType.Descricao
            });

            return result > 0;
        }

        /// <summary>
        /// This method changes data of a type
        /// </summary>
        /// <param name="address">Instance of ContactType</param>
        /// <returns>True Updated or false</returns>
        public async Task<bool> UpdateContactType(ContactType contactType)
        {
            var db = dbConnection();
            var sql = @"UPDATE Tipo_contacto
                        SET descricao = @Descricao
                        WHERE ID = @id";

            var result = await db.ExecuteAsync(sql, new
            {
                contactType.Descricao,
                contactType.ID
            });

            return result > 0;
        }

        /// <summary>
        /// This method delete a type of database 
        /// </summary>
        /// <param name="address">Instance of ContactType</param>
        /// <returns>True deleted or false</returns>
        public async Task<bool> DeleteContactType(ContactType contactType)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM Tipo_contacto
                        WHERE id = @ID";
            var result = await db.ExecuteAsync(sql, new { ID = contactType.ID });
            return result > 0;
        }
    }
}
