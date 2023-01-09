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
    /// This class contains all information of login user
    /// </summary>
    public class UserLogin
    {
        /// <summary>
        /// Email is a variable that saves the email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Password is a variable that saves the password
        /// </summary>
        public string Password { get; set; }
    }
}
