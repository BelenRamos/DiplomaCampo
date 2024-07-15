using System;
using System.Windows.Forms;
using Negocio;
using Modelo;

namespace Presentacion.Formularios_de_Seguridad.Gestion_Grupos
{
    public partial class FormGestionGrupos : Form
    {
        private readonly NegPermisos _negPermisos;

        public FormGestionGrupos(NegPermisos negPermisos)
        {
            _negPermisos = negPermisos;
            InitializeComponent();
        }

        private void FormGestionGrupos_Load(object sender, EventArgs e)
        {
            
        }


    }
}


