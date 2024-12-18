using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Escorpion.SubInterfacez;

namespace Escorpion.InterfazesPrincipales
{
    public partial class InterfazAdmin : Form
    {
        public InterfazAdmin()
        {
            InitializeComponent();
        }

       

        private void registrarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngresarUsuario ingresar = new IngresarUsuario();
            ingresar.Show();
        }

        private void generarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CodigoBarras cod = new CodigoBarras();
            cod.Show();
        }

        private void registrarMaterialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void registrarPiezaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ingres_píeza ingr = new Ingres_píeza();
            ingr.Show();
        }

        private void listaDeCurpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaCurps liscurps = new ListaCurps();
            liscurps.Show();
        }

        private void rutaDeProduccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Produccion  prodd = new Produccion();


            prodd.Show();
        }

        private void registrarTrabajadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trabajadores trabajadores = new trabajadores();
            trabajadores.Show();
        }

        private void entradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void registrarProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proveedores pro = new proveedores();
            pro.Show();
        }

        private void listaDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarProv buscarProv = new BuscarProv();
            buscarProv.Show();
        }

        private void entradasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            entradas entradas = new entradas();
            entradas.Show();
        }

        private void registarSalidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           MainForm mainForm = new MainForm();  
            mainForm.Show();    
         

        }

        private void listaDeSalidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lista_de_salidas lista_De_Salidas = new Lista_de_salidas();
            lista_De_Salidas.Show();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock stock = new Stock();
            stock.Show();
        }

        private void almacenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
