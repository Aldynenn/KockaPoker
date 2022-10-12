using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KockaPoker.SajatOsztalyok
{
    public class Leosztas
    {
        List<int> kockak = new List<int>();

        public int Pont { get; set; }

        public Leosztas()
        {
            kockak = Keveres();
        }

        private List<int> Keveres()
        {
            List<int> k = new List<int>();
            Random rnd = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < 5; i++)
            {
                k.Add(rnd.Next(1, 7));
            }
            return k;
        }

        public override string ToString()
        {
            StringBuilder temp = new StringBuilder("");
            foreach (var kocka in kockak) temp.Append($"{kocka} ");
            return temp.ToString().Trim();
        }

        public void UjLeosztas()
        {
            kockak = Keveres();
        }

        public int MilyenErtek(int hanyadikKocka)
        {
            return kockak[hanyadikKocka];
        }

        public void LeosztasBeallitasa(List<int> kockak)
        {
            this.kockak = kockak;
        }

        public string LeosztasErteke()
        {
            #region atlathatatlan

            //kockak List
            //kockak.Sort();

            //if (kockak[0] == kockak[1] && kockak[1] == kockak[2] && kockak[2] == kockak[3] && kockak[3] == kockak[4])
            //{
            //    return $"{kockak[0]} Nagy póker";
            //}
            //else if (kockak[0] == 1 && kockak[1] == 2 && kockak[2] == 3 && kockak[3] == 4 && kockak[4] == 5)
            //{
            //    return "Kissor";
            //}
            //else if (kockak[0] == 2 && kockak[1] == 3 && kockak[2] == 4 && kockak[3] == 5 && kockak[4] == 6)
            //{
            //    return "Nagysor";
            //}
            //else if (kockak[0] == kockak[1] && kockak[1] == kockak[2] && kockak[2] == kockak[3] || kockak[1] == kockak[2] && kockak[2] == kockak[3] && kockak[3] == kockak[4])
            //{
            //    return $"{kockak[1]} Póker";
            //}
            //else if (kockak[0] == kockak[1] && kockak[2] == kockak[3] && kockak[3] == kockak[4])
            //{
            //    return $"{kockak[2]} - {kockak[0]} Full";
            //}
            //else if (kockak[0] == kockak[1] && kockak[1] == kockak[2] && kockak[3] == kockak[4])
            //{
            //    return $"{kockak[0]} - {kockak[3]} Full";
            //}
            #endregion

            Dictionary<int, int> stat = Statisztika(kockak);

            string eredmeny = "";

            if (stat.Count == 1)
            {
                int poker = stat.First().Key;
                eredmeny = $"{poker} Nagypóker";
                Pont = 8000 + poker;
            }
            else if (stat.Count == 5)
            {
                eredmeny = KissorNagysorSemmi(stat);
            }
            else if (stat.Count == 2)
            {
                eredmeny = PokerFull(stat);
            }
            else if (stat.Count == 3)
            {
                eredmeny = Drill2Par(stat);
            }
            else
            {
                int par = stat.OrderByDescending(x => x.Value).First().Key;
                eredmeny = $"{par} Pár";
                Pont = par;
            }

            return eredmeny;
        }

        private string Drill2Par(Dictionary<int, int> stat)
        {
            string eredmeny;
            int drill = stat.OrderByDescending(x => x.Value).First().Key;
            if (stat.ContainsValue(3))
            {
                eredmeny = $"{drill} Drill";
                Pont = 100 * drill;
            }
            else
            {
                List<int> parok = new List<int>();
                foreach (var s in stat)
                {
                    if (s.Value == 2) parok.Add(s.Key);
                }
                int max = parok.Max();
                int min = parok.Min();
                eredmeny = $"{max} - {min} pár";
                Pont = 10 * max + min;
            }
            return eredmeny;
        }

        private string PokerFull(Dictionary<int, int> stat)
        {
            string eredmeny;
            int elsoTag = stat.OrderByDescending(x => x.Value).First().Key;
            int masodikTag = stat.OrderBy(x => x.Value).First().Key;
            if (stat.ContainsValue(4))
            {
                eredmeny = $"{elsoTag} Póker";
                Pont = 7000 + elsoTag;
            }
            else
            {
                eredmeny = $"{elsoTag} - {masodikTag} Full";
                Pont = 1000 * elsoTag + masodikTag;
            }
            return eredmeny;
        }

        private string KissorNagysorSemmi(Dictionary<int, int> stat)
        {
            string eredmeny;
            if (!stat.ContainsKey(1))
            {
                eredmeny = $"Nagysor";
                Pont = 7020;
            }
            else if (!stat.ContainsKey(6))
            {
                eredmeny = $"Kissor";
                Pont = 7010;
            }
            else
            {
                eredmeny = $"Semmi";
                Pont = 0;
            }
            return eredmeny;
        }

        private Dictionary<int, int> Statisztika(List<int> kockak)
        {
            Dictionary<int, int> temp = new Dictionary<int, int>();

            foreach (var k in kockak)
            {
                if (temp.ContainsKey(k)) temp[k]++;
                else temp.Add(k, 1);
            }

            return temp;
        }
    }
}