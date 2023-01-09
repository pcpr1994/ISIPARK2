/*
 * Grupo 4
 * Trabalho II de ISI
 * Alunos
 *  Carlos Pereira nº6498
 *  Paula Rodrigues nº21133
 *  Sérgio Gonçalves nº20343
 *  
 */
using System;

namespace ISIParkAPI.Model
{
    /// <summary>
    /// This class contains all information of personal data
    /// </summary>
    public class PersonalData
    {
        /// <summary>
        /// Numero is a variable that saves the number
        /// </summary>
        public int Numero { get; set; }
        /// <summary>
        /// Nome is a variable that saves the name
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// CP4 ia a variable that saves the first four numbers of postal code
        /// </summary>
        public int CP4 { get; set; }
        /// <summary>
        /// CP3 ia a variable that saves the seconds three numbers of postal code
        /// </summary>
        public int CP3 { get; set; }
        /// <summary>
        /// Rua is a variable that saves the road
        /// </summary>
        public string Rua { get; set; }
        /// <summary>
        /// Contacto is a variable that saves the contact number
        /// </summary>
        public int Contacto { get; set; }
        /// <summary>
        /// Nif is a variable that saves the number of contributors
        /// </summary>
        public int NIF { get; set; }
        /// <summary>
        /// Email is a variable that saves the email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Password is a variable that saves the password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// DataNasc is a variable that saves the date of birth
        /// </summary>
        public DateTime DataNasc{ get; set; }
        /// <summary>
        /// Genero is a variable that saves the gender
        /// </summary>
        public string Genero { get; set; }
        /// <summary>
        /// Tipo_Utilizador is a variable that saves the user type
        /// </summary>
        public string Tipo_Utilizador { get; set; }
        /// <summary>
        /// Pagamento is a variable that saves the pay state
        /// </summary>
        public bool Pagamento { get; set; }

    }
}
