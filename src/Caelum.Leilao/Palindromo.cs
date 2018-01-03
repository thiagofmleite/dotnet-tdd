using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class Palindromo
    {
        public bool EhPalindromo(string frase)
        {
            string fraseFiltrada = frase
                    .ToUpper().Replace(" ", "").Replace("-", "");

            //for (int i = 0; i < fraseFiltrada.Length; i++)
            //{
            //    if (fraseFiltrada[i] != fraseFiltrada[fraseFiltrada.Length - i])
            //    {
            //        return false;
            //    }
            //}

            string reverso = Inverter(fraseFiltrada);
            if (reverso.Equals(fraseFiltrada))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

       private string Inverter(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
