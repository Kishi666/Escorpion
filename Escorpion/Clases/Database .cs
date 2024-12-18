using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
namespace Escorpion.Clases
{
    internal class Database
    {

        private string connectionString = "server=192.168.1.5;port=3306;database=pretecsa;uid=usuario_remoto;pwd=pretecsa160698;";

        // Método para obtener los productos disponibles
        public DataTable ObtenerProductos()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id_material, descripcion FROM materiales";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable productos = new DataTable();
                adapter.Fill(productos);
                return productos;
            }
        }

        // Método para registrar la salida de los productos
        public void RegistrarSalida(int idMaterial, int cantidad, string tipoOperacion)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO entradas_salidas (id_material, cantidad, tipo_operacion, fecha) VALUES (@idMaterial, @cantidad, @tipoOperacion, @fecha)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idMaterial", idMaterial);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@tipoOperacion", tipoOperacion);
                cmd.Parameters.AddWithValue("@fecha", DateTime.Now.Date);
                cmd.ExecuteNonQuery();
            }
        }

        // Método para actualizar el stock del material
        public void ActualizarStock(int idMaterial, int cantidadSalida)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE almacen SET cantidad = cantidad - @cantidadSalida WHERE id_material = @idMaterial";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cantidadSalida", cantidadSalida);
                cmd.Parameters.AddWithValue("@idMaterial", idMaterial);
                cmd.ExecuteNonQuery();
            }
        }






    }





}
