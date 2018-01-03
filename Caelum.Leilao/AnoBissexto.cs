using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public static class AnoBissexto
    {
        public static bool EhBissexto(int ano)
        {
            return (ano % 4 == 0);
        }
    }
}
