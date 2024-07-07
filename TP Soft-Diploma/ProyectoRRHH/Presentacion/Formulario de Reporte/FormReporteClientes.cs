using Modelo;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Formulario_de_Reporte
{
    public partial class FormReporte : Form
    {
        private NegClientes negClientes;
        public FormReporte()
        {
            InitializeComponent();
            negClientes = NegClientes.ObtenerInstancia();
        }

        private void FormReporte_Load(object sender, EventArgs e)
        {
            List<Clientes> clientes = negClientes.ObtenerTodosLosClientes();
            dgvDataClientes.DataSource = clientes;
        }

        private void btnGenerarReporteCliente_Click(object sender, EventArgs e)
        {
            List<Clientes> clientes = (List<Clientes>)dgvDataClientes.DataSource;
            string rutaArchivo = "reporte_clientes.pdf";

            ReportePDF reporte = new ReportePDF();
            reporte.GenerarReporteClientes(clientes, rutaArchivo);

            MessageBox.Show("Reporte de clientes generado y guardado como PDF en " + rutaArchivo);
        }
    }
}
