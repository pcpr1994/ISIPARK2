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
    /// This class contains all the functions that perform actions on the personal data
    /// </summary>
    public class PersonalDataRepository : IPersonalDataRepository
    {
        /// <summary>
        /// An instance of class MySQLConfiguration
        /// </summary>
        private MySQLConfiguration _connectionString;

        /// <summary>
        /// Initialize the instance containing the database connection information
        /// </summary>
        /// <param name="connectionString"></param>
        public PersonalDataRepository(MySQLConfiguration connectionString)
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
        /// This method gets all personal data from database using a query
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PersonalData>> GetAllPersonalData()
        {
            var db = dbConnection();
            var sql = @"SELECT numero, nome, cp4, cp3, rua, contacto, nif, email, 
                        password, dataNasc, genero, tipo_utilizador, pagamento
                        FROM dados_pessoais";
            return await db.QueryAsync<PersonalData>(sql, new { });
        }

        /// <summary>
        /// This method get one personal data from database
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public async Task<PersonalData> GetPersonalDataDetails(int numero)
        {
            var db = dbConnection();
            var sql = @"SELECT numero, nome, cp4, cp3, rua, contacto, nif, email, 
                        password, dataNasc, genero, tipo_utilizador, pagamento
                        FROM dados_pessoais
                        WHERE numero = @Numero";
            return await db.QueryFirstOrDefaultAsync<PersonalData>(sql, new { Numero = numero });
        }

        /// <summary>
        /// This method insert a new people on database
        /// </summary>
        /// <param name="personalData"></param>
        /// <returns>True inserted or false</returns>
        public async Task<bool> InsertPersonalData(PersonalData personalData)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO dados_pessoais (nome, cp4, cp3, rua, contacto, nif, email, 
                        password, dataNasc, genero, tipo_utilizador, pagamento)
                        VALUES (@nome, @cp4, @cp3, @rua, @contacto, @nif, @email, 
                        @password, @dataNasc, @genero, @tipo_utilizador, @pagamento)";

            var result =  await db.ExecuteAsync(sql, new {personalData.Nome, personalData.CP4, personalData.CP3,
            personalData.Rua, personalData.Contacto, personalData.NIF, personalData.Email, personalData.Password,
            personalData.DataNasc, personalData.Genero, personalData.Tipo_Utilizador, personalData.Pagamento});

            return result > 0;
        }

        /// <summary>
        /// This method changes the data in person
        /// </summary>
        /// <param name="personalData"></param>
        /// <returns></returns>
        public async Task<bool> UpdatePersonalData(PersonalData personalData)
        {
            var db = dbConnection();
            var sql = @"UPDATE dados_pessoais
                        SET nome = @Nome, cp4 = @CP4, cp3 = @CP3, rua = @Rua, contacto = @Contacto, nif = @NIF, 
                        email = @Email, password = @Password, dataNasc = @DataNasc, genero = @Genero,
                        tipo_utilizador = @Tipo_Utilizador, pagamento = @Pagamento
                        WHERE @numero = Numero";

            var result = await db.ExecuteAsync(sql, new { personalData.Nome, personalData.CP4, personalData.CP3,
                personalData.Rua, personalData.Contacto, personalData.NIF, personalData.Email, personalData.Password,
                personalData.DataNasc, personalData.Genero, personalData.Tipo_Utilizador, personalData.Pagamento,
                personalData.Numero});

            return result > 0;
        }

        /// <summary>
        /// Este método elimina uma pessoa da base de dados
        /// </summary>
        /// <param name="personalData"></param>
        /// <returns>True deleted or false</returns>
        public async Task<bool> DeletePersonalData(PersonalData personalData)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM dados_pessoais
                        WHERE numero = @Numero";
            var result = await db.ExecuteAsync(sql, new { Numero = personalData.Numero });
            return result > 0;
        }
    }
}
