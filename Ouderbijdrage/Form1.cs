using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ouderbijdrage
{
    public partial class Form1 : Form
    {
        //
        // Vars
        //
        double jonger = 0;
        double ouder = 0;
        byte aantalKinderen;
        byte opgeslagenKinderen;
        bool eenOuderGezin;

        public Form1()
        {
            InitializeComponent();
        }
        //
        //Methodes
        //
        private void Bereken()
        {
            double uit = 50;
            if ((DateTime.Now.Year - dateTimePicker1.Value.Year) >= 10) { ouder += 1; }
            else { jonger += 1; }
            opgeslagenKinderen += 1;
            if (opgeslagenKinderen >= aantalKinderen)
            {
                if(jonger > 3) { uit += 75; }
                else { uit += (jonger * 25); }

                if (ouder > 2) { uit += 62; }
                else { uit += (ouder * 37); }

                if (uit >= 150) uit = 150;

                if (eenOuderGezin) uit = (uit / 100) * 75;
                lblOut.Text = "Te betalen Ouder bijdrage: €" + uit.ToString();
                jonger = 0;
                ouder = 0;
                aantalKinderen = 0;
                opgeslagenKinderen = 0;
                eenOuderGezin = false;
            }
        }

        //
        //Events
        //

        private void btnpnlOk_Click(object sender, EventArgs e)
        {
            Bereken();
            lblID.Text = "Kind " + (opgeslagenKinderen + 1).ToString();
            dateTimePicker1.Value = DateTime.Now;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            aantalKinderen = byte.Parse(txbaantalKinderen.Text);
            panel1.Visible = true;
            eenOuderGezin = checkBox1.Checked;
        }
    }
}
