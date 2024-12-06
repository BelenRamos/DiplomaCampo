using Negocio;
using System;
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
            txtContraNueva.PasswordChar = '*';
            txtConfirmaContra.PasswordChar = '*';
        }

        private void btnGuardarContra_Click(object sender, EventArgs e)
        {
            string email = txtMailUsu.Text.Trim();
            string nuevaContrasenia = txtContraNueva.Text.Trim();
            string confirmaContrasenia = txtConfirmaContra.Text.Trim();

            try
            {
                // Validar que ningún campo esté vacío
                if (string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("El campo de email no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(nuevaContrasenia))
                {
                    MessageBox.Show("El campo de nueva contraseña no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(confirmaContrasenia))
                {
                    MessageBox.Show("El campo de confirmación de contraseña no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que la nueva contraseña tenga al menos 6 caracteres
                if (nuevaContrasenia.Length < 6)
                {
                    MessageBox.Show("La nueva contraseña debe tener al menos 6 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool cambioExitoso = negUsuarios.CambiarContraseña(email, nuevaContrasenia, confirmaContrasenia);

                if (cambioExitoso)
                {
                    MessageBox.Show("Contraseña cambiada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
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
