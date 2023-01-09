/*
 * Grupo 4
 * Trabalho II de ISI
 * Alunos
 *  Carlos Pereira nº6498
 *  Paula Rodrigues nº21133
 *  Sérgio Gonçalves nº20343
 *  
 */
using ISIParkAPI.Data.Repositories.Interfaces;
using ISIParkAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ISIParkAPI.Controllers
{
    /// <summary>
    /// Class controller of Report, this class have all routes of ReportRepository methods
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        /// <summary>
        /// Create a instance of Interface Report
        /// </summary>
        private readonly IReportRepository _reportRepository;

        /// <summary>
        /// Give a value to the instance
        /// </summary>
        /// <param name="reportRepository"></param>
        public ReportController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        /// <summary>
        /// Route to give all reports from database, this method uses a http get
        /// </summary>
        /// <returns>All reports</returns>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllReport()
        {
            return Ok(await _reportRepository.GetAllReport());
        }

        /// <summary>
        /// Route to give only one report from database, this method uses a http get
        /// </summary>
        /// <param name="id">Id of the report that we want</param>
        /// <returns>The report that corresponds the id entered</returns>
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReportDetails(int id)
        {
            return Ok(await _reportRepository.GetReportDetails(id));
        }

        /// <summary>
        /// Route to insert a new report, this method uses a http post
        /// </summary>
        /// <param name="report">An object to represent Report</param>
        /// <returns>Bad or not result depending on the result</returns>
        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertReport([FromBody] Report report)
        {
            if (report == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _reportRepository.InsertReport(report);
            return Created("created", inserted);
        }

        /// <summary>
        /// Route to update a report from database, this method uses a http put
        /// </summary>
        /// <param name="report">An object to represent Report</param>
        /// <returns>Bad or not result depending on the result</returns>
        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateReport([FromBody] Report report)
        {
            if (report == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _reportRepository.UpdateReport(report);
            return NoContent();
        }

        /// <summary>
        /// Route to delete a report from database, this method uses a http delete
        /// </summary>
        /// <param name="id">Id of the report that we want to delete</param>
        /// <returns>Nothing</returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReport(int id)
        {
            await _reportRepository.DeleteReport(new Report { ID_Report = id });

            return NoContent();
        }
    }
}
