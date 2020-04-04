using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LP4Project.Models
{
    public class Cidade
    {
        string __cidadeNome;
        string __cidadeUF;

        public Cidade()
        {
            CidadeNome = "";
            CidadeUF = "";
        }

        public Cidade(string cidadeNome,string cidadeUF)
        {
            CidadeNome = cidadeNome;
            CidadeUF = cidadeUF;
        }

        public string CidadeNome { get => __cidadeNome; set => __cidadeNome = value; }
        public string CidadeUF { get => __cidadeUF; set => __cidadeUF = value; }
    }
}
