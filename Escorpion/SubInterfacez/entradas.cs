using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;

namespace Escorpion.SubInterfacez
{
    public partial class entradas : Form
    {


        public entradas()
        {
            InitializeComponent();

            formapago();
            LlenarComboBox();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void formapago()
        {
            combofor.Items.Add("Transferencia");
            combofor.Items.Add("Deposito");
            combofor.Items.Add("Cheque");
            combofor.Items.Add("Efectivo");

        }
        private void LlenarComboBox()
        {
            // Cadena de conexión a tu base de datos MySQL
            string connectionString = "Server=192.168.1.5;port=3306;database=pretecsa;uid=usuario_remoto;pwd=pretecsa160698;";

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
                    comobounidad.Items.Clear();

                    // Llenar el ComboBox con los datos obtenidos
                    while (reader.Read())
                    {
                        // Agregar al ComboBox el valor que desees, en este caso 'nombre'
                        comobounidad.Items.Add(reader["Unidad"].ToString()); // Puedes agregar más campos si lo necesitas
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
        //-----------------------------------------------------------------------------------------------//



        //-----------------------------------------------------------------------------------------------//
        private void button1_Click(object sender, EventArgs e)
        {
            
            // Definir la cadena de conexión
            string connectionString = "Server=192.168.1.5;port=3306;database=pretecsa;uid=usuario_remoto;pwd=pretecsa160698;";

            // Crear la conexión
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    conn.Open();

                    // Iniciar una transacción
                    MySqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Crear el comando para insertar un nuevo material en la tabla materiales
                        string queryMaterial = "INSERT INTO materiales (descripcion, tipo_material, cantidad, forma_pago, precio_unitario, total, unidad, fecha_ingreso, quien_ingresa) " +
                                               "VALUES (@descripcion, @tipo_material, @cantidad, @forma_pago, @precio_unitario, @total, @unidad, @fecha_ingreso, @quien_ingresa)";

                        MySqlCommand cmdMaterial = new MySqlCommand(queryMaterial, conn, transaction);
                        cmdMaterial.Parameters.AddWithValue("@descripcion", textdesc.Text);
                        cmdMaterial.Parameters.AddWithValue("@tipo_material", textmat.Text);
                        cmdMaterial.Parameters.AddWithValue("@cantidad", int.Parse(textcan.Text));
                        cmdMaterial.Parameters.AddWithValue("@forma_pago", combofor.SelectedItem.ToString());
                        cmdMaterial.Parameters.AddWithValue("@precio_unitario", decimal.Parse(textpre.Text));
                        cmdMaterial.Parameters.AddWithValue("@total", decimal.Parse(texttot.Text));
                        cmdMaterial.Parameters.AddWithValue("@unidad", comobounidad.SelectedItem.ToString());
                        cmdMaterial.Parameters.AddWithValue("@fecha_ingreso", DateTime.Now);
                        cmdMaterial.Parameters.AddWithValue("@quien_ingresa", textemp.Text);

                        // Ejecutar el comando para insertar en materiales
                        cmdMaterial.ExecuteNonQuery();

                        // Obtener el id_material insertado (último ID insertado)
                        long idMaterial = cmdMaterial.LastInsertedId;

                        // Crear el comando para insertar en la tabla almacen
                        string queryAlmacen = "INSERT INTO almacen (id_material, descripcion, tipo_material, cantidad, unidad) " +
                                              "VALUES (@id_material, @descripcion, @tipo_material, @cantidad, @unidad)";

                        MySqlCommand cmdAlmacen = new MySqlCommand(queryAlmacen, conn, transaction);
                        cmdAlmacen.Parameters.AddWithValue("@id_material", idMaterial);
                        cmdAlmacen.Parameters.AddWithValue("@descripcion", textdesc.Text);
                        cmdAlmacen.Parameters.AddWithValue("@tipo_material", textmat.Text);
                        cmdAlmacen.Parameters.AddWithValue("@cantidad", int.Parse(textcan.Text));
                        cmdAlmacen.Parameters.AddWithValue("@unidad", comobounidad.SelectedItem.ToString());

                        // Ejecutar el comando para insertar en almacen
                        cmdAlmacen.ExecuteNonQuery();

                        // Confirmar la transacción
                        transaction.Commit();

                        MessageBox.Show("Registros insertados correctamente.");
                    }
                    catch (Exception ex)
                    {
                        // Si algo falla, revertir la transacción
                        transaction.Rollback();
                        MessageBox.Show("Error al insertar los registros: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexión: " + ex.Message);
                }
            }
        }


    




        

        private void combofor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void entradas_Load(object sender, EventArgs e)
        {

        }
    }
    }

