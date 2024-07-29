using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Modelo;
using Negocio;

namespace Presentacion.Formularios_OL
{
    public partial class FormCandidatosOL : Form
    {
        private int numeroOferta;
        private NegEvaluaciones negEvaluaciones;

        public FormCandidatosOL(int numero)
        {
            InitializeComponent();
            this.numeroOferta = numero;
            negEvaluaciones = NegEvaluaciones.ObtenerInstancia();
        }

        private void FormPostulantesOL_Load(object sender, EventArgs e)
        {
            try
            {
                var postulantesConEvaluacion = NegEvaluaciones.ObtenerInstancia().ObtenerPostulantesConEvaluacion(numeroOferta);

                listaCandidatos.Items.Clear();
                listaCandidatos.View = View.Details;
                listaCandidatos.Columns.Add("Nombre Postulante", -1, HorizontalAlignment.Left);
                listaCandidatos.Columns.Add("Resultado Evaluación", -2, HorizontalAlignment.Left);

                foreach (var candidato in postulantesConEvaluacion) 
                {
                    var item = new ListViewItem(candidato.NombrePostulante);
                    item.SubItems.Add(candidato.ResultadoEvaluacion);
                    listaCandidatos.Items.Add(item);
                }

                listaCandidatos.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los candidatos: " + ex.Message);
            }
        }



        private void btnSeleccionCandidato_Click(object sender, EventArgs e)
        {
            if (listaCandidatos.SelectedItems.Count > 0)
            {
                var evaluacionSeleccionada = (Evaluaciones)listaCandidatos.SelectedItems[0].Tag;
                // Actualizar el estado de la oferta laboral a "Selección"
                // Código para actualizar el estado de la oferta laboral
                // ofertasLaborales.ActualizarEstadoOferta(numeroOferta, 9); // Estado 9: Selección
                MessageBox.Show("Oferta laboral actualizada a estado 'Selección'.");
            }
            else
            {
                MessageBox.Show("Seleccione un candidato.");
            }
        }

        private void btnPreseleccion_Click(object sender, EventArgs e)
        {
            if (listaCandidatos.SelectedItems.Count > 0)
            {
                var evaluacionSeleccionada = (Evaluaciones)listaCandidatos.SelectedItems[0].Tag;
                // Actualizar el estado de la oferta laboral a "Preselección"
                // Código para actualizar el estado de la oferta laboral
                // ofertasLaborales.ActualizarEstadoOferta(numeroOferta, 6); // Estado 6: Preselección
                MessageBox.Show("Oferta laboral actualizada a estado 'Preselección'.");
            }
            else
            {
                MessageBox.Show("Seleccione un candidato.");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
