using Modelo;
using Negocio;
using System;
using System.Windows.Forms;

namespace Presentacion.Formularios_Postulantes
{
    public partial class FormPostulanteNuevo : Form
    {
        private NegPostulantes negocio;
        private bool esModificacion = false;
        private int numeroPostulanteExistente;

        public FormPostulanteNuevo()
        {
            InitializeComponent();
            negocio = NegPostulantes.ObtenerInstancia();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Recoger los datos ingresados por el usuario
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string email = txtEmail.Text;
                string telefono = txtTelefono.Text;
                DateTime fechaNacimiento = dtpFechaNacimiento.Value;

                int numero;
                if (esModificacion)
                {
                    // Usar el número del postulante existente
                    numero = numeroPostulanteExistente;
                }
                else
                {
                    // Obtener y usar el siguiente número de postulante
                    int ultimoNumero = negocio.ObtenerUltimoNumero();
                    numero = ultimoNumero + 1;
                }

                // Crear el objeto Postulante
                Postulantes postulante = new Postulantes
                {
                    numero = numero,
                    nombre = nombre,
                    apellido = apellido,
                    mail = email,
                    telefono = telefono,
                    fechaNacimiento = fechaNacimiento,
                    esCandidato = 0
                };

                int resultado;
                if (esModificacion)
                {
                    // Llamar al método de modificación
                    resultado = negocio.ModificarPostulante(postulante);
                }
                else
                {
                    // Llamar al método de alta
                    resultado = negocio.AltaPostulante(postulante);
                }

                if (resultado > 0)
                {
                    MessageBox.Show("Postulante guardado correctamente.");
                    this.Close(); // Cerrar el formulario si se guarda correctamente
                }
                else
                {
                    MessageBox.Show("Error al guardar el postulante.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void CargarDatosParaModificacion(int numero, string nombre, string apellido, string email, string telefono, DateTime fechaNacimiento)
        {
            // Indicar que estamos en modo modificación
            esModificacion = true;
            numeroPostulanteExistente = numero;

            // Cargar los datos del postulante en los controles de entrada del formulario
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtEmail.Text = email;
            txtTelefono.Text = telefono;
            dtpFechaNacimiento.Value = fechaNacimiento;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario o realizar cualquier otra acción de cancelación
            this.Close();
        }
    }
}

