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
    /// This class contains all information of UserContactType
    /// </summary>
    public class UserContactType
    {
        /// <summary>
        /// Utilizadorid is a variable that holds the user id
        /// </summary>
        public int Utilizadorid { get; set; }
        /// <summary>
        /// Tipo_contacton_contacto is a variable that holds the id of the contact type
        /// </summary>
        public int Tipo_contacton_contacto { get; set; }
        /// <summary>
        /// Contacto is a variable that holds the contact
        /// </summary>
        public string Contacto { get; set; }    
    }
}
