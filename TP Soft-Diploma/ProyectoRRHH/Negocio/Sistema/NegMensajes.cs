using System;
using System.Collections.Generic;
using Modelo;
using Datos;

namespace Negocio
{
    public class NegMensajes
    {
        private static NegMensajes instancia;
        private RepoMensajes repositorioMensajes;

        private NegMensajes()
        {
            repositorioMensajes = new RepoMensajes();
        }

        public static NegMensajes ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegMensajes();
            }
            return instancia;
        }

        public List<Mensajes> ObtenerTodosLosMensajes()
        {
            try
            {
                return repositorioMensajes.ObtenerTodosLosMensajes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Mensajes> ObtenerMensajePorNumero(int numeroMensaje)
        {
            try
            {
                return repositorioMensajes.ObtenerMensajePorNumero(numeroMensaje);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

