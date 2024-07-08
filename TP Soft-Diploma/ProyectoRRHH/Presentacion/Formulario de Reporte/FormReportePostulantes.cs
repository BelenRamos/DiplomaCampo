using Modelo;
using Negocio;
using System;
using System.Collections.Generic;

using System.Windows.Forms;

namespace Presentacion.Formulario_de_Reporte
{
    public partial class FormReportePostulantes : Form
    {
        private NegPostulantes negPostulantes;
        private NegReportes negReportes;

        public FormReportePostulantes()
        {
            InitializeComponent();
            negPostulantes = NegPostulantes.ObtenerInstancia();
            negReportes = NegReportes.ObtenerInstancia();
        }

        private void FormReportePostulantes_Load(object sender, EventArgs e)
        {
            List<Postulantes> postulantes = negPostulantes.ObtenerTodosLosPostulantes();
            dgvDataPostulantes.DataSource = postulantes;
        }

        private void btnGenerarReportePostulantes_Click(object sender, EventArgs e)
        {
            try
            {
                List<Postulantes> postulantes = (List<Postulantes>)dgvDataPostulantes.DataSource;
                if (postulantes == null || postulantes.Count == 0)
                {
                    MessageBox.Show("No hay datos de postulantes para generar el reporte.");
                    return;
                }

                string rutaDirectorio = @"C:\Reportes";
                if (!System.IO.Directory.Exists(rutaDirectorio))
                {
                    System.IO.Directory.CreateDirectory(rutaDirectorio);
                }

                string rutaArchivo = System.IO.Path.Combine(rutaDirectorio, "reporte_postulantes.pdf");
                negReportes.GenerarReportePostulantes(postulantes, rutaArchivo);
                MessageBox.Show("Reporte de Postulantes generado exitosamente en " + rutaArchivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}");
            }
        }
    }
}

