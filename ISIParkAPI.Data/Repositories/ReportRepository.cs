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
    /// This class contains all the functions that perform actions on the reports
    /// </summary>
    public class ReportRepository : IReportRepository
    {
        /// <summary>
        /// An instance of class MySQLConfiguration
        /// </summary>
        private MySQLConfiguration _connectionString;

        /// <summary>
        /// Initialize the instance containing the database connection information
        /// </summary>
        /// <param name="connectionString"></param>
        public ReportRepository(MySQLConfiguration connectionString)
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
        /// This method gets all reports from database using a query
        /// </summary>
        /// <returns>Get all reports</returns>
        public async Task<IEnumerable<Report>> GetAllReport()
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM Report";
            return await db.QueryAsync<Report>(sql, new { });
        }

        /// <summary>
        /// This method get one report from database
        /// </summary>
        /// <param name="id">Id report entered</param>
        /// <returns>Get the report with the same id that id entered</returns>
        public async Task<Report> GetReportDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM Report
                        WHERE id_report = @ID_Report";
            return await db.QueryFirstOrDefaultAsync<Report>(sql, new { ID_Report = id });
        }

        /// <summary>
        /// This method insert a new report on database
        /// </summary>
        /// <param name="report">Instance of Report</param>
        /// <returns>True inserted or false</returns>
        public async Task<bool> InsertReport(Report report)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO Report (descricao, utilizadorid, data, imagem)
                        VALUES (@Descricao, @UtilizadorID, @Data, @Imagem)";

            var result = await db.ExecuteAsync(sql, new
            {
                report.Descricao,
                report.UtilizadorID,
                report.Data,
                report.Imagem        
            });

            return result > 0;
        }

        /// <summary>
        /// This method changes data of a report
        /// </summary>
        /// <param name="report">Instance of Report</param>
        /// <returns>True Updated or false</returns>
        public async Task<bool> UpdateReport(Report report)
        {
            var db = dbConnection();
            var sql = @"UPDATE Report
                        SET descricao = @Descricao, utilizadorid = @UtilizadorID, data = @Data, imagem = @Imagem
                        WHERE @id_report = ID_Report";

            var result = await db.ExecuteAsync(sql, new
            {
                report.Descricao,
                report.UtilizadorID,
                report.Data,
                report.Imagem
            });

            return result > 0;
        }

        /// <summary>
        /// This method delete a report of database 
        /// </summary>
        /// <param name="report">Instance of Report</param>
        /// <returns>True deleted or false</returns>
        public async Task<bool> DeleteReport(Report report)
        {
            var db = dbConnection();
            var sql = @"DELETE
                        FROM Report
                        WHERE id_report = @ID_Report";
            var result = await db.ExecuteAsync(sql, new { ID_Report = report.ID_Report });
            return result > 0;
        }
    }
}
