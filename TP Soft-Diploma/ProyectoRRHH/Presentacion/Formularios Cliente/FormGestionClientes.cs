using Negocio;
using Presentacion.Formularios_Cliente;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormGestionClientes : Form
    {
        private NegClientes negClientes;
        private NegClientesTels negClientesTelefonos;

        public FormGestionClientes()
        {
            InitializeComponent();
        }

        private void FormGestionClientes_Load(object sender, EventArgs e)
        {
            negClientes = NegClientes.ObtenerInstancia();
            negClientesTelefonos = NegClientesTels.ObtenerInstancia();
            try
            {
                dataClientes.DataSource = negClientes.ObtenerClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
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
            // Implementación de modificar cliente (si es necesario)
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
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
    }
}
