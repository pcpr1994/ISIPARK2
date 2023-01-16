using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ISIParkAPI.Model
{
    public class ShowSetorMoto
    {

        public string setor { get; set; }

        public string normal { get; set; }

        public string motorcycle { get; set; }

        public ShowSetorMoto()
        {
        }

        public ShowSetorMoto(string setor, string normal, string motorcycle)
        {
            this.setor = setor;
            this.normal = normal;
            this.motorcycle = motorcycle;
        }

        public void addInfo(string descricao, int num)
        {
            if (descricao == "MotorCycle")
            {
                this.motorcycle = descricao + ": " + num;
            }
            if (descricao == "Normal")
            {
                this.normal = descricao + ": " + num;
            }
        }

        public string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("sector(");
            sb.Append(this.setor);
            sb.Append(", ");
            sb.Append(this.normal);
            sb.Append(", ");
            sb.Append(this.motorcycle);
            sb.Append(")");

            return sb.ToString();
        }
    }
}

