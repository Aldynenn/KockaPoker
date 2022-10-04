using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KockaPoker.SajatOsztalyok
{
    class Leosztas
    {
        List<int> kockak = new List<int>();

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
                k.Add(rnd.Next(1, 6));
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
    }
}
