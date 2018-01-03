using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Caelum.Leilao;


namespace Caelum.Leilao
{
    [TestClass]
    public class AvaliadorTest
    {
        private Avaliador leiloeiro;
        private Usuario joao;
        private Usuario jose;
        private Usuario maria;


        [TestInitialize] // equivalente ao [SetUp] do NUnit
        public void SetUp()
        {
            this.leiloeiro = new Avaliador();

            this.joao = new Usuario("João");
            this.jose = new Usuario("José");
            this.maria = new Usuario("Maria");

        }


        [TestMethod]
        public void DeveEntenderLancesEmOrdemCrescente()
        {

            Leilao leilao = new CriadorDeLeilao()
                .Para("Playstation 3 Novo")
                .Lance(maria, 250.0)
                .Lance(joao, 300.0)
                .Lance(jose, 400.0)
                .Constroi();

            leiloeiro.Avalia(leilao);

            double maiorEsperado = 400;
            double menorEsperado = 250;
            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance);
            Assert.AreEqual(menorEsperado, leiloeiro.MenorLance);

        }

        [TestMethod]
        public void CalculaValorMedio()
        {

            Leilao leilao = new CriadorDeLeilao()
                .Para("Playstation 3 Novo")
                .Lance(maria, 300.0)
                .Lance(joao, 300.0)
                .Lance(jose, 300.0)
                .Constroi();

            leiloeiro.Avalia(leilao);

            double esperado = 300;
            Assert.AreEqual(esperado, leiloeiro.MediaDosLances, 0.0001);
        }

        [TestMethod]
        public void DeveEntenderLeilaoComApenasUmLance()
        {
            Leilao leilao = new CriadorDeLeilao()
                .Para("Playstation 3 Novo")
                .Lance(joao, 1000)
                .Constroi();

            leiloeiro.Avalia(leilao);

            Assert.AreEqual(1000, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(1000, leiloeiro.MenorLance, 0.0001);


        }

        [TestMethod]
        public void DeveEncontrarOsTresMaioresLances()
        {
            Leilao leilao = new CriadorDeLeilao()
                .Para("Playstation 3 Novo")
                .Lance(joao, 100)
                .Lance(maria, 200)
                .Lance(joao, 300)
                .Lance(maria, 400)
                .Constroi();

            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(3, maiores.Count);
            Assert.AreEqual(400, maiores[0].Valor, 0.0001);
            Assert.AreEqual(300, maiores[1].Valor, 0.0001);
            Assert.AreEqual(200, maiores[2].Valor, 0.0001);
        }

        [TestMethod]
        public void LanceDeDuzentos()
        {
            double valorLance = 200;
            Leilao leilao = new CriadorDeLeilao().
                Para("Playstation 3 Novo")
                .Lance(joao, valorLance)
                .Constroi();
            
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(valorLance, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(valorLance, leiloeiro.MenorLance, 0.0001);
        }

        [TestMethod]
        public void LancesRandomicos()
        {
            Leilao leilao = new CriadorDeLeilao()
                .Para("Playstation 3 Novo")
                .Lance(joao, 200)
                .Lance(jose, 450)
                .Lance(joao, 120)
                .Lance(jose, 700)
                .Lance(joao, 630)
                .Lance(jose, 230)
                .Constroi();
            
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(120, leiloeiro.MenorLance, 0.0001);
            Assert.AreEqual(700, leiloeiro.MaiorLance, 0.0001);
        }

        [TestMethod]
        public void LancesDecrescentes()
        {
            Leilao leilao = new CriadorDeLeilao()
                .Para("Playstation 3 Novo")
                .Lance(joao, 400)
                .Lance(jose, 300)
                .Lance(joao, 200)
                .Lance(jose, 100)
                .Constroi();
            
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(100, leiloeiro.MenorLance, 0.0001);
            Assert.AreEqual(400, leiloeiro.MaiorLance, 0.0001);
        }

        [TestMethod]
        public void LeilaoComCincoLances()
        {
            Leilao leilao = new CriadorDeLeilao()
                .Para("Playstation 3 Novo")
                .Lance(joao, 100)
                .Lance(jose, 200)
                .Lance(joao, 300)
                .Lance(jose, 400)
                .Lance(joao, 500)
                .Constroi();
            
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(3, leiloeiro.TresMaiores.Count);
        }

        [TestMethod]
        public void LeilaoComDoisLances()
        {
            Leilao leilao = new CriadorDeLeilao()
                .Para("Playstation 3 Novo")
                .Lance(joao, 100)
                .Lance(jose, 200)
                .Constroi();
            
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(2, leiloeiro.TresMaiores.Count);
        }

        [TestMethod]
        public void LeilaoSemLances()
        {
            Leilao leilao = new Leilao("Playstation 3 Novo");
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(0, leiloeiro.TresMaiores.Count);
        }
        
        [TestMethod]
        [ExpectedException(typeof(Exception), "")]
        public void NaoDeveAvaliarLeiloesSemNenhumLanceDado()
        {
            Leilao leilao = new CriadorDeLeilao()
                .Para("Playstation 3 Novo")
                .Constroi();

            leiloeiro.Avalia(leilao);

            
        }
    }
}
