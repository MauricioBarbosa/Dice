using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dice.Models;
using Microsoft.AspNetCore.Authorization;

namespace Dice.Controllers
{
    [Authorize("CookieAuth")]
    public class HomeController : Controller
    {
        public HomeController(AppSettings appConfig)
        {
            //obtendo a injeção de dependência
            //appConfig.EmailPadrao; 

        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult obterProdutosPesquisados(string pesquisa)
        {
            CamadaNegocio.ProdutoCamadaNegocio pcm = new CamadaNegocio.ProdutoCamadaNegocio();
            List<Models.Produto> ps = pcm.obterProdutos(pesquisa);

            var produtosLimpos = new List<object>();

            foreach (Models.Produto p in ps)
            {
                var produtolimpo = new {
                    nome = p.NomeProduto,
                    preco = p.PrecoAtual,
                    descricao = p.DescricaoProduto
                };
                produtosLimpos.Add(produtolimpo);
            }
            return Json(produtosLimpos);
        }

        public IActionResult obterProdutos()
        {
            CamadaNegocio.ProdutoCamadaNegocio pcm = new CamadaNegocio.ProdutoCamadaNegocio();
            List<Models.Produto> ps = pcm.obterProdutos();

            var produtosLimpos = new List<object>();

            foreach (Models.Produto p in ps)
            {
                var produtolimpo = new
                {
                    nome = p.NomeProduto,
                    preco = p.PrecoAtual,
                    descricao = p.DescricaoProduto
                };
                produtosLimpos.Add(produtolimpo);
            }
            return Json(produtosLimpos);
        }
    }
}
