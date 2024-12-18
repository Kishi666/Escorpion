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
    public partial class IngresarUsuario : Form
    {
       

        public IngresarUsuario()
        {
            
            InitializeComponent();
            LlenarComboBox();


        }
        // Método para llenar el ComboBox
        private void LlenarComboBox()
        {
            // Cadena de conexión a tu base de datos MySQL
            string connectionString = "Server=192.168.1.5;port=3306;database=pretecsa;uid=usuario_remoto;pwd=pretecsa160698;";

            // Consulta SQL para obtener los datos que quieres mostrar
            string query = "SELECT*  FROM tipo_usuario";  // Cambia 'tu_tabla' por el nombre real de la tabla

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
                    ComboTipo.Items.Clear();

                    // Llenar el ComboBox con los datos obtenidos
                    while (reader.Read())
                    {
                        // Agregar al ComboBox el valor que desees, en este caso 'nombre'
                        ComboTipo.Items.Add(reader["tipo_usuario"].ToString()); // Puedes agregar más campos si lo necesitas
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



        private void Form1_Load(object sender, EventArgs e)
        {
           








        }






        private void usuariosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.usuariosBindingSource.EndEdit();
            

        }

        private void usuariosBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.usuariosBindingSource.EndEdit();
         

        }

        private void usuariosBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
            this.usuariosBindingSource.EndEdit();
            

        }

        private void IngresarUsuario_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'pretecsaDataSet.Usuarios' Puede moverla o quitarla según sea necesario.
       

        }

        private void BtnRegistar_Click(object sender, EventArgs e)
        {
            string connectionString = "server=192.168.1.5;port=3306;database=pretecsa;uid=usuario_remoto;pwd=pretecsa160698;";

            string username = TxTUsuario.Text;
            string password = TxTContraseña.Text;
            string Tipo = ComboTipo.SelectedItem.ToString();

          

            // Crear la conexión y el comando SQL
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "INSERT INTO usuarios (username, password, tipo_usuario) VALUES (@username, @password, @tipo_usuario)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@tipo_usuario", Tipo);

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

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            

            // Llamamos al método para cargar los datos en el DataGridView
            CargarDatos();



        }
        private void CargarDatos()
        {
            string connectionString = "Server=192.168.1.5;port=3306;database=pretecsa;uid=usuario_remoto;pwd=pretecsa160698;";
            // Crear la consulta SQL para obtener los datos de la tabla "Usuarios"
            string query = "SELECT Id, username, password, tipo_usuario FROM usuarios";

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
                    dataGridViewUsuarios.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Mostrar un mensaje de error si la conexión falla
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }

            }


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            // Obtener los datos de los TextBox
            string nombre = textBoxNombre.Text.Trim();
            string apellido = textBoxApellido.Text.Trim();
            
            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido))
            {
                MessageBox.Show("Por favor ingresa tu nombre y apellido.");
                return;
            }

            // Generar nombre de usuario (puede ser una combinación de nombre y apellido)
            string nombreUsuario = GenerarNombreUsuario(nombre, apellido);

            // Generar contraseña aleatoria
            string contraseña = GenerarContrasena();

            // Mostrar los resultados en los TextBox correspondientes
            TxTUsuario.Text = nombreUsuario;
            TxTContraseña.Text = contraseña;
        }

        // Método para generar el nombre de usuario
        private string GenerarNombreUsuario(string nombre, string apellido )
        {
                  
        
              



            // Crear un nombre de usuario usando las primeras letras del nombre y apellido
            return nombre.Substring(0, 2).ToLower()   + apellido.ToLower();
        }

        // Método para generar una contraseña aleatoria
        private string GenerarContrasena()
        {
            // Definir caracteres permitidos en la contraseña
            const string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=<>?";
            StringBuilder contrasena = new StringBuilder();
            Random random = new Random();

            // Generar una contraseña de 8 caracteres
            for (int i = 0; i < 8; i++)
            {
                int indice = random.Next(caracteres.Length);
                contrasena.Append(caracteres[indice]);
            }

            return contrasena.ToString();
        }
      



    }
}
