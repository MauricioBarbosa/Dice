using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LP4Project.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LP4Project.Controllers
{
    public class CadastrarProdutoController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody]Dictionary<string,string> data)
        {
            bool operacao = false;
            double preco;
            string msg = "";
            if(!Double.TryParse(data["preco"],out preco)){
                msg = "Preço inválido, digite números com vírgula";
            }
            else
            {
                Produto p = new Produto(data["nome"], Convert.ToDouble(data["preco"]), data["descricao"],
                data["fabricante"], data["categoria"]);

                if (p.NomeProduto!=""&&p.CategoriaProduto!=""&&p.FabricanteProduto!="")
                {
                    CamadaNegocio.ProdutoCamadaNegocio camp = new CamadaNegocio.ProdutoCamadaNegocio();
                    (operacao, msg) = camp.registrarProduto(p);
                }
                else
                {
                    msg = "erro ao cadastrar";
                }
            }

         return Json(new
         {
             operacao,
             msg
         });
        }
    }
}
