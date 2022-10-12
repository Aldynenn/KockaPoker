using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KockaPoker.SajatOsztalyok
{
    public class Jatekos
    {
        protected List<PictureBox> kockaKepek = new List<PictureBox>();
        private string nev;
        protected Leosztas leosztas = new Leosztas();

        public string Nev
        {
            get { return nev; }
            set { nev = value; }
        }

        public Leosztas Kockak
        {
            get { return leosztas; }
        }

        public Jatekos(string nev, List<PictureBox> kockaKepek)
        {
            Nev = nev;
            this.kockaKepek = kockaKepek;
        }

        public void UjLeosztas()
        {
            leosztas.UjLeosztas();
        }

        public void KepekBeallitasa()
        {
            int i = 0;
            foreach (var k in kockaKepek)
            {
                switch (leosztas.MilyenErtek(i++))
                {
                    case 1:
                        k.Image = Properties.Resources.k1;
                        break;
                    case 2:
                        k.Image = Properties.Resources.k2;
                        break;
                    case 3:
                        k.Image = Properties.Resources.k3;
                        break;
                    case 4:
                        k.Image = Properties.Resources.k4;
                        break;
                    case 5:
                        k.Image = Properties.Resources.k5;
                        break;
                    case 6:
                        k.Image = Properties.Resources.k6;
                        break;
                    default:
                        break;
                }
            }
        }
        public override string ToString()
        {
            return $"{Nev} - {leosztas.ToString()}";
        }

        public void LeosztasBeallitasa(List<int> kockak)
        {
            leosztas.LeosztasBeallitasa(kockak);
        }

        public string LeosztasErteke { 
            get { return leosztas.LeosztasErteke(); } 
        }

        public int Pont
        {
            get { return leosztas.Pont; }
        }
    }
}
