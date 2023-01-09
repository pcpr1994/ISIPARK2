/*
 * Grupo 4
 * Trabalho II de ISI
 * Alunos
 *  Carlos Pereira nº6498
 *  Paula Rodrigues nº21133
 *  Sérgio Gonçalves nº20343
 *  
 */
namespace ISIParkAPI.Model
{
    /// <summary>
    /// This class contains all information of UserVechicleType
    /// </summary>
    public class UserVechicleType
    {
        /// <summary>
        /// Utilizadorid is a variable that holds the user id
        /// </summary>
        public int Utilizadorid { get; set; }
        /// <summary>
        /// Tipo_veiculosid_veiculo is a variable that holds the id of the vehicle type
        /// </summary>
        public int Tipo_veiculosid_veiculo { get; set; }
        /// <summary>
        /// Matricula is a variable that holds the license plate
        /// </summary>
        public string Matricula { get; set; }
    }
}
