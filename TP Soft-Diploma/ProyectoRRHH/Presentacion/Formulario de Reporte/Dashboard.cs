using Negocio;
using System;
using System.Windows.Forms;

namespace Presentacion.Formulario_de_Reporte
{

    public partial class Dashboard : Form
    {
        private NegClientes negClientes;
        private NegPostulantes negPostulantes;
        private const int MaxClientes = 100; // Número máximo de clientes
        private const int MaxPostulantes = 100; // Número máximo de postulantes


        public Dashboard()
        {
            InitializeComponent();
            negClientes = NegClientes.ObtenerInstancia();
            negPostulantes = NegPostulantes.ObtenerInstancia();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            ActualizarBarrasDeProgreso();
        }

        private void ActualizarBarrasDeProgreso()
        {
            int porcentajeClientes = negClientes.ObtenerPorcentajeClientes(MaxClientes);
            int porcentajePostulantes = negPostulantes.ObtenerPorcentajePostulantes(MaxPostulantes);

            pbClientes.Value = Math.Min(porcentajeClientes, 100); // Asegurar que no se pase de 100
            pbPostulantes.Value = Math.Min(porcentajeClientes, 100); // pbPostulantes.Value = Math.Min(porcentajePostulantes, 100); // Asegurar que no se pase de 100
        }

        private void btnGenerarReporteCliente_Click(object sender, EventArgs e)
        {
            FormReporteClientes formReporteClientes = new FormReporteClientes();
            formReporteClientes.ShowDialog();
        }

        private void btnGenerarReportePostulante_Click(object sender, EventArgs e)
        {
            FormReportePostulantes formReportePostulantes = new FormReportePostulantes();
            formReportePostulantes.ShowDialog();
        }
    }
}
