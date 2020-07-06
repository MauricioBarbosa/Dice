using Dice.CamadaAcessoDados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Dice.CamadaAcessoDados
{
    public class CategoriaBD
    {
        MySQLPersistencia _bd = new MySQLPersistencia();
        public static Models.Categoria Map(DataRow row)
        {
            return new Models.Categoria(
                Convert.ToInt32(row["categoria_id"].ToString()),
                row["categoria_nome"].ToString());
        }

        public List<Models.Categoria> pesquisar(string pesquisa)
        {
            List<Models.Categoria> categorias = new List<Models.Categoria>();

            string sql = "select * from categoria " +
                "where categoria_nome like @nome";

            var parametros = _bd.GerarParametros();
            parametros.Add("@nome", "%" + pesquisa + "%");

            DataTable dt = _bd.ExecutarSelect(sql, parametros);

            foreach (DataRow row in dt.Rows)
            {
                categorias.Add(Map(row));
            }

            return categorias;
        }

        public List<Models.Categoria> obter()
        {
            List<Models.Categoria> categorias = new List<Models.Categoria>();

            string sql = "select * from categoria";

            DataTable dt = _bd.ExecutarSelect(sql);

            foreach (DataRow row in dt.Rows)
            {
                categorias.Add(Map(row));
            }

            return categorias;
        }
    }
}
