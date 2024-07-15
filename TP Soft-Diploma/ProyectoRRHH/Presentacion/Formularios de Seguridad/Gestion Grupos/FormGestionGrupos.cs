using System;
using System.Windows.Forms;
using Negocio;
using Modelo;

namespace Presentacion.Formularios_de_Seguridad.Gestion_Grupos
{
    public partial class FormGestionGrupos : Form
    {
        private readonly NegGrupos negGrupos;

        public FormGestionGrupos()
        {
            InitializeComponent();
            negGrupos = new NegGrupos();
        }

        public FormGestionGrupos(NegPermisos negPermisos) : this()
        {
            // Aquí puedes usar negPermisos si es necesario
        }

        private void FormGestionGrupos_Load(object sender, EventArgs e)
        {
            CargarGrupos();
            CargarTreeView();
        }

        private void CargarGrupos()
        {
            var grupos = negGrupos.ObtenerGrupos();
            dataGrupos.DataSource = grupos;
        }

        private void CargarTreeView()
        {
            var grupos = negGrupos.ObtenerGrupos();
            treeGrupos.Nodes.Clear();

            foreach (var grupo in grupos)
            {
                if (grupo.Grupos2.Count == 0) // Raíz, no tiene grupo padre
                {
                    TreeNode nodoGrupo = new TreeNode(grupo.nombreGrupo) { Tag = grupo };
                    CargarSubGrupos(nodoGrupo, grupo);
                    treeGrupos.Nodes.Add(nodoGrupo);
                }
            }
        }

        private void CargarSubGrupos(TreeNode nodoPadre, Grupos grupoPadre)
        {
            foreach (var subGrupo in grupoPadre.Grupos1)
            {
                TreeNode nodoSubGrupo = new TreeNode(subGrupo.nombreGrupo) { Tag = subGrupo };
                CargarSubGrupos(nodoSubGrupo, subGrupo);
                nodoPadre.Nodes.Add(nodoSubGrupo);
            }
        }

        private void btnAltaGrupos_Click(object sender, EventArgs e)
        {
            // Este botón abrirá un formulario separado para agregar un nuevo grupo
        }

        private void btnModificarGrupos_Click(object sender, EventArgs e)
        {
            //if (dataGrupos.SelectedRows.Count > 0)
            //{
            //    var selectedRow = dataGrupos.SelectedRows[0];
            //    int idGrupo = (int)selectedRow.Cells["IdGrupo"].Value;
            //    Grupos grupo = negGrupos.ObtenerGrupoPorId(idGrupo);

            //    // Abrir el formulario de alta/modificación y pasarle el grupo
            //    var formAltaModificacionGrupo = new FormAltaModificacionGrupo(grupo);
            //    if (formAltaModificacionGrupo.ShowDialog() == DialogResult.OK)
            //    {
            //        CargarGrupos();
            //        CargarTreeView();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Por favor, seleccione un grupo para modificar.");
            //}
        }

        private void btnBajaGrupos_Click(object sender, EventArgs e)
        {
            if (dataGrupos.SelectedRows.Count > 0)
            {
                var selectedRow = dataGrupos.SelectedRows[0];
                int idGrupo = (int)selectedRow.Cells["IdGrupo"].Value;
                negGrupos.EliminarGrupo(idGrupo);
                CargarGrupos();
                CargarTreeView();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un grupo para eliminar.");
            }
        }
    }
}



