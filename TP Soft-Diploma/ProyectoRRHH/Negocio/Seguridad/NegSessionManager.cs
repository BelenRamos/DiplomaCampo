using System;
using Modelo;
using Datos.RepoSeguridad;

namespace Negocio
{
    public class NegSessionManager
    {
        private readonly RepoSessionManager repoSessionManager;

        public NegSessionManager()
        {
            repoSessionManager = new RepoSessionManager();
        }

        public Usuarios ValidarUsuario(string email, string pass)
        {
            return repoSessionManager.Login(email, pass);
        }

        public bool CerrarSesion(int userId)
        {
            return repoSessionManager.Logout(userId);
        }
    }
}
