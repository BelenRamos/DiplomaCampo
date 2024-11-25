using Negocio;
using Presentacion.Formularios_Postulantes;
using System;
using System.Windows.Forms;

using Modelo;
using System.Collections.Generic;
using Presentacion.Formularios_de_Seguridad.Gestion_Grupos;

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
            if (dataUsuarios.SelectedRows.Count > 0)
            {
                Usuarios usuarioSeleccionado = (Usuarios)dataUsuarios.SelectedRows[0].DataBoundItem;
                FormPermisosUsuario formPermisosUsuario = new FormPermisosUsuario(usuarioSeleccionado);
                formPermisosUsuario.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para ver sus permisos.");
            }
        }

        private void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            FormAltaUsuario formAltaUsuario = new FormAltaUsuario();
            if (formAltaUsuario.ShowDialog() == DialogResult.OK)
            {
                Usuarios nuevoUsuario = formAltaUsuario.ObtenerUsuario();
                try
                {
                    int resultado = negocioUsuarios.AltaUsuario(nuevoUsuario);
                    if (resultado > 0)
                    {
                        MessageBox.Show("Usuario agregado exitosamente.");
                        CargarUsuarios(); // Recargar la lista de usuarios después de agregar uno nuevo
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar el usuario. Verifica los datos e inténtalo nuevamente.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar el usuario en el form gestion: " + ex.Message);
                    Console.WriteLine(ex); // Esto imprimirá el error en la consola para depuración
                }
            }
        }


        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            if (dataUsuarios.SelectedRows.Count > 0)
            {
                Usuarios usuarioSeleccionado = (Usuarios)dataUsuarios.SelectedRows[0].DataBoundItem;
                FormAltaUsuario formModificarUsuario = new FormAltaUsuario(usuarioSeleccionado);

                if (formModificarUsuario.ShowDialog() == DialogResult.OK)
                {
                    Usuarios usuarioModificado = formModificarUsuario.ObtenerUsuario();
                    try
                    {
                        negocioUsuarios.ModificarUsuario(usuarioModificado);
                        CargarUsuarios(); // Recargar la lista de usuarios después de modificar uno
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al modificar el usuario: " + ex.Message);
                        Console.WriteLine(ex.ToString()); // Esto imprimirá más detalles del error en la consola
                    }
                }
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

        private void btnSessionManager_Click(object sender, EventArgs e)
        {
            FormSesiones formSesiones = new FormSesiones();
            formSesiones.ShowDialog();
        }
    }
}
