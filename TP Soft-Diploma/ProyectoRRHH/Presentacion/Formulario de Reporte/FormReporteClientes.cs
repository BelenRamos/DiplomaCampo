using Modelo;
using Negocio;
using System;
using System.Collections.Generic;

using System.Windows.Forms;

namespace Presentacion.Formulario_de_Reporte
{
    public partial class FormReporteClientes : Form
    {
        private NegClientes negClientes;
        private NegReportes negReportes;

        public FormReporteClientes()
        {
            InitializeComponent();
            negClientes = NegClientes.ObtenerInstancia();
            negReportes = NegReportes.ObtenerInstancia();
        }

        private void FormReporte_Load(object sender, EventArgs e)
        {
            List<Clientes> clientes = negClientes.ObtenerClientes();
            dgvDataClientes.DataSource = clientes;
        }

        private void btnGenerarReporteCliente_Click(object sender, EventArgs e)
        {
            try
            {
                List<Clientes> clientes = (List<Clientes>)dgvDataClientes.DataSource;
                if (clientes == null || clientes.Count == 0)
                {
                    MessageBox.Show("No hay datos de clientes para generar el reporte.");
                    return;
                }

                string rutaDirectorio = @"C:\Reportes";
                if (!System.IO.Directory.Exists(rutaDirectorio))
                {
                    System.IO.Directory.CreateDirectory(rutaDirectorio);
                }

                string rutaArchivo = System.IO.Path.Combine(rutaDirectorio, "reporte_clientes.pdf");
                negReportes.GenerarReporteClientes(clientes, rutaArchivo);
                MessageBox.Show("Reporte de Clientes generado exitosamente en " + rutaArchivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}");
            }
        }
    }
}

