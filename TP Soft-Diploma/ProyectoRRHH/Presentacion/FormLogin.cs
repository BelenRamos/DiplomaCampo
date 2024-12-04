using Modelo;
using Negocio;
using Presentacion.Formularios_de_Seguridad.Gestion_de_Usuarios;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormLogin : Form
    {
        private readonly NegSessionManager negSessionManager;
        

        public FormLogin()
        {
            InitializeComponent();
            negSessionManager = NegSessionManager.ObtenerInstancia(); // Usar el Singleton de NegSessionManager
            txtContra.PasswordChar = '*';


        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string email = txtMailUsu.Text.Trim();
            string contrasenia = txtContra.Text.Trim();

            try
            {
                // Intentar iniciar sesión usando el NegSessionManager
                bool loginExitoso = negSessionManager.IniciarSesion(email, contrasenia);

                if (loginExitoso)
                {
                    Usuarios usuario = negSessionManager.UsuarioActual;

                    if (usuario.habilitado.HasValue && usuario.habilitado.Value == 1)
                    {
                        // Establece el usuario actual y permisos en NegUsuarios
                        NegUsuarios.ObtenerInstancia().EstablecerUsuarioActual(usuario);

                        MessageBox.Show("Login exitoso");
                        FormularioMenu formularioMenu = new FormularioMenu(NegUsuarios.ObtenerInstancia());
                        formularioMenu.FormClosed += (s, args) => this.Show();
                        formularioMenu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("El usuario no está habilitado.");
                        negSessionManager.CerrarSesion();
                    }
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión: " + ex.Message);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit();
        }

        private void btnRestablecerContra_Click(object sender, EventArgs e)
        {
            FormRestablecerContraseña formRestablecerContraseña=new FormRestablecerContraseña();
            formRestablecerContraseña.Show();
        }
    }
}
