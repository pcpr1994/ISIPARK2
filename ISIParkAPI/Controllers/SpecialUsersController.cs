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
    /// Class controller of SpecialUser, this class have all routes of SpecialUserRepository methods
    /// </summary>
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialUsersController : ControllerBase
    {
        /// <summary>
        /// Create a instance of Interface SpecialUser
        /// </summary>
        private readonly ISpecialUsersRepository _specialUsersRepository;

        /// <summary>
        /// Give a value to the instance
        /// </summary>
        /// <param name="specialUsersRepository"></param>
        public SpecialUsersController(ISpecialUsersRepository specialUsersRepository)
        {
            _specialUsersRepository = specialUsersRepository;
        }

        /// <summary>
        /// Route to give all Special user from database, this method uses a http get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllSpecialUser()
        {
            return Ok(await _specialUsersRepository.GetAllSpecialUser());
        }

        /// <summary>
        /// Route to give only one special user from database, this method uses a http get
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        [HttpGet("{numero}")]
        public async Task<IActionResult> GetSpecialUserByID(int numero)
        {
            return Ok(await _specialUsersRepository.GetSpecialUserByID(numero));
        }

        /// <summary>
        /// Route to insert a new special user, this method uses a http post
        /// </summary>
        /// <param name="specialUser"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertSpecialUser([FromBody] SpecialUser specialUser)
        {
            if (specialUser == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _specialUsersRepository.InsertSpecialUser(specialUser);
            return Created("created", inserted);
        }

        /// <summary>
        /// Route to update a special user, this method uses a http post
        /// </summary>
        /// <param name="specialUser"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateSpecialUser([FromBody] SpecialUser specialUser)
        {
            if (specialUser == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _specialUsersRepository.UpdateSpecialUser(specialUser);
            return NoContent();
        }

        /// <summary>
        /// Route to delete a special user from database, this method uses a http delete
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        [HttpDelete("{numero}")]
        public async Task<IActionResult> DeleteSpecialUser(int numero)
        {
            await _specialUsersRepository.DeleteSpecialUser(new SpecialUser { Id = numero });

            return NoContent();
        }
    }
}
