using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dice.Models
{
    public class Fabricante
    {
        int _id;
        string _fabricanteNome;

        public Fabricante(int id)
        {
            Id = id;
        }

        public Fabricante(int id, string fabricanteNome)
        {
            Id = id;
            FabricanteNome = fabricanteNome;
        }

        public int Id { get => _id; set => _id = value; }
        public string FabricanteNome { get => _fabricanteNome; set => _fabricanteNome = value; }
    }
}
