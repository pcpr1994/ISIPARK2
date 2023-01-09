/*
 * Grupo 4
 * Trabalho II de ISI
 * Alunos
 *  Carlos Pereira nº6498
 *  Paula Rodrigues nº21133
 *  Sérgio Gonçalves nº20343
 */

using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories.Interfaces
{
    /// <summary>
    /// This interface it will be consumed by the class QRCodeRepository
    /// </summary>
    public interface IQRCodeRepository
    {
        Task<IEnumerable<string>> Get();
        Task<string> GetExternalResponse();
    }
}
