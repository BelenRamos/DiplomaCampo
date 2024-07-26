using System;
using Modelo;
using Datos.RepoSeguridad;

namespace Negocio
{
    public class NegSessionManager
    {
        private readonly RepoSessionManager repoSessionManager;
        private static NegSessionManager instancia;
        public Usuarios UsuarioActual { get; private set; }

        private NegSessionManager()
        {
            repoSessionManager = new RepoSessionManager();
        }

        public static NegSessionManager ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegSessionManager();
            }
            return instancia;
        }

        public Usuarios ValidarUsuario(string email, string pass)
        {
            try
            {
                return repoSessionManager.Login(email, pass);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar usuario.", ex);
            }
        }

        public bool CerrarSesion(int userId)
        {
            try
            {
                return repoSessionManager.Logout(userId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cerrar sesión.", ex);
            }
        }



    }
}
