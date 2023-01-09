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
    /// Class controller of VehicleType, this class have all routes of VehicleTypeRepository methods's
    /// </summary>
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleTypeController : ControllerBase
    {
        /// <summary>
        /// Create a instance of Interface VehicleType
        /// </summary>
        private readonly IVehicleTypeRepository _vehicleTypeRepository;

        /// <summary>
        /// Give a value to the instance
        /// </summary>
        /// <param name="vehicleTypeRepository"></param>
        public VehicleTypeController(IVehicleTypeRepository vehicleTypeRepository)
        {
            _vehicleTypeRepository = vehicleTypeRepository;
        }

        /// <summary>
        /// Route to give all types from database, this method uses a http get
        /// </summary>
        /// <returns>All types</returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllVehickeType()
        {
            return Ok(await _vehicleTypeRepository.GetAllVehicleType());
        }

        /// <summary>
        /// Route to give only one type from database, this method uses a http get
        /// </summary>
        /// <param name="id">Id of the type that we want</param>
        /// <returns>The type that corresponds the id entered</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleTypeDetails(int id)
        {
            return Ok(await _vehicleTypeRepository.GetVehicleTypeDetails(id));
        }

        /// <summary>
        /// Route to insert a new type from database, this method uses a http put
        /// </summary>
        /// <param name="vehicleType">An object to represent VehicleType</param>
        /// <returns>Bad or not result depending on the result</returns>
        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertVehicleType([FromBody] VehicleType vehicleType)
        {
            if (vehicleType == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _vehicleTypeRepository.InsertVehicleType(vehicleType);
            return Created("created", inserted);
        }

        /// <summary>
        /// Route to update a type from database, this method uses a http put
        /// </summary>
        /// <param name="vehicleType">An object to represent VehicleType</param>
        /// <returns>Bad or not result depending on the result</returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateVehicletType([FromBody] VehicleType vehicleType)
        {
            if (vehicleType == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _vehicleTypeRepository.UpdateVehicleType(vehicleType);
            return NoContent();
        }

        /// <summary>
        /// Route to delete a type from database, this method uses a http delete
        /// </summary>
        /// <param name="id">Id of the type that we want to delete</param>
        /// <returns>Nothing</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleType(int id)
        {
            await _vehicleTypeRepository.DeleteVehicleType(new VehicleType { ID_Veiculo = id });

            return NoContent();
        }
    }
}
