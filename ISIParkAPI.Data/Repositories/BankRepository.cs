/*
 * Grupo 4
 * Trabalho II de ISI
 * Alunos
 *  Carlos Pereira nº6498
 *  Paula Rodrigues nº21133
 *  Sérgio Gonçalves nº20343
 */

using ISIParkAPI.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories
{
    public class BankRepository : IBankRepository
    {
        /// <summary>
        /// Variable that has the URL for External API
        /// </summary>
        static string _address = "http://api.worldbank.org/countries?format=json";
        /// <summary>
        /// This method gets values from the exetrnal API
        /// </summary>
        /// <returns>Get all values</returns>
        public async Task<IEnumerable<string>> Get()
        {
            var result = await GetExternalResponse();

            return new string[] { result };
        }
        /// <summary>
        /// This method gets external response from API
        /// </summary>
        /// <returns>Result from get request</returns>
        public async Task<string> GetExternalResponse()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(_address);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
