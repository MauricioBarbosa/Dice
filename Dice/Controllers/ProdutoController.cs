using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dice.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult obterProduto(int id)
        {
            try
            {
                CamadaNegocio.ProdutoCamadaNegocio pcn = 
                    new CamadaNegocio.ProdutoCamadaNegocio();
                Models.Produto p = pcn.obterProduto(id);
                return Json(new
                {
                    id = p.Id, 
                    nome = p.NomeProduto,
                    preco = p.PrecoAtual, 
                    informacoes = p.DescricaoProduto, 
                    fabricante = p.FabricanteProduto.FabricanteNome
                }); 
            }catch(Exception e)
            {
                return Json(new
                {
                    msg = e.Message
                });
            }
        }

    }
}