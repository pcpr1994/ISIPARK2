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
    /// This class contains all information of history
    /// </summary>
    public class History
    {
        /// <summary>
        /// ID is a variable that saves the id
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Dia is a variable that saves the day
        /// </summary>
        public DateTime Dia { get; set; }
        /// <summary>
        /// Hora_entrada is a variable that saves the clock in
        /// </summary>
        public DateTime Hora_entrada { get; set; }
        /// <summary>
        /// Hora_saida is a variable that saves the clock out
        /// </summary>
        public DateTime Hora_saida { get; set; }
        /// <summary>
        /// Lugarnumero_lugar is a variable that saves the place number
        /// </summary>
        public int Lugarnumero_lugar { get; set; }
    }
}
