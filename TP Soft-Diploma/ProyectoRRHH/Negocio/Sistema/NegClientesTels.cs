using System.Collections.Generic;
using Datos;
using Modelo;

namespace Negocios
{
    public class NegClientesTelefonos
    {
        private readonly RepoClientesTelefonos _repoClientesTelefonos;

        public NegClientesTelefonos(string connectionString)
        {
            _repoClientesTelefonos = new RepoClientesTelefonos(connectionString);
        }

        public List<Clientes_Telefonos> ObtenerTelefonosPorClienteId(int id_cliente)
        {
            return _repoClientesTelefonos.GetTelefonosByClienteId(id_cliente);
        }

        public void AgregarTelefono(Clientes_Telefonos telefono)
        {
            _repoClientesTelefonos.AddTelefono(telefono);
        }

        public void EliminarTelefono(int id_cliente, string telefono)
        {
            _repoClientesTelefonos.DeleteTelefono(id_cliente, telefono);
        }
    }
}
