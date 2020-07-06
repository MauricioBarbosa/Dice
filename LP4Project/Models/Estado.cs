using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LP4Project.Models
{
    public class Estado
    {
        string __UF;
        string __estadoNome;

        public Estado()
        {
            __UF = "";
            __estadoNome = "";
        }

        public Estado(string UF, string estadoNome)
        {
            __UF = UF;
            __estadoNome = estadoNome;
        }

        public string UF { get => __UF; set => __UF = value; }
        public string EstadoNome { get => __estadoNome; set => __estadoNome = value; }
    }
}
