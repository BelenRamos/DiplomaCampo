using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormGestionClientes : Form
    {
        NegClientes clientes;
        public FormGestionClientes()
        {
            InitializeComponent();
        }

        private void FormGestionClientes_Load(object sender, EventArgs e)
        {
            clientes = NegClientes.ObtenerInstancia();
            try
            {
                dataClientes.DataSource = clientes.ObtenerTodosLosClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
