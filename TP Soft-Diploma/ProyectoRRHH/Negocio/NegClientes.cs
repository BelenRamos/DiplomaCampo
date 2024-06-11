using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Datos; 


namespace Negocio
{
    public class NegClientes
    {
        private static NegClientes instancia;
        private RepoClientes repositorioClientes;

        private NegClientes()
        {
            repositorioClientes = new RepoClientes();
        }

        public static NegClientes ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegClientes();
            }
            return instancia;
        }

        public List<Clientes> ObtenerTodosLosClientes()
        {
            try
            {
                return repositorioClientes.ObtenerTodosLosClientes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Clientes> ObtenerClientePorID(int idCliente)
        {
            try
            {
                return repositorioClientes.ObtenerClientePorID(idCliente);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
