using Negocio;
using Modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;

namespace Presentacion.Formularios_Cliente
{
    public partial class FormNuevoCliente : Form
    {
        private NegClientes negClientes;
        private NegClientesTels negClientesTelefonos;
        private List<string> telefonos;

        public FormNuevoCliente(NegClientes negClientes, NegClientesTels negClientesTelefonos)
        {
            InitializeComponent();
            this.negClientes = negClientes;
            this.negClientesTelefonos = negClientesTelefonos;
            telefonos = new List<string>();
        }

        private void FormNuevoCliente_Load(object sender, EventArgs e)
        {

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
                var nuevoCliente = new Clientes
                {
                    nombre = txtNombre.Text,
                    mail = txtMail.Text
                };

                negClientes.AgregarCliente(nuevoCliente);

                var clienteGuardado = negClientes.ObtenerClientePorId(nuevoCliente.id);

                foreach (var telefono in telefonos)
                {
                    var clienteTelefono = new Clientes_Telefonos
                    {
                        id_cliente = clienteGuardado.id,
                        telefono = telefono
                    };

                    negClientesTelefonos.AgregarTelefono(clienteTelefono);
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


//Algo que faltaria es que el sistema le agregue automaticamente el id, este debe ser el ultimo mas uno de los id que ya estan cragados:using Negocio;
//using Modelo;
//using System;
//using System.Collections.Generic;
//using System.Windows.Forms;

//namespace Presentacion.Formularios_Cliente
//{
//    public partial class FormNuevoCliente : Form
//    {
//        private NegClientes negClientes;
//        private NegClientesTels negClientesTelefonos;
//        private List<string> telefonos;

//        public FormNuevoCliente(NegClientes negClientes, NegClientesTels negClientesTelefonos)
//        {
//            InitializeComponent();
//            this.negClientes = negClientes;
//            this.negClientesTelefonos = negClientesTelefonos;
//            telefonos = new List<string>();
//        }

//        private void FormNuevoCliente_Load(object sender, EventArgs e)
//        {

//        }

//        private void btnAgregarTelefono_Click(object sender, EventArgs e)
//        {
//            if (!string.IsNullOrEmpty(txtTelefono.Text))
//            {
//                telefonos.Add(txtTelefono.Text);
//                listTelefonos.Items.Add(txtTelefono.Text);
//                txtTelefono.Clear();
//            }
//            else
//            {
//                MessageBox.Show("Ingrese un número de teléfono.");
//            }
//        }

//        private void btnGuardar_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                var nuevoCliente = new Clientes
//                {
//                    nombre = txtNombre.Text,
//                    mail = txtMail.Text
//                };

//                negClientes.AgregarCliente(nuevoCliente);

//                var clienteGuardado = negClientes.ObtenerClientePorId(nuevoCliente.id);

//                foreach (var telefono in telefonos)
//                {
//                    var clienteTelefono = new Clientes_Telefonos
//                    {
//                        id_cliente = clienteGuardado.id,
//                        telefono = telefono
//                    };

//                    negClientesTelefonos.AgregarTelefono(clienteTelefono);
//                }

//                MessageBox.Show("Cliente guardado con éxito.");
//                this.Close();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error al guardar el cliente: " + ex.ToString());
//            }
//        }

//        private void btnCancelar_Click(object sender, EventArgs e)
//        {
//            this.Close();
//        }
//    }
//}


//Te dejo como ejemplo para el metodo, este que esta implementado en RepoPostulantes:
//        public int ObtenerUltimoNumero()
//{
//    string consultaSQL = "SELECT ISNULL(MAX(numero), 0) FROM Postulantes";
//    try
//    {
//        DataTable result = ExecuteReader(consultaSQL);
//        if (result.Rows.Count > 0)
//        {
//            return Convert.ToInt32(result.Rows[0][0]);
//        }
//        return 0;
//    }
//    catch (Exception ex)
//    {
//        throw new Exception("Error al obtener el último número de postulante", ex);
//    }
//}

