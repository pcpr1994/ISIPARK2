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
    /// Class controller of Sector, this class have all routes of SectorRepository methods
    /// </summary>
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class SetorController : ControllerBase
    {
        /// <summary>
        /// Create a instance of Interface Sector
        /// </summary>
        private readonly ISectorRepository _sectorRepository;

        /// <summary>
        /// Give a value to the instance
        /// </summary>
        /// <param name="sectorRepository"></param>
        public SetorController(ISectorRepository sectorRepository)
        {
            _sectorRepository = sectorRepository;
        }

        /// <summary>
        /// Route to give all sectors from database, this method uses a http get
        /// </summary>
        /// <returns>All sectors</returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllSector()
        {
            return Ok(await _sectorRepository.GetAllSector());
        }

        /// <summary>
        /// Route to give only one sector from database, this method uses a http get
        /// </summary>
        /// <param name="id">Id of the sector that we want</param>
        /// <returns>The sector that corresponds the id entered</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSectorDetails(int id)
        {
            return Ok(await _sectorRepository.GetSectorDetails(id));
        }

        /// <summary>
        /// Route to insert a new sector, this method uses a http post
        /// </summary>
        /// <param name="sector">An object to represent Sector</param>
        /// <returns>Bad or not result depending on the result</returns>
        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertSector([FromBody] Sector sector)
        {
            if (sector == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _sectorRepository.InsertSector(sector);
            return Created("created", inserted);
        }

        /// <summary>
        /// Route to update a sector, this method uses a http post
        /// </summary>
        /// <param name="sector">An object to represent Sector</param>
        /// <returns>Bad or not result depending on the result</returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateSector([FromBody] Sector sector)
        {
            if (sector == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _sectorRepository.UpdateSector(sector);
            return NoContent();
        }

        /// <summary>
        /// Route to delete a sector from database, this method uses a http delete
        /// </summary>
        /// <param name="id">Id of the sector that we want to delete</param>
        /// <returns>Nothing</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSector(int id)
        {
            await _sectorRepository.DeleteSector(new Sector { ID_Setor = id });

            return NoContent();
        }
    }
}
