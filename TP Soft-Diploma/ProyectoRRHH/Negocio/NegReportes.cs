using Datos;
using Modelo;
using System.Collections.Generic;

namespace Negocio
{
    public class NegReportes
    {
        private static NegReportes instancia;
        private Reportes reportes;

        private NegReportes()
        {
            reportes = new Reportes();
        }

        public static NegReportes ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegReportes();
            }
            return instancia;
        }

        public void GenerarReporteClientes(List<Clientes> clientes, string nombreArchivo)
        {
            reportes.GenerarReporteClientes(clientes, nombreArchivo);
        }

        public void GenerarReportePostulantes(List<Postulantes> postulantes, string nombreArchivo)
        {
            reportes.GenerarReportePostulantes(postulantes, nombreArchivo);
        }
    }

}
