using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LP4Project.CamadaNegocio
{
    public class UsuarioCamadaNegocio
    {
        public (bool,string) Criar(Models.Usuario user)
        {
            string msg = "";
            bool operacao = false;

            if(user.Senha.Length < 8)
            {
                msg = "senha muito pequena";
            }
            else
            {
                CamadaAcessoDados.UsuarioDB ubd = new CamadaAcessoDados.UsuarioDB();
                if (ubd.ValidarUsername(user.Email))
                {
                    ubd.Criar(user);
                    operacao = true;
                    msg = "Cadastrado com sucesso";
                }
                else
                {
                    operacao = false;
                    msg = "não foi possível cadastrar, o e-mail já possui uma conta em uso";
                }
            }
            return (operacao, msg);
        }

        public bool Validar(string UsuarioNome, string senha)
        {
            CamadaAcessoDados.UsuarioDB ubd = new CamadaAcessoDados.UsuarioDB();
            return ubd.Validar(UsuarioNome, senha);
        }

        public Models.Usuario obter(int id)
        {
            CamadaAcessoDados.UsuarioDB ubd = new CamadaAcessoDados.UsuarioDB();
            return ubd.Obter(id);
        }

        public List<Models.Usuario> Pesquisar(string nome)
        {
            CamadaAcessoDados.UsuarioDB ubd = new CamadaAcessoDados.UsuarioDB();

            nome = nome.ToLower();

            return ubd.Pesquisar(nome);
        }

        public bool excluir(int id)
        {
            CamadaAcessoDados.UsuarioDB ubd = new CamadaAcessoDados.UsuarioDB();
            return ubd.excluir(id);
        }

    }
}
