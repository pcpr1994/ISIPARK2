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
    /// This class contains all information of place
    /// </summary>
    public class Place
    {
        /// <summary>
        /// Numero_lugar is a variable that saves the place number.
        /// </summary>
        public int Numero_lugar { get; set; }
        /// <summary>
        /// Setorid_setor is a variable that saves the sector id .
        /// </summary>
        public int Setorid_setor { get; set; }
        /// <summary>
        /// Tipo_lugarn_tipo is a variable that holds the id of the type of place
        /// </summary>
        public int Tipo_lugarn_tipo { get; set; }
        /// <summary>
        /// Estado is a variable that holds true when busy and false when free
        /// </summary>
        public bool Estado { get; set; }
        /// <summary>
        /// Utilizador_Tipo_veiculosmatricula é uma variável que guarda a matricula
        /// </summary>
        public string Utilizador_Tipo_veiculosmatricula { get; set; }
    }
}
