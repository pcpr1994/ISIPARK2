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
    /// This class contains all information of Reports
    /// </summary>
    public class Report
    {
        /// <summary>
        /// ID_Report is a variable that saves the id of each Report
        /// </summary>
        public int ID_Report { get; set; }

        /// <summary>
        /// Descricao is a variable that saves the content of each Report
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// UtilizadorID is a variable that saves the number of the user that sends the report
        /// </summary>
        public int UtilizadorID { get; set; }

        /// <summary>
        /// Data is a variable that saves the data when a report is sent
        /// </summary>
        public DateTime Data { get; set; }

        /// <summary>
        /// Imagem is a variable that saves the imagem attached to a report
        /// </summary>
        public string Imagem { get; set; }
    }
}
