using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KockaPoker.SajatOsztalyok
{
    class Gep : Jatekos
    {
        public Gep(string nev, List<PictureBox> kockakepek) : base (nev, kockakepek)
        {
        }

        public void KepekBeallitasa()
        {
            int i = 0;
            foreach (var k in kockaKepek)
            {
                switch (leosztas.MilyenErtek(i++))
                {
                    case 1:
                        k.Image = Properties.Resources.z1;
                        break;
                    case 2:
                        k.Image = Properties.Resources.z2;
                        break;
                    case 3:
                        k.Image = Properties.Resources.z3;
                        break;
                    case 4:
                        k.Image = Properties.Resources.z4;
                        break;
                    case 5:
                        k.Image = Properties.Resources.z5;
                        break;
                    case 6:
                        k.Image = Properties.Resources.z6;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
