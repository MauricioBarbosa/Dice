using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dice
{
    public class AppSettings
    {
        public string StringConexaoMySql { get; set; }

        public string EmailPadrao { get; set; }

        public string DitTemp { get; set; }

        public int CookieTempoVida { get; set; }

        public AppSettings()
        {

        }
    }
}
