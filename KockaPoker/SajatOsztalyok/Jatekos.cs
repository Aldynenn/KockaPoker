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

        public string Nev
        {
            get { return nev; }
            set { nev = value; }
        }

        protected Leosztas kockak = new Leosztas();

        public Leosztas Kockak
        {
            get { return kockak; }
        }

        public override string ToString()
        {
            return $"{Nev} - {kockak.ToString()}";
        }

        public Jatekos(string nev, List<PictureBox> kockaKepek)
        {
            Nev = nev;
            this.kockaKepek = kockaKepek;
        }

        public void UjLeosztas()
        {
            kockak.UjLeosztas();
        }

        public void KepekBeallitasa()
        {
            int i = 0;
            foreach (var k in kockaKepek)
            {
                switch (kockak.MilyenErtek(i++))
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
                    default:
                        break;
                }
            }
        }
    }
}
