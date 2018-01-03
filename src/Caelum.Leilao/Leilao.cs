using System.Collections.Generic;
namespace Caelum.Leilao
{

    public class Leilao
    {

        public string Descricao { get; set; }
        public IList<Lance> Lances { get; set; }

        public Leilao(string descricao)
        {
            this.Descricao = descricao;
            this.Lances = new List<Lance>();
        }

        public void Propoe(Lance lance)
        {
            if (Lances.Count == 0 || podeDarLance(lance.Usuario))
            {
                Lances.Add(lance);
            }
        }

        public void DobraLance(Usuario usuario)
        {
            if (podeDarLance(usuario))
            {
                var ultimo = ultimoLanceDado();
                Propoe(new Lance(usuario, ultimo.Valor * 2));
            }
        }

        public Lance ultimoLanceDado()
        {
            return Lances[Lances.Count - 1];
        }

        private bool podeDarLance(Usuario usuario)
        {
            return (!ultimoLanceDado().Usuario.Equals(usuario) && qtrLancesDo(usuario) < 5);
        }

        private int qtrLancesDo(Usuario usuario)
        {
            int total = 0;
            foreach (var l in Lances)
            {
                if (l.Usuario.Equals(usuario))
                {
                    total++;
                }
            }

            return total;
        }

    }
}