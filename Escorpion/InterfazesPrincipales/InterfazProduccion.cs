using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Escorpion.SubInterfacez;

namespace Escorpion.InterfazesPrincipales
{
    public partial class InterfazProduccion : Form
    {
        public InterfazProduccion()
        {
            InitializeComponent();
        }

        private void listaDeCurpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rutaDeProduccionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registrarPiezaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listaDeCurpToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ListaCurps liscurps = new ListaCurps();
            liscurps.Show();
        }

        private void rutaDeProduccionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            Produccion prodd = new Produccion();


            prodd.Show();
        }

        private void registrarPiezaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Ingres_píeza ingr = new Ingres_píeza();
            ingr.Show();
        }
    }
}
