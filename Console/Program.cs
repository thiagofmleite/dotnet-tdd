using Caelum.Leilao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuPrograma
{
    class Program
    {
        static void Main(string[] args)
        {
            Palindromo palindromo = new Palindromo();

            string pa1 = "Socorram-me subi no onibus em Marrocos";
            string pa2 = "Anotaram a data da maratona";

            Console.WriteLine("{0} | {1}", pa1, palindromo.EhPalindromo(pa1));
            Console.WriteLine("{0} | {1}", pa2, palindromo.EhPalindromo(pa2));

            Console.ReadLine();

        }
    }
}
