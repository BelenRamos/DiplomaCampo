using Presentacion.Formularios_OL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        //        private struct RGBColors
        //        {
        //            public static Color color1 = Color.FromArgb(234, 144, 255);
        //            public static Color color2 = Color.FromArgb(132, 175, 249);
        //            public static Color color3 = Color.FromArgb(228, 250, 114);

        //        }


        //        //Eventos
        private void btnPerfiles_Click(object sender, EventArgs e)
        {
            //ActivateButton(sender, RGBColors.color1);
            //OpenChildForm(new FormGestionPerfiles());
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
            OpenChildForm(new FormDashboard());
        }

    }
}
