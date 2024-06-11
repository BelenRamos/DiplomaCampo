using System;
using System.Collections.Generic;
using Modelo;
using Datos;

namespace Negocio
{
    public class NegEstados
    {
        private static NegEstados instancia;
        private RepoEstados repositorioEstados;

        private NegEstados()
        {
            repositorioEstados = new RepoEstados();
        }

        public static NegEstados ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegEstados();
            }
            return instancia;
        }

        public List<Estados> ObtenerTodosLosEstados()
        {
            try
            {
                return repositorioEstados.ObtenerTodosLosEstados();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Estados> ObtenerEstadoPorCodigo(int codigoEstado)
        {
            try
            {
                return repositorioEstados.ObtenerEstadoPorCodigo(codigoEstado);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

