using Negocio;
using Modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.Formularios_Cliente
{
    public partial class FormNuevoCliente : Form
    {
        private NegClientes negClientes;
        private NegClientesTels negClientesTelefonos;
        private List<string> telefonos;
        private Clientes clienteExistente;

        public FormNuevoCliente(NegClientes negClientes, NegClientesTels negClientesTelefonos)
        {
            InitializeComponent();
            this.negClientes = negClientes;
            this.negClientesTelefonos = negClientesTelefonos;
            telefonos = new List<string>();
        }

        public FormNuevoCliente(NegClientes negClientes, NegClientesTels negClientesTelefonos, Clientes cliente) : this(negClientes, negClientesTelefonos)
        {
            this.clienteExistente = cliente;
        }

        private void FormNuevoCliente_Load(object sender, EventArgs e)
        {
            if (clienteExistente != null)
            {
                txtNombre.Text = clienteExistente.nombre;
                txtMail.Text = clienteExistente.mail;

                // Cargar los teléfonos existentes del cliente
                var telefonosExistentes = negClientesTelefonos.ObtenerTelefonosPorClienteId(clienteExistente.id);
                foreach (var telefono in telefonosExistentes)
                {
                    telefonos.Add(telefono.telefono);
                    listTelefonos.Items.Add(telefono.telefono);
                }
            }
        }

        private void btnAgregarTelefono_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTelefono.Text))
            {
                telefonos.Add(txtTelefono.Text);
                listTelefonos.Items.Add(txtTelefono.Text);
                txtTelefono.Clear();
            }
            else
            {
                MessageBox.Show("Ingrese un número de teléfono.");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (clienteExistente == null)
                {
                    // Crear nuevo cliente
                    int nuevoId = negClientes.ObtenerUltimoId() + 1;

                    var nuevoCliente = new Clientes
                    {
                        id = nuevoId,
                        nombre = txtNombre.Text,
                        mail = txtMail.Text
                    };

                    negClientes.AgregarCliente(nuevoCliente);

                    foreach (var telefono in telefonos)
                    {
                        var clienteTelefono = new Clientes_Telefonos
                        {
                            id_cliente = nuevoCliente.id,
                            telefono = telefono
                        };

                        negClientesTelefonos.AgregarTelefono(clienteTelefono);
                    }

                    MessageBox.Show("Cliente guardado con éxito.");
                }
                else
                {
                    // Modificar cliente existente
                    clienteExistente.nombre = txtNombre.Text;
                    clienteExistente.mail = txtMail.Text;

                    negClientes.ModificarCliente(clienteExistente);

                    // Primero, eliminar todos los teléfonos existentes
                    negClientesTelefonos.EliminarTelefonosPorClienteId(clienteExistente.id);

                    // Luego, agregar los teléfonos actualizados
                    foreach (var telefono in telefonos)
                    {
                        var clienteTelefono = new Clientes_Telefonos
                        {
                            id_cliente = clienteExistente.id,
                            telefono = telefono
                        };

                        negClientesTelefonos.AgregarTelefono(clienteTelefono);
                    }

                    MessageBox.Show("Cliente modificado con éxito.");
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el cliente: " + ex.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
