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
    /// Class controller of UserHistoric, this class have all routes of UserHistoricRepository methods's
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserHistoryController : ControllerBase
    {
        /// <summary>
        /// Create a instance of Interface UserHistoric
        /// </summary>
        private readonly IUserHistoryRepository _userHistoryRepository;

        /// <summary>
        /// Give a value to the instance
        /// </summary>
        /// <param name="userHistoryRepository"></param>
        public UserHistoryController(IUserHistoryRepository userHistoryRepository)
        {
            _userHistoryRepository = userHistoryRepository;
        }

        /// <summary>
        /// Route to give all historic of user from database, this method uses a http get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllUserHistory()
        {
            return Ok(await _userHistoryRepository.GetAllUserHistory());
        }

        /// <summary>
        /// Route to give only one historic of user from database, this method uses a http get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserHistoryID(int id)
        {
            return Ok(await _userHistoryRepository.GetUserHistoryID(id));
        }

        /// <summary>
        /// Route to insert a new histric of user from database, this method uses a http post
        /// </summary>
        /// <param name="userHistory"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertUserHistory([FromBody] UserHistory userHistory)
        {
            if (userHistory == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _userHistoryRepository.InsertUserHistory(userHistory);
            return Created("created", inserted);
        }

        //[HttpPut]
        //[Route("update")]
        //public async Task<IActionResult> UpdateUserHistory([FromBody] UserHistory userHistory)
        //{
        //    if (userHistory == null)
        //        return BadRequest();
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    await _userHistoryRepository.UpdateUserHistory(userHistory);
        //    return NoContent();
        //}

        /// <summary>
        /// Route to delete a historic of user from database, this method uses a http delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserHistory(int id)
        {
            await _userHistoryRepository.DeleteUserHistory(new UserHistory { Utilizadorid = id });

            return NoContent();
        }
    }
}
