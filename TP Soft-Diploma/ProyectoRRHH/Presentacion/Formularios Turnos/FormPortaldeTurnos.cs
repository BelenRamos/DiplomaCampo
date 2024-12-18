﻿using Modelo;
using Negocio;
using Presentacion.Formularios_Cliente;
using Presentacion.Formularios_Turnos;
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
            FormAgendarReunion formAgendarReunion = new FormAgendarReunion();
            formAgendarReunion.Show();

        }

        private void btnAgendarTurno_Click(object sender, EventArgs e)
        {
            if (!UsuarioTienePermiso("ABM_REUNION"))
            {
                MessageBox.Show("No tiene permiso para agregar turnos.");
                return;
            }

            FormAgendarTurno formAgendarTurno = new FormAgendarTurno();

            // Manejador para actualizar datos cuando se cierre el formulario
            formAgendarTurno.FormClosed += (s, args) =>
            {
                CargarTurnos();
                MostrarTodasLasFechas();
            };

            formAgendarTurno.Show();
        }


        //private void btnAgendarTurno_Click(object sender, EventArgs e)
        //{
        //    if (!UsuarioTienePermiso("ABM_REUNION"))
        //    {
        //        MessageBox.Show("No tiene permiso para agregar clientes.");
        //        return;
        //    }
        //    FormAgendarTurno formAgendarTurno = new FormAgendarTurno();
        //    formAgendarTurno.Show();

        //}

        //private void btnEliminarFecha_Click(object sender, EventArgs e)
        //{
        //    if (!UsuarioTienePermiso("ABM_REUNION") || !UsuarioTienePermiso("ABM_TURNO"))
        //    {
        //        MessageBox.Show("No tiene permiso para agregar clientes.");
        //        return;

        //    }

        //}

        private void btnEliminarFecha_Click(object sender, EventArgs e)
        {
            // Validar permisos
            if (!UsuarioTienePermiso("ABM_REUNION") || !UsuarioTienePermiso("ABM_TURNO"))
            {
                MessageBox.Show("No tiene permiso para eliminar reuniones.");
                return;
            }

            // Verificar que haya una reunión seleccionada en dataReuniones
            if (dataReuniones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una reunión para eliminar.");
                return;
            }

            // Obtener el nro_reunion de la fila seleccionada
            int nroReunion = (int)dataReuniones.SelectedRows[0].Cells["nro_reunion"].Value;

            // Confirmar eliminación
            DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar esta reunión?",
                                                  "Confirmar eliminación",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Llamar al método de negocio para eliminar la reunión
                    negTurnosReuniones.EliminarTurnoReunion(nroReunion);

                    // Recargar la lista de reuniones y actualizar el calendario
                    CargarTurnosReuniones();
                    MostrarTodasLasFechas();

                    MessageBox.Show("Reunión eliminada exitosamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la reunión: " + ex.Message);
                }
            }
        }
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabTurnos.SelectedTab == tabDataReuniones) // Pestaña de reuniones
            {
                CargarTurnosReuniones();
            }
            else if (TabTurnos.SelectedTab == tabCalendario) // Pestaña de calendario
            {
                MostrarTodasLasFechas();
            }
        }

    }
}
