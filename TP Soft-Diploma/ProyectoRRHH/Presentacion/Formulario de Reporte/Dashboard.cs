using Negocio;
using System;
using System.Windows.Forms;

namespace Presentacion.Formulario_de_Reporte
{

    public partial class Dashboard : Form
    {
        private NegClientes negClientes;
        private NegPostulantes negPostulantes;

        public Dashboard()
        {
            InitializeComponent();
            negClientes = NegClientes.ObtenerInstancia();
            negPostulantes = NegPostulantes.ObtenerInstancia();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            cbReportes.Items.Add("Clientes");
            cbReportes.Items.Add("Postulantes");
            cbReportes.Items.Add("Ofertas Laborales");
            cbReportes.SelectedIndex = 0;
        }


        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            // Verificar la selección del ComboBox y abrir el formulario correspondiente
            string opcionSeleccionada = cbReportes.SelectedItem.ToString();

            switch (opcionSeleccionada)
            {
                case "Clientes":
                    FormReporteClientes formClientes = new FormReporteClientes();
                    formClientes.ShowDialog();
                    break;

                case "Postulantes":
                    FormReportePostulantes formPostulantes = new FormReportePostulantes();
                    formPostulantes.ShowDialog();
                    break;

                case "Ofertas Laborales":
                    FormReporteOfertasLaborales formOfertas = new FormReporteOfertasLaborales();
                    formOfertas.ShowDialog();
                    break;

                default:
                    MessageBox.Show("Seleccione una opción válida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
    }
}
