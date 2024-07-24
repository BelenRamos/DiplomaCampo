using System.Collections.Generic;
using Datos;
using Modelo;

namespace Negocio
{
    public class NegEvaluaciones
    {
        private RepoEvaluaciones repoEvaluaciones;

        private static NegEvaluaciones instancia = null;

        private NegEvaluaciones()
        {
            repoEvaluaciones = new RepoEvaluaciones();
        }

        public static NegEvaluaciones ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegEvaluaciones();
            }
            return instancia;
        }

        public List<(string NombrePostulante, string ResultadoEvaluacion)> ObtenerCandidatosConEvaluacion(int numeroOL)
        {
            return repoEvaluaciones.ObtenerCandidatosConEvaluacion(numeroOL);
        }
    }
}
