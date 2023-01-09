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
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories
{
    /// <summary>
    /// This class contains all the functions that perform actions on the utilizador
    /// </summary>
    public class UserRepository: IUserRepository
    {
        /// <summary>
        /// An instance of class MySQLConfiguration
        /// </summary>
        private MySQLConfiguration _connectionString;

        /// <summary>
        /// Initialize the instance containing the database connection information
        /// </summary>
        /// <param name="connectionString"></param>
        public UserRepository(MySQLConfiguration connectionString)
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
        /// This method gets an e-mail from the database using a query
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool GetUserByEm(string email)
        {
            var db = dbConnection();
            var sql = @"SELECT email
                        FROM utilizador
                        WHERE email = @Email";
            var x = db.QueryFirstOrDefaultAsync<UserDTO>(sql, new { Email = email });
            var em = x.Result;
           
            if (em == null)
                return false;
            else
                return true;
        }

        /// <summary>
        /// This method gets the passwordHash of a given email from the database using a query
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public byte[] GetUserByPasswordh(string email)
        {
            var db = dbConnection();
            var sql = @"SELECT passwordHash
                        FROM utilizador
                        WHERE email = @Email";
            var x = db.QueryFirstOrDefaultAsync<UserDTO>(sql, new { Email = email });
            var ph = x.Result;
            return ph.PasswordHash;
        }

        //This method gets the passwordSalt of a given email from the database using a query
        public byte[] GetUserByPasswords(string email)
        {
            var db = dbConnection();
            var sql = @"SELECT passwordSalt
                        FROM utilizador
                        WHERE email = @Email";
            var x = db.QueryFirstOrDefaultAsync<UserDTO>(sql, new { Email = email });
            var ps = x.Result;

            return ps.PasswordSalt;
        }

        /// <summary>
        /// This method gets all user from database using a query
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserDTO>> GetAllUser()
        {
            var db = dbConnection();
            var sql = @"SELECT id, nome, nif, DataNasc, genero, tipo_utilizadorid, Moradaid_morada, email
                        FROM utilizador";
            return await db.QueryAsync<UserDTO>(sql, new { });
        }

        /// <summary>
        /// Method that searches a user's data via email, in the database
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<UserDTO> GetUserByEmail(string email)
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM utilizador
                        WHERE email = @Email";
            return await db.QueryFirstOrDefaultAsync<UserDTO>(sql, new { Email = email });
        }

        /// <summary>
        /// Method that searches a user's data via number, in the database
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public async Task<UserDTO> GetUserById(int numero)
        {
            var db = dbConnection();
            var sql = @"SELECT nome, nif, DataNasc, genero, tipo_utilizadorid, Moradaid_morada, email, password
                        FROM utilizador
                        WHERE id = @Id";
            return await db.QueryFirstOrDefaultAsync<UserDTO>(sql, new { Id = numero });
        }

        /// <summary>
        /// This method insert a new user on database
        /// </summary>
        /// <param name="user"></param>
        /// <returns>True inserted or false</returns>
        public async Task<bool> InsertUser(UserDTO user)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO utilizador (nome, nif, DataNasc, genero, tipo_utilizadorid, 
                                    Moradaid_morada, email, password, passwordHash, passwordSalt, token)
                         VALUES (@nome, @nif, @DataNasc, @genero, @tipo_utilizadorid, @Moradaid_morada, @email, @password, @passwordHash, @passwordSalt, @token)";  
                       
            var result = await db.ExecuteAsync(sql, new
            {
                user.Nome,
                user.Nif,
                user.DataNasc,
                user.Genero,
                user.Tipo_utilizadorid,
                user.Moradaid_morada,
                user.Email,
                user.Password,
                user.PasswordHash,
                user.PasswordSalt,
                user.Token
            });

            return result > 0;
        }

        /// <summary>
        /// This method changes data of an user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>True Updated or false</returns>
        public async Task<bool> UpdateUser(UserDTO user)
        {
            var db = dbConnection();
            var sql = @"UPDATE utilizador
                        SET nome = @Nome, nif = @Nif, DataNasc = @DataNasc, genero = @Genero, tipo_utilizadorid = @Tipo_utilizadorid, 
                                    Moradaid_morada = @Moradaid_morada, email = @Email, password = @Password
                        WHERE @id = Id";

            var result = await db.ExecuteAsync(sql, new
            {
                user.Id,
                user.Nome,
                user.Nif,
                user.DataNasc,
                user.Genero,
                user.Tipo_utilizadorid,
                user.Moradaid_morada,
                user.Email,
                user.Password              
            });

            return result > 0;
        }

        /// <summary>
        /// This method changes data of an user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<bool> UpdateUserToken(UserDTO user, string token)
        {
            var db = dbConnection();
            var sql = @"UPDATE utilizador
                        SET token = @Token
                        WHERE @email = Email";

            var result = await db.ExecuteAsync(sql, new
            {
                user.Id,
                user.Nome,
                user.Nif,
                user.DataNasc,
                user.Genero,
                user.Tipo_utilizadorid,
                user.Moradaid_morada,
                user.Email,
                user.Password,
                user.Token
            });

            return result > 0;
        }

        /// <summary>
        /// This method delete an user of database 
        /// </summary>
        /// <param name="user"></param>
        /// <returns>True deleted or false</returns>
        public async Task<bool> DeleteUser(UserDTO user)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM utilizador
                        WHERE @id = Id";
            var result = await db.ExecuteAsync(sql, new { Id = user.Id });
            return result > 0;
        }
    }
}
