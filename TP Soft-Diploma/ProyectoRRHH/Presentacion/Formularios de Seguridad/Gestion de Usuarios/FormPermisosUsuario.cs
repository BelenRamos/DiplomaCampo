using Modelo;
using Negocio;
using System;
using System.Collections.Generic;

using System.Windows.Forms;

namespace Presentacion.Formularios_Postulantes
{
    public partial class FormPermisosUsuario : Form
    {
        private Usuarios usuario;
        private NegUsuarios negocioUsuarios;

        public FormPermisosUsuario(Usuarios usuario)
        {
            InitializeComponent();
            this.usuario = usuario ?? throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser null");
            negocioUsuarios = NegUsuarios.ObtenerInstancia() ?? throw new InvalidOperationException("No se pudo obtener la instancia de NegUsuarios.");
        }

        private void FormPermisosUsuario_Load(object sender, EventArgs e)
        {
            CargarPermisos();
        }

        private void CargarPermisos()
        {
            try
            {
                List<Permisos> permisos = negocioUsuarios.ObtenerPermisosPorUsuario(usuario.idUsuario);

                treePermisosUsu.Nodes.Clear();

                foreach (var permiso in permisos)
                {
                    TreeNode nodoPermiso = new TreeNode(permiso.nombrePermiso);
                    treePermisosUsu.Nodes.Add(nodoPermiso);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los permisos del usuario: " + ex.Message);
            }
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            // Código para guardar cambios (si es necesario)
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
