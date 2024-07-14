using Modelo;
using System;
using System.Windows.Forms;

namespace Presentacion.Formularios_de_Seguridad.Gestion_de_Usuarios
{
    public partial class FormAltaUsuario : Form
    {
        private Usuarios usuario;
        private bool esModificacion;

        public FormAltaUsuario()
        {
            InitializeComponent();
            esModificacion = false;
        }

        public FormAltaUsuario(Usuarios usuario) : this()
        {
            this.usuario = usuario;
            esModificacion = true;
            CargarDatosUsuario();
        }

        private void CargarDatosUsuario()
        {
            if (usuario != null)
            {
                txtNombreUsuario.Text = usuario.nombreUsuario;
                txtContrasenia.Text = usuario.contrasenia;
                txtContraseniaConfirma.Text = usuario.contrasenia;
                txtEmailUsuario.Text = usuario.emailUsuario;
                chkHabilitado.Checked = usuario.habilitado.HasValue && usuario.habilitado.Value == 1;
                txtLegajo.Text = usuario.legajo.HasValue ? usuario.legajo.Value.ToString() : string.Empty;
            }
        }

        public Usuarios ObtenerUsuario()
        {
            if (usuario == null)
                usuario = new Usuarios();

            usuario.nombreUsuario = txtNombreUsuario.Text;
            usuario.contrasenia = txtContrasenia.Text;
            usuario.emailUsuario = txtEmailUsuario.Text;
            usuario.habilitado = chkHabilitado.Checked ? (byte)1 : (byte)0;
            usuario.legajo = !string.IsNullOrEmpty(txtLegajo.Text) ? int.Parse(txtLegajo.Text) : (int?)null;

            return usuario;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidarDatos()
        {
            // Validar nombre de usuario
            if (string.IsNullOrEmpty(txtNombreUsuario.Text))
            {
                MessageBox.Show("El nombre de usuario es obligatorio.");
                return false;
            }

            // Validar contraseña
            if (string.IsNullOrEmpty(txtContrasenia.Text))
            {
                MessageBox.Show("La contraseña es obligatoria.");
                return false;
            }

            // Validar confirmación de contraseña
            if (txtContrasenia.Text != txtContraseniaConfirma.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return false;
            }

            // Agregar otras validaciones según sea necesario
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

