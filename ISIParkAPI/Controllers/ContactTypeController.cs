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
    /// Class controller of ContactType, this class have all routes of ContactTypeRepository methods's
    /// </summary>
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactTypeController : ControllerBase
    {
        /// <summary>
        /// Create a instance of Interface ContactType
        /// </summary>
        private readonly IContactTypeRepository _contactTypeRepository;

        /// <summary>
        /// Give a value to the instance
        /// </summary>
        /// <param name="contactTypeRepository"></param>
        public ContactTypeController(IContactTypeRepository contactTypeRepository)
        {
            _contactTypeRepository = contactTypeRepository;
        }

        /// <summary>
        /// Route to give all contact types from database, this method uses a http get
        /// </summary>
        /// <returns>All types</returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllContactType()
        {
            return Ok(await _contactTypeRepository.GetAllContactType());
        }

        /// <summary>
        /// Route to give only one type from database, this method uses a http get
        /// </summary>
        /// <param name="id">Id of the type that we want</param>
        /// <returns>The type that corresponds the id entered</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactTypeDetails(int id)
        {
            return Ok(await _contactTypeRepository.GetContactTypeDetails(id));
        }

        /// <summary>
        /// Route to insert a new type, this method uses a http post
        /// </summary>
        /// <param name="contactType">An object to represent ContactType</param>
        /// <returns>Bad or not result depending on the result</returns>
        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertContactType([FromBody] ContactType contactType)
        {
            if (contactType == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _contactTypeRepository.InsertContactType(contactType);
            return Created("created", inserted);
        }

        /// <summary>
        /// Route to update a type, this method uses a http post
        /// </summary>
        /// <param name="contactType">An object to represent ContactType</param>
        /// <returns>Bad or not result depending on the result</returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateContactType([FromBody] ContactType contactType)
        {
            if (contactType == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _contactTypeRepository.UpdateContactType(contactType);
            return NoContent();
        }

        /// <summary>
        /// Route to delete a type from database, this method uses a http delete
        /// </summary>
        /// <param name="id">Id of the type that we want to delete</param>
        /// <returns>Nothing</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactType(int id)
        {
            await _contactTypeRepository.DeleteContactType(new ContactType { ID = id });

            return NoContent();
        }
    }
}
