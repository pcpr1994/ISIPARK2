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
    /// This class contains all information of Special user
    /// </summary>
    public class SpecialUser
    {
        /// <summary>
        /// Id is a variable that saves the id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome is a variable that saves the name
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Matricula is a variable that saves the car license plate
        /// </summary>
        public string Matricula { get; set; }
        /// <summary>
        /// Contacto is a variable that saves contact
        /// </summary>
        public string Contacto { get; set; }
        /// <summary>
        /// Tipo_veiculosid_veiculo is a variable that saves the vehicle type id
        /// </summary>
        public int Tipo_veiculosid_veiculo { get; set; }
    }
}
