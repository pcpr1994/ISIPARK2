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
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories.Interfaces
{
    /// <summary>
    /// This interface it will be consumed by the class PlaceRepository
    /// </summary>
    public interface IPlaceRepository
    {
        Task<IEnumerable<Place>> GetAllPlace();
        Task<Place> GetPlaceById(int id);
        Task<bool> InsertPlace(Place place);
        Task<bool> UpdatePlace(Place place);
        Task<bool> DeletePlace(Place place);
        Task<IEnumerable<SetorType>> GetPlaceSectorType();
        Task<string> GetSetorUser(int User);
    }
}
