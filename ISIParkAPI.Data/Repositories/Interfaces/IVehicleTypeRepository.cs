/*
 * Grupo 4
 * Trabalho II de ISI
 * Alunos
 *  Carlos Pereira nº6498
 *  Paula Rodrigues nº21133
 *  Sérgio Gonçalves nº20343
 *  
 */
using ISIParkAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories.Interfaces
{
    /// <summary>
    /// This interface it will be consumed by the class VehicleTypeRepository
    /// </summary>
    public interface IVehicleTypeRepository
    {
        Task<IEnumerable<VehicleType>> GetAllVehicleType();
        Task<VehicleType> GetVehicleTypeDetails(int id);
        Task<bool> InsertVehicleType(VehicleType vehicleType);
        Task<bool> UpdateVehicleType(VehicleType vehicleType);
        Task<bool> DeleteVehicleType(VehicleType vehicleType);
    }
}
