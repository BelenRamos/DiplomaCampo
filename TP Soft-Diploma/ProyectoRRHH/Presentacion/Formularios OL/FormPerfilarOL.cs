using Modelo;
using Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.Formularios_OL
{
    public partial class FormPerfilarOL : Form
    {
        private NegUsuarios negUsuarios;
        public FormPerfilarOL(int numero)
        {
            InitializeComponent();
            negUsuarios = NegUsuarios.ObtenerInstancia();
        }
        private void FormPerfilarOL_Load(object sender, EventArgs e)
        {
            CargarPerfilesEnLista();
        }
        private void CargarPerfilesEnLista()
        {
            try
            {
                NegPerfiles negPerfiles = NegPerfiles.ObtenerInstancia();
                List<Perfiles> perfiles = negPerfiles.ObtenerTodosLosPerfiles();

                listaPerfiles.Items.Clear();
                foreach (Perfiles perfil in perfiles)
                {
                    listaPerfiles.Items.Add(perfil.nombre);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los perfiles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        
    }
}
