using Modelo;
using Negocio;
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
    public partial class FormPortaldeTurnos : Form
    {
        private NegTurnos negTurnos;
        private NegTurnosReuniones negTurnosReuniones;
        public FormPortaldeTurnos()
        {
            InitializeComponent();
            negTurnos = new NegTurnos();
            negTurnosReuniones = new NegTurnosReuniones();
        }

        private void FormPortaldeTurnos_Load(object sender, EventArgs e)
        {
            CargarTurnos();
            CargarTurnosReuniones();
            MostrarTodasLasFechas();
        }

        private void CargarTurnos()
        {
            List<Turnos> turnos = negTurnos.ObtenerTurnos();
            dataTurnos.DataSource = turnos;
        }

        private void CargarTurnosReuniones()
        {
            List<TurnosReuniones> turnosReuniones = negTurnosReuniones.ObtenerTurnosReuniones();
            dataReuniones.DataSource = turnosReuniones;
        }

        private void MostrarTodasLasFechas()
        {
            List<Turnos> turnos = (List<Turnos>)dataTurnos.DataSource;
            List<TurnosReuniones> turnosReuniones = (List<TurnosReuniones>)dataReuniones.DataSource;

            var fechas = new HashSet<DateTime>();

            // Agregar fechas de turnos
            foreach (var turno in turnos)
            {
                fechas.Add(turno.fecha);
            }

            // Agregar fechas de reuniones
            foreach (var turnoReunion in turnosReuniones)
            {
                fechas.Add(turnoReunion.fecha);
            }

            // Mostrar fechas en el MonthCalendar
            foreach (var fecha in fechas)
            {
                clndFechas.AddBoldedDate(fecha);
            }
            clndFechas.UpdateBoldedDates();
        }


        private void btnAgendarReunion_Click(object sender, EventArgs e)
        {

        }

        private void btnAgendarTurno_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminarFecha_Click(object sender, EventArgs e)
        {

        }
    }
}
