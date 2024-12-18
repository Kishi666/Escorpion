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
using Excel = Microsoft.Office.Interop.Excel;
namespace Escorpion.SubInterfacez
{
    public partial class Produccion : Form
    {
        public Produccion()
        {
            InitializeComponent();
            buscarTabla();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Cadena de conexión a la base de datos MySQL
            string connectionString = "Server=192.168.1.5;port=3306;database=pretecsa;uid=usuario_remoto;pwd=pretecsa160698;";

            // Consulta SQL con el parámetro de búsqueda
            string query = "SELECT * FROM piezas WHERE curp   = @curp";

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
                            dataTabla.DataSource = dt;
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

        private void buscarTabla()
        {

            string connectionString = "Server=192.168.1.5;port=3306;database=pretecsa;uid=usuario_remoto;pwd=pretecsa160698;";
            // Crear la consulta SQL para obtener los datos de la tabla "Usuarios"
            string query = "SELECT * FROM piezas";

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
                    dataTabla.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Mostrar un mensaje de error si la conexión falla
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }

            }


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Crear una aplicación Excel
            Excel.Application excelApp = new Excel.Application();
            if (excelApp == null)
            {
                MessageBox.Show("Excel no está instalado en el sistema.");
                return;
            }

            // Crear un nuevo libro de trabajo y una nueva hoja de trabajo
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

            // Escribir los encabezados de las columnas del DataGridView en Excel
            for (int i = 0; i < dataTabla.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = dataTabla.Columns[i].HeaderText;
            }

            // Escribir los datos del DataGridView en las celdas correspondientes de Excel
            for (int i = 0; i < dataTabla.Rows.Count; i++)
            {
                for (int j = 0; j < dataTabla.Columns.Count; j++)
                {
                    if (dataTabla.Rows[i].Cells[j].Value != null)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataTabla.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }

            // Hacer visible la aplicación Excel
            excelApp.Visible = true;

            // Guardar el archivo de Excel
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivos Excel (*.xlsx)|*.xlsx|Todos los archivos (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Datos exportados correctamente a Excel.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el archivo: " + ex.Message);
            }
            finally
            {
                // Cerrar el libro y la aplicación de Excel
                workbook.Close(false);
                excelApp.Quit();
            }
        }
    }
}
