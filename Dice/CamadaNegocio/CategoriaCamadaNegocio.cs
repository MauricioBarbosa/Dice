using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dice.CamadaNegocio
{
    public class CategoriaCamadaNegocio
    {
        public List<Models.Categoria> obterCategorias(string pesquisa)
        {
            CamadaAcessoDados.CategoriaBD cdb = new CamadaAcessoDados.CategoriaBD();
            try
            {
                if (pesquisa == null || pesquisa == "")
                    return cdb.obter();
                return cdb.pesquisar(pesquisa);
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
