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
        List<PictureBox> gepKepek = new List<PictureBox>();

        Jatekos j;
        Gep g;

        public Form1()
        {
            InitializeComponent();

            PictureBoxokBeallitasa();
            //JatekosokBeallitasa();

            VezerlokBeallitasa();
            //Kiertekeles();
        }

        private void Kiertekeles()
        {
            lblJatekosErtek.Text = $"1. játékos: {j.LeosztasErteke}";
            lblGepErtek.Text = $"2. játékos: {g.LeosztasErteke}";
            if (j.Pont > g.Pont)
            {
                MessageBox.Show("Ember nyert");
            }
            else if (j.Pont < g.Pont)
            {
                MessageBox.Show("Gép nyert");
            }
            else
            {
                MessageBox.Show("Döntetlen");
            }
        }

        private void VezerlokBeallitasa()
        {
            lblGepErtek.Text = "";
            lblJatekosErtek.Text = "";
            lblMenetSzam.Text = "";
            lblJGyozelem.Text = "Játékos: 0";
            lblGGyozelem.Text = "Gép:     0";
        }

        private void JatekosokBeallitasa()
        {
            //List<int> kocka = new List<int>() { 2, 2, 3, 3, 4 };
            j = new Jatekos("Szerencsés Pista", jatekosKepek);
            //j.LeosztasBeallitasa(kocka);
            g = new Gep("Gép", gepKepek);
            j.KepekBeallitasa();
            g.KepekBeallitasa();
        }

        private void PictureBoxokBeallitasa()
        {
            jatekosKepek.Add(pbElsoJ1);
            jatekosKepek.Add(pbElsoJ2);
            jatekosKepek.Add(pbElsoJ3);
            jatekosKepek.Add(pbElsoJ4);
            jatekosKepek.Add(pbElsoJ5);

            gepKepek.Add(pbMadosikJ1);
            gepKepek.Add(pbMadosikJ2);
            gepKepek.Add(pbMadosikJ3);
            gepKepek.Add(pbMadosikJ4);
            gepKepek.Add(pbMadosikJ5);
        }

        private void btnKilepes_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}