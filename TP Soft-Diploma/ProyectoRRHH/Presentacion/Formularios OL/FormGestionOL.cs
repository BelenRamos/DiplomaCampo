using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Modelo;
using Negocio;

namespace Presentacion.Formularios_OL
{
    public partial class FormGestionOL : Form
    {
        private NegOfertasLaborales ofertasLaborales;
        private NegEstados negEstados;
        private NegUsuarios negUsuarios;

        public FormGestionOL()
        {
            InitializeComponent();
            negUsuarios = NegUsuarios.ObtenerInstancia();
        }

        private bool UsuarioTienePermiso(string permisoNombre)
        {
            return negUsuarios.PermisosUsuarioActual.Exists(p => p.nombrePermiso == permisoNombre);
        }

        private void FormGestionOL_Load(object sender, EventArgs e)
        {
            ofertasLaborales = NegOfertasLaborales.ObtenerInstancia();
            negEstados = NegEstados.ObtenerInstancia();
            try
            {
                InicializarComboEstados();
                dgvOfertasLaborales.DataSource = ofertasLaborales.ObtenerOfertasLaborales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ComboEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboEstados.SelectedItem != null)
            {
                var estadoSeleccionado = (Estados)comboEstados.SelectedItem;
                CargarOfertasLaborales(estadoSeleccionado.codigo);
            }
        }

        private void CargarOfertasLaborales(int codigoEstado)
        {
            try
            {
                if (codigoEstado == -1) // Mostrar todas las ofertas si se selecciona "Todos"
                {
                    dgvOfertasLaborales.DataSource = ofertasLaborales.ObtenerOfertasLaborales();
                }
                else
                {
                    dgvOfertasLaborales.DataSource = ofertasLaborales.ObtenerOfertasPorEstado(codigoEstado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar las ofertas laborales por estado: " + ex.Message);
            }
        }

        private void InicializarComboEstados()
        {
            try
            {
                List<Estados> estados = negEstados.ObtenerEstados();
                estados.Insert(0, new Estados { codigo = -1, designacion = "Todos" });
                comboEstados.DataSource = estados;
                comboEstados.DisplayMember = "designacion";
                comboEstados.ValueMember = "codigo";
                comboEstados.SelectedIndex = 0; // Seleccionar "Todos" al inicio
                comboEstados.SelectedIndexChanged += ComboEstados_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los estados: " + ex.Message);
            }
        }

        private void btnAgregarOL_Click(object sender, EventArgs e)
        {
            if (!UsuarioTienePermiso("ABM_OFERTA_LABORAL"))
            {
                MessageBox.Show("No tiene permiso para agregar ofertas laborales.");
                return;
            }
            using (FormOLNuevo formulario = new FormOLNuevo { EsAlta = true })
            {
                if (formulario.ShowDialog() == DialogResult.OK)
                {
                    // Refrescar la lista de ofertas laborales
                    dgvOfertasLaborales.DataSource = ofertasLaborales.ObtenerOfertasLaborales();
                }
            }
        }

        private void btnModificarOL_Click(object sender, EventArgs e)
        {
            if (!UsuarioTienePermiso("ABM_OFERTA_LABORAL"))
            {
                MessageBox.Show("No tiene permiso para modificar ofertas laborales.");
                return;
            }
            if (dgvOfertasLaborales.SelectedRows.Count > 0)
            {
                var ofertaSeleccionada = (Ofertas_Laborales)dgvOfertasLaborales.SelectedRows[0].DataBoundItem;
                using (FormOLNuevo formulario = new FormOLNuevo { EsAlta = false, Oferta = ofertaSeleccionada })
                {
                    if (formulario.ShowDialog() == DialogResult.OK)
                    {
                        // Refrescar la lista de ofertas laborales
                        dgvOfertasLaborales.DataSource = ofertasLaborales.ObtenerOfertasLaborales();
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
            if (!UsuarioTienePermiso("ABM_OFERTA_LABORAL"))
            {
                MessageBox.Show("No tiene permiso para eliminar ofertas laborales.");
                return;
            }
            if (dgvOfertasLaborales.SelectedRows.Count > 0)
            {
                var ofertaSeleccionada = (Ofertas_Laborales)dgvOfertasLaborales.SelectedRows[0].DataBoundItem;
                try
                {
                    ofertasLaborales.BajaOfertaLaboral(ofertaSeleccionada.numero);
                    // Refrescar la lista de ofertas laborales
                    dgvOfertasLaborales.DataSource = ofertasLaborales.ObtenerOfertasLaborales();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la oferta laboral: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una oferta laboral para eliminar.");
            }
        }

        private void btnPublicar_Click(object sender, EventArgs e)
        {
            if (dgvOfertasLaborales.SelectedRows.Count > 0)
            {
                var ofertaSeleccionada = (Ofertas_Laborales)dgvOfertasLaborales.SelectedRows[0].DataBoundItem;
                try
                {
                    ofertasLaborales.PublicarOfertaLaboral(ofertaSeleccionada.numero);
                    // Refrescar la lista de ofertas laborales
                    dgvOfertasLaborales.DataSource = ofertasLaborales.ObtenerOfertasLaborales();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al publicar la oferta laboral: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una oferta laboral para publicar.");
            }
        }

        private void btnSeleccionCandidato_Click(object sender, EventArgs e)
        {
            if (dgvOfertasLaborales.SelectedRows.Count > 0)
            {
                var ofertaSeleccionada = (Ofertas_Laborales)dgvOfertasLaborales.SelectedRows[0].DataBoundItem;
                using (FormCandidatosOL formulario = new FormCandidatosOL(ofertaSeleccionada.numero))
                {
                    formulario.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una oferta laboral para cerrar la publicación.");
            }
        }

        private void btnRequistosOl_Click(object sender, EventArgs e)
        {
            if (dgvOfertasLaborales.SelectedRows.Count > 0)
            {
                var ofertaSeleccionada = (Ofertas_Laborales)dgvOfertasLaborales.SelectedRows[0].DataBoundItem;
                using (var formRequisitos = new FormRequisitosOL(ofertaSeleccionada.numero))
                {
                    formRequisitos.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una oferta laboral para ver los requisitos.");
            }
        }
    }
}
