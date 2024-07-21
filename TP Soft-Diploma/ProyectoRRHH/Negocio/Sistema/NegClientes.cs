using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Modelo;

namespace Negocio
{
    public class NegClientes
    {
        private static NegClientes instancia;
        private RepoClientes repoClientes;

        private NegClientes()
        {
            repoClientes = new RepoClientes();
        }

        public static NegClientes ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegClientes();
            }
            return instancia;
        }

        public List<Clientes> ObtenerClientes()
        {
            return repoClientes.GetClientes();
        }

        public Clientes ObtenerClientePorId(int id)
        {
            return repoClientes.ObtenerClienteById(id);
        }

        public void AgregarCliente(Clientes cliente)
        {
            cliente.id = repoClientes.ObtenerUltimoId() + 1;
            repoClientes.AgregarCliente(cliente);
        }

        public void ModificarCliente(Clientes cliente)
        {
            repoClientes.ActualizarCliente(cliente);
        }

        public void EliminarCliente(int id)
        {
            repoClientes.EliminarCliente(id);
        }

        public int ObtenerUltimoId()
        {
            return repoClientes.ObtenerUltimoId();
        }

        public int ObtenerPorcentajeClientes(int maxClientes)
        {
            int totalPostulantes = repoClientes.ObtenerTotalClientes();
            return (int)((float)totalPostulantes / maxClientes * 100);
        }
    }


}
