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
            Produto[] prods=new Produto[12];
            for(int i = 0; i < 12; i++)
            {
                prods[i] = new Produto(i, "Produto", 12.00, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce dictum nulla vitae bibendum ullamcorper");
            }

            ViewBag.Produtos = prods;
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
    }
}
