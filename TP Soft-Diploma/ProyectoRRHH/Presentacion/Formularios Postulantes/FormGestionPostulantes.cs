using Negocio;
using Presentacion.Formularios_Postulantes;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormGestionPostulantes : Form
    {
        private NegPostulantes postulantes;

        public FormGestionPostulantes()
        {
            InitializeComponent();
            postulantes = NegPostulantes.ObtenerInstancia();
        }

        private void FormGestionPostulantes_Load(object sender, EventArgs e)
        {
            InicializarComboCandidatos();
            CargarPostulantes();
        }

        private void InicializarComboCandidatos()
        {
            comboCandidatos.Items.Add("Todos");
            comboCandidatos.Items.Add("Candidatos");
            comboCandidatos.Items.Add("No Candidatos");
            comboCandidatos.SelectedIndex = 0;
            comboCandidatos.SelectedIndexChanged += ComboCandidatos_SelectedIndexChanged;
        }

        private void ComboCandidatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPostulantes(comboCandidatos.SelectedItem.ToString());
        }

        private void CargarPostulantes(string filtro = "Todos")
        {
            try
            {
                dgvPostulantes.DataSource = postulantes.ObtenerPostulantesFiltrados(filtro);
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
                if (formulario.ShowDialog() == DialogResult.OK)
                {
                    // Refresca los datos después de agregar un nuevo postulante
                    CargarPostulantes(comboCandidatos.SelectedItem.ToString());
                }
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
                            // Refresca los datos después de eliminar un postulante
                            CargarPostulantes(comboCandidatos.SelectedItem.ToString());
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
                        if (formulario.ShowDialog() == DialogResult.OK)
                        {
                            // Refresca los datos después de modificar un postulante
                            CargarPostulantes(comboCandidatos.SelectedItem.ToString());
                        }
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
