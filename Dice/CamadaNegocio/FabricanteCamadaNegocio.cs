using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dice.CamadaNegocio
{
    public class FabricanteCamadaNegocio
    {

        public List<Models.Fabricante> obterFabricantes(string args)
        {
            CamadaAcessoDados.FabricanteDB fdb =
                new CamadaAcessoDados.FabricanteDB();
            try
            {
                if (args==null||args == "" || args.Length < 1)
                    return fdb.obterTodos();
                return fdb.pesquisar(args);
            }catch(Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}
