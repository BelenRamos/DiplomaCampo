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
            using (FormNuevoPerfil formAlta = new FormNuevoPerfil())
            {
                formAlta.ShowDialog(); // Abre el formulario como modal
                CargarPerfilesEnLista(); // Actualiza la lista después de que se cierra el formulario de alta
            }
        }

        private void btnModificarPerfil_Click(object sender, EventArgs e)
        {
            // Implementar funcionalidad de modificación de perfil
        }

        private void btnEliminarPerfil_Click(object sender, EventArgs e)
        {
            // Implementar funcionalidad de eliminación de perfil
        }
    }
}
