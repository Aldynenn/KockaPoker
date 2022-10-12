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

        private int OsszesMenet { get; set; }

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
                lblKijelzo.Text = "Ember nyert";
                j.Nyert++;
            }
            else if (j.Pont < g.Pont)
            {
                lblKijelzo.Text = "Gép nyert";
                g.Nyert++;
            }
            else
            {
                lblKijelzo.Text = "Döntetlen";
                j.Nyert++;
                g.Nyert++;
            }
            OsszesMenet++;
            EredmenyekKiirasa();
        }

        private void EredmenyekKiirasa()
        {
            lblMenetSzam.Text = $"{OsszesMenet}. menet";
            lblJGyozelem.Text = $"Játékos győzelem: {j.Nyert}";
            lblGGyozelem.Text = $"Gép győzelem:     {g.Nyert}";
        }

        private void VezerlokBeallitasa()
        {
            lblGepErtek.Text = "";
            lblJatekosErtek.Text = "";
            lblMenetSzam.Text = "";
            lblJGyozelem.Text = "Játékos:   0";
            lblGGyozelem.Text = "Gép:       0";
            lblDontetlen.Text = "Döntetlen: 0";
            lblKijelzo.Text = "";
            OsszesMenet = 0;
        }

        private void JatekosokBeallitasa()
        {
            j = new Jatekos("Szerencsés Pista", jatekosKepek);
            g = new Gep("Gép", gepKepek);
            
            //Teszteléshez
            //List<int> kocka = new List<int>() { 2, 2, 3, 3, 4 };
            //j.LeosztasBeallitasa(kocka);

            j.Nyert = 0;
            g.Nyert = 0;

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

        private void btnUjJatek_Click(object sender, EventArgs e)
        {
            JatekosokBeallitasa();
            btnKovetkezoMenet.Enabled = true;
            VezerlokBeallitasa();
        }

        private void btnKovetkezoMenet_Click(object sender, EventArgs e)
        {
            j.UjLeosztas();
            g.UjLeosztas();

            j.KepekBeallitasa();
            g.KepekBeallitasa();

            Kiertekeles();
        }
    }
}