using Modelo;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.Formularios_Perfiles
{
    public partial class FormGestionPerfiles : Form
    {
        public FormGestionPerfiles()
        {
            InitializeComponent();
        }

        private void FormGestionPerfiles_Load(object sender, EventArgs e)
        {
            CargarPerfilesEnLista();
        }

        private void CargarPerfilesEnLista()
        {
            try
            {
                NegPerfiles negPerfiles = NegPerfiles.ObtenerInstancia();
                List<Perfiles> perfiles = negPerfiles.ObtenerTodosLosPerfiles();

                listaPerfiles.Items.Clear();
                foreach (Perfiles perfil in perfiles)
                {
                    listaPerfiles.Items.Add(perfil.nombre);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los perfiles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarPerfil_Click(object sender, EventArgs e)
        {
            FormNuevoPerfil formAlta = new FormNuevoPerfil();
            if (formAlta.ShowDialog() == DialogResult.OK)
            {
                CargarPerfilesEnLista();
            }
        }

        private void btnEliminarPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                if (listaPerfiles.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un perfil para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string nombrePerfilSeleccionado = listaPerfiles.SelectedItem.ToString();
                NegPerfiles negPerfiles = NegPerfiles.ObtenerInstancia();
                List<Perfiles> perfiles = negPerfiles.ObtenerTodosLosPerfiles();
                Perfiles perfilAEliminar = perfiles.Find(p => p.nombre == nombrePerfilSeleccionado);

                if (perfilAEliminar != null)
                {
                    if (MessageBox.Show("¿Está seguro de que desea eliminar el perfil seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int resultado = negPerfiles.BajaPerfil(perfilAEliminar.id);
                        if (resultado > 0)
                        {
                            MessageBox.Show("Perfil eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarPerfilesEnLista();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el perfil.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el perfil: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                if (listaPerfiles.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un perfil para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string nombrePerfilSeleccionado = listaPerfiles.SelectedItem.ToString();
                NegPerfiles negPerfiles = NegPerfiles.ObtenerInstancia();
                List<Perfiles> perfiles = negPerfiles.ObtenerTodosLosPerfiles();
                Perfiles perfilAModificar = perfiles.Find(p => p.nombre == nombrePerfilSeleccionado);

                if (perfilAModificar != null)
                {
                    FormNuevoPerfil formModificar = new FormNuevoPerfil(perfilAModificar);
                    if (formModificar.ShowDialog() == DialogResult.OK)
                    {
                        CargarPerfilesEnLista();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el perfil: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
