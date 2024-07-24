using Modelo;
using Negocio;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormLogin : Form
    {
        private readonly NegUsuarios negUsuarios;

        public FormLogin()
        {
            InitializeComponent();
            negUsuarios = new NegUsuarios();
        }



        private void btnIngresar_Click(object sender, EventArgs e)
        { 
            string email = txtMailUsu.Text.Trim();
            string contrasenia = txtContra.Text.Trim();

            try
            {
                Usuarios usuario = negUsuarios.ValidarUsuario(email, contrasenia);

                if (usuario != null)
                {
                    // Usuario validado correctamente
                    if (usuario.habilitado.HasValue && usuario.habilitado.Value == 1)
                    {
                        MessageBox.Show("Login exitoso");
                        FormularioMenu formularioMenu = new FormularioMenu();
                        formularioMenu.FormClosed += (s, args) => Application.Exit();
                        formularioMenu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("El usuario no está habilitado.");
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
    }
}
