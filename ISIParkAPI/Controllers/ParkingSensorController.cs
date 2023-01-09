/*
 * Grupo 4
 * Trabalho II de ISI
 * Alunos
 *  Carlos Pereira nº6498
 *  Paula Rodrigues nº21133
 *  Sérgio Gonçalves nº20343
 */

using ISIParkAPI.Data.Repositories.Interfaces;
using ISIParkAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ISIParkAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingSensorController : ControllerBase
    {
        /// <summary>
        /// Create a instance of Interface Address
        /// </summary>
        private readonly IParkingSensorRepository _parkingSensorRepository;

        /// <summary>
        /// Give a value to the instance
        /// </summary>
        /// <param name="parkingSensorRepository"></param>
        public ParkingSensorController(IParkingSensorRepository parkingSensorRepository)
        {
            _parkingSensorRepository = parkingSensorRepository;
        }

        /// <summary>
        /// Route to give all parking sensors from database, this method uses a http get
        /// </summary>
        /// <returns>All parking sensors</returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllParkingSensor()
        {
            return Ok(await _parkingSensorRepository.GetAllParkingSensor());
        }

        /// <summary>
        /// Route to give only one parking sensor from database, this method uses a http get
        /// </summary>
        /// <param name="lugar">Sensor that we want</param>
        /// <returns>The sensor that corresponds the place entered</returns>
        [HttpGet("{lugar}")]
        public async Task<IActionResult> GetParkingSensorDetails(int lugar)
        {
            return Ok(await _parkingSensorRepository.GetParkingSensorDetails(lugar));
        }

        /// <summary>
        /// Route to insert a new parking sensor, this method uses a http post
        /// </summary>
        /// <param name="parkingSensor">An object to represent Parking Sensor</param>
        /// <returns>Bad or not result depending on the result</returns>
        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertParkingSensor([FromBody] ParkingSensor parkingSensor)
        {
            if (parkingSensor == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _parkingSensorRepository.InsertParkingSensor(parkingSensor);
            return Created("created", inserted);
        }

        /// <summary>
        /// Route to update parking sensor from database, this method uses a http put
        /// </summary>
        /// <param name="parkingSensor">An object to represent Parking Sensor</param>
        /// <returns>Bad or not result depending on the result</returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateParkingSensor([FromBody] ParkingSensor parkingSensor)
        {
            if (parkingSensor == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _parkingSensorRepository.UpdateParkingSensor(parkingSensor);
            return NoContent();
        }

        /// <summary>
        /// Route to delete a parking sensor from database, this method uses a http delete
        /// </summary>
        /// <param name="lugar">Parking Sensor that we want to delete</param>
        /// <returns>Nothing</returns>
        [HttpDelete("{lugar}")]
        public async Task<IActionResult> DeleteParkingSensor(int lugar)
        {
            await _parkingSensorRepository.DeleteParkingSensor(new ParkingSensor { Lugar = lugar });

            return NoContent();
        }
    }
}
