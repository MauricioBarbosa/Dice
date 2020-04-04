using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LP4Project.Controllers
{
    public class CidadeController : Controller
    {
        public IActionResult ObterEstados()
        {
            CamadaNegocio.CidadeCamadaNegocio ccn = new CamadaNegocio.CidadeCamadaNegocio();
            return Json(ccn.carregarEstados());
        }

        public IActionResult ObterCidades(string UF)
        {
            CamadaNegocio.CidadeCamadaNegocio ccn = new CamadaNegocio.CidadeCamadaNegocio();
            return Json(ccn.obterCidades(UF));
        }
    }
}