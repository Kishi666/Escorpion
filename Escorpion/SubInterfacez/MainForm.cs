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
    public partial class MainForm : Form
    {
        // Cadena de conexión a la base de datos MySQL
        private string connectionString = "Server=192.168.1.5;port=3306;database=pretecsa;uid=usuario_remoto;pwd=pretecsa160698;";

        public MainForm()
        {
            InitializeComponent();
        }

        // Cargar los productos disponibles en el ComboBox
        private void LoadProducts()
        {
            string query = "SELECT id_material, descripcion FROM almacen";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                comboBoxMaterials.DataSource = dataTable;
                comboBoxMaterials.DisplayMember = "descripcion";
                comboBoxMaterials.ValueMember = "id_material";
            }
        }

        // Método para registrar las salidas
        private void RegisterExit()
        {
            foreach (DataGridViewRow row in dataGridViewProducts.Rows)
            {
                if (row.Cells["Cantidad"].Value != null && row.Cells["Cantidad"].Value.ToString() != "")
                {
                    int idMaterial = Convert.ToInt32(row.Cells["id_material"].Value);
                    int cantidadSalida = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    string descripcion = comboBoxMaterials.SelectedItem.ToString();
                    // Verificar si hay stock suficiente
                    if (CheckStock(idMaterial, cantidadSalida))
                    {
                        // Registrar salida
                        RegisterExitInDatabase(idMaterial, cantidadSalida);

                        // Actualizar stock
                        UpdateStock(idMaterial, cantidadSalida);
                    }
                    else
                    {
                        MessageBox.Show("Artículos insuficientes para el material ID: " + idMaterial);
                    }
                }
            }
        }

        // Verificar si hay suficiente stock
        private bool CheckStock(int idMaterial, int cantidadSalida)
        {
            string query = "SELECT cantidad FROM almacen WHERE id_material = @idMaterial";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idMaterial", idMaterial);
                conn.Open();

                object result = cmd.ExecuteScalar();
                if (result != null && Convert.ToInt32(result) >= cantidadSalida)
                {
                    return true;
                }
            }
            return false;
        }

        // Registrar la salida en la base de datos
        private void RegisterExitInDatabase(int idMaterial, int cantidadSalida)
        {
            string query = "INSERT INTO entradas_salidas (id_material, cantidad, tipo_operacion, fecha) " +
                           "VALUES (@idMaterial,  @cantidadSalida, 'Salida', @fecha)";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idMaterial", idMaterial);
             
                cmd.Parameters.AddWithValue("@cantidadSalida", cantidadSalida);
                cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Actualizar el stock después de la salida
        private void UpdateStock(int idMaterial, int cantidadSalida)
        {
            string query = "UPDATE almacen SET cantidad = cantidad - @cantidadSalida WHERE id_material = @idMaterial";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idMaterial", idMaterial);
                cmd.Parameters.AddWithValue("@cantidadSalida", cantidadSalida);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Evento para cargar los productos al iniciar el formulario
        private void MainForm_Load(object sender, EventArgs e)
        {
            CargarDatos();
            LoadProducts();
            dataGridViewProducts.Columns.Add("id_material", "id_material");
            dataGridViewProducts.Columns.Add("Descripcion", "Descripcion");
            dataGridViewProducts.Columns.Add("Cantidad", "Cantidad");
        }
        private void CargarDatos()
        {
            string connectionString = "Server=192.168.1.5;port=3306;database=pretecsa;uid=usuario_remoto;pwd=pretecsa160698;";
            // Crear la consulta SQL para obtener los datos de la tabla "Usuarios"
            string query = "SELECT* FROM almacen";

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
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Mostrar un mensaje de error si la conexión falla
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }

            }


        }





        // Evento para agregar un artículo al DataGridView
        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            if (comboBoxMaterials.SelectedValue != null && !string.IsNullOrEmpty(txtCantidad.Text))
            {
                int idMaterial = Convert.ToInt32(comboBoxMaterials.SelectedValue);
                string descripcion = comboBoxMaterials.Text;
                int cantidad = Convert.ToInt32(txtCantidad.Text);

                // Verificar si hay suficiente stock antes de agregarlo al DataGridView
                if (CheckStock(idMaterial, cantidad))
                {
                    dataGridViewProducts.Rows.Add(idMaterial, descripcion, cantidad);
                }
                else
                {
                    MessageBox.Show("No hay suficiente stock para el material: " + descripcion);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un material y una cantidad válida.");
            }
        }
        // Evento para registrar las salidas cuando se hace clic en el botón
        private void btnRegistrarsalida_Click_1(object sender, EventArgs e)
        {
            RegisterExit();
            MessageBox.Show("La operación se registró correctamente.");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Cadena de conexión a la base de datos MySQL
            string connectionString = "Server=192.168.1.5;port=3306;database=pretecsa;uid=usuario_remoto;pwd=pretecsa160698;";

            // Consulta SQL con el parámetro de búsqueda
            string query = "SELECT * FROM almacen WHERE descripcion = @descripcion";

            // Crear una conexión MySQL
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Crear el comando SQL
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Agregar el parámetro al comando SQL
                    command.Parameters.AddWithValue("@descripcion", textMaterial.Text);

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
                            dataGridView1.DataSource = dt;
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
    }
}
