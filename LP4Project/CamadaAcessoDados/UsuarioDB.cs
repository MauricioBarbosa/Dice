using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LP4Project.CamadaAcessoDados
{
    public class UsuarioDB
    {
        MySQLPersistencia _bd = new MySQLPersistencia(); 

        public bool Criar(Models.Usuario usuario)
        {
            string insert = @"insert into usuario(usu_login, usu_senha) 
            values(@nome, @senha)";


            var parametros = _bd.GerarParametros();
            parametros.Add("@email", usuario.Email);
            parametros.Add("@senha", usuario.Senha);

            int linhasAfetadas = _bd.ExecutarNonQuery(insert, parametros);
            if(linhasAfetadas > 0)
            {
                usuario.Id = _bd.UltimoId;
            }
            return linhasAfetadas > 0;
        }

        public bool ValidarUsername(string Username)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            parametros.Add("@username",Username);

            string select = @"select count(*) as contas
                            from usuario
                            where usu_login = @username";

            DataTable dt = _bd.ExecutarSelect(select, parametros);

            int conta = Convert.ToInt32(dt.Rows[0]["contas"]);

            return conta == 0;
        }

        public bool Validar(string usuarioNome, string senha)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            parametros.Add("@nome", usuarioNome);
            parametros.Add("@senha", senha);

            string select = @"select count(*) as conta
                            from usuario 
                            where usu_login = @nome and usu_senha = @senha";

            DataTable dt = _bd.ExecutarSelect(select, parametros);

            int conta = Convert.ToInt32(dt.Rows[0]["conta"]);

            return conta > 0;
        }

        public Models.Usuario Obter(int id)
        {
            Models.Usuario user= null;
            string select = @"select * from usuario where usu_id = " +id;
            DataTable dt = _bd.ExecutarSelect(select);

            if(dt.Rows.Count == 1)
            {
                //MAPEAMENTO OBJETO RELACIONAL  || RELACIONAL -> OBJETO
                user = new Models.Usuario();
                user.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                //user.Senha = dt.Rows[0]["senha"];
                user.Nome = dt.Rows[0]["nome"].ToString();
            }

            return user;
        }
        public List<Models.Usuario> Pesquisar(string nome)
        {
            //oo-er
            List<Models.Usuario> usuarios = new List<Models.Usuario>();
            string select = @"select * from usuario where nome like @nome";

            var parametros = _bd.GerarParametros();
            parametros.Add("@nome", "%" + nome + "%");

            DataTable dt = _bd.ExecutarSelect(select);

            foreach(DataRow row in dt.Rows)
            {
                usuarios.Add(Map(dt.Rows[0]));
            }
            
            return usuarios;
        }

        internal Models.Usuario Map(DataRow row)
        {
            Models.Usuario user = new Models.Usuario();                                         
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             
            //Mapear o objeto
            return user;
        }
    }
}
