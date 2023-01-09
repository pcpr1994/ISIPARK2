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
    /// Class controller of History, this class have all routes of HistoryRepository methods
    /// </summary>
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        /// <summary>
        /// Create a instance of Interface History
        /// </summary>
        private readonly IHistoryRepository _historyRepository;

        /// <summary>
        /// Give a value to the instance
        /// </summary>
        /// <param name="historyRepository"></param>
        public HistoryController(IHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }

        /// <summary>
        /// Route to give all Historic from database, this method uses a http get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllHistory()
        {
            return Ok(await _historyRepository.GetAllHistory());
        }

        /// <summary>
        /// Route to give only one historic from database, this method uses a http get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHistoryDetails(int id)
        {
            return Ok(await _historyRepository.GetHistoryDetails(id));
        }

        /// <summary>
        /// Route to insert a new histric of place, this method uses a http post
        /// </summary>
        /// <param name="history"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertHistory([FromBody] History history)
        {
            if (history == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _historyRepository.InsertHistory(history);
            return Created("created", inserted);
        }

        /// <summary>
        /// Route to update a historic, this method uses a http post
        /// </summary>
        /// <param name="history"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateHistory([FromBody] History history)
        {
            if (history == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _historyRepository.UpdateHistory(history);
            return NoContent();
        }

        /// <summary>
        /// Route to delete a historic from database, this method uses a http delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalData(int id)
        {
            await _historyRepository.DeleteHistory(new History { ID = id });

            return NoContent();
        }
    }
}