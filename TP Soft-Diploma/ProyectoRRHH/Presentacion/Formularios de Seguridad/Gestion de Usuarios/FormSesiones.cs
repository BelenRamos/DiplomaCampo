using iTextSharp.text.pdf;
using iTextSharp.text;
using Modelo;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Formularios_de_Seguridad.Gestion_de_Usuarios
{
    public partial class FormSesiones : Form
    {
        private NegSessionManager negSessionManager;
        public FormSesiones()
        {
            InitializeComponent();
            negSessionManager = NegSessionManager.ObtenerInstancia();
        }
        private void FormSesiones_Load(object sender, EventArgs e)
        {
            try
            {
                // Obtener las sesiones desde la capa de negocio
                DataTable sesiones = negSessionManager.ObtenerReporteSesiones();

                if (sesiones == null || sesiones.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos de sesiones para mostrar.");
                    return;
                }

                // Asignar los datos al DataGridView
                dgvDataSesiones.DataSource = sesiones;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las sesiones: {ex.Message}");
            }
        }
        private void btnGenerarReporteSM_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el reporte de sesiones desde la capa de negocio
                DataTable reporteSesiones = negSessionManager.ObtenerReporteSesiones();

                if (reporteSesiones == null || reporteSesiones.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos de sesiones para generar el reporte.");
                    return;
                }

                // Definir el directorio y archivo donde se guardará el reporte
                string rutaDirectorio = @"C:\Reportes";
                if (!System.IO.Directory.Exists(rutaDirectorio))
                {
                    System.IO.Directory.CreateDirectory(rutaDirectorio);
                }

                string rutaArchivo = System.IO.Path.Combine(rutaDirectorio, "reporte_sesiones.pdf");

                // Generar el reporte PDF
                GenerarReporteSesionesPDF(reporteSesiones, rutaArchivo);

                MessageBox.Show("Reporte de Sesiones generado exitosamente en " + rutaArchivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}");
            }
        }

        private void GenerarReporteSesionesPDF(DataTable sesiones, string rutaArchivo)
        {
            try
            {
                using (FileStream stream = new FileStream(rutaArchivo, FileMode.Create))
                {
                    Document documento = new Document(PageSize.A4);
                    PdfWriter.GetInstance(documento, stream);

                    documento.Open();

                    // Título del reporte
                    documento.Add(new Paragraph("Reporte de Sesiones"));
                    documento.Add(new Paragraph($"Generado el: {DateTime.Now}"));
                    documento.Add(new Paragraph(" ")); // Espacio

                    // Tabla para el reporte
                    PdfPTable tabla = new PdfPTable(sesiones.Columns.Count);
                    tabla.WidthPercentage = 100;

                    // Encabezados
                    foreach (DataColumn columna in sesiones.Columns)
                    {
                        PdfPCell celdaEncabezado = new PdfPCell(new Phrase(columna.ColumnName));
                        celdaEncabezado.BackgroundColor = BaseColor.LIGHT_GRAY;
                        tabla.AddCell(celdaEncabezado);
                    }

                    // Datos
                    foreach (DataRow fila in sesiones.Rows)
                    {
                        foreach (var celda in fila.ItemArray)
                        {
                            tabla.AddCell(celda != null ? celda.ToString() : string.Empty);
                        }
                    }

                    documento.Add(tabla);
                    documento.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar el archivo PDF: " + ex.Message);
            }
        }

        private void dgvDataSesiones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
