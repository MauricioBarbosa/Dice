using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LP4Project.CamadaNegocio
{
    public class CategoriaCamadaNegocio
    {
        public List<string> obterCategorias()
        {
            List<string> categorias = new List<string>();

            categorias.Add("Action Figure");
            categorias.Add("Gunpla");
            categorias.Add("Boneco De Pelúcia");
            categorias.Add("Heróis");

            return categorias;
        }
    }
}
