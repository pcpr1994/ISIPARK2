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
    /// Class controller of UserMessage, this class have all routes of UserMessageRepository methods's
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessageController : ControllerBase
    {
        /// <summary>
        /// Create a instance of Interface UserMessage
        /// </summary>
        private readonly IUserMessageRepository _userMessageRepository;

        /// <summary>
        /// Give a value to the instance
        /// </summary>
        /// <param name="userMessageRepository"></param>
        public UserMessageController(IUserMessageRepository userMessageRepository)
        {
            _userMessageRepository = userMessageRepository;
        }

        /// <summary>
        /// Route to give all message the user from database, this method uses a http get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllUserMessage()
        {
            return Ok(await _userMessageRepository.GetAllUserMessage());
        }

        /// <summary>
        /// Route to give only one message the user from database, this method uses a http get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserMessageID(int id)
        {
            return Ok(await _userMessageRepository.GetUserMessageID(id));
        }

        /// <summary>
        /// Route to insert a new message the user from database, this method uses a http post
        /// </summary>
        /// <param name="userMessage"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertUserMessage([FromBody] UserMessage userMessage)
        {
            if (userMessage == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _userMessageRepository.InsertUserMessage(userMessage);
            return Created("created", inserted);
        }

        /// <summary>
        /// Route to update a message the user from database, this method uses a http put
        /// </summary>
        /// <param name="userMessage"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateUserMessage([FromBody] UserMessage userMessage)
        {
            if (userMessage == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userMessageRepository.UpdateUserMessage(userMessage);
            return NoContent();
        }

        /// <summary>
        /// Route to delete a message the user from database, this method uses a http delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserMessage(int id)
        {
            await _userMessageRepository.DeleteUserMessage(new UserMessage { Utilizadorid = id });

            return NoContent();
        }





    }
}
