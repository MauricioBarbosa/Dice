using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dice.Controllers
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
            CamadaNegocio.UsuarioCamadaNegocio ucn = new CamadaNegocio.UsuarioCamadaNegocio();
            List<Models.Usuario> usuarios = ucn.Pesquisar(nome);

            var usuariosLimpos = new List<object>(); 

            foreach(var u in usuarios)
            {
                var usuarioLimpo = new
                {
                    id = u.Id,
                    nome = u.Nome
                };
                usuariosLimpos.Add(usuarioLimpo);
            }
            return Json(usuariosLimpos);
        }

        [HttpDelete]
        public IActionResult Excluir(int id)
        {
            CamadaNegocio.UsuarioCamadaNegocio ucn = new CamadaNegocio.UsuarioCamadaNegocio();
            bool operacao = ucn.excluir(id);
            return Json(new
            {
                operacao
            });
        }
    }
}