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

namespace Presentacion.Formularios_de_Seguridad.Gestion_de_Usuarios
{
    public partial class FormRestablecerContraseña : Form
    {

        private static NegUsuarios negUsuarios;
        public FormRestablecerContraseña()
        {
            InitializeComponent();
            negUsuarios= NegUsuarios.ObtenerInstancia();
        }

        private void btnGuardarContra_Click(object sender, EventArgs e)
        {
            string email = txtMailUsu.Text.Trim();
            string nuevaContrasenia = txtContraNueva.Text.Trim();
            string confirmaContrasenia = txtConfirmaContra.Text.Trim();

            try
            {
                
                bool cambioExitoso = negUsuarios.CambiarContraseña(email, nuevaContrasenia, confirmaContrasenia);

                if (cambioExitoso)
                {
                    MessageBox.Show("Contraseña cambiada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Cerrar el formulario si el cambio fue exitoso
                }
                else
                {
                    MessageBox.Show("No se pudo cambiar la contraseña. Verifique los datos ingresados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
