using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao.Desafio.Tests
{
    [TestClass]
    public class LanceTest
    {
        private Avaliador leiloeiro;
        private Usuario joao;

        [TestInitialize] // equivalente ao [SetUp] do NUnit
        public void SetUp()
        {
            this.leiloeiro = new Avaliador();

            this.joao = new Usuario("João");

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NaoPodeLanceMenorOuIgualZero()
        {
            Leilao leiao = new CriadorDeLeilao()
                .Para("Playstatin 4 Pro")
                .Lance(joao, 0)
                .Constroi();
        }
    }
}
