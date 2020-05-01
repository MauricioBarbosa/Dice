using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LP4Project.Models;

namespace LP4Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

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

        public IActionResult obterProdutos()
        {
            CamadaNegocio.ProdutoCamadaNegocio pcm = new CamadaNegocio.ProdutoCamadaNegocio();
            List<Models.Produto> ps = pcm.obterProdutos();

            var produtosLimpos = new List<object>();

            foreach (Models.Produto p in ps)
            {
                var produtolimpo = new {
                    nome = p.NomeProduto,
                    preco = p.PrecoProduto,
                    descricao = p.DescricaoProduto
                };
                produtosLimpos.Add(produtolimpo);
            }
            return Json(produtosLimpos);
        }
    }
}
