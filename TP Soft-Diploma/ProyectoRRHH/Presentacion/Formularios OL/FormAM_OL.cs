using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Negocio;
using Modelo;

namespace Presentacion.Formularios_OL
{
    public partial class FormAM_OL : Form
    {
        private Dictionary<int, string> requisitosDict;

        public bool EsAlta { get; set; } // Hacer pública la propiedad EsAlta
        public Ofertas_Laborales Oferta { get; set; } // Hacer pública la propiedad Oferta

        public FormAM_OL()
        {
            InitializeComponent();
            requisitosDict = new Dictionary<int, string>();
            CargarDescripcionesRequisitos();
        }

        private void FormAM_OL_Load(object sender, EventArgs e)
        {
            if (!EsAlta && Oferta != null)
            {
                txtTitulo.Text = Oferta.titulo;
                txtDescripcion.Text = Oferta.descripcion;
                //dtpFechaCreacion.Value = Oferta.fechaCreacion.HasValue ? Oferta.fechaCreacion.Value : DateTime.Now;

                // Marcar los requisitos asociados a la oferta
                foreach (var requisito in Oferta.Requisitos)
                {
                    for (int i = 0; i < ListaRequisitos.Items.Count; i++)
                    {
                        if (ListaRequisitos.Items[i].ToString() == requisito.descripcion)
                        {
                            ListaRequisitos.SetItemChecked(i, true);
                            break;
                        }
                    }
                }
            }
        }

        private void CargarDescripcionesRequisitos()
        {
            try
            {
                NegRequisitos negRequisitos = NegRequisitos.ObtenerInstancia();
                List<(int Id, string Descripcion)> requisitos = negRequisitos.ObtenerRequisitos();

                ListaRequisitos.Items.Clear();
                requisitosDict.Clear();
                foreach (var requisito in requisitos)
                {
                    requisitosDict[requisito.Id] = requisito.Descripcion;
                    ListaRequisitos.Items.Add(requisito.Descripcion);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las descripciones de los requisitos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void btnGuardar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        NegOfertasLaborales ofertasLaborales = NegOfertasLaborales.ObtenerInstancia();
        //        List<int> requisitoIds = new List<int>();

        //        foreach (var item in ListaRequisitos.CheckedItems)
        //        {
        //            string descripcion = item.ToString();
        //            int requisitoId = requisitosDict.FirstOrDefault(x => x.Value == descripcion).Key;
        //            if (requisitoId != 0)
        //            {
        //                requisitoIds.Add(requisitoId);
        //            }
        //        }

        //        if (EsAlta)
        //        {
        //            // Obtener el cliente seleccionado del combo box
        //            Cliente clienteSeleccionado = (Cliente)cbClientesOL.SelectedItem;

        //            // Crear una nueva oferta laboral con los datos necesarios
        //            var nuevaOferta = new Ofertas_Laborales
        //            {
        //                numero = ofertasLaborales.ObtenerUltimoNumero() + 1,
        //                titulo = txtTitulo.Text,
        //                descripcion = txtDescripcion.Text,
        //                fechaCreacion = DateTime.Today, // La fecha de creación es el día actual
        //                fechaCierre = DateTime.MinValue,
        //                fechaPublicacion = DateTime.MinValue,
        //                estado = "Abierta", // Establecer el estado como "Abierta"
        //                clienteId = clienteSeleccionado.Id // Asignar el ID del cliente seleccionado
        //            };

        //            // Agregar la oferta laboral
        //            ofertasLaborales.AltaOfertaLaboral(nuevaOferta, new List<int>(), new List<int>(), new List<int>(), requisitoIds);
        //        }
        //        else
        //        {
        //            // Modificar la oferta laboral existente
        //            Oferta.titulo = txtTitulo.Text;
        //            Oferta.descripcion = txtDescripcion.Text;

        //            ofertasLaborales.ModificarOfertaLaboral(Oferta);
        //        }

        //        this.DialogResult = DialogResult.OK;
        //        this.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al guardar la oferta laboral: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}


