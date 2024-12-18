using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using System.IO;
namespace Escorpion.SubInterfacez
{
    public partial class CodigoBarras : Form
    {
        public CodigoBarras()
        {
            InitializeComponent();
        }

        private void CodigoBarras_Load(object sender, EventArgs e)
        {
          
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {

            // Obtener el texto ingresado en el TextBox
            string codigo = textBoxCodigo.Text.Trim();

            // Verificar si se ingresó algo
            if (string.IsNullOrEmpty(codigo))
            {
                MessageBox.Show("Por favor ingrese un código para generar el código de barras.");
                return;
            }

            // Generar el código de barras
            Bitmap codigoDeBarras = GenerarCodigoDeBarras(codigo);

            // Mostrar el código de barras en el PictureBox
            pictureBoxCodigoDeBarras.Image = codigoDeBarras;
            }
        private Bitmap GenerarCodigoDeBarras(string codigo)
        {
            // Crear el objeto de codificador de códigos de barras
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.CODE_128; // Seleccionamos el tipo de código de barras (Code 128 en este caso)

            // Configurar la codificación
            barcodeWriter.Options = new ZXing.Common.EncodingOptions
            {
                Width = 400,  // Ancho del código de barras
                Height = 100  // Alto del código de barras
            };

            // Generar el código de barras como un objeto Bitmap
            return barcodeWriter.Write(codigo);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar si se ha generado un código de barras
            if (pictureBoxCodigoDeBarras.Image == null)
            {
                MessageBox.Show("Primero debe generar un código de barras.");
                return;
            }

            // Guardar el código de barras en un archivo de imagen
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos de imagen PNG|*.png";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Guardar la imagen en el archivo seleccionado
                    pictureBoxCodigoDeBarras.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    MessageBox.Show("Código de barras guardado exitosamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el código de barras: " + ex.Message);
                }
            }





        }
    }
}
