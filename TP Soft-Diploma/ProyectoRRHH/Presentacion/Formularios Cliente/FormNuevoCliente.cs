using Negocios;
using Modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.Formularios_Cliente
{
    public partial class FormNuevoCliente : Form
    {
        private NegClientes _negClientes;
        private NegClientesTelefonos _negClientesTelefonos;
        
        private List<string> _telefonos;

        public FormNuevoCliente()
        {
            InitializeComponent();
            _telefonos = new List<string>();
        }

        private void btnAgregarTelefono_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTelefono.Text))
            {
                _telefonos.Add(txtTelefono.Text);
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
                var nuevoCliente = new Clientes
                {
                    nombre = txtNombre.Text,
                    mail = txtMail.Text
                };

                _negClientes.AgregarCliente(nuevoCliente);

                var clienteGuardado = _negClientes.ObtenerClientePorId(nuevoCliente.id);

                foreach (var telefono in _telefonos)
                {
                    var clienteTelefono = new Clientes_Telefonos
                    {
                        id_cliente = clienteGuardado.id,
                        telefono = telefono
                    };

                    _negClientesTelefonos.AgregarTelefono(clienteTelefono);
                }

                MessageBox.Show("Cliente guardado con éxito.");
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

