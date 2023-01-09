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
    /// Class controller of User, this class have all routes of UserRepository methods
    /// </summary>
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Create a instance of Interface User
        /// </summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Give a value to the instance
        /// </summary>
        /// <param name="userRepository"></param>
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Route to give all user from database, this method uses a http get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllUser()
        {
            return Ok(await _userRepository.GetAllUser());
        }

        /// <summary>
        /// Route to give only one user from database, this method uses a http get
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        [HttpGet("{numero}")]
        public async Task<IActionResult> GetUserById(int numero)
        {
            return Ok(await _userRepository.GetUserById(numero));
        }

        /// <summary>
        /// Route to update a user, this method uses a http post
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDTO user)
        {
            if (user == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userRepository.UpdateUser(user);
            return NoContent();
        }

        /// <summary>
        /// Route to delete a user from database, this method uses a http delete
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        [HttpDelete("{numero}")]
        public async Task<IActionResult> DeleteUser(int numero)
        {
            await _userRepository.DeleteUser(new UserDTO { Id = numero });

            return NoContent();
        }
    }
}
