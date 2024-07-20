using Modelo;
using Datos;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class NegClientesTels
    {
        private static NegClientesTels instancia;
        private RepoClientesTels repositorio;
        private List<Clientes_Telefonos> clientesTelefonos;

        private NegClientesTels()
        {
            repositorio = new RepoClientesTels();
            clientesTelefonos = new List<Clientes_Telefonos>();
        }

        public static NegClientesTels ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegClientesTels();
            }
            return instancia;
        }

        public void AgregarTelefono(Clientes_Telefonos clienteTelefono)
        {
            repositorio.AgregarTelefono(clienteTelefono);
        }

        public List<Clientes_Telefonos> ObtenerTelefonosPorCliente(int clienteId)
        {
            return repositorio.ObtenerTelefonosPorCliente(clienteId);
        }
    }
}
