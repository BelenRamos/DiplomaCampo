using Modelo;
using Negocio;
using Presentacion.Formularios_Postulantes;
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
    public partial class FormGestionPostulantes : Form
    {
        NegPostulantes postulantes;
        public FormGestionPostulantes()
        {
            InitializeComponent();
        }

        private void FormGestionPostulantes_Load(object sender, EventArgs e)
        {
            postulantes = NegPostulantes.ObtenerInstancia();
            try
            {
                dgvPostulantes.DataSource = postulantes.ObtenerTodosLosPostulantes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregarPostulante_Click(object sender, EventArgs e)
        {
            // Abre el formulario FormPostulanteNuevo
            using (FormPostulanteNuevo formulario = new FormPostulanteNuevo())
            {
                formulario.ShowDialog();
            }
        }

        private void btnEliminarPostulante_Click(object sender, EventArgs e)
        {
            // Verifica si hay una fila seleccionada en el DataGridView
            if (dgvPostulantes.SelectedRows.Count > 0)
            {
                // Obtiene el número del postulante seleccionado en la primera columna
                int numeroPostulante = Convert.ToInt32(dgvPostulantes.SelectedRows[0].Cells["Numero"].Value);

                // Pide confirmación para eliminar
                DialogResult result = MessageBox.Show("¿Estás seguro de eliminar este postulante?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Llama a la función de eliminación de postulante
                    try
                    {
                        int resultado = postulantes.BajaPostulante(numeroPostulante);
                        if (resultado > 0)
                        {
                            MessageBox.Show("Postulante eliminado correctamente.");
                            // Actualiza la vista después de la eliminación
                            dgvPostulantes.DataSource = postulantes.ObtenerTodosLosPostulantes();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el postulante.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un postulante para eliminar.");
            }
        }


        private void btnModificarPostulante_Click(object sender, EventArgs e)
        {
            // Verifica si hay una fila seleccionada en el DataGridView
            if (dgvPostulantes.SelectedRows.Count > 0)
            {
                // Obtiene los datos del postulante seleccionado
                int numero = Convert.ToInt32(dgvPostulantes.SelectedRows[0].Cells["Numero"].Value);
                string nombre = dgvPostulantes.SelectedRows[0].Cells["Nombre"].Value.ToString();
                string apellido = dgvPostulantes.SelectedRows[0].Cells["Apellido"].Value.ToString();
                string email = dgvPostulantes.SelectedRows[0].Cells["Mail"].Value.ToString();
                string telefono = dgvPostulantes.SelectedRows[0].Cells["Telefono"].Value.ToString();

                // Convertir la cadena a DateTime
                DateTime fechaNacimiento;
                string fechaNacimientoStr = dgvPostulantes.SelectedRows[0].Cells["FechaNacimiento"].Value.ToString();
                if (DateTime.TryParse(fechaNacimientoStr, out fechaNacimiento))
                {
                    // Abre el formulario FormPostulanteNuevo para modificar el postulante seleccionado
                    using (FormPostulanteNuevo formulario = new FormPostulanteNuevo())
                    {
                        // Pasa los datos del postulante al formulario de modificación
                        formulario.CargarDatosParaModificacion(numero, nombre, apellido, email, telefono, fechaNacimiento);
                        formulario.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("La fecha de nacimiento no es válida.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un postulante para modificar.");
            }
        }


    }
}
