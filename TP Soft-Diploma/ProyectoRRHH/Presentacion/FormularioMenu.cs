using Presentacion.Formularios_OL;
using Presentacion.Formularios_Perfiles;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormularioMenu : Form
    {

        private Form currentChildForm;
        //Constructor
        public FormularioMenu()
        {
            InitializeComponent();
            
        }

        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelFormularios.Controls.Add(childForm);
            panelFormularios.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            
        }


        //        //Eventos
        private void btnPerfiles_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormGestionPerfiles());
        }
        
        private void btnOL_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormGestionOL());
        }

        private void btnTurnos_Click(object sender, EventArgs e)
        {
            //ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new FormPortaldeTurnos());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            //ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new FormGestionClientes());
        }

        private void btnPostulantes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormGestionPostulantes());
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Formulario_de_Reporte.Dashboard());
        }

        private void btnSeguridad_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Formularios_de_Seguridad.MenuSeguridad());
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                FormLogin formLogin = new FormLogin();
                formLogin.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar sesión: " + ex.Message);
            }
        }
    
    }
}
