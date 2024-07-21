using System.Collections.Generic;
using Datos;
using Modelo;

namespace Negocio
{
    public class NegClientesTels
    {
        private static NegClientesTels instancia;
        private RepoClientesTels repoClientesTels;

        private NegClientesTels()
        {
            repoClientesTels = new RepoClientesTels();
        }

        public static NegClientesTels ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegClientesTels();
            }
            return instancia;
        }

        public List<Clientes_Telefonos> ObtenerTelefonosPorClienteId(int clienteId)
        {
            return repoClientesTels.ObtenerTelefonosPorCliente(clienteId);
        }

        public void EliminarTelefonosPorClienteId(int clienteId)
        {
            repoClientesTels.EliminarTelefonosPorClienteId(clienteId);
        }

        public void AgregarTelefono(Clientes_Telefonos clienteTelefono)
        {
            repoClientesTels.AgregarTelefono(clienteTelefono);
        }
    }
}
