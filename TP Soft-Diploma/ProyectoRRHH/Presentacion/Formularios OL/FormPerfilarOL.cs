using Modelo;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.Formularios_OL
{
    public partial class FormPerfilarOL : Form
    {
        private readonly NegRequisitos negRequisitos;
        private readonly NegPerfiles negPerfiles;
        private readonly int numeroOferta;

        public FormPerfilarOL(int numero)
        {
            InitializeComponent();
            negRequisitos = NegRequisitos.ObtenerInstancia();
            negPerfiles = NegPerfiles.ObtenerInstancia();
            numeroOferta = numero;
        }

        private void FormPerfilarOL_Load(object sender, EventArgs e)
        {
            try
            {
                CargarPerfilesEnLista();
                CargarRequisitosDeLaOferta();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPerfilesEnLista()
        {
            List<Perfiles> perfiles = negPerfiles.ObtenerTodosLosPerfiles();

            if (perfiles?.Count > 0)
            {
                listaPerfiles.Items.Clear();
                foreach (Perfiles perfil in perfiles)
                {
                    listaPerfiles.Items.Add(perfil.nombre);
                }
            }
            else
            {
                MessageBox.Show("No se encontraron perfiles para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CargarRequisitosDeLaOferta()
        {
            List<Requisitos> requisitos = negRequisitos.ObtenerRequisitosPorOferta(numeroOferta);

            if (requisitos?.Count > 0)
            {
                listRequisitos.DataSource = requisitos;
                listRequisitos.DisplayMember = "descripcion";
            }
            else
            {
                MessageBox.Show("No se encontraron requisitos para esta oferta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (listaPerfiles.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un perfil antes de guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string nombrePerfilSeleccionado = listaPerfiles.SelectedItem.ToString();
                Perfiles perfilSeleccionado = negPerfiles.ObtenerPerfilPorNombre(nombrePerfilSeleccionado);

                if (perfilSeleccionado == null)
                {
                    MessageBox.Show("El perfil seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                NegOfertasLaborales negOfertas = NegOfertasLaborales.ObtenerInstancia();
                bool resultado = negOfertas.AsignarPerfilAOferta(numeroOferta, perfilSeleccionado.id);

                if (resultado)
                {
                    MessageBox.Show("Perfil asignado exitosamente a la oferta laboral.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo asignar el perfil a la oferta laboral.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al asignar el perfil: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
