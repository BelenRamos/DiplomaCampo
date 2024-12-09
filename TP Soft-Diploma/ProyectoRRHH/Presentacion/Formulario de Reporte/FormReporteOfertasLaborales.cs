using Negocio;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml;
using System;
using System.IO;
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
                var datos = negOfertasLaborales.ObtenerPorcentajesPorEstado();

                string filePath = @"C:\Reportes\ReporteOfertasLaborales.xlsx";

                // Configuración para EPPlus
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Reporte Ofertas Laborales");

                    // Encabezados
                    worksheet.Cells[1, 1].Value = "Estado";
                    worksheet.Cells[1, 2].Value = "Cantidad";
                    worksheet.Cells[1, 3].Value = "Porcentaje";

                    int row = 2;

                    foreach (var (Estado, Cantidad, Porcentaje) in datos)
                    {
                        worksheet.Cells[row, 1].Value = Estado;
                        worksheet.Cells[row, 2].Value = Cantidad;
                        worksheet.Cells[row, 3].Value = Porcentaje / 100.0; 
                        worksheet.Cells[row, 3].Style.Numberformat.Format = "0.00%";
                        row++;
                    }

                    // Agregar gráfico de torta
                    var chart = worksheet.Drawings.AddChart("GráficoOfertasLaborales", eChartType.Pie) as ExcelPieChart;
                    chart.Title.Text = "Distribución por Estados";
                    chart.Series.Add($"B2:B{row - 1}", $"A2:A{row - 1}");
                    chart.SetPosition(1, 0, 4, 0); 
                    chart.SetSize(600, 400);       

                    // Guardar el archivo
                    package.SaveAs(new FileInfo(filePath));
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
                    MessageBox.Show($"Reporte y gráfico generados en: {filePath}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
