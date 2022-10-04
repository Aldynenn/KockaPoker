using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KockaPoker.SajatOsztalyok;

namespace KockaPoker
{
    public partial class Form1 : Form
    {
        List<PictureBox> jatekosKepek = new List<PictureBox>();

        Jatekos j;

        public Form1()
        {
            InitializeComponent();

            jatekosKepek.Add(pbElsoJ1);
            jatekosKepek.Add(pbElsoJ2);
            jatekosKepek.Add(pbElsoJ3);
            jatekosKepek.Add(pbElsoJ4);
            jatekosKepek.Add(pbElsoJ5);

            j = new Jatekos("Szerencsés Pista", jatekosKepek);

            pbElsoJ1.Image = Properties.Resources.k1;
            pbElsoJ2.Image = Properties.Resources.k2;
            pbElsoJ3.Image = Properties.Resources.k3;
            pbElsoJ4.Image = Properties.Resources.k4;
            pbElsoJ5.Image = Properties.Resources.k5;

            pbMadosikJ1.Image = Properties.Resources.z1;
            pbMadosikJ2.Image = Properties.Resources.z2;
            pbMadosikJ3.Image = Properties.Resources.z3;
            pbMadosikJ4.Image = Properties.Resources.z4;
            pbMadosikJ5.Image = Properties.Resources.z5;
        }

        private void btnKilepes_Click(object sender, EventArgs e)
        {
            MessageBox.Show(j.ToString());
            j.UjLeosztas();
            MessageBox.Show(j.ToString());

            Application.Exit();
        }
    }
}