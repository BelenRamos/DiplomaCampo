using Modelo;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormPortaldeTurnos : Form
    {
        private NegTurnos negTurnos;
        private NegTurnosReuniones negTurnosReuniones;
        private NegUsuarios negUsuarios;
        public FormPortaldeTurnos()
        {
            InitializeComponent();
            negUsuarios = NegUsuarios.ObtenerInstancia();
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

            foreach (var turno in turnos)
            {
                fechas.Add(turno.fecha);
            }

            foreach (var turnoReunion in turnosReuniones)
            {
                fechas.Add(turnoReunion.fecha);
            }

            foreach (var fecha in fechas)
            {
                clndFechas.AddBoldedDate(fecha);
            }
            clndFechas.UpdateBoldedDates();
        }
        private bool UsuarioTienePermiso(string permisoNombre)
        {
            return negUsuarios.PermisosUsuarioActual.Exists(p => p.nombrePermiso == permisoNombre);
        }


        private void btnAgendarReunion_Click(object sender, EventArgs e)
        {
            if (!UsuarioTienePermiso("ABM_TURNO"))
            {
                MessageBox.Show("No tiene permiso para agregar clientes.");
                return;
            }
        }

        private void btnAgendarTurno_Click(object sender, EventArgs e)
        {
            if (!UsuarioTienePermiso("ABM_REUNION"))
            {
                MessageBox.Show("No tiene permiso para agregar clientes.");
                return;
            }
        }

        private void btnEliminarFecha_Click(object sender, EventArgs e)
        {
            if (!UsuarioTienePermiso("ABM_REUNION") || !UsuarioTienePermiso("ABM_TURNO"))
            {
                MessageBox.Show("No tiene permiso para agregar clientes.");
                return;
            }

        }
    }
}
