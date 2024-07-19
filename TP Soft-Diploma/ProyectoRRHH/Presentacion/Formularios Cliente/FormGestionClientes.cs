using Negocios;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormGestionClientes : Form
    {
        private NegClientes _negClientes;
        private string _connectionString = "your_connection_string_here"; // Define tu cadena de conexión

        public FormGestionClientes()
        {
            InitializeComponent();
        }

        private void FormGestionClientes_Load(object sender, EventArgs e)
        {
            _negClientes = new NegClientes(_connectionString);
            try
            {
                dataClientes.DataSource = _negClientes.ObtenerClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {

        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {

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
                        _negClientes.EliminarCliente(id);
                        dataClientes.DataSource = _negClientes.ObtenerClientes();
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
