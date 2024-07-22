using Modelo;
using Negocio;
using System;
using System.Windows.Forms;

namespace Presentacion.Formularios_Perfiles
{
    public partial class FormNuevoPerfil : Form
    {
        private Perfiles perfil;
        private bool esModificacion;

        public FormNuevoPerfil()
        {
            InitializeComponent();
            esModificacion = false;
        }

        public FormNuevoPerfil(Perfiles perfilAModificar)
        {
            InitializeComponent();
            perfil = perfilAModificar;
            esModificacion = true;
            CargarDatos();
        }

        private void CargarDatos()
        {
            if (perfil != null)
            {
                txtNombre.Text = perfil.nombre;
                txtDescripcion.Text = perfil.descripcion;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (esModificacion)
                {
                    perfil.nombre = txtNombre.Text;
                    perfil.descripcion = txtDescripcion.Text;

                    NegPerfiles negPerfiles = NegPerfiles.ObtenerInstancia();
                    int resultado = negPerfiles.ModificarPerfil(perfil);

                    if (resultado > 0)
                    {
                        MessageBox.Show("Perfil modificado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al modificar el perfil.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
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
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar el perfil.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
