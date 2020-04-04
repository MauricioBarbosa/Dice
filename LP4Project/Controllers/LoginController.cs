using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LP4Project.Controllers
{
    public class LoginController : Controller
    {
        // GET: /<controller>/

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logar([FromBody] Dictionary<string,string> dados)
        {
            string nome = dados["email"];
            string senha = dados["senha"];

            CamadaNegocio.UsuarioCamadaNegocio ucn = new CamadaNegocio.UsuarioCamadaNegocio();

            if(ucn.Validar(nome,senha))
            {
                return Json(new
                {
                    operacao = true,
                    msg = "Bem-Vindo!"
                }) ;
            }
            else
            {
                return Json(new
                {
                    operacao = false,
                    msg = "Dados Inválidos"
                });
            }
        }
    }
}
