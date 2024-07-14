using Negocio;
using Presentacion.Formularios_Postulantes;
using System;
using System.Windows.Forms;
using Negocio;
using Modelo;
using System.Collections.Generic;

namespace Presentacion.Formularios_de_Seguridad.Gestion_de_Usuarios
{
    public partial class FormGestionUsuarios : Form
    {
        private NegUsuarios negocioUsuarios;
        public FormGestionUsuarios()
        {
            InitializeComponent();
            negocioUsuarios = NegUsuarios.ObtenerInstancia();
        }

        private void btnPermisosUsuarios_Click(object sender, EventArgs e)
        {
            FormPermisosUsuario formPermisosUsuario = new FormPermisosUsuario();
            formPermisosUsuario.ShowDialog();
        }

        private void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            FormAltaUsuario formAltaUsuario = new FormAltaUsuario();
            if (formAltaUsuario.ShowDialog() == DialogResult.OK)
            {
                Usuarios nuevoUsuario = formAltaUsuario.ObtenerUsuario();
                try
                {
                    negocioUsuarios.AltaUsuario(nuevoUsuario);
                    CargarUsuarios(); // Recargar la lista de usuarios después de agregar uno nuevo
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar el usuario: " + ex.Message);
                }
            }
        }

        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            if (dataUsuarios.SelectedRows.Count > 0)
            {
                Usuarios usuarioSeleccionado = (Usuarios)dataUsuarios.SelectedRows[0].DataBoundItem;
                dataUsuarios.BeginEdit(true);
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para modificar.");
            }
        }

        private void btnBajaUsuario_Click(object sender, EventArgs e)
        {
            if (dataUsuarios.SelectedRows.Count > 0)
            {
                Usuarios usuarioSeleccionado = (Usuarios)dataUsuarios.SelectedRows[0].DataBoundItem;
                DialogResult resultado = MessageBox.Show($"¿Está seguro de que desea eliminar al usuario {usuarioSeleccionado.nombreUsuario}?", "Confirmar eliminación", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        negocioUsuarios.BajaUsuario(usuarioSeleccionado.idUsuario);
                        CargarUsuarios(); // Recargar la lista de usuarios después de eliminar uno
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el usuario: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para eliminar.");
            }
        }

        private void FormGestionUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            try
            {
                List<Usuarios> usuarios = negocioUsuarios.ObtenerTodosLosUsuarios();
                dataUsuarios.DataSource = usuarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los usuarios: " + ex.Message);
            }
        }

        private void dataUsuarios_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                Usuarios usuarioModificado = (Usuarios)dataUsuarios.Rows[rowIndex].DataBoundItem;

                negocioUsuarios.ModificarUsuario(usuarioModificado);

                MessageBox.Show("Usuario modificado exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el usuario: " + ex.Message);
            }
        }
    }
}
