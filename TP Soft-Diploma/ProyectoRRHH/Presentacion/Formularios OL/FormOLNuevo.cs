using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Modelo;
using Negocio;

namespace Presentacion.Formularios_OL
{
    public partial class FormOLNuevo : Form
    {
        private NegClientes negClientes;
        private NegEstados negEstados;
        private NegRequisitos negRequisitos;
        private NegOfertasLaborales negOfertasLaborales;
        private Ofertas_Laborales ofertaActual;
        internal Ofertas_Laborales Oferta;

        public bool EsAlta { get; internal set; }

        public FormOLNuevo()
        {
            InitializeComponent();
            negClientes = NegClientes.ObtenerInstancia();
            negEstados = NegEstados.ObtenerInstancia();
            negRequisitos = NegRequisitos.ObtenerInstancia();
            negOfertasLaborales = NegOfertasLaborales.ObtenerInstancia();

            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                List<Clientes> clientes = negClientes.ObtenerClientes();
                cbClientes.DataSource = clientes;
                cbClientes.DisplayMember = "nombre";
                cbClientes.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los clientes: " + ex.Message);
            }
        }

        private void FormOLNuevo_Load(object sender, EventArgs e)
        {
            try
            {
                // Cargar lista de requisitos
                List<Requisitos> requisitos = negRequisitos.ObtenerRequisitos();
                clbRequisitos.Items.Clear();
                foreach (var requisito in requisitos)
                {
                    clbRequisitos.Items.Add(requisito);
                }
                
                clbRequisitos.DisplayMember = "descripcion";

                // Si no es un alta, cargar datos de la oferta actual
                if (!EsAlta && Oferta != null)
                {
                    txtTitulo.Text = Oferta.titulo;
                    txtDescripcion.Text = Oferta.descripcion;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los requisitos: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que los campos de título y descripción no estén vacíos
                if (string.IsNullOrWhiteSpace(txtTitulo.Text))
                {
                    MessageBox.Show("El campo de título no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                {
                    MessageBox.Show("El campo de descripción no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Validar que haya al menos un requisito seleccionado
                if (clbRequisitos.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar al menos un requisito.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear una nueva oferta si no existe
                if (ofertaActual == null)
                {
                    ofertaActual = new Ofertas_Laborales
                    {
                        numero = negOfertasLaborales.ObtenerUltimoNumero() + 1
                    };
                }

                // Asignar valores a la oferta
                ofertaActual.titulo = txtTitulo.Text;
                ofertaActual.descripcion = txtDescripcion.Text;
                

                // Obtener cliente seleccionado
                var clienteSeleccionado = (Clientes)cbClientes.SelectedItem;
                if (clienteSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idCliente = clienteSeleccionado.id;

                // Obtener los requisitos seleccionados
                List<int> requisitoIds = new List<int>();
                foreach (var item in clbRequisitos.CheckedItems)
                {
                    requisitoIds.Add(((Requisitos)item).id);
                }

                if (EsAlta)
                {
                    negOfertasLaborales.AltaOfertaLaboral(ofertaActual, idCliente, requisitoIds);
                }
                else
                {
                    negOfertasLaborales.ModificarOfertaLaboral(ofertaActual);
                }

                MessageBox.Show("Oferta Laboral guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la oferta laboral: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
