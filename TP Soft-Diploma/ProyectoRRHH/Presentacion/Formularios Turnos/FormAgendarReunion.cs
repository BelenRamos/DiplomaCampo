using Modelo;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.Formularios_Turnos
{
    public partial class FormAgendarReunion : Form
    {
        private NegClientes negClientes;
        private NegTurnosReuniones negTurnosReuniones;
        public FormAgendarReunion()
        {
            InitializeComponent();
            negClientes = NegClientes.ObtenerInstancia();
            negTurnosReuniones = new NegTurnosReuniones();

            CargarClientes();
            CargarHorarios(); // Asegúrate de llamar a CargarHorarios aquí
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

        private void CargarHorarios()
        {
            try
            {
                List<string> horarios = new List<string>
                {
                    "10:00", "10:30", "11:00", "11:30",
                    "14:00", "14:30", "15:00", "15:30",
                    "16:00", "16:30"
                };

                cbHorarios.DataSource = horarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los horarios: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaSeleccionada = calenderAgenda.SelectionRange.Start;

                TurnosReuniones nuevoTurno = new TurnosReuniones
                {
                    fecha = fechaSeleccionada,
                    horario = TimeSpan.Parse(cbHorarios.SelectedItem.ToString()),
                    disponible = 1,
                    id_cliente = (int)cbClientes.SelectedValue
                };

                negTurnosReuniones.AgregarTurnoReunion(nuevoTurno);
                MessageBox.Show("Reunión guardada exitosamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la reunión: " + ex.Message);
            }
        }
    }
}
