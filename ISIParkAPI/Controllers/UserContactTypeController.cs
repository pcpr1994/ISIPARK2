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
    /// Class controller of UserContactType, this class have all routes of UserContactTypeRepository methods's
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserContactTypeController : ControllerBase
    {
        /// <summary>
        /// Create a instance of Interface UserContactType
        /// </summary>
        private readonly IUserContactTypeRepository _userContactTypeRepository;

        /// <summary>
        /// Give a value to the instance
        /// </summary>
        /// <param name="userContactTypeRepository"></param>
        public UserContactTypeController(IUserContactTypeRepository userContactTypeRepository)
        {
            _userContactTypeRepository = userContactTypeRepository;
        }

        /// <summary>
        /// Route to give all contact type of user from database, this method uses a http get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllUserContactType()
        {
            return Ok(await _userContactTypeRepository.GetAllUserContactType());
        }

        /// <summary>
        /// Route to give only a user's contact from the database, this method uses an http get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserContactTypeID(int id)
        {
            return Ok(await _userContactTypeRepository.GetUserContactTypeID(id));
        }

        /// <summary>
        /// Method to insert a contact to a user
        /// </summary>
        /// <param name="userContactType"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertUserContactType([FromBody] UserContactType userContactType)
        {
            if (userContactType == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _userContactTypeRepository.InsertUserContactType(userContactType);
            return Created("created", inserted);
        }

        /// <summary>
        /// Route to update a contact the user from database, this method uses a http put
        /// </summary>
        /// <param name="userContactType"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateUserContactType([FromBody] UserContactType userContactType)
        {
            if (userContactType == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userContactTypeRepository.UpdateUserContactType(userContactType);
            return NoContent();
        }

        /// <summary>
        /// Route to delete a contact the user from database, this method uses a http delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserContactType(int id)
        {
            await _userContactTypeRepository.DeleteUserContactType(new UserContactType { Utilizadorid = id });

            return NoContent();
        }


    }
}
