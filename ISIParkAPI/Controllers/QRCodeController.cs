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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ISIParkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QRCodeController : ControllerBase
    {
        /// <summary>
        /// Create an instance of QRRepository
        /// </summary>
        private readonly IQRCodeRepository _qrCodeRepository;

        /// <summary>
        /// Give a value to the instance
        /// </summary>
        /// <param name="qrCodeRepository"></param>
        public QRCodeController(IQRCodeRepository qrCodeRepository)
        {
            _qrCodeRepository = qrCodeRepository;
        }

        [HttpGet]
        [Route("getQRCode")]
        /// <summary>
        /// Route to get a QR Code from API, this method uses a http get
        /// </summary>
        /// <returns>All values</returns>
        public async Task<IActionResult> Get()
        {
            return Ok(await _qrCodeRepository.Get());
        }
    }
}

