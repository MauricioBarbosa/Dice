using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dice.Models
{
    public class Categoria
    {
        int _id;
        string _categoriaNome;

        public Categoria(int id)
        {
            Id = id;
        }

        public Categoria(int id, string categoriaNome)
        {
            Id = id;
            CategoriaNome = categoriaNome;
        }

        public int Id { get => _id; set => _id = value; }
        public string CategoriaNome { get => _categoriaNome; set => _categoriaNome = value; }
    }
}
