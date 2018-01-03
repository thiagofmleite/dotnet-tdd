using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class Avaliador
    {
        private double maiorDeTodos = double.MinValue;
        private double menorDeTodos = double.MaxValue;
        private double valorMedio = double.MinValue;
        private List<Lance> maiores;

        public void Avalia(Leilao leilao)
        {

            if (leilao.Lances.Count.Equals(0))
            {
                throw new Exception("Não é possível avaliar um leilão sem lances");
            }

            double totalLances = 0;

            foreach (var lance in leilao.Lances)
            {
                if (lance.Valor > maiorDeTodos)
                {
                    maiorDeTodos = lance.Valor;
                }
                if (lance.Valor < menorDeTodos)
                {
                    menorDeTodos = lance.Valor;
                }

                totalLances += lance.Valor;
            }

            pegaOsMaioresNo(leilao);

            valorMedio = totalLances / leilao.Lances.Count;
        }

        private void pegaOsMaioresNo(Leilao leilao)
        {
            //maiores = new List<Lance>(leilao.Lances.OrderByDescending(x => x.Valor));
            //maiores = maiores.GetRange(0, maiores.Count > 3 ? 3 : maiores.Count);

            var filtro = leilao.Lances.OrderByDescending(p => p.Valor).Take(3);
            maiores = new List<Lance>(filtro);
        }

        public double MaiorLance
        {
            get { return maiorDeTodos; }
        }

        public double MenorLance
        {
            get { return menorDeTodos; }
        }

        public double MediaDosLances
        {
            get { return valorMedio; }
        }

        public List<Lance> TresMaiores
        {
            get { return maiores; }
        }
    }
}
