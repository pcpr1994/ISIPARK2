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
using System.Text.Json.Serialization;

namespace ISIParkAPI.Model
{
    /// <summary>
    /// This class contains all information of user
    /// </summary>
    public class UserDTO
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
        /// Nif is a variable that saves the number of contributors
        /// </summary>
        public int Nif { get; set; }
        /// <summary>
        /// DataNasc is a variable that saves the date of birth
        /// </summary>
        public DateTime DataNasc { get; set; }
        /// <summary>
        /// Genero is a variable that saves the gender
        /// </summary>
        public string Genero { get; set; }
        /// <summary>
        /// Tipo_utilizadorid is a variable that saves the user type id
        /// </summary>
        public int Tipo_utilizadorid { get; set; }
        /// <summary>
        /// Moradaid_morada is a variable that saves the adress id
        /// </summary>
        public int Moradaid_morada { get; set; }
        /// <summary>
        /// Email is a variable that saves the email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Password is a variable that saves the password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// PasswordHash is a variable that saves the password Hash 
        /// </summary>
        [JsonIgnore]
        public byte[] PasswordHash { get; set; }
        /// <summary>
        /// PasswordSalt is a variable that saves the password salt 
        /// </summary>
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }
        /// <summary>
        /// Token is a variable that saves the Token
        /// </summary>
        [JsonIgnore]
        public string Token { get; set; }
    }
}
