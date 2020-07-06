using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LP4Project.CamadaNegocio
{
    public class ProdutoCamadaNegocio
    {
        public (bool,string) registrarProduto(Models.Produto p)
        {
            bool ret=false;
            string msgRet="";
            if (p.NomeProduto.Length > 3)
            {
                if (p.FabricanteProduto.Length > 3)
                {
                    CamadaAcessoDados.ProdutoDB pdb = new CamadaAcessoDados.ProdutoDB();
                    ret = pdb.Inserir(p);
                    msgRet = ret == true ? "Inserido!" : "Erro ao cadastrar produto";
                }
                else
                {
                    ret = false;
                    msgRet = "Nome do fornecedor muito pequeno!";
                }
            }
            msgRet = "Nome do produto muito pequeno";
            return (ret, msgRet);
        }

        public List<Models.Produto> obterProdutos()
        {
            CamadaAcessoDados.ProdutoDB pdb = new CamadaAcessoDados.ProdutoDB();
            return pdb.obterProdutos();
        }
    }
}
