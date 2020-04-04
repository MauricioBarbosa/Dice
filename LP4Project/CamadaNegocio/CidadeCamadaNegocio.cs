using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LP4Project.CamadaNegocio
{
    public class CidadeCamadaNegocio
    {
        public List<Models.Estado> carregarEstados()
        {
            List<Models.Estado> estados = new List<Models.Estado>();
            estados.Add(new Models.Estado("AC", "Acre"));
            estados.Add(new Models.Estado("AL", "Alagoas"));
            estados.Add(new Models.Estado("AP", "Amapá"));
            estados.Add(new Models.Estado("AM", "Amazonas"));
            estados.Add(new Models.Estado("BA", "Bahia"));
            estados.Add(new Models.Estado("CE", "Ceará"));
            estados.Add(new Models.Estado("DF", "Distrito Federal"));
            estados.Add(new Models.Estado("ES", "Espirito Santo"));
            estados.Add(new Models.Estado("GO", "Goiás"));
            estados.Add(new Models.Estado("MA", "Maranhão"));
            estados.Add(new Models.Estado("MT", "Mato Grosso"));
            estados.Add(new Models.Estado("MS", "Mato Grosso Do Sul"));
            estados.Add(new Models.Estado("MG", "Minas Gerais"));
            estados.Add(new Models.Estado("PA", "Pará"));
            estados.Add(new Models.Estado("PB", "Paraíba"));
            estados.Add(new Models.Estado("PE", "Pernambuco"));
            estados.Add(new Models.Estado("PR", "Paraná"));
            estados.Add(new Models.Estado("PI", "Piauí"));


            return estados;
        }

        public List<Models.Cidade> obterCidades(string UF)
        {
            List<Models.Cidade> cidades = new List<Models.Cidade>();
            if (UF == "MS")
            {
                cidades.Add(new Models.Cidade("Dourados",UF));
                cidades.Add(new Models.Cidade("Campo Grande", UF));
                cidades.Add(new Models.Cidade("Corumbá", UF));
            }
            if(UF == "MT")
            {
                cidades.Add(new Models.Cidade("Cuiabá", UF));
                cidades.Add(new Models.Cidade("Rondonópolis", UF));
                cidades.Add(new Models.Cidade("Barra das Garças", UF));
            }

            return cidades;
        }
    }
}
