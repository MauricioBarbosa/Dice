using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LP4Project.Models
{
    public class Produto
    {
        private int idProduto;
        private string nomeProduto;
        private double precoProduto;
        private string descricaoProduto;
        private string fabricanteProduto;
        private string categoriaProduto;

        public Produto(string nomeProduto, double precoProduto, string descricaoProduto, string fabricanteProduto, string categoriaProduto)
        {
            this.fabricanteProduto = fabricanteProduto;
            this.categoriaProduto = categoriaProduto;
            this.nomeProduto = nomeProduto;
            this.precoProduto = precoProduto;
            this.descricaoProduto = descricaoProduto;
        }

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
        public string FabricanteProduto { get => fabricanteProduto; set => fabricanteProduto = value; }
        public string CategoriaProduto { get => categoriaProduto; set => categoriaProduto = value; }
    }
}
