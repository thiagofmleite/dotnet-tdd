using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao.Desafio.Tests
{
    [TestClass]
    public class LeilaoTest
    {
        private Avaliador leiloeiro;
        private Usuario jobs;
        private Usuario gates;
        private Usuario woz;

        [TestInitialize] // equivalente ao [SetUp] do NUnit
        public void SetUp()
        {
            this.leiloeiro = new Avaliador();
            this.jobs = new Usuario("Steve Jobs");
            this.woz = new Usuario("Steve Wozniac");
            this.gates = new Usuario("Bill Gates");
        }

        [TestMethod]
        public void DeveReceberUmLance()
        {
            Leilao leilao = new CriadorDeLeilao().
                Para("Macbook Pro 15")
                .Constroi();

            Assert.AreEqual(0, leilao.Lances.Count);

            leilao.Propoe(new Lance(jobs, 2000));

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances.FirstOrDefault().Valor, 0.0001);
        }

        [TestMethod]
        public void DeveReceberVariosLances()
        {
            Leilao leilao = new CriadorDeLeilao()
                .Para("Macbook Pro 15")
                .Lance(jobs, 2000)
                .Lance(woz, 3000)
                .Constroi();

            Assert.AreEqual(2, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances.FirstOrDefault().Valor, 0.0001);
            Assert.AreEqual(3000, leilao.Lances[1].Valor, 0.0001);
        }

        [TestMethod]
        public void NaoDeveAceitarDoisLancesSeguidosDoMesmoUsuario()
        {
            Leilao leilao = new CriadorDeLeilao()
                .Para("Macbook Pro 15")
                .Lance(jobs, 2000)
                .Lance(jobs, 3000)
                .Constroi();

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances.FirstOrDefault().Valor, 0.0001);

        }

        [TestMethod]
        public void NaoDeveAceitarMaisDoQue5LancesDeUmMesmoUsuario()
        {
            Leilao leilao = new CriadorDeLeilao()
                .Para("Macbook Pro 15")
                .Lance(jobs, 2000)
                .Lance(gates, 3000)
                .Lance(jobs, 4000)
                .Lance(gates, 5000)
                .Lance(jobs, 6000)
                .Lance(gates, 7000)
                .Lance(jobs, 8000)
                .Lance(gates, 9000)
                .Lance(jobs, 10000)
                .Lance(gates, 11000)
                .Lance(jobs, 12000) // deve ser ignorado
                .Constroi();

            Assert.AreEqual(10, leilao.Lances.Count);

            var ultimo = leilao.Lances.Count - 1;
            Lance ultimoLance = leilao.Lances[ultimo];
            Assert.AreEqual(11000, ultimoLance.Valor, 0.00001);

        }

        [TestMethod]
        public void DeveDobrarOLance()
        {
            Leilao leilao = new CriadorDeLeilao()
                .Para("Macbook Pro 15")
                .Lance(jobs, 2000)
                .Lance(gates, 3000)
                .Constroi();

            leilao.DobraLance(jobs);

            Assert.AreEqual(6000, leilao.ultimoLanceDado().Valor, 0.00001);
        }
    }
}
