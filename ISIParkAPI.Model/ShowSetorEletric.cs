using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ISIParkAPI.Model
{
    public class ShowSetorEletric
    {

        public string setor { get; set; }

        public string normal { get; set; }

        public string eletrico { get; set; }

        public ShowSetorEletric()
        {
        }

        public ShowSetorEletric(string setor, string normal, string eletrico)
        {
            this.setor = setor;
            this.normal = normal;
            this.eletrico = eletrico;
        }

        public void addInfo(string descricao, int num)
        {
            if (descricao == "Electric")
            {
                this.eletrico = descricao + ": " + num;
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
            sb.Append(this.eletrico);
            sb.Append(")");

            return sb.ToString();
        }
    }
}

