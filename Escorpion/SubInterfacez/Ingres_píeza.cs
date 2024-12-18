using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Escorpion.SubInterfacez
{
    public partial class Ingres_píeza : Form
    {
        public Ingres_píeza()
        {
            InitializeComponent();
            Bloquearcajas();
            LlenarComboBoxalm();
            LlenarComboBoxcentro();
            LlenarComboBoxtrab();
            LlenarComboBoxuni();
            LlenarCombomat();
            llenarComboTrabajo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los controles
            string curp = textCurp.Text;
            string cantidad = textCantidad.Text;
            string peso = textPeso.Text;
            string material = comboMaterial.SelectedItem.ToString();
            string unidad = comboUnidad.SelectedItem.ToString();
            string centro = comboCentro.SelectedItem.ToString();
            string almacen = comboAlmacen.SelectedItem.ToString();            
            // Convertir las fechas a tipo DATETIME
            DateTime fecha = dtpFecha.Value;
            DateTime hora = dtpHora.Value;

            string trabajador = comboTrabajador.SelectedItem.ToString();
            string trabajo = comboTrabajo.SelectedItem.ToString();
            string descr = textDescripcion.Text;
            // Cadena de conexión a MySQL
            string connectionString = "Server=192.168.1.5;port=3306;database=pretecsa;uid=usuario_remoto;pwd=pretecsa160698;";

            // Consulta SQL para insertar los datos
            string query = "INSERT INTO piezas (curp, cantidad, peso, material, unidad, centro, almacen, fecha, hora, trabajador,TipoTrabajo, descripcion ) " +
                           "VALUES (@curp, @cantidad, @peso, @material, @unidad, @centro, @almacen, @fecha, @hora, @trabajador, @TipoTrabajo, @descripcion)";

            // Crear la conexión y el comando
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);

                // Definir los parámetros para evitar inyección SQL
                command.Parameters.AddWithValue("@curp", curp);
                command.Parameters.AddWithValue("@cantidad", cantidad);
                command.Parameters.AddWithValue("@peso", peso);
                command.Parameters.AddWithValue("@material", material);
                command.Parameters.AddWithValue("@unidad", unidad);
                command.Parameters.AddWithValue("@centro", centro);
                command.Parameters.AddWithValue("@almacen", almacen);
                command.Parameters.AddWithValue("@fecha", fecha);
                command.Parameters.AddWithValue("@hora", hora);
                command.Parameters.AddWithValue("@trabajador", trabajador);
                command.Parameters.AddWithValue("@Tipotrabajo", trabajo);
                command.Parameters.AddWithValue("@descripcion", descr);

                // Abrir la conexión y ejecutar el comando
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery(); // Ejecutar la inserción
                    MessageBox.Show("Datos insertados correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar datos: " + ex.Message);
                }
            }
            Bloquearcajas();

        }

        private void Ingres_píeza_Load(object sender, EventArgs e)
        {
        }

        private void llenarComboTrabajo()
        {

            //llenar el combotrabajo
            comboTrabajo.Items.Add("trabajo");
            comboTrabajo.Items.Add("Retrabajo");

        }
            

        private void LlenarComboBoxuni()
        {
            // Cadena de conexión a tu base de datos MySQL
            string connectionString = "server=192.168.1.5;port=3306;database=pretecsa;uid=usuario_remoto;pwd=pretecsa160698;";

            // Consulta SQL para obtener los datos que quieres mostrar
            string query = "SELECT*  FROM unidad";  // Cambia 'tu_tabla' por el nombre real de la tabla

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
                    comboUnidad.Items.Clear();

                    // Llenar el ComboBox con los datos obtenidos
                    while (reader.Read())
                    {
                        // Agregar al ComboBox el valor que desees, en este caso 'nombre'
                        comboUnidad.Items.Add(reader["unidad"].ToString()); // Puedes agregar más campos si lo necesitas
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



        //-----------------------------------------------------------//
        private void LlenarComboBoxcentro()
        {
            // Cadena de conexión a tu base de datos MySQL
            string connectionString = "server=192.168.1.5;port=3306;database=pretecsa;uid=usuario_remoto;pwd=pretecsa160698;";

            // Consulta SQL para obtener los datos que quieres mostrar
            string query = "SELECT*  FROM centros";  // Cambia 'tu_tabla' por el nombre real de la tabla

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
                    comboCentro.Items.Clear();

                    // Llenar el ComboBox con los datos obtenidos
                    while (reader.Read())
                    {
                        // Agregar al ComboBox el valor que desees, en este caso 'nombre'
                        comboCentro.Items.Add(reader["centro"].ToString()); // Puedes agregar más campos si lo necesitas
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
        //------------------------------------------------------------------------------------------------------------------------
        private void LlenarComboBoxalm()
        {
            // Cadena de conexión a tu base de datos MySQL
            string connectionString = "server=192.168.1.5;port=3306;database=pretecsa;uid=usuario_remoto;pwd=pretecsa160698;";

            // Consulta SQL para obtener los datos que quieres mostrar
            string query = "SELECT*  FROM almacenes";  // Cambia 'tu_tabla' por el nombre real de la tabla

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
                    comboAlmacen.Items.Clear();

                    // Llenar el ComboBox con los datos obtenidos
                    while (reader.Read())
                    {
                        // Agregar al ComboBox el valor que desees, en este caso 'nombre'
                        comboAlmacen.Items.Add(reader["almacenes"].ToString()); // Puedes agregar más campos si lo necesitas
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
        //------------------------------------------------------------------------------------------------------------------------
        private void LlenarComboBoxtrab()
        {
            // Cadena de conexión a tu base de datos MySQL
            string connectionString = "server=192.168.1.5;port=3306;database=pretecsa;uid=usuario_remoto;pwd=pretecsa160698;";

            // Consulta SQL para obtener los datos que quieres mostrar
            string query = "SELECT*  FROM empiezas";  // Cambia 'tu_tabla' por el nombre real de la tabla

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
                    comboTrabajador.Items.Clear();

                    // Llenar el ComboBox con los datos obtenidos
                    while (reader.Read())
                    {
                        // Agregar al ComboBox el valor que desees, en este caso 'nombre'
                        comboTrabajador.Items.Add(reader["nombre"].ToString()); // Puedes agregar más campos si lo necesitas
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
        //-------------------------------------------------------------------------------------------------------------------------------------------------------
        private void LlenarCombomat()
        {
            // Cadena de conexión a tu base de datos MySQL
            string connectionString = "server=192.168.1.5;port=3306;database=pretecsa;uid=usuario_remoto;pwd=pretecsa160698;";

            // Consulta SQL para obtener los datos que quieres mostrar
            string query = "SELECT*  FROM material";  // Cambia 'tu_tabla' por el nombre real de la tabla

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
                    comboMaterial.Items.Clear();

                    // Llenar el ComboBox con los datos obtenidos
                    while (reader.Read())
                    {
                        // Agregar al ComboBox el valor que desees, en este caso 'nombre'
                        comboMaterial.Items.Add(reader["id_material"].ToString()); // Puedes agregar más campos si lo necesitas
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





        //-------------------------------------------------------------------------------------------------------------------------------------------------------


        public void limpiar()
        {
            
            textCurp.Text = ("");
            comboMaterial.Text = ("");
            comboUnidad.Text = ("");
            comboCentro.Text = ("");
            textCantidad.Text = ("");
            dtpFecha.Text = ("");
            comboAlmacen.Text = ("");
            dtpHora.Text = ("");
            comboTrabajador.Text = ("");
            textPeso.Text = ("");
            textDescripcion.Text = ("");
            comboTrabajo.Text = ("");

        }
        public void Bloquearcajas()
        {
            textCurp.Enabled = false;
            comboMaterial.Enabled = false;
            comboUnidad.Enabled = false;
            comboCentro.Enabled = false;
            textCantidad.Enabled = false;
            dtpFecha.Enabled = false;
            comboAlmacen.Enabled = false;
            dtpHora.Enabled = false;
            comboTrabajador.Enabled = false;
            textPeso.Enabled = false;
            textDescripcion.Enabled = false;
            comboTrabajo.Enabled = false;


        }
        public void desbloquear()
        {

            textCurp.Enabled = true;
            comboMaterial.Enabled = true;
            comboUnidad.Enabled = true;
            comboCentro.Enabled = true;
            textCantidad.Enabled = true;
            dtpFecha.Enabled = true;
            comboAlmacen.Enabled = true;
           // dtpHora.Enabled = true;
            comboTrabajador.Enabled = true;
            textPeso.Enabled = true;
            textDescripcion.Enabled= true;
            comboTrabajo.Enabled = true;

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
           desbloquear();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            Bloquearcajas();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboTrabajo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}

