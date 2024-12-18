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

namespace Escorpion.SubInterfacez
{
    public partial class trabajadores : Form
    {
        public trabajadores()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string connectionString = "server=192.168.1.5;port=3306;database=pretecsa;uid=usuario_remoto;pwd=pretecsa160698;";

            string cod = textNum.Text;
            string Nom = textNom.Text;
            string Ar = comboarea.SelectedItem.ToString();



            // Crear la conexión y el comando SQL
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "INSERT INTO empiezas (cod_empleado, nombre, area) VALUES (@cod_empleado, @nombre, @area)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cod_empleado", cod);
                    cmd.Parameters.AddWithValue("@nombre", Nom);
                    cmd.Parameters.AddWithValue("@area", Ar);

                    // Ejecutar la consulta
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Datos guardados correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al guardar los datos.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar a la base de datos: {ex.Message}");
                }
            }










        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LlenarComboBox()
        {
            // Cadena de conexión a tu base de datos MySQL
            string connectionString = "Server=192.168.1.5;port=3306;database=pretecsa;uid=usuario_remoto;pwd=pretecsa160698;";

            // Consulta SQL para obtener los datos que quieres mostrar
            string query = "SELECT*  FROM centros ";  // Cambia 'tu_tabla' por el nombre real de la tabla

            // Crear una conexión a la base de datos
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    conn.Open();

                    // Crear un comando MySQL
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Ejecutar el comando y obtener los datos
                    MySqlDataReader reader = cmd.ExecuteReader();

                    // Limpiar el ComboBox antes de agregar nuevos elementos
                    comboarea.Items.Clear();

                    // Llenar el ComboBox con los datos obtenidos
                    while (reader.Read())
                    {
                        // Agregar al ComboBox el valor que desees, en este caso 'nombre'
                        comboarea.Items.Add(reader["centro"].ToString()); // Puedes agregar más campos si lo necesitas
                    }

                    // Cerrar el lector
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            
           CargarDatos();
        }

        private void CargarDatos()
        {
            string connectionString = "Server=192.168.1.5;port=3306;database=pretecsa;uid=usuario_remoto;pwd=pretecsa160698;";
            // Crear la consulta SQL para obtener los datos de la tabla "Usuarios"
            string query = "SELECT*  FROM empiezas";

            // Crear la conexión a la base de datos MySQL
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    conn.Open();

                    // Crear el comando SQL
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Crear un adaptador de datos para ejecutar la consulta
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);

                    // Crear un DataTable para almacenar los datos
                    DataTable dataTable = new DataTable();

                    // Llenar el DataTable con los datos de la base de datos
                    dataAdapter.Fill(dataTable);

                    // Asignar el DataTable al DataGridView
                    datos.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Mostrar un mensaje de error si la conexión falla
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }

            }


        }


    }
}
