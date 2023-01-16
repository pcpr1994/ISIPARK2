using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIParkAPI.Model
{
    public class SetorType
    {
        /// <summary>
        /// ID_Sector is a variable that saves the id of each sector
        /// </summary>
        public string setor { get; set; }

        /// <summary>
        /// Sector is a variable that saves the name of each sector
        /// </summary>
        public string descricao { get; set; }

        /// <summary>
        /// Total_Lugares is a variable that saves the number of places of each sector
        /// </summary>
        public int num { get; set; }
    }
}
