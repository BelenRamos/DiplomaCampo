using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Modelo;
using Negocio;

namespace Presentacion.Formularios_OL
{
    public partial class FormRequisitosOL : Form
    {
        private int numeroOferta;
        private NegRequisitos negRequisitos;

        public FormRequisitosOL(int numeroOferta)
        {
            InitializeComponent();
            this.numeroOferta = numeroOferta;
            negRequisitos = NegRequisitos.ObtenerInstancia();
        }

        private void FormRequisitosOL_Load(object sender, EventArgs e)
        {
            try
            {
                List<Requisitos> requisitos = negRequisitos.ObtenerRequisitosPorOferta(numeroOferta);
                listRequisitos.DataSource = requisitos;
                listRequisitos.DisplayMember = "descripcion";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los requisitos: " + ex.Message);
            }
        }
    }
}
