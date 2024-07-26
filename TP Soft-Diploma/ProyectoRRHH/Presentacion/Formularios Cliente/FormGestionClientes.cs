﻿using Modelo;
using Negocio;
using Presentacion.Formularios_Cliente;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormGestionClientes : Form
    {
        private NegClientes negClientes;
        private NegClientesTels negClientesTelefonos;
        private NegMensajes negMensajes;
        private NegUsuarios negUsuarios;
        private NegSessionManager sessionManager;

        public FormGestionClientes()
        {
            InitializeComponent();
            this.tabClientes.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            negUsuarios = NegUsuarios.ObtenerInstancia();
            sessionManager = NegSessionManager.ObtenerInstancia();
        }

        private void FormGestionClientes_Load(object sender, EventArgs e)
        {
            negClientes = NegClientes.ObtenerInstancia();
            negClientesTelefonos = NegClientesTels.ObtenerInstancia();
            negMensajes = NegMensajes.ObtenerInstancia();

            try
            {
                dataClientes.DataSource = negClientes.ObtenerClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            // Inicializar el DataGridView para mensajes
            InicializarDataGridViewMensajes();
        }

        private void InicializarDataGridViewMensajes()
        {
            dgvMensajes.AutoGenerateColumns = true;
        }

        private bool UsuarioTienePermiso(string permisoNombre)
        {
            return negUsuarios.PermisosUsuarioActual.Exists(p => p.nombrePermiso == permisoNombre);
        }

        //private bool UsuarioEsSupervisor()
        //{
        //    try
        //    {
        //        // Obtén el idUsuario del usuario actualmente autenticado
        //        int idUsuarioActual = ObtenerIdUsuarioActual();

        //        // Obtén el grupo del usuario actual
        //        var grupoUsuarioActual = negUsuarios.ObtenerGrupoUsuario(idUsuarioActual);
        //        return grupoUsuarioActual == 2; // Grupo 2 es Supervisores
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al verificar el grupo del usuario: " + ex.Message);
        //        return false;
        //    }
        //}

        private int ObtenerIdUsuarioActual()
        {
            // Supongamos que tienes una clase NegSessionManager para manejar la sesión del usuario
            var usuarioActual = NegSessionManager.ObtenerInstancia().UsuarioActual;

            if (usuarioActual == null)
            {
                throw new InvalidOperationException("No hay un usuario autenticado.");
            }

            return usuarioActual.idUsuario;
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            if (!UsuarioTienePermiso("ABM_CLIENTE"))
            {
                MessageBox.Show("No tiene permiso para agregar clientes.");
                return;
            }
            var formNuevoCliente = new FormNuevoCliente(negClientes, negClientesTelefonos);
            formNuevoCliente.ShowDialog();
            try
            {
                dataClientes.DataSource = negClientes.ObtenerClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            if (!UsuarioTienePermiso("ABM_CLIENTE"))
            {
                MessageBox.Show("No tiene permiso para modificar clientes.");
                return;
            }

            if (dataClientes.SelectedRows.Count > 0)
            {
                int id = (int)dataClientes.SelectedRows[0].Cells["id"].Value;
                var cliente = negClientes.ObtenerClientePorId(id);
                var formNuevoCliente = new FormNuevoCliente(negClientes, negClientesTelefonos, cliente);
                formNuevoCliente.ShowDialog();
                try
                {
                    dataClientes.DataSource = negClientes.ObtenerClientes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un cliente para modificar.");
            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (!UsuarioTienePermiso("ABM_CLIENTE"))
            {
                MessageBox.Show("No tiene permiso para eliminar clientes.");
                return;
            }

            if (dataClientes.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("¿Estás seguro de que deseas eliminar este cliente?", "Confirmación de eliminación", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int id = (int)dataClientes.SelectedRows[0].Cells["id"].Value;
                        negClientes.EliminarCliente(id);
                        dataClientes.DataSource = negClientes.ObtenerClientes();
                        // Limpiar los mensajes
                        dgvMensajes.DataSource = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el cliente: " + ex.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un cliente para eliminar.");
            }
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabClientes.SelectedTab == tabMensajes)
            {
                CargarTodosLosMensajes();
            }
        }

        private void CargarTodosLosMensajes()
        {
            try
            {
                var mensajes = negMensajes.ObtenerTodosLosMensajes();
                dgvMensajes.DataSource = mensajes.Select(m => new
                {
                    m.numero,
                    m.asunto,
                    m.contenido,
                    m.emisor,
                    m.receptor
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar todos los mensajes: " + ex.ToString());
            }
        }
    }
}
