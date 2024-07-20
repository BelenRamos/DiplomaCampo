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

        public bool EsAlta { get; internal set; }

        public FormOLNuevo()
        {
            InitializeComponent();
            negClientes = NegClientes.ObtenerInstancia();
            negEstados = NegEstados.ObtenerInstancia();
            negRequisitos = NegRequisitos.ObtenerInstancia();
            negOfertasLaborales = NegOfertasLaborales.ObtenerInstancia();

            CargarClientes();
            CargarRequisitos();
            CargarUltimoNumeroOferta();
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

        private void CargarRequisitos()
        {
            try
            {
                List<Requisitos> requisitos = negRequisitos.ObtenerRequisitos();
                clbRequisitos.DataSource = requisitos;
                clbRequisitos.DisplayMember = "descripcion";
                clbRequisitos.ValueMember = "codigo";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los requisitos: " + ex.Message);
            }
        }

        private void CargarUltimoNumeroOferta()
        {
            try
            {
                int ultimoNumeroOferta = negOfertasLaborales.ObtenerUltimoNumero();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el último número de oferta: " + ex.Message);
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
                    //ofertaActual.Estados = new List<Estados> { negEstados.ObtenerEstadoPorCodigo("1") };
                }

                ofertaActual.titulo = txtTitulo.Text;
                ofertaActual.descripcion = txtDescripcion.Text;
                ofertaActual.fechaCreacion = dtpCreacion.Value;

                ofertaActual.Clientes = new List<Clientes> { (Clientes)cbClientes.SelectedItem };

                ofertaActual.Requisitos = new List<Requisitos>();
                foreach (var item in clbRequisitos.CheckedItems)
                {
                    ofertaActual.Requisitos.Add((Requisitos)item);
                }

                //negOfertasLaborales.GuardarOfertaLaboral(ofertaActual);

                MessageBox.Show("Oferta Laboral guardada exitosamente.");
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
    }
}




