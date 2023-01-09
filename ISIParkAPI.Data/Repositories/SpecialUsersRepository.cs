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
    /// This class contains all the functions that perform actions on the special user
    /// </summary>
    public class SpecialUsersRepository : ISpecialUsersRepository
    {
        /// <summary>
        /// An instance of class MySQLConfiguration
        /// </summary>
        private MySQLConfiguration _connectionString;

        /// <summary>
        /// Initialize the instance containing the database connection information
        /// </summary>
        /// <param name="connectionString"></param>
        public SpecialUsersRepository(MySQLConfiguration connectionString)
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
        /// This method gets all special users from database using a query
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SpecialUser>> GetAllSpecialUser()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM perfil_especial";
            return await db.QueryAsync<SpecialUser>(sql, new { });
        }

        /// <summary>
        /// This method get one special userfrom database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SpecialUser> GetSpecialUserByID(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT nome, matricula, contacto, Tipo_veiculosid_veiculo
                        FROM perfil_especial
                        WHERE id = @ID";

            return await db.QueryFirstOrDefaultAsync<SpecialUser>(sql, new { ID = id });
        }

        /// <summary>
        /// This method insert a new special user on database
        /// </summary>
        /// <param name="specialUser"></param>
        /// <returns>True inserted or false</returns>
        public async Task<bool> InsertSpecialUser(SpecialUser specialUser)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO perfil_especial (nome, matricula, contacto, Tipo_veiculosid_veiculo)
                        VALUES (@nome, @matricula, @contacto, @Tipo_veiculosid_veiculo)";

            var result = await db.ExecuteAsync(sql, new
            {
                specialUser.Nome,
                specialUser.Matricula,
                specialUser.Contacto,
                specialUser.Tipo_veiculosid_veiculo,
                specialUser.Id

            });

            return result > 0;
        }

        /// <summary>
        /// This method changes data of an special user
        /// </summary>
        /// <param name="specialUser"></param>
        /// <returns>True Updated or false</returns>
        public async Task<bool> UpdateSpecialUser(SpecialUser specialUser)
        {
            var db = dbConnection();
            var sql = @"UPDATE perfil_especial
                        SET nome = @nome, matricula = @matricula, contacto = @contacto, 
                                Tipo_veiculosid_veiculo = @Tipo_veiculosid_veiculo
                        WHERE @id = Id";

            var result = await db.ExecuteAsync(sql, new
            {
                specialUser.Nome,
                specialUser.Matricula,
                specialUser.Contacto,
                specialUser.Tipo_veiculosid_veiculo,
                specialUser.Id
            });

            return result > 0;
        }

        /// <summary>
        /// This method delete an special user of database
        /// </summary>
        /// <param name="specialUser"></param>
        /// <returns>True deleted or false</returns>
        public async Task<bool> DeleteSpecialUser(SpecialUser specialUser)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM perfil_especial
                        WHERE id = @Id";
            var result = await db.ExecuteAsync(sql, new { Id = specialUser.Id });
            return result > 0;
        }
    }
}
