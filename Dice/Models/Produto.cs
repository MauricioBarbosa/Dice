using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dice.Models
{
    public class Produto
    {
        int _id;
        string _nomeProduto;
        double _precoAtual;
        double _precoAnterior;
        string _descricaoProduto;
        double _classificacaoProduto;
        Fabricante _fabricanteProduto;
        Categoria _categoriaProduto;
        byte[] _imagemProduto;
        byte[] _imagemProduto2;

        public Produto() { }

        public Produto(int id, string nomeProduto, string descricaoProduto, 
            Categoria categoriaProduto, Fabricante fabricanteProduto,
            double precoAnterior)
        {
            Id = id;
            NomeProduto = nomeProduto;
            DescricaoProduto = descricaoProduto;
            CategoriaProduto = categoriaProduto;
            FabricanteProduto = fabricanteProduto;
            PrecoAnterior = precoAnterior;
        }

        public int Id { get => _id; set => _id = value; }
        public string NomeProduto { get => _nomeProduto; set => _nomeProduto = value; }
        public string DescricaoProduto { get => _descricaoProduto; set => _descricaoProduto = value; }
        public byte[] ImagemProduto { get => _imagemProduto; set => _imagemProduto = value; }
        public byte[] ImagemProduto2 { get => _imagemProduto2; set => _imagemProduto2 = value; }
        public Categoria CategoriaProduto { get => _categoriaProduto; set => _categoriaProduto = value; }
        public Fabricante FabricanteProduto { get => _fabricanteProduto; set => _fabricanteProduto = value; }
        public double PrecoAnterior { get => _precoAnterior; set => _precoAnterior = value; }
        public double PrecoAtual { get => _precoAtual; set => _precoAtual = value; }
        public double ClassificacaoProduto { get => _classificacaoProduto; set => _classificacaoProduto = value; }
    }
}
