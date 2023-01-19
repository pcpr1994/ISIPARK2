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
using System.Threading.Tasks;

namespace ISIParkAPI.Controllers
{
    /// <summary>
    /// Class controller of UserVechicleType, this class have all routes of UserVechicleTypeRepository methods's
    /// </summary>
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserVechicleTypeController : ControllerBase
    {
        /// <summary>
        /// Create a instance of Interface UserVechicleType
        /// </summary>
        private readonly IUserVechicleTypeRepository _userVechicleTypeRepository;

        /// <summary>
        /// Give a value to the instance
        /// </summary>
        /// <param name="userVechicleTypeRepository"></param>
        public UserVechicleTypeController(IUserVechicleTypeRepository userVechicleTypeRepository)
        {
            _userVechicleTypeRepository = userVechicleTypeRepository;
        }

        /// <summary>
        /// Route to give all User vehicle type from database, this method uses a http get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllUserVechicleTypey()
        {
            return Ok(await _userVechicleTypeRepository.GetAllUserVechicleTypey());
        }

        /// <summary>
        /// Route to give only the vehicles of a database user, this method uses an http get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IEnumerable<VehiclesByUsers>> GetUserVechicleTypeID(int id)
        {
            return await _userVechicleTypeRepository.GetUserVechicleTypeID(id);
        }

        /// <summary>
        /// Route to insert a new vehicle for user from the database, this method uses an http put
        /// </summary>
        /// <param name="userVechicleType"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertUserVechicleType([FromBody] UserVechicleType userVechicleType)
        {
            if (userVechicleType == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _userVechicleTypeRepository.InsertUserVechicleType(userVechicleType);
            return Created("created", inserted);
        }

        /// <summary>
        /// Route to update a user's vehicle from the database, this method uses an http put
        /// </summary>
        /// <param name="userVechicleType"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateUserVechicleType([FromBody] UserVechicleType userVechicleType)
        {
            if (userVechicleType == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userVechicleTypeRepository.UpdateUserVechicleType(userVechicleType);
            return NoContent();
        }

        /// <summary>
        /// Route to delete a vehicle from a database user, this method uses an http delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserVechicleType(int id)
        {
            await _userVechicleTypeRepository.DeleteUserVechicleType(new UserVechicleType { Utilizadorid = id });

            return NoContent();
        }

    }
}
