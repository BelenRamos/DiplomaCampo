using System;
using System.Collections.Generic;
using Modelo;
using Datos;

namespace Negocio
{
    public class NegClientesTels
    {
        private static NegClientesTels instancia;
        private RepoClientesTels repositorioClientesTels;

        private NegClientesTels()
        {
            repositorioClientesTels = new RepoClientesTels();
        }

        public static NegClientesTels ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegClientesTels();
            }
            return instancia;
        }

        public List<Clientes_Telefonos> ObtenerTodosLosTelefonos()
        {
            try
            {
                return repositorioClientesTels.ObtenerTodosLosTelefonos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Clientes_Telefonos> ObtenerTelefonosPorIDCliente(int idCliente)
        {
            try
            {
                return repositorioClientesTels.ObtenerTelefonosPorIDCliente(idCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
