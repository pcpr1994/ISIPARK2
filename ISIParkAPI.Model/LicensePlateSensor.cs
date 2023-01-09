/*
 * Grupo 4
 * Trabalho II de ISI
 * Alunos
 *  Carlos Pereira nº6498
 *  Paula Rodrigues nº21133
 *  Sérgio Gonçalves nº20343  
 */

namespace ISIParkAPI.Model
{
    /// <summary>
    /// This class contains all information of license plate sensor
    /// </summary>
    public class LicensePlateSensor
    {
        /// <summary>
        /// NIF is a variable that saves the user's NIF
        /// </summary>
        public int NIF { get; set; }

        /// <summary>
        /// Brand is a variable that saves the vehicle's brand
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Model is a variable that saves the model of the vehicle
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// LicensePlate ia a variable that saves the vehicle's license plate
        /// </summary>
        public string LicensePlate { get; set; }

        /// <summary>
        /// Type ia a variable that saves the vehicle's type
        /// </summary>
        public string Type { get; set; }
    }
}
