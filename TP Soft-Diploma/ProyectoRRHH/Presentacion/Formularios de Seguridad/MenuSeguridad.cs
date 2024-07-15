using Presentacion.Formulario_de_Reporte;
using Presentacion.Formularios_de_Seguridad.Gestion_de_Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Formularios_de_Seguridad
{
    public partial class MenuSeguridad : Form
    {
        public MenuSeguridad()
        {
            InitializeComponent();
        }

        private void btmGestionPermisos(object sender, EventArgs e)
        {
            FormGestionPermisos formGestionPermisos = new FormGestionPermisos();
            formGestionPermisos.ShowDialog();
        }

        private void btnGestionGrupos_Click(object sender, EventArgs e)
        {
            //FormGestionGrupos formGestionGrupos = new FormGestionGrupos();
            //formGestionGrupos.ShowDialog();
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            FormGestionUsuarios formGestionUsuarios = new FormGestionUsuarios();
            formGestionUsuarios.ShowDialog();
        }
    }
}
