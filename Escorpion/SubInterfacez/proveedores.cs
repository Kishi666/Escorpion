using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Escorpion.SubInterfacez
{
    public partial class proveedores : Form
    {
        MySqlConnection conexion;

        public proveedores()
        {
            InitializeComponent();
            conexion = new MySqlConnection("Server=192.168.1.5;port=3306;database=pretecsa;uid=usuario_remoto;pwd=pretecsa160698;");
            formapago();
        }
        private void formapago()
        {
            comboTipoPago.Items.Add("Transferencia");
            comboTipoPago.Items.Add("Deposito");
            comboTipoPago.Items.Add("Cheque");
            comboTipoPago.Items.Add("Efectivo");

        }



        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                string query = "INSERT INTO proveedores (nombre_comercial, razon_social, direccion, telefono, correo, tipo_pago) " +
                               "VALUES (@nombre_comercial, @razon_social, @direccion, @telefono, @correo, @tipo_pago)";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@nombre_comercial", txtNombreComercial.Text);
                cmd.Parameters.AddWithValue("@razon_social", txtRazonSocial.Text);
                cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@correo", txtCorreo.Text);
                cmd.Parameters.AddWithValue("@tipo_pago", comboTipoPago.SelectedItem.ToString());

                cmd.ExecuteNonQuery();
                MessageBox.Show("Proveedor registrado con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el proveedor: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            } 
            
        }




    }
}
