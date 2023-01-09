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
    /// Class controller of PlaceType, this class have all routes of PlaceTypeRepository methods's
    /// </summary>
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceTypeController : ControllerBase
    {
        /// <summary>
        /// Create a instance of Interface PlaceType
        /// </summary>
        private readonly IPlaceTypeRepository _placeTypeRepository;

        /// <summary>
        /// Give a value to the instance
        /// </summary>
        /// <param name="placeTypeRepository"></param>
        public PlaceTypeController(IPlaceTypeRepository placeTypeRepository)
        {
            _placeTypeRepository = placeTypeRepository;
        }

        /// <summary>
        /// Route to give all types from database, this method uses a http get
        /// </summary>
        /// <returns>All types</returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllPlaceType()
        {
            return Ok(await _placeTypeRepository.GetAllPlaceType());
        }

        /// <summary>
        /// Route to give only one atype from database, this method uses a http get
        /// </summary>
        /// <param name="id">Id of the type that we want</param>
        /// <returns>The type that corresponds the id entered</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlaceTypeDetails(int id)
        {
            return Ok(await _placeTypeRepository.GetPlaceTypeDetails(id));
        }

        /// <summary>
        /// Route to insert a new type from database, this method uses a http put
        /// </summary>
        /// <param name="placeType">An object to represent PlaceType</param>
        /// <returns>Bad or not result depending on the result</returns>
        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertPlaceType([FromBody] PlaceType placeType)
        {
            if (placeType == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _placeTypeRepository.InsertPlaceType(placeType);
            return Created("created", inserted);
        }

        /// <summary>
        /// Route to update a type from database, this method uses a http put
        /// </summary>
        /// <param name="placeType">An object to represent PlaceType</param>
        /// <returns>Bad or not result depending on the result</returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdatePlaceType([FromBody] PlaceType placeType)
        {
            if (placeType == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _placeTypeRepository.UpdatePlaceType(placeType);
            return NoContent();
        }

        /// <summary>
        /// Route to delete a type from database, this method uses a http delete
        /// </summary>
        /// <param name="id">Id of the type that we want to delete</param>
        /// <returns>Nothing</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaceType(int id)
        {
            await _placeTypeRepository.DeletePlaceType(new PlaceType { N_Tipo = id });

            return NoContent();
        }
    }
}
