using System.Collections.Generic;
using Datos;
using Modelo;

namespace Negocio
{
    public class NegClientes
    {
        private static NegClientes instancia;

        public NegClientes()
        {
            repoClientes = new RepoClientes();
        }

        public List<Clientes> ObtenerClientes()
        {
            return repoClientes.GetClientes();
        }

        public Clientes ObtenerClientePorId(int id)
        {
            return repoClientes.GetClienteById(id);
        }

        public void AgregarCliente(Clientes cliente)
        {
            repoClientes.AddCliente(cliente);
        }

        public void ActualizarCliente(Clientes cliente)
        {
            repoClientes.UpdateCliente(cliente);
        }

        public void EliminarCliente(int id)
        {
            repoClientes.DeleteCliente(id);
        }

        public static NegClientes ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegClientes();
            }
            return instancia;
        }

        public int ObtenerPorcentajeClientes(int maxClientes)
        {
            int totalClientes = repoClientes.ObtenerTotalClientes();
            return (int)((float)totalClientes / maxClientes * 100);
        }
    }
}
