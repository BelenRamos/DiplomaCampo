using Datos;
using System.Collections.Generic;
using System;
using Modelo;



namespace Negocio
{
    public class NegEstados
    {
        private static NegEstados instancia;
        private RepoEstados repositorio;

        private NegEstados()
        {
            repositorio = new RepoEstados();
        }

        public static NegEstados ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegEstados();
            }
            return instancia;
        }

        public List<Estados> ObtenerEstados()
        {
            try
            {
                return repositorio.ObtenerEstados();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los estados.", ex);
            }
        }

        public List<Estados> ObtenerEstadoPorCodigo(int codigoEstado)
        {
            try
            {
                return repositorio.ObtenerEstadoPorCodigo(codigoEstado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el estado por código.", ex);
            }
        }

        public List<int> ObtenerEstadosPorOferta(int ofertaLaboralId)
        {
            try
            {
                return repositorio.ObtenerEstadosPorOferta(ofertaLaboralId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los estados de la oferta laboral.", ex);
            }
        }

        public Estados ObtenerEstadoPorDesignacion(string designacionEstado)
        {
            try
            {
                return repositorio.ObtenerEstadoPorDesignacion(designacionEstado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el estado por designación.", ex);
            }
        }
    }
}
