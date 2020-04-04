using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LP4Project.Models
{
    public class Usuario
    {
        int _id;
        string _nome;
        string _senha;
        string _email;
        string _endereco;
        string _cep;
        string _telefone;
        string _cpf;
        string _observacao;

        public Usuario()
        {
            _id = 0;
            _nome = "";
            _senha = "";
            _email = "";
            _endereco = "";
            Cep = "";
            _cpf = "";
            Observacao = "";
        }

        public Usuario(int id,string nome,string senha,string email, string endereco,string cep,string telefone,string cpf,string observacao)
        {
            _id = 0;
            _nome = nome;
            _senha = senha;
            _email = email;
            _endereco = endereco;
            _cep = cep;
            _telefone = telefone;
            _cpf = cpf;
            Observacao = observacao;
        }

        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Senha { get => _senha; set => _senha = value; }
        public string Email { get => _email; set => _email = value; }
        public string Endereco { get => _endereco; set => _endereco = value; }
        public string Cep { get => _cep; set => _cep = value; }
        public string Telefone { get => _telefone; set => _telefone = value; }
        public string Cpf { get => _cpf; set => _cpf = value; }
        public string Observacao { get => _observacao; set => _observacao = value; }
    }
}
