using Dice.CamadaAcessoDados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Dice.CamadaAcessoDados
{
    public class FabricanteDB
    {
        MySQLPersistencia _bd = new MySQLPersistencia();

        public static Models.Fabricante Map(DataRow row)
        {
           return new Models.Fabricante(Convert.ToInt32(row["fabricante_id"]),
                row["nome_fabricante"].ToString());
        }

        public List<Models.Fabricante> pesquisar(string pesquisa)
        {
            List<Models.Fabricante> fabricantes = new List<Models.Fabricante>();

            string sql = "select * from fabricante " +
                "where nome_fabricante like @nome";

            var parametros = _bd.GerarParametros();
            parametros.Add("@nome","%" + pesquisa + "%");

            DataTable dt = _bd.ExecutarSelect(sql, parametros);

            foreach(DataRow row in dt.Rows)
            {
                fabricantes.Add(Map(row));
            }

            return fabricantes;
        }

        public List<Models.Fabricante> obterTodos()
        {
            List<Models.Fabricante> fabricantes = new List<Models.Fabricante>();

            string sql = "select * from fabricante";

            DataTable dt = _bd.ExecutarSelect(sql);

            foreach (DataRow row in dt.Rows)
            {
                fabricantes.Add(Map(row));
            }

            return fabricantes;
        }
    }
}
