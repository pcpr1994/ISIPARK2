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
    /// Class controller of PersonalData, this class have all routes of PersonalDataRepository methods's
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalDataController : ControllerBase
    {
        /// <summary>
        /// Create a instance of Interface PersonalData
        /// </summary>
        private readonly IPersonalDataRepository _personalDataRepository;

        /// <summary>
        /// Give a value to the instance
        /// </summary>
        /// <param name="personalDataRepository"></param>
        public PersonalDataController(IPersonalDataRepository personalDataRepository)
        {
            _personalDataRepository = personalDataRepository;
        }

        /// <summary>
        /// Route to give all personal data from database, this method uses a http get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllPersonalData()
        {
            return Ok(await _personalDataRepository.GetAllPersonalData());
        }

        /// <summary>
        /// Route to give one personal data from database, this method uses a http get
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        [HttpGet("{numero}")]
        public async Task<IActionResult> GetPersonalDataDetails(int numero)
        {
            return Ok(await _personalDataRepository.GetPersonalDataDetails(numero));
        }

        /// <summary>
        /// Route to insert a new user, this method uses a http post
        /// </summary>
        /// <param name="personalData"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertPersonalData([FromBody] PersonalData personalData)
        {
            if (personalData == null)
                return BadRequest();
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _personalDataRepository.InsertPersonalData(personalData);
            return Created("created", inserted);
        }

        /// <summary>
        /// Route to update one personal data , this method uses a http post
        /// </summary>
        /// <param name="personalData"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdatePersonalData([FromBody] PersonalData personalData)
        {
            if (personalData == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _personalDataRepository.UpdatePersonalData(personalData);
            return NoContent();
        }

        /// <summary>
        /// Route to delete one personal data from database, this method uses a http delete
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        [HttpDelete("{numero}")]
        public async Task<IActionResult> DeletePersonalData(int numero)
        {
            await _personalDataRepository.DeletePersonalData(new PersonalData { Numero = numero });

            return NoContent();
        }
    }
}
