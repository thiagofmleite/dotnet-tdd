using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Caelum.Leilao;

namespace Caelum.Leilao.Desafio.Tests
{
    [TestClass]
    public class DesafioTest
    {
        [TestMethod]
        public void ValidaPalindromo()
        {
            Palindromo palindromo = new Palindromo();

            string pa1 = "Socorram-me subi no onibus em Marrocos";

            Assert.AreEqual(true, palindromo.EhPalindromo(pa1));
        }

        [TestMethod]
        public void NumeroMaiorQue30MultiplicaPor4()
        {
            var matematica = new MatematicaMaluca();
            int n = 40;
            int conta = matematica.ContaMaluca(n);

            Assert.AreEqual((n*4), conta);

        }

        [TestMethod]
        public void NumeroMaiorQue10MenorQuer30MultiplicaPor3()
        {
            var matematica = new MatematicaMaluca();
            int n = 11;
            int conta = matematica.ContaMaluca(n);

            Assert.AreEqual((n*3), conta);

        }

        [TestMethod]
        public void NumeroMenorQue10MultiplicaPor2()
        {
            var matematica = new MatematicaMaluca();

            int n = 9;

            int conta = matematica.ContaMaluca(n);

            Assert.AreEqual((n*2), conta);

        }

        [TestMethod]
        public void DeveSerAnoBissexto()
        {
            int ano = 2016;

            Assert.AreEqual(true, AnoBissexto.EhBissexto(ano));
        }

        [TestMethod]
        public void NaoDeveSerAnoBissexto()
        {
            int ano = 2015;

            Assert.AreEqual(false, AnoBissexto.EhBissexto(ano));
        }
    }
}
