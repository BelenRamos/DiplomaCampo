using System.Collections.Generic;
using Datos;
using Modelo;

namespace Negocios
{
    public class NegClientes
    {
        private readonly RepoClientes _repoClientes;

        public NegClientes(string connectionString)
        {
            _repoClientes = new RepoClientes(connectionString);
        }

        public List<Clientes> ObtenerClientes()
        {
            return _repoClientes.GetClientes();
        }

        public Clientes ObtenerClientePorId(int id)
        {
            return _repoClientes.GetClienteById(id);
        }

        public void AgregarCliente(Clientes cliente)
        {
            _repoClientes.AddCliente(cliente);
        }

        public void ActualizarCliente(Clientes cliente)
        {
            _repoClientes.UpdateCliente(cliente);
        }

        public void EliminarCliente(int id)
        {
            _repoClientes.DeleteCliente(id);
        }
    }
}
