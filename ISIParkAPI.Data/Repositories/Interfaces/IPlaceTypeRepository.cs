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
    /// This interface it will be consumed by the class PlaceTypeRepository
    /// </summary>
    public interface IPlaceTypeRepository
    {
        Task<IEnumerable<PlaceType>> GetAllPlaceType();
        Task<PlaceType> GetPlaceTypeDetails(int id);
        Task<bool> InsertPlaceType(PlaceType placeType);
        Task<bool> UpdatePlaceType(PlaceType placeType);
        Task<bool> DeletePlaceType(PlaceType placeType);
    }
}
