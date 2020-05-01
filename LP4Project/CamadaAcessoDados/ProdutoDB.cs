using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LP4Project.CamadaAcessoDados
{
    public class ProdutoDB
    {
        MySQLPersistencia _bd = new MySQLPersistencia();
        
        public bool Inserir(Models.Produto produto)
        {
            string sql = "insert into produto(`produto_nome`, `produto_preco`, `produto_descricao`, `produto_fabricante`, `produto_categoria`) values(@prod_nome,@prod_preco,@prod_descricao,@prod_fabricante," +
                "@prod_categoria)";

            var parametros = _bd.GerarParametros();
            parametros.Add("@prod_nome", produto.NomeProduto);
            parametros.Add("@prod_preco", produto.PrecoProduto);
            parametros.Add("@prod_descricao", produto.DescricaoProduto);
            parametros.Add("@prod_fabricante", produto.FabricanteProduto);
            parametros.Add("@prod_categoria", produto.CategoriaProduto);

            int linhas_afetadas = _bd.ExecutarNonQuery(sql, parametros);
            if(linhas_afetadas > 0)
            {
                produto.Id = _bd.UltimoId;
            }
            return linhas_afetadas > 0;
        }

        public List<Models.Produto> Pesquisar(string pesquisa)
        {
            List<Models.Produto> produtos = new List<Models.Produto>();

            string sql = "select * from produto where produto_nome like @nome";

            var parametros = _bd.GerarParametros();
            parametros.Add("@nome", "%" + pesquisa + "%"); 

            DataTable dt = _bd.ExecutarSelect(sql, parametros);
            
            foreach(DataRow r in dt.Rows)
            {
                produtos.Add(mapearProduto(r));
            }
            return produtos;
        }

        public List<Models.Produto> obterProdutos()
        {
            List<Models.Produto> produtos = new List<Models.Produto>();

            string sql = "select * from produto";

            DataTable dt = _bd.ExecutarSelect(sql);

            foreach (DataRow r in dt.Rows)
            {
                produtos.Add(mapearProduto(r));
            }
            return produtos;
        }

        public Models.Produto mapearProduto(DataRow dr)
        {
            Models.Produto prod = new Models.Produto();
            prod.NomeProduto = dr["produto_nome"].ToString();
            prod.DescricaoProduto = dr["produto_descricao"].ToString();
            prod.PrecoProduto = Convert.ToDouble(dr["produto_preco"].ToString());
            prod.FabricanteProduto = dr["produto_fabricante"].ToString();
            return prod;
        }
    }
}
