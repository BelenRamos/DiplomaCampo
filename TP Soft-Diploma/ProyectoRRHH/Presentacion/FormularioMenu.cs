using Presentacion.Formularios_OL;
using Presentacion.Formularios_Perfiles;
using System;
using System.Windows.Forms;
using Negocio;

namespace Presentacion
{
    public partial class FormularioMenu : Form
    {
        private Form currentChildForm;
        private NegUsuarios negUsuarios;

        //public FormularioMenu()
        //{
        //    InitializeComponent();
        //    negUsuarios = NegUsuarios.ObtenerInstancia();
        //}

        // Constructor modificado
        public FormularioMenu(NegUsuarios negUsuarios)
        {
            InitializeComponent();
            this.negUsuarios = negUsuarios; // Asigna la instancia de NegUsuarios
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelFormularios.Controls.Add(childForm);
            panelFormularios.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private bool UsuarioTienePermiso(string permisoNombre)
        {
            return negUsuarios.PermisosUsuarioActual.Exists(p => p.nombrePermiso == permisoNombre);
        }

        private void btnPerfiles_Click(object sender, EventArgs e)
        {
            if (UsuarioTienePermiso("VER_FORMULARIO_GestionPerfiles"))
            {
                OpenChildForm(new FormGestionPerfiles());
            }
            else
            {
                MessageBox.Show("No tiene permiso para acceder a este formulario.");
            }
        }

        private void btnOL_Click(object sender, EventArgs e)
        {
            if (UsuarioTienePermiso("VER_FORMULARIO_GestionOL"))
            {
                OpenChildForm(new FormGestionOL());
            }
            else
            {
                MessageBox.Show("No tiene permiso para acceder a este formulario.");
            }
        }

        private void btnTurnos_Click(object sender, EventArgs e)
        {
            if (UsuarioTienePermiso("VER_PORTAL_TURNOS"))
            {
                OpenChildForm(new FormPortaldeTurnos());
            }
            else
            {
                MessageBox.Show("No tiene permiso para acceder a este formulario.");
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            if (UsuarioTienePermiso("VER_FORMULARIO_GestionClientes"))
            {
                OpenChildForm(new FormGestionClientes());
            }
            else
            {
                MessageBox.Show("No tiene permiso para acceder a este formulario.");
            }
        }

        private void btnPostulantes_Click(object sender, EventArgs e)
        {
            if (UsuarioTienePermiso("VER_FORMULARIO_GestionPostulante"))
            {
                OpenChildForm(new FormGestionPostulantes());
            }
            else
            {
                MessageBox.Show("No tiene permiso para acceder a este formulario.");
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if (UsuarioTienePermiso("VER_DASHBOARD"))
            {
                OpenChildForm(new Formulario_de_Reporte.Dashboard());
            }
            else
            {
                MessageBox.Show("No tiene permiso para acceder a este formulario.");
            }
        }

        private void btnSeguridad_Click(object sender, EventArgs e)
        {
            if (UsuarioTienePermiso("VER_MENU_SEGURIDAD"))
            {
                OpenChildForm(new Formularios_de_Seguridad.MenuSeguridad());
            }
            else
            {
                MessageBox.Show("No tiene permiso para acceder a este formulario.");
            }
        }

        //private void btnCerrarSesion_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        FormLogin formLogin = new FormLogin();
        //        formLogin.Show();
        //        this.Hide();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al cerrar sesión: " + ex.Message);
        //    }
        //}

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtén la instancia de NegSessionManager y cierra la sesión actual
                var sessionManager = NegSessionManager.ObtenerInstancia();
                sessionManager.CerrarSesion();

                // Redirige al formulario de inicio de sesión
                FormLogin formLogin = new FormLogin();
                formLogin.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar sesión: " + ex.Message);
            }
        }



    }
}
