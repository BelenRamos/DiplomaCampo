using Modelo;

namespace Datos.RepoSeguridad
{
    public interface ISessionManager
    {
        Usuarios Login(string email, string pass);
        bool Logout(int userId);
        bool ActualizarEstadoSesion(int sessionId, bool isLoggedIn);
        int GuardarSession(SessionManager session);
        SessionManager ObtenerSession(int sessionId);
    }
}