using iTextSharp.text;
using iTextSharp.text.pdf;
using Modelo;
using System.Collections.Generic;

namespace Datos
{
    public class Reportes
    {
        public void GenerarReporteClientes(List<Clientes> clientes, string rutaArchivo)
        {
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new System.IO.FileStream(rutaArchivo, System.IO.FileMode.Create));
            document.Open();

            document.Add(new Paragraph("Reporte de Clientes") { Alignment = Element.ALIGN_CENTER, Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20) });

            PdfPTable table = new PdfPTable(2); // Ajusta el número de columnas según las propiedades de Clientes
            table.AddCell(new PdfPCell(new Phrase("ID")));
            table.AddCell(new PdfPCell(new Phrase("Nombre")));
            // Agrega más celdas de encabezado según sea necesario

            foreach (Clientes cliente in clientes)
            {
                table.AddCell(new PdfPCell(new Phrase(cliente.id.ToString())));
                table.AddCell(new PdfPCell(new Phrase(cliente.nombre)));
                // Agrega más celdas según las propiedades de Clientes
            }

            document.Add(table);
            document.Close();
        }

        public void GenerarReportePostulantes(List<Postulantes> postulantes, string rutaArchivo)
        {
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new System.IO.FileStream(rutaArchivo, System.IO.FileMode.Create));
            document.Open();

            document.Add(new Paragraph("Reporte de Postulantes") { Alignment = Element.ALIGN_CENTER, Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20) });

            PdfPTable table = new PdfPTable(6); // Ajusta el número de columnas según las propiedades de Postulantes
            table.AddCell(new PdfPCell(new Phrase("Número")));
            table.AddCell(new PdfPCell(new Phrase("Nombre")));
            table.AddCell(new PdfPCell(new Phrase("Apellido")));
            table.AddCell(new PdfPCell(new Phrase("Email")));
            table.AddCell(new PdfPCell(new Phrase("Teléfono")));
            table.AddCell(new PdfPCell(new Phrase("Fecha Nacimiento")));
            // Agrega más celdas de encabezado según sea necesario

            foreach (Postulantes postulante in postulantes)
            {
                table.AddCell(new PdfPCell(new Phrase(postulante.numero.ToString())));
                table.AddCell(new PdfPCell(new Phrase(postulante.nombre)));
                table.AddCell(new PdfPCell(new Phrase(postulante.apellido)));
                table.AddCell(new PdfPCell(new Phrase(postulante.mail)));
                table.AddCell(new PdfPCell(new Phrase(postulante.telefono)));
                table.AddCell(new PdfPCell(new Phrase(postulante.fechaNacimiento?.ToString("dd/MM/yyyy") ?? "N/A")));
                // Agrega más celdas según las propiedades de Postulantes
            }

            document.Add(table);
            document.Close();
        }
    }
}


