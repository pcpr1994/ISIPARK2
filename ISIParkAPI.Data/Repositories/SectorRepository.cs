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
    /// This class contains all the functions that perform actions on the sectors
    /// </summary>
    public class SectorRepository : ISectorRepository
    {
        /// <summary>
        /// An instance of class MySQLConfiguration
        /// </summary>
        private MySQLConfiguration _connectionString;

        /// <summary>
        /// Initialize the instance containing the database connection information
        /// </summary>
        /// <param name="connectionString"></param>
        public SectorRepository(MySQLConfiguration connectionString)
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
        /// This method gets all sectors from database using a query
        /// </summary>
        /// <returns>Get all sectors</returns>
        public async Task<IEnumerable<Sector>> GetAllSector()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM setor";
            return await db.QueryAsync<Sector>(sql, new { });
        }

        /// <summary>
        /// This method get one sector from database
        /// </summary>
        /// <param name="id">Id sector entered</param>
        /// <returns>Get the sector with the same id that id entered</returns>
        public async Task<Sector> GetSectorDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM setor
                        WHERE id_setor = @ID_Setor";
            return await db.QueryFirstOrDefaultAsync<Sector>(sql, new { ID_Setor = id });
        }

        /// <summary>
        /// This method insert a new sector on database
        /// </summary>
        /// <param name="setor">Instance of Sector</param>
        /// <returns>True inserted or false</returns>
        public async Task<bool> InsertSector(Sector setor)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO setor (setor, total_lugares)
                        VALUES (@setor, @total_lugares)";

            var result = await db.ExecuteAsync(sql, new
            {
                setor.Setor,
                setor.Total_Lugares
            });

            return result > 0;
        }

        /// <summary>
        /// This method changes data of a sector
        /// </summary>
        /// <param name="setor">Instance of Sector</param>
        /// <returns>True Updated or false</returns>
        public async Task<bool> UpdateSector(Sector setor)
        {
            var db = dbConnection();
            var sql = @"UPDATE setor
                        SET setor = @Setor, total_lugares = @Total_Lugares
                        WHERE @ID_Setor = id_setor";

            var result = await db.ExecuteAsync(sql, new
            {
                setor.Setor,
                setor.Total_Lugares,
                setor.ID_Setor
            });

            return result > 0;
        }

        /// <summary>
        /// This method delete a sector of database 
        /// </summary>
        /// <param name="setor">Instance of Sector</param>
        /// <returns>True deleted or false</returns>
        public async Task<bool> DeleteSector(Sector setor)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM setor
                        WHERE id_setor = @ID_Setor";
            var result = await db.ExecuteAsync(sql, new { ID_Setor = setor.ID_Setor });
            return result > 0;
        }
    }
}
