using ClosedXML.Excel;
using Negocio;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Formulario_de_Reporte
{
    public partial class FormReporteOfertasLaborales : Form
    {
        private NegOfertasLaborales negOfertasLaborales;

        public FormReporteOfertasLaborales()
        {
            InitializeComponent();
            negOfertasLaborales = NegOfertasLaborales.ObtenerInstancia();
            GenerarReporte();
        }
        private void FormReporteOfertasLaborales_Load(object sender, EventArgs e)
        {
            MostrarReporteEnListView();
        }
        private void MostrarReporteEnListView()
        {
            var datos = negOfertasLaborales.ObtenerPorcentajesPorEstado();

            // Configurar columnas del ListView (si no están configuradas)
            lvReportes.Clear();
            lvReportes.View = View.Details;
            lvReportes.Columns.Add("Estado", 150);
            lvReportes.Columns.Add("Cantidad", 100);
            lvReportes.Columns.Add("Porcentaje", 100);

            // Agregar datos
            foreach (var (Estado, Cantidad, Porcentaje) in datos)
            {
                var item = new ListViewItem(Estado);
                item.SubItems.Add(Cantidad.ToString());
                item.SubItems.Add($"{Porcentaje}%");
                lvReportes.Items.Add(item);
            }
        }

        private void GenerarReporte()
        {
            try
            {
                // Obtener los porcentajes por estado
                var porcentajes = negOfertasLaborales.ObtenerPorcentajesPorEstado();
                var datos = negOfertasLaborales.ObtenerPorcentajesPorEstado();

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Reporte Ofertas Laborales");

                    // Encabezados
                    worksheet.Cell(1, 1).Value = "Estado";
                    worksheet.Cell(1, 2).Value = "Cantidad";
                    worksheet.Cell(1, 3).Value = "Porcentaje";

                    int row = 2;
                    
                    foreach (var (Estado, Cantidad, Porcentaje) in datos)
                    {
                        worksheet.Cell(row, 1).Value = Estado;     
                        worksheet.Cell(row, 2).Value = Cantidad;   
                        worksheet.Cell(row, 3).Value = $"{Porcentaje}%"; 
                        row++;
                    }

                    // Guardar archivo
                    string filePath = @"C:\Reportes\ReporteOfertasLaborales.xlsx";
                    workbook.SaveAs(filePath);
                    Console.WriteLine($"Reporte generado en: {filePath}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerarReporteOL_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = @"C:\Reportes\ReporteOfertasLaborales.xlsx";

                // Verificar si el archivo existe
                if (System.IO.File.Exists(filePath))
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = filePath,
                        UseShellExecute = true
                    });
                }
                else
                {
                    MessageBox.Show("El archivo no existe. Por favor, genere el reporte primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al intentar abrir el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
