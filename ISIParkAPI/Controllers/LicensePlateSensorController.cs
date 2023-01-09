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
    /// Class controller of LicensePlateSensor, this class have all routes of LicensePlateSensorRepository methods
    /// </summary>
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class LicensePlateSensorController : ControllerBase
    {
        /// <summary>
        /// Create a instance of Interface LicensePlateSensor
        /// </summary>
        private readonly ILicensePlateSensorRepository _licensePlateSensorRepository;

        /// <summary>
        /// Give a value to the instance
        /// </summary>
        /// <param name="licensePlateSensorRepository"></param>
        public LicensePlateSensorController(ILicensePlateSensorRepository licensePlateSensorRepository)
        {
            _licensePlateSensorRepository = licensePlateSensorRepository;
        }

        /// <summary>
        /// Route to give all vehicles that was read from license plate sensor, this method uses a http get
        /// </summary>
        /// <returns>All vehicles</returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllPlateSensor()
        {
            return Ok(await _licensePlateSensorRepository.GetAllPlateSensor());
        }

        /// <summary>
        /// Route to give only one user's vehicle from database, this method uses a http get
        /// </summary>
        /// <param name="nif">NIF of the user that we want</param>
        /// <returns>The user's vehicle that corresponds the nif entered</returns>
        [HttpGet("{nif}")]
        public async Task<IActionResult> GetPlateSensorDetails(int nif)
        {
            return Ok(await _licensePlateSensorRepository.GetPlateSensorDetails(nif));
        }

        /// <summary>
        /// Route to insert a new user's vehicle that passes on license plate sensor, this method uses a http post
        /// </summary>
        /// <param name="licensePlateSensor">An object to represent LicensePlateSensor</param>
        /// <returns>Bad or not result depending on the result</returns>
        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertVehicleSensor([FromBody] LicensePlateSensor licensePlateSensor)
        {
            if (licensePlateSensor == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _licensePlateSensorRepository.InsertVehicleSensor(licensePlateSensor);
            return Created("created", inserted);
        }

        /// <summary>
        /// Route to update a user's vehicle that passes on license plate sensor, this method uses a http post
        /// </summary>
        /// <param name="licensePlateSensor">An object to represent LicensePlateSensor</param>
        /// <returns>Bad or not result depending on the result</returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateVehicleSensor([FromBody] LicensePlateSensor licensePlateSensor)
        {
            if (licensePlateSensor == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _licensePlateSensorRepository.UpdateVehicleSensor(licensePlateSensor);
            return NoContent();
        }

        /// <summary>
        /// Route to delete a user's vehicle that passes on license plate sensor from database, this method uses a http delete
        /// </summary>
        /// <param name="nif">Nif of the user's vehicle that we want to delete</param>
        /// <returns>Nothing</returns>
        [HttpDelete("{nif}")]
        public async Task<IActionResult> DeleteVehicleSensor(int nif)
        {
            await _licensePlateSensorRepository.DeleteVehicleSensor(new LicensePlateSensor { NIF = nif });

            return NoContent();
        }
    }
}
