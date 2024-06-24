using System;
using System.Collections.Generic;
using Datos;
using Modelo;

namespace Negocio
{
    public class NegClientes
    {
        private static NegClientes instancia;
        private RepoClientes repositorio;
        private List<Clientes> clientes;

        private NegClientes()
        {
            repositorio = new RepoClientes();
            clientes = new List<Clientes>();
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
                return repositorio.ObtenerTodosLosClientes();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los clientes.", ex);
            }
        }

        public List<Clientes> ObtenerClientePorID(int idCliente)
        {
            try
            {
                return repositorio.ObtenerClientePorID(idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el cliente por ID.", ex);
            }
        }

        public int AgregarClienteAOferta(int ofertaLaboralId, int clienteId)
        {
            try
            {
                return repositorio.AgregarClienteAOferta(ofertaLaboralId, clienteId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el cliente a la oferta laboral.", ex);
            }
        }

        public int EliminarClienteDeOferta(int ofertaLaboralId, int clienteId)
        {
            try
            {
                return repositorio.EliminarClienteDeOferta(ofertaLaboralId, clienteId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el cliente de la oferta laboral.", ex);
            }
        }

        public List<int> ObtenerClientesPorOferta(int ofertaLaboralId)
        {
            try
            {
                return repositorio.ObtenerClientesPorOferta(ofertaLaboralId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los clientes de la oferta laboral.", ex);
            }
        }
    }
}


//namespace Negocio
//{
//    public class NegClientes
//    {
//        private static NegClientes instancia;
//        private RepoClientes repositorioClientes;

//        private NegClientes()
//        {
//            repositorioClientes = new RepoClientes();
//        }

//        public static NegClientes ObtenerInstancia()
//        {
//            if (instancia == null)
//            {
//                instancia = new NegClientes();
//            }
//            return instancia;
//        }

//        public List<Clientes> ObtenerTodosLosClientes()
//        {
//            try
//            {
//                return repositorioClientes.ObtenerTodosLosClientes();
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public List<Clientes> ObtenerClientePorID(int idCliente)
//        {
//            try
//            {
//                return repositorioClientes.ObtenerClientePorID(idCliente);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//    }
//}
