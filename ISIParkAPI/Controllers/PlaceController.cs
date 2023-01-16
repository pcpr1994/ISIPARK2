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
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace ISIParkAPI.Controllers
{
    /// <summary>
    /// Class controller of Place, this class have all routes of PlaceRepository methods
    /// </summary>
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        /// <summary>
        /// Create a instance of Interface Place
        /// </summary>
        private readonly IPlaceRepository _placeRepository;

        /// <summary>
        /// Give a value to the instance
        /// </summary>
        /// <param name="placeRepository"></param>
        public PlaceController(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        /// <summary>
        /// Route to give all places from database, this method uses a http get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllPlace()
        {
            return Ok(await _placeRepository.GetAllPlace());
        }

        /// <summary>
        /// Route to give only one place from database, this method uses a http get
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        [HttpGet("{numero}")]
        public async Task<IActionResult> GetPlaceById(int numero)
        {
            return Ok(await _placeRepository.GetPlaceById(numero));
        }

        /// <summary>
        /// Route to insert a new place, this method uses a http post
        /// </summary>
        /// <param name="place"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertPlace([FromBody] Place place)
        {
            if (place == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _placeRepository.InsertPlace(place);
            return Created("created", inserted);
        }

        /// <summary>
        /// Route to update a place, this method uses a http put
        /// </summary>
        /// <param name="place"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdatePlace([FromBody] Place place)
        {
            if (place == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _placeRepository.UpdatePlace(place);
            return NoContent();
        }

        /// <summary>
        /// Route to delete a place from database, this method uses a http delete
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        [HttpDelete("{numero}")]
        public async Task<IActionResult> DeletePlace(int numero)
        {
            await _placeRepository.DeletePlace(new Place { Numero_lugar = numero });

            return NoContent();
        }

        /// <summary>
        /// Route to delete a place from database, this method uses a http delete
        /// </summary>
        /// <returns></returns>
        [HttpGet("SetorType")]
        public async Task<List<ShowSetor>> GetPlaceSectorType()
        {
            return await _placeRepository.GetPlaceSectorType();

        }

        [HttpGet("SetorTypeNormal")]
        public async Task<List<ShowSetorNormal>> GetPlaceSectorTypeNormal()
        {
            return await _placeRepository.GetPlaceSectorTypeNormal();

        }

        [HttpGet("SetorTypeMoto")]
        public async Task<List<ShowSetorMoto>> GetPlaceSectorTypeMoto ()
        {
            return await _placeRepository.GetPlaceSectorTypeMoto();

        }

        [HttpGet("SetorTypeEletric")]
        public async Task<List<ShowSetorEletric>> GetPlaceSectorTypeEletric()
        {
            return await _placeRepository.GetPlaceSectorTypeEletric();

        }

        [HttpGet("SetorTypeReduceMob")]
        public async Task<List<ShowSetorReduceMob>> GetPlaceSectorTypeReduceMob()
        {
            return await _placeRepository.GetPlaceSectorTypeReduceMob();

        }

        /// <summary>
        /// Route to delete a place from database, this method uses a http delete
        /// </summary>
        /// <param name="Userid"></param>
        /// <returns></returns>
        [HttpGet("Setor/{Userid}")]
        public async Task<IActionResult> GetSetorUser(int Userid)
        {
            return Ok(await _placeRepository.GetSetorUser(Userid));

        }
    }
}
