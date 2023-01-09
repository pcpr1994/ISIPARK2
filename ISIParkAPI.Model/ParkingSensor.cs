/*
 * Grupo 4
 * Trabalho II de ISI
 * Alunos
 *  Carlos Pereira nº6498
 *  Paula Rodrigues nº21133
 *  Sérgio Gonçalves nº20343  
 */

using System;

namespace ISIParkAPI.Model
{
    /// <summary>
    /// This class contains all information of parking sensors 
    /// </summary>
    public class ParkingSensor
    {
        /// <summary>
        /// Brand is a variable that saves the vehicle's brand
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Model is a variable that saves the vehicle's model
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Type is a variable that saves the type of the vehicle
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Setor ia a variable that saves the parking's sector
        /// </summary>
        public int Setor { get; set; }

        /// <summary>
        /// Lugar ia a variable that saves the parking's place
        /// </summary>
        public int Lugar { get; set; }

        /// <summary>
        /// Estado is a variable that saves the place's state, if occupied or free
        /// </summary>
        public bool Estado { get; set; }

        /// <summary>
        /// Dia is a variable that saves the day the vehicle was parked
        /// </summary>
        public DateTime Dia { get; set; }

        /// <summary>
        /// Hora is a variable that saves the hour the vehicle was parked
        /// </summary>
        public DateTime Hora { get; set; }

        /// <summary>
        /// Matricula is a variable that saves the license plate of the vehicle that was parked
        /// </summary>
        public string Matricula { get; set; }

        /// <summary>
        /// Result_image is a variable that saves the result image 
        /// </summary>
        public string Result_image { get; set; }
    }
}
