﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ISIParkAPI.Model
{
    public class ShowSetorNormal
    {

        public string setor { get; set; }

        public string normal { get; set; }

        public string eletrico { get; set; }

        public string motorcycle { get; set; }

        public string reduce_mob { get; set; }

        public ShowSetorNormal()
        {
            this.eletrico = "";
            this.motorcycle = "";
            this.reduce_mob = "";
        }

        public ShowSetorNormal(string setor, string normal)
        {
            this.setor = setor;
            this.normal = normal;
        }

        public void addInfo(string descricao, int num)
        {
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
            sb.Append(")");

            return sb.ToString();
        }
    }
}
