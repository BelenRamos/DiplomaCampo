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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofertaActual == null)
                {
                    ofertaActual = new Ofertas_Laborales();
                    ofertaActual.numero = negOfertasLaborales.ObtenerUltimoNumero() + 1;
                }

                ofertaActual.titulo = txtTitulo.Text;
                ofertaActual.descripcion = txtDescripcion.Text;
                ofertaActual.fechaCreacion = dtpCreacion.Value;

                var clienteSeleccionado = (Clientes)cbClientes.SelectedItem;
                List<int> clienteIds = new List<int> { clienteSeleccionado.id };

                List<int> requisitoIds = new List<int>();
                foreach (var item in clbRequisitos.CheckedItems)
                {
                    requisitoIds.Add(((Requisitos)item).id);
                }

                // Llama al método para guardar la oferta
                negOfertasLaborales.AltaOfertaLaboral(ofertaActual, clienteIds, new List<int>(), new List<int>(), requisitoIds);

                MessageBox.Show("Oferta Laboral guardada exitosamente.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la oferta laboral: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormOLNuevo_Load(object sender, EventArgs e)
        {
            try
            {
                List<Requisitos> requisitos = negRequisitos.ObtenerRequisitos();
                clbRequisitos.Items.Clear();
                foreach (var requisito in requisitos)
                {
                    clbRequisitos.Items.Add(requisito);
                }

                // Configurar DisplayMember para mostrar la descripción del requisito
                clbRequisitos.DisplayMember = "descripcion";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los requisitos: " + ex.Message);
            }
        }
    }
}
