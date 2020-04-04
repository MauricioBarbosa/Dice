using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LP4Project.Controllers
{
    public class CadastrarUsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar([FromBody]Dictionary<string, string> dados)
        {
            bool operacao = false;
            string msg = "";

            if(dados["nomeUsuario"] == "" || dados["sobrenomeUsuario"]==""||dados["enderecoUsuario"] == ""||
                dados["CEPUsuario"]==""||dados["telefoneUsuario"]==""||dados["emailUsuario"]==""||dados["senhaUsuario"]==""||
                dados["senhaconfirmacaoUsuario"] == "")
            {
                msg = "Dados inválidos";
            }
            if (dados["senhaUsuario"] != dados["senhaconfirmacaoUsuario"])
            {
                msg = "As senhas não batem";
            }
            else
            {
                Models.Usuario usuario= new Models.Usuario();
                usuario.Nome = dados["nomeUsuario"] + " " +dados["sobrenomeUsuario"];
                usuario.Cpf = dados["CPFUsuario"];
                usuario.Endereco = dados["telefoneUsuario"];
                usuario.Cep = dados["CEPUsuario"];
                usuario.Telefone = dados["telefoneUsuario"];
                usuario.Observacao = dados["observacaoUsuario"];
                usuario.Email = dados["emailUsuario"];
                usuario.Senha = dados["senhaUsuario"];

                CamadaNegocio.UsuarioCamadaNegocio
                    ucn = new CamadaNegocio.UsuarioCamadaNegocio();
                (operacao, msg) = ucn.Criar(usuario);
            }

            return Json(new
            {
                operacao,
                msg
            });
        }
        //Index para listar usuários
        public IActionResult IndexListar()
        {

            return View();
        }

        public IActionResult Pesquisar(string nome)
        {
            // Chamar neg. 
            // chamar bd 


            return null;
        }
    }
}