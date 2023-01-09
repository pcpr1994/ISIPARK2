/*
 * Grupo 4
 * Trabalho II de ISI
 * Alunos
 *  Carlos Pereira nº6498
 *  Paula Rodrigues nº21133
 *  Sérgio Gonçalves nº20343
 */

using ISIParkAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories.Interfaces
{
    /// <summary>
    /// This interface it will be consumed by the class ParkingSensorRepository
    /// </summary>
    public interface IParkingSensorRepository
    {
        Task<IEnumerable<ParkingSensor>> GetAllParkingSensor();
        Task<ParkingSensor> GetParkingSensorDetails(int lugar);
        Task<bool> InsertParkingSensor(ParkingSensor parkingSensor);
        Task<bool> UpdateParkingSensor(ParkingSensor parkingSensor);
        Task<bool> DeleteParkingSensor(ParkingSensor parkingSensor);
    }
}
