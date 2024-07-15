using Negocio;
using Datos;
using Modelo;
using System;
using System.Windows.Forms;

namespace Presentacion.Formularios_de_Seguridad
{
    public partial class FormGestionPermisos : Form
    {
        private readonly NegPermisos negPermisos;

        public FormGestionPermisos()
        {
            negPermisos = new NegPermisos();
            InitializeComponent();
        }

        private void FormGestionPermisos_Load(object sender, EventArgs e)
        {
            CargarPermisosEnTreeView();
        }

        private void CargarPermisosEnTreeView()
        {
            treePermisos.Nodes.Clear();

            var permisos = negPermisos.ObtenerTodosPermisos();
            foreach (var permiso in permisos)
            {
                var nodoPermiso = new TreeNode(permiso.nombrePermiso)
                {
                    Tag = permiso
                };

                // Si tienes una estructura jerárquica, puedes agregar nodos hijos aquí.
                // Por ejemplo, si los permisos están relacionados con formularios:
                if (permiso.idForm.HasValue)
                {
                    var nodoFormulario = new TreeNode($"Formulario ID: {permiso.idForm.Value}")
                    {
                        Tag = permiso.idForm.Value
                    };
                    nodoPermiso.Nodes.Add(nodoFormulario);
                }

                treePermisos.Nodes.Add(nodoPermiso);
            }
        }
    }
}
