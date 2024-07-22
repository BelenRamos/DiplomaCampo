using Modelo;
using Datos;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class NegMensajes
    {
        private static NegMensajes instancia;
        private RepoMensajes repositorio;

        private NegMensajes()
        {
            repositorio = new RepoMensajes();
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
                return repositorio.GetMensajes();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todos los mensajes.", ex);
            }
        }

        public List<Mensajes> ObtenerMensajesPorCliente(int clienteId)
        {
            try
            {
                return repositorio.ObtenerMensajesPorCliente(clienteId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los mensajes del cliente.", ex);
            }
        }
    }
}
