using iTextSharp.text;
using iTextSharp.text.pdf;
using Modelo;
using System.Collections.Generic;
using System.IO;

namespace Datos
{
    public class Reportes
    {
        private string rutaBase = @"C:\Reportes"; // Carpeta donde se guardarán los reportes

        public Reportes()
        {
            // Crear la carpeta de reportes si no existe
            if (!Directory.Exists(rutaBase))
            {
                Directory.CreateDirectory(rutaBase);
            }
        }

        public void GenerarReporteClientes(List<Clientes> clientes, string nombreArchivo)
        {
            string rutaArchivo = Path.Combine(rutaBase, nombreArchivo);
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(rutaArchivo, FileMode.Create));
            document.Open();

            document.Add(new Paragraph("Reporte de Clientes") { Alignment = Element.ALIGN_CENTER, Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20) });

            PdfPTable table = new PdfPTable(3); // 3 columnas para ID, Nombre y Mail
            table.WidthPercentage = 100;

            // Establece el alto fijo para las celdas del encabezado
            PdfPCell cell = new PdfPCell(new Phrase("ID")) { FixedHeight = 30f };
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Nombre")) { FixedHeight = 30f };
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Mail")) { FixedHeight = 30f };
            table.AddCell(cell);

            foreach (Clientes cliente in clientes)
            {
                table.AddCell(new PdfPCell(new Phrase(cliente.id.ToString())) { FixedHeight = 20f });
                table.AddCell(new PdfPCell(new Phrase(cliente.nombre)) { FixedHeight = 20f });
                table.AddCell(new PdfPCell(new Phrase(cliente.mail)) { FixedHeight = 20f });
            }

            document.Add(table);
            document.Close();
        }

        public void GenerarReportePostulantes(List<Postulantes> postulantes, string nombreArchivo)
        {
            string rutaArchivo = Path.Combine(rutaBase, nombreArchivo);
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(rutaArchivo, FileMode.Create));
            document.Open();

            document.Add(new Paragraph("Reporte de Postulantes") { Alignment = Element.ALIGN_CENTER, Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20) });

            PdfPTable table = new PdfPTable(6); // 6 columnas para Número, Nombre, Apellido, Email, Teléfono y Fecha de Nacimiento
            table.WidthPercentage = 100;

            // Establece el alto fijo para las celdas del encabezado
            PdfPCell cell = new PdfPCell(new Phrase("Número")) { FixedHeight = 30f };
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Nombre")) { FixedHeight = 30f };
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Apellido")) { FixedHeight = 30f };
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Email")) { FixedHeight = 30f };
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Teléfono")) { FixedHeight = 30f };
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Fecha Nacimiento")) { FixedHeight = 30f };
            table.AddCell(cell);

            foreach (Postulantes postulante in postulantes)
            {
                table.AddCell(new PdfPCell(new Phrase(postulante.numero.ToString())) { FixedHeight = 20f });
                table.AddCell(new PdfPCell(new Phrase(postulante.nombre)) { FixedHeight = 20f });
                table.AddCell(new PdfPCell(new Phrase(postulante.apellido)) { FixedHeight = 20f });
                table.AddCell(new PdfPCell(new Phrase(postulante.mail)) { FixedHeight = 20f });
                table.AddCell(new PdfPCell(new Phrase(postulante.telefono)) { FixedHeight = 20f });
                table.AddCell(new PdfPCell(new Phrase(postulante.fechaNacimiento?.ToString("dd/MM/yyyy") ?? "N/A")) { FixedHeight = 20f });
            }

            document.Add(table);
            document.Close();
        }

    }
}



