using Datos.RepoSeguridad;
using Modelo;
using System;

namespace Datos.Decorator
{
    public class SessionManagerDecorator : ISessionManager
    {
        private readonly ISessionManager _decoratedSessionManager;

        public SessionManagerDecorator(ISessionManager decoratedSessionManager)
        {
            _decoratedSessionManager = decoratedSessionManager;
        }

        public Usuarios Login(string email, string pass)
        {
            var usuario = _decoratedSessionManager.Login(email, pass);

            if (usuario != null)
            {
                Console.WriteLine($"Usuario {usuario.nombreUsuario} inició sesión - Hora: {DateTime.Now}");
            }

            return usuario;
        }

        public bool Logout(int userId)
        {
            var resultado = _decoratedSessionManager.Logout(userId);

            if (resultado)
            {
                Console.WriteLine($"Usuario {userId} cerró sesión - Hora: {DateTime.Now}");
            }

            return resultado;
        }

        public bool ActualizarEstadoSesion(int sessionId, bool isLoggedIn)
        {
            var resultado = _decoratedSessionManager.ActualizarEstadoSesion(sessionId, isLoggedIn);

            Console.WriteLine($"Sesión {sessionId} actualizada. Estado: {(isLoggedIn ? "Iniciada" : "Cerrada")} - Hora: {DateTime.Now}");

            return resultado;
        }

        public int GuardarSession(SessionManager session)
        {
            int sessionId = _decoratedSessionManager.GuardarSession(session);

            Console.WriteLine($"Sesión guardada para el usuario {session.userId} - ID sesión: {sessionId} - Hora: {DateTime.Now}");

            return sessionId;
        }

        public SessionManager ObtenerSession(int sessionId)
        {
            return _decoratedSessionManager.ObtenerSession(sessionId);
        }
    }
}
