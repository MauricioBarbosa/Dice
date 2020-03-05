using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LP4Project.Models
{
    public class Produto
    {
        private int idProduto;
        private String nomeProduto;
        private double precoProduto;
        private String descricaoProduto;

        public Produto(int idProduto, string nomeProduto, double precoProduto,string descricaoProduto)
        {
            this.idProduto = idProduto;
            this.nomeProduto = nomeProduto;
            this.precoProduto = precoProduto;
            this.DescricaoProduto = descricaoProduto;
        }

        public double PrecoProduto { get => precoProduto; set => precoProduto = value; }
        public string NomeProduto { get => nomeProduto; set => nomeProduto = value; }
        public int IdProduto { get => idProduto; set => idProduto = value; }
        public string DescricaoProduto { get => descricaoProduto; set => descricaoProduto = value; }
    }
}
