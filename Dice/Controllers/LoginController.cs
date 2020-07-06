using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dice.Controllers
{
    [Authorize("CookieAuth")]
    public class LoginController : Controller
    {
        // GET: /<controller>/

        public LoginController(AppSettings appConfig)
        {

        }

        [AllowAnonymous] //Data Notation que permite que acesse o método sem estar autenticado
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Logar([FromBody] Dictionary<string,string> dados)
        {

            //criar cookie....
            string nome = dados["email"];
            string senha = dados["senha"];

            CamadaNegocio.UsuarioCamadaNegocio ucn = 
                new CamadaNegocio.UsuarioCamadaNegocio();

            Models.Usuario usuarioOk = ucn.Validar(nome, senha);

            if (usuarioOk != null)
            {
                // É importante que a Cookie guarde o que eu quiser

                #region Criando cookie de autenticação 

                // informações que coloco para verificar se o usuário está autenticado
                var usuarioClaims = new List<Claim>()
                {
                    new Claim("usuarioId", usuarioOk.Id.ToString()),
                    new Claim("usuarioNome", usuarioOk.Nome),
                    new Claim("usuarioTipo", usuarioOk.Tipo)
                };

                var identificacao = new ClaimsIdentity(usuarioClaims,
                    "Identificação do Usuário");
                var principal = new ClaimsPrincipal(identificacao);

                //gerar a cookie 

                Microsoft.AspNetCore.Authentication
                    .AuthenticationHttpContextExtensions
                    .SignInAsync(HttpContext, principal);

                #endregion 

                // .......

                return Json(new
                {
                    operacao = true,
                    msg = "Feito"
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

        //Destruindo a cookie
        public IActionResult Sair()
        {
            Microsoft.AspNetCore.Authentication
                    .AuthenticationHttpContextExtensions
                    .SignOutAsync(HttpContext);
            return Redirect("/Home/Index");
        }
    }
}
