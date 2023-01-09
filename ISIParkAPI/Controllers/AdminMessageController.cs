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
    /// Class controller of AdminMessage, this class have all routes of AdminMessageRepository methods's
    /// </summary>
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminMessageController : ControllerBase
    {
        /// <summary>
        /// Create a instance of Interface AdminMessage
        /// </summary>
        private readonly IAdminMessageRepository _adminMessageRepository;

        /// <summary>
        /// Give a value to the instance
        /// </summary>
        /// <param name="adminMessageRepository"></param>
        public AdminMessageController(IAdminMessageRepository adminMessageRepository)
        {
            _adminMessageRepository = adminMessageRepository;
        }

        /// <summary>
        /// Route to give all messages from database, this method uses a http get
        /// </summary>
        /// <returns>All addresses</returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllAdminMessage()
        {
            return Ok(await _adminMessageRepository.GetAllAdminMessage());
        }

        /// <summary>
        /// Route to give only one message from database, this method uses a http get
        /// </summary>
        /// <param name="id">Id of the message that we want</param>
        /// <returns>The message that corresponds the id entered</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdminMessageDetails(int id)
        {
            return Ok(await _adminMessageRepository.GetAdminMessageDetails(id));
        }

        /// <summary>
        /// Route to insert a new message, this method uses a http post
        /// </summary>
        /// <param name="adminMessage">An object to represent AdminMessage</param>
        /// <returns>Bad or not result depending on the result</returns>
        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertAdminMessageHistory([FromBody] AdminMessage adminMessage)
        {
            if (adminMessage == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _adminMessageRepository.InsertAdminMessage(adminMessage);
            return Created("created", inserted);
        }

        /// <summary>
        /// Route to update a message from database, this method uses a http put
        /// </summary>
        /// <param name="adminMessage">An objetc to represent AdminMessage</param>
        /// <returns>Bad or not result depending on the result</returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAdminMessage([FromBody] AdminMessage adminMessage)
        {
            if (adminMessage == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _adminMessageRepository.UpdateAdminMessage(adminMessage);
            return NoContent();
        }

        /// <summary>
        /// Route to delete a message from database, this method uses a http delete
        /// </summary>
        /// <param name="id">Id of the message that we want to delete</param>
        /// <returns>Nothing</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminMessage(int id)
        {
            await _adminMessageRepository.DeleteAdminMessage(new AdminMessage { Id_Mensagem = id });

            return NoContent();
        }
    }
}
