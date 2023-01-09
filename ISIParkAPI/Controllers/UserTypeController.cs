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
    /// Class controller of UserTYpe, this class have all routes of UserTypeRepository methods's
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        /// <summary>
        /// Create a instance of Interface UserType
        /// </summary>
        private readonly IUserTypeRepository _userTypeRepository;

        /// <summary>
        /// Give a value to the instance
        /// </summary>
        /// <param name="userTypeRepository"></param>
        public UserTypeController(IUserTypeRepository userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }

        /// <summary>
        /// Route to give all type user from database, this method uses a http get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllUserType()
        {
            return Ok(await _userTypeRepository.GetAllUserType());
        }

        /// <summary>
        /// Route to give only one type the user from database, this method uses a http get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserTypeDetails(int id)
        {
            return Ok(await _userTypeRepository.GetUserTypeDetails(id));
        }

        /// <summary>
        /// Route to insert a new type of user, from the database, this method uses a post http
        /// </summary>
        /// <param name="userType"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertUserType([FromBody] UserType userType)
        {
            if (userType == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _userTypeRepository.InsertUserType(userType);
            return Created("created", inserted);
        }

        /// <summary>
        /// Route to update a type of user from database, this method uses a http put
        /// </summary>
        /// <param name="userType"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateUserType([FromBody] UserType userType)
        {
            if (userType == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userTypeRepository.UpdateUserType(userType);
            return NoContent();
        }

        /// <summary>
        /// Route to delete a type of user from database, this method uses a http delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserType(int id)
        {
            await _userTypeRepository.DeleteUserType(new UserType { ID = id });

            return NoContent();
        }
    }
}
