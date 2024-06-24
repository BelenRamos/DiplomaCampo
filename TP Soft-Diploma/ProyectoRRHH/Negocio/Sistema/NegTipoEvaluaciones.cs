using System;
using System.Collections.Generic;
using Modelo;
using Datos;

namespace Negocio
{
    public class NegTipoEvaluaciones
    {
        private static NegTipoEvaluaciones instancia;
        private RepoTipoEvaluaciones repositorioTipoEvaluaciones;

        private NegTipoEvaluaciones()
        {
            repositorioTipoEvaluaciones = new RepoTipoEvaluaciones();
        }

        public static NegTipoEvaluaciones ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegTipoEvaluaciones();
            }
            return instancia;
        }

        public List<Tipo_Evaluaciones> ObtenerTodosLosTipoEvaluaciones()
        {
            try
            {
                return repositorioTipoEvaluaciones.ObtenerTodosLosTipoEvaluaciones();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Tipo_Evaluaciones ObtenerTipoEvaluacionPorId(int idTipoEvaluacion)
        {
            try
            {
                return repositorioTipoEvaluaciones.ObtenerTipoEvaluacionPorId(idTipoEvaluacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

