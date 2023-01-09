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
    /// Class controller of Address, this class have all routes of AddressRepository methods's
    /// </summary>
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        /// <summary>
        /// Create a instance of Interface Address
        /// </summary>
        private readonly IAddressRepository _addressRepository;


        /// <summary>
        /// Give a value to the instance
        /// </summary>
        /// <param name="addressRepository"></param>
        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }


        /// <summary>
        /// Route to give all addresses from database, this method uses a http get
        /// </summary>
        /// <returns>All addresses</returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllAddress()
        {
            return Ok(await _addressRepository.GetAllAddress());
        }

        /// <summary>
        /// Route to give only one address from database, this method uses a http get
        /// </summary>
        /// <param name="id">Id of the address that we want</param>
        /// <returns>The address that corresponds the id entered</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressDetails(int id)
        {
            return Ok(await _addressRepository.GetAddressDetails(id));
        }

        /// <summary>
        /// Route to insert a new address, this method uses a http post
        /// </summary>
        /// <param name="address">An object to represent Address</param>
        /// <returns>Bad or not result depending on the result</returns>
        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertAddressHistory([FromBody] Address address)
        {
            if (address == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _addressRepository.InsertAddress(address);
            return Created("created", inserted);
        }

        /// <summary>
        /// Route to update an address from database, this method uses a http put
        /// </summary>
        /// <param name="address">An object to represent Address</param>
        /// <returns>Bad or not result depending on the result</returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAddress([FromBody] Address address)
        {
            if (address == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _addressRepository.UpdateAddress(address);
            return NoContent();
        }

        /// <summary>
        /// Route to delete an address from database, this method uses a http delete
        /// </summary>
        /// <param name="id">Id of the address that we want to delete</param>
        /// <returns>Nothing</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            await _addressRepository.DeleteAddress(new Address { ID_Morada = id });

            return NoContent();
        }
    }
}
