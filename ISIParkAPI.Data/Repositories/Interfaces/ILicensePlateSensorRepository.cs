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
    /// This interface it will be consumed by the class LicensePlateSensorRepository
    /// </summary>
    public interface ILicensePlateSensorRepository
    {
        Task<IEnumerable<LicensePlateSensor>> GetAllPlateSensor();
        Task<LicensePlateSensor> GetPlateSensorDetails(int nif);
        Task<bool> InsertVehicleSensor(LicensePlateSensor licensePlateSensor);
        Task<bool> UpdateVehicleSensor(LicensePlateSensor licensePlateSensor);
        Task<bool> DeleteVehicleSensor(LicensePlateSensor licensePlateSensor);
    }
}
