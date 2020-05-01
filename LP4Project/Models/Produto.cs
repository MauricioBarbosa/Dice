using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LP4Project.Models
{
    public class Produto
    {
        int _id;
        string _nomeProduto;
        double _precoProduto;
        string _descricaoProduto;
        string _fabricanteProduto;
        string _categoriaProduto;
        byte[] _imagemProduto;

        public Produto() { }

        public Produto(int id, string nomeProduto, double precoProduto, string descricaoProduto)
        {
            Id = id;
            NomeProduto = nomeProduto;
            PrecoProduto = precoProduto;
            DescricaoProduto = descricaoProduto;
        }

        public Produto(int id, string nomeProduto, double precoProduto, string descricaoProduto, string fabricanteProduto, string categoriaProduto)
        {
            Id = id;
            NomeProduto = nomeProduto;
            PrecoProduto = precoProduto;
            DescricaoProduto = descricaoProduto;
            FabricanteProduto = fabricanteProduto;
            CategoriaProduto = categoriaProduto;
        }

        public Produto(string nomeProduto, double precoProduto, string descricaoProduto, string fabricanteProduto, string categoriaProduto)
        {
            NomeProduto = nomeProduto;
            PrecoProduto = precoProduto;
            DescricaoProduto = descricaoProduto;
            FabricanteProduto = fabricanteProduto;
            CategoriaProduto = categoriaProduto;
        }

        public int Id { get => _id; set => _id = value; }
        public string NomeProduto { get => _nomeProduto; set => _nomeProduto = value; }
        public double PrecoProduto { get => _precoProduto; set => _precoProduto = value; }
        public string DescricaoProduto { get => _descricaoProduto; set => _descricaoProduto = value; }
        public string FabricanteProduto { get => _fabricanteProduto; set => _fabricanteProduto = value; }
        public string CategoriaProduto { get => _categoriaProduto; set => _categoriaProduto = value; }
        public byte[] ImagemProduto { get => _imagemProduto; set => _imagemProduto = value; }
    }
}
