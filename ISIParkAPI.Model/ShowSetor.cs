using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ISIParkAPI.Model
{
    public class ShowSetor
    {

        public string setor { get; set; }

        public string normal { get; set; }

        public string eletrico { get; set; }

        public string motorcycle { get; set; }

        public string reduce_mob { get; set; }

        public ShowSetor()
        {
        }

        public ShowSetor(string setor, string normal, string eletrico, string motorcycle, string reduce_mob)
        {
            this.setor = setor;
            this.normal = normal;
            this.eletrico = eletrico;
            this.motorcycle = motorcycle;
            this.reduce_mob = reduce_mob;
        }

        public void addInfo(string descricao, int num)
        {
            if (descricao == "Electric")
            {
                this.eletrico = descricao + ": " + num;
            }
            if (descricao == "MotorCycle")
            {
                this.motorcycle = descricao + ": " + num;
            }
            if (descricao == "Normal")
            {
                this.normal = descricao + ": " + num;
            }
            if (descricao == "R.Mobility")
            {
                this.reduce_mob = descricao + ": " + num;
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
            sb.Append(", ");
            sb.Append(this.motorcycle);
            sb.Append(", ");
            sb.Append(this.reduce_mob);
            sb.Append(")");

            return sb.ToString();
        }
    }
}
