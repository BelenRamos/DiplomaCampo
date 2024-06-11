using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;
using Negocio;
using Presentacion.Formularios_Postulantes;

namespace Presentacion.Formularios_OL
{
    public partial class FormGestionOL : Form
    {
        private NegOfertasLaborales ofertaslaborales;

        public FormGestionOL()
        {
            InitializeComponent();
        }

        private void FormGestionOL_Load(object sender, EventArgs e)
        {
            ofertaslaborales = NegOfertasLaborales.ObtenerInstancia();
            try
            {
                dgvOfertasLaborales.DataSource = ofertaslaborales.ObtenerTodasLasOfertasLaborales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregarOL_Click(object sender, EventArgs e)
        {
            using (FormAM_OL formulario = new FormAM_OL { EsAlta = true })
            {
                if (formulario.ShowDialog() == DialogResult.OK)
                {
                    // Refrescar la lista de ofertas laborales
                    dgvOfertasLaborales.DataSource = ofertaslaborales.ObtenerTodasLasOfertasLaborales();
                }
            }
        }

        private void btnModificarOL_Click(object sender, EventArgs e)
        {
            if (dgvOfertasLaborales.SelectedRows.Count > 0)
            {
                var ofertaSeleccionada = (Ofertas_Laborales)dgvOfertasLaborales.SelectedRows[0].DataBoundItem;
                using (FormAM_OL formulario = new FormAM_OL { EsAlta = false, Oferta = ofertaSeleccionada })
                {
                    if (formulario.ShowDialog() == DialogResult.OK)
                    {
                        // Refrescar la lista de ofertas laborales
                        dgvOfertasLaborales.DataSource = ofertaslaborales.ObtenerTodasLasOfertasLaborales();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una oferta laboral para modificar.");
            }
        }

        private void btnEliminarOL_Click(object sender, EventArgs e)
        {
            if (dgvOfertasLaborales.SelectedRows.Count > 0)
            {
                var ofertaSeleccionada = (Ofertas_Laborales)dgvOfertasLaborales.SelectedRows[0].DataBoundItem;
                try
                {
                    ofertaslaborales.BajaOfertaLaboral(ofertaSeleccionada.numero);
                    // Refrescar la lista de ofertas laborales
                    dgvOfertasLaborales.DataSource = ofertaslaborales.ObtenerTodasLasOfertasLaborales();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Seleccione una oferta laboral para eliminar.");
            }
        }
    }

}
