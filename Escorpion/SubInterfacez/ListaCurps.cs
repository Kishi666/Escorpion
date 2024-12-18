using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Escorpion.SubInterfacez
{
    public partial class ListaCurps : Form
    {
        public ListaCurps()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void ListaCurps_Load(object sender, EventArgs e)
        {

        }
        private void CargarDatos()
        {
            string connectionString = "Server=192.168.1.5;port=3306;database=pretecsa;uid=usuario_remoto;pwd=pretecsa160698;";
            // Crear la consulta SQL para obtener los datos de la tabla "Usuarios"
            string query = "SELECT id_Curp, CURP FROM curp";

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
                    dataGridViewCurp.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Mostrar un mensaje de error si la conexión falla
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }

            }


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            // Cadena de conexión a la base de datos MySQL
            string connectionString = "Server=192.168.1.5;port=3306;database=pretecsa;uid=usuario_remoto;pwd=pretecsa160698;";

            // Consulta SQL con el parámetro de búsqueda
            string query = "SELECT * FROM curp WHERE CURP = @CURP";

            // Crear una conexión MySQL
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Crear el comando SQL
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Agregar el parámetro al comando SQL
                    command.Parameters.AddWithValue("@CURP", textBox1.Text);

                    try
                    {
                        // Abrir la conexión
                        connection.Open();

                        // Crear un adaptador de datos
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            // Crear un DataTable para almacenar los resultados
                            DataTable dt = new DataTable();

                            // Llenar el DataTable con los datos obtenidos de la consulta
                            adapter.Fill(dt);

                            // Mostrar los resultados en el DataGridView
                            dataGridViewCurp.DataSource = dt;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Mostrar el error si hay alguna excepción
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }

            }
            }

        private void dataGridViewCurp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
