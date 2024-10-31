using Modelo;
using Datos.RepoSeguridad;
using System;

namespace Negocio
{
    public class NegSessionManager
    {
        private static NegSessionManager instancia;
        private readonly RepoSessionManager repoSessionManager;  // Dependencia a la capa de Datos
        public Usuarios UsuarioActual { get; private set; }
        public SessionManager SesionActual { get; private set; }

        // Constructor privado para el patrón Singleton
        private NegSessionManager()
        {
            repoSessionManager = new RepoSessionManager(); // Inicializar el repositorio
        }

        // Obtener la instancia Singleton
        public static NegSessionManager ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegSessionManager();
            }
            return instancia;
        }

        // Método para iniciar sesión
        public bool IniciarSesion(string email, string contrasenia)
        {
            UsuarioActual = repoSessionManager.Login(email, contrasenia);
            if (UsuarioActual != null)
            {
                SesionActual = new SessionManager
                {
                    userId = UsuarioActual.idUsuario,
                    sessionLogIn = DateTime.Now,
                    isLoggedIn = 1 // 1 para indicar que el usuario está conectado
                };

                SesionActual.sessionId = repoSessionManager.GuardarSession(SesionActual);
                return true;
            }
            return false; // Login fallido
        }

        // Método para cerrar sesión
        //public void CerrarSesion()
        //{
        //    if (UsuarioActual != null)
        //    {
        //        // Actualizar el estado de la sesión en la base de datos
        //        repoSessionManager.Logout(UsuarioActual.idUsuario);
        //        UsuarioActual = null;
        //        SesionActual = null;
        //    }
        //}

        public void CerrarSesion()
        {
            if (UsuarioActual != null && SesionActual != null)
            {
                repoSessionManager.Logout(SesionActual.sessionId); // Usa sessionId en lugar de userId
                UsuarioActual = null;
                SesionActual = null;
            }
        }


        // Método para actualizar el estado de la sesión
        public void ActualizarEstadoSesion(byte isLoggedIn)
        {
            if (SesionActual != null)
            {
                repoSessionManager.ActualizarEstadoSesion(SesionActual.sessionId, isLoggedIn);
                SesionActual.isLoggedIn = isLoggedIn; // Asignar el valor de isLoggedIn correctamente
            }
        }
    }
}
