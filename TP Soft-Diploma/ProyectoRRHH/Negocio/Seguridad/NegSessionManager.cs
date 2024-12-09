using Modelo;
using Datos.RepoSeguridad;
using System;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace Negocio
{
    public class NegSessionManager
    {
        private static NegSessionManager instancia;
        private readonly RepoSessionManager repoSessionManager;  
        public Usuarios UsuarioActual { get; private set; }
        public SessionManager SesionActual { get; private set; }

        
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

        public DataTable ObtenerReporteSesiones(DateTime fechaDesde, DateTime fechaHasta)
        {
            return repoSessionManager.ObtenerReporteSesiones(fechaDesde, fechaHasta);
        }
    }
}
