using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Dice.CamadaAcessoDados
{
    public class ProdutoDB
    {
        MySQLPersistencia _bd = new MySQLPersistencia();
        
        public bool Inserir(Models.Produto produto)
        {
            string sql = "INSERT INTO `lp4project`.`produto` (`produto_nome`, `produto_precoatual`, `produto_informacoes`," +
                " `categoria_Id`, `fornecedor_Id`, `produto_precoanterior`,`produto_classificacao`)" +
                " VALUES (@prod_nome, @prod_precoAtual, @prod_informacoes, @categoriaId," +
                " @fornecedorId, @prod_precoAnterior, @prod_classificacao);";

            var parametros = _bd.GerarParametros();
            parametros.Add("@prod_nome", produto.NomeProduto);
            parametros.Add("@prod_precoAtual", produto.PrecoAtual);
            parametros.Add("@prod_informacoes", produto.DescricaoProduto);
            parametros.Add("@categoriaId", produto.CategoriaProduto.Id);
            parametros.Add("@fornecedorId", produto.FabricanteProduto.Id);
            parametros.Add("@prod_precoAnterior", produto.PrecoAnterior);
            parametros.Add("@prod_classificacao", produto.ClassificacaoProduto);

            int linhas_afetadas = _bd.ExecutarNonQuery(sql, parametros);
            if(linhas_afetadas > 0)
            {
                produto.Id = _bd.UltimoId;
            }
            return linhas_afetadas > 0;
        }

        public List<byte[]> obterFoto(int id)
        {
            List<byte[]> ret = new List<byte[]>();
            string sql = "select produto_imagem1 from imagem_produto " +
                "where produto_Id = "+id;

            object fotodb = _bd.ExecutarEscalar(sql);
            if (fotodb != DBNull.Value)
            {
                ret.Add((byte[])fotodb);
            }

            sql = "select produto_imagem2 from imagem_produto "+
            "where produto_Id = " + id;

            fotodb = _bd.ExecutarEscalar(sql);
            if (fotodb != DBNull.Value)
            {
                ret.Add((byte[])fotodb);
            }

            return ret;
        }

        public bool InserirFoto(int id, List<byte[]> fotos)
        {
            string sql = "insert into `lp4project`.`imagem_produto`(`produto_imagem1`," +
                "`produto_imagem2`,`produto_Id`) values " +
                "(@imagem1,@imagem2,@produto_id)";

            var parametros = _bd.GerarParametros();
            parametros.Add("@produto_id", id);

            var parametrosBinarios = _bd.gerarParametrosBinarios();
            parametrosBinarios.Add("@imagem1", fotos[0]);
            parametrosBinarios.Add("@imagem2", fotos[1]);

            int linhasAfetadas = _bd.ExecutarNonQuery(sql, parametros,
                parametrosBinarios);

            return linhasAfetadas > 0;
        }

        public List<Models.Produto> Pesquisar(string pesquisa)
        {
            List<Models.Produto> produtos = new List<Models.Produto>();

            string sql = "select * from produto where produto_nome like @nome";

            var parametros = _bd.GerarParametros();
            parametros.Add("@nome", "'%" + pesquisa + "%'"); 

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

            string sql = "select categoria.*, fabricante.*, produto.* "+
"from produto "+
"inner join categoria on categoria.categoria_id = produto.categoria_Id "+
"inner join fabricante on fabricante.fabricante_id = produto.fornecedor_Id;";

            DataTable dt = _bd.ExecutarSelect(sql);

            foreach (DataRow r in dt.Rows)
            {
                produtos.Add(mapearProduto(r));
            }
            return produtos;
        }

        public List<Models.Produto> obterProdutos10()
        {
            List<Models.Produto> produtos = new List<Models.Produto>();

            string sql = "select categoria.*, fabricante.*, produto.* " +
"from produto " +
"inner join categoria on categoria.categoria_id = produto.categoria_Id " +
"inner join fabricante on fabricante.fabricante_id = produto.fornecedor_Id " +
"limit 10;";

            DataTable dt = _bd.ExecutarSelect(sql);

            foreach (DataRow r in dt.Rows)
            {
                produtos.Add(mapearProduto(r));
            }
            return produtos;
        }

        public Models.Produto obterProduto(int id)
        {
            Models.Produto produto = null;

            string sql = "select produto.*,fabricante.*, categoria.* from produto " +
"inner join fabricante on fabricante.fabricante_id = produto.fornecedor_Id" +
" inner join categoria on categoria.categoria_id = produto.categoria_Id" +
" where id = @id; ";

            var parametros = _bd.GerarParametros();

            parametros.Add("@id", id);

            DataTable dt = _bd.ExecutarSelect(sql, parametros);

            if(dt.Rows.Count > 0){
                produto = mapearProduto(dt.Rows[0]);
            }

            return produto;
        }

        public Models.Produto mapearProduto(DataRow row)
        {
            Models.Produto prod = new Models.Produto();
            prod.Id = Convert.ToInt32(row["Id"]);
            prod.NomeProduto = row["produto_nome"].ToString();
            prod.PrecoAtual = Convert.ToDouble(row["produto_precoatual"]);
            prod.DescricaoProduto = row["produto_informacoes"].ToString();
            prod.PrecoAnterior = Convert.ToDouble(row["produto_precoanterior"]);
            prod.ClassificacaoProduto = Convert.ToDouble(row["produto_classificacao"]);

            prod.FabricanteProduto = FabricanteDB.Map(row);
            prod.CategoriaProduto = CategoriaBD.Map(row);

            return prod;
        }
    }
}
