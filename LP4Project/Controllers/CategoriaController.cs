using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LP4Project.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult ObterCategorias()
        {
            CamadaNegocio.CategoriaCamadaNegocio catNeg = new CamadaNegocio.CategoriaCamadaNegocio();
            return Json(catNeg.obterCategorias());
        }
    }
}