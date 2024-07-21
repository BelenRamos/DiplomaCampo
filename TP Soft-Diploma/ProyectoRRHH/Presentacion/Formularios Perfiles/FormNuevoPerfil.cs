using Modelo;
using Negocio;
using System;
using System.Windows.Forms;

namespace Presentacion.Formularios_Perfiles
{
    public partial class FormNuevoPerfil : Form
    {
        public FormNuevoPerfil()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Perfiles nuevoPerfil = new Perfiles
                {
                    nombre = txtNombre.Text,
                    descripcion = txtDescripcion.Text
                };

                NegPerfiles negPerfiles = NegPerfiles.ObtenerInstancia();
                int resultado = negPerfiles.AltaPerfil(nuevoPerfil);

                if (resultado > 0)
                {
                    MessageBox.Show("Perfil guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al guardar el perfil.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el perfil: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
