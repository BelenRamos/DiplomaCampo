using Modelo;
using Datos.RepoSeguridad;
using System;

namespace Negocio
{
    public class NegSessionManager
    {
        private static NegSessionManager instancia;
        public Usuarios UsuarioActual { get; private set; }

        private NegSessionManager() { }

        public static NegSessionManager ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegSessionManager();
            }
            return instancia;
        }

        public void EstablecerUsuarioActual(Usuarios usuario)
        {
            UsuarioActual = usuario;
        }

        public void CerrarSesion()
        {
            UsuarioActual = null;
        }
    }
}
