






using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Escorpion.InterfazesPrincipales;
using MySql.Data.MySqlClient;

namespace Escorpion
{
    public partial class Loggin : Form
    {
        // Cadena de conexión a MySQL
        string connectionString = "server=192.168.1.5;port=3306;database=pretecsa;uid=usuario_remoto;pwd=pretecsa160698;";



        public Loggin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            string username = TxTUsuario.Text;
            string password = TxTContraseña.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Lblerror.Text = "Por favor ingrese usuario y contraseña.";
                return;
            }

            // Llamada a la función para validar usuario
            string tipoUsuario = ValidarUsuario(username, password);

            if (!string.IsNullOrEmpty(tipoUsuario))
            {
                Lblerror.Text = $"Bienvenido " + TxTUsuario.Text;

                // Aquí se puede redirigir según el tipo de usuario
                if (tipoUsuario == "admin")
                {
                    MessageBox.Show("Acceso de administrador concedido." + TxTUsuario.Text);
                    // Redirigir a otro formulario o cargar funcionalidades de admin

                    InterfazAdmin adm = new InterfazAdmin();
                    adm.Show();
                    this.Hide();
                }
                else
                {
                    if (tipoUsuario == "nomina")
                    {
                        MessageBox.Show("Acceso a Nomina concedido." + TxTUsuario.Text);
                        // Redirigir a otro formulario o cargar funcionalidades de admin
                    }
                    else
                    {

                        if (tipoUsuario == "almacen")
                        {
                            MessageBox.Show("Acceso a Almacen concedido." + TxTUsuario.Text);
                            // Redirigir a otro formulario o cargar funcionalidades de admin
                        }
                        else
                        {

                            if (tipoUsuario == "produccion")
                            {
                                MessageBox.Show("Acceso a Producción concedido." + TxTUsuario.Text);
                                InterfazProduccion interfazProduccion = new InterfazProduccion();
                                interfazProduccion.Show();
                                this.Hide();


                            }

                            else
                            {
                                if (tipoUsuario == "administracion")
                                {
                                    MessageBox.Show("Acceso a administración concedido." + TxTUsuario.Text);
                                    // Redirigir a otro formulario o cargar funcionalidades de admin
                                }

                                else {

                                    if (tipoUsuario == "RH")
                                    {
                                        MessageBox.Show("Acceso a RH concedido." + TxTUsuario.Text);
                                        // Redirigir a otro formulario o cargar funcionalidades de admin
                                    }
                                }

                            }

                        }

                    }

                }
            }
            else
            {
                Lblerror.Text = "Usuario o contraseña incorrectos.";
            }
        }

        // Función para validar usuario en la base de datos
        private string ValidarUsuario(string username, string password)
        {
            string tipoUsuario = string.Empty;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Consulta SQL para validar usuario y contraseña
                    string query = "SELECT tipo_usuario FROM usuarios WHERE username = @username AND password = @password";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            tipoUsuario = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión a la base de datos: " + ex.Message);
            }

            return tipoUsuario;

        }
    }
}


















