using System;
using System.Collections.Generic;
using Modelo;
using Datos;

namespace Negocio
{
    public class NegEvaluaciones
    {
        private static NegEvaluaciones instancia;
        private RepoEvaluaciones repositorioEvaluaciones;

        private NegEvaluaciones()
        {
            repositorioEvaluaciones = new RepoEvaluaciones();
        }

        public static NegEvaluaciones ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegEvaluaciones();
            }
            return instancia;
        }

        public List<Evaluaciones> ObtenerTodasLasEvaluaciones()
        {
            try
            {
                return repositorioEvaluaciones.ObtenerTodasLasEvaluaciones();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Evaluaciones> ObtenerEvaluacionPorNumero(int numeroEvaluacion)
        {
            try
            {
                return repositorioEvaluaciones.ObtenerEvaluacionPorNumero(numeroEvaluacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


