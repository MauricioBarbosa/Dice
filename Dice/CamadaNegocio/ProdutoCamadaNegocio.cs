using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Dice.CamadaNegocio
{
    public class ProdutoCamadaNegocio
    {
        public (bool,string) registrarProduto(Models.Produto p)
        {
            bool ret = true;
            string msg = "OK";
            if(p.NomeProduto.Length < 5)
            {
                ret = false;
                msg = "Erro: O nome do produto está muito pequeno";
            }
            else
            {
                try
                {
                    CamadaAcessoDados.ProdutoDB pdb = 
                        new CamadaAcessoDados.ProdutoDB();
                    pdb.Inserir(p); 
                }catch(Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

            return (ret, msg);
        }

        public List<byte[]> obterFoto(int id)
        {
            try
            {
                CamadaAcessoDados.ProdutoDB PDB = new CamadaAcessoDados.ProdutoDB();
                return PDB.obterFoto(id);
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void inserirImagem(int id, List<byte[]> mls)
        {
            try
            {
                CamadaAcessoDados.ProdutoDB pdb= 
                    new CamadaAcessoDados.ProdutoDB();
                pdb.InserirFoto(id, mls);
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Models.Produto> obterProdutos()
        {
            try
            {
                CamadaAcessoDados.ProdutoDB pdb = new CamadaAcessoDados.ProdutoDB();
                return pdb.obterProdutos();
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Models.Produto> obterProdutos(string pesquisa)
        {
            List<Models.Produto> produtosPesquisados = new List<Models.Produto>();
            if(pesquisa.Length > 3)
            {
                CamadaAcessoDados.ProdutoDB pdb = new CamadaAcessoDados.ProdutoDB();
                produtosPesquisados = pdb.Pesquisar(pesquisa);
            }

            return produtosPesquisados;
        }

        public Models.Produto obterProduto(int id)
        {
            try
            {
                Models.Produto p = new Models.Produto();
                CamadaAcessoDados.ProdutoDB pdb =
                    new CamadaAcessoDados.ProdutoDB();
                p = pdb.obterProduto(id);
                if (p == null)
                    throw new Exception("Produto não encontrado");
                else
                    return p;
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
