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
    /// This class contains all information of Sector
    /// </summary>
    public class Sector
    {
        /// <summary>
        /// ID_Sector is a variable that saves the id of each sector
        /// </summary>
        public int ID_Setor { get; set; }

        /// <summary>
        /// Sector is a variable that saves the name of each sector
        /// </summary>
        public string Setor { get; set; }

        /// <summary>
        /// Total_Lugares is a variable that saves the number of places of each sector
        /// </summary>
        public int Total_Lugares { get; set; }

    }
}
