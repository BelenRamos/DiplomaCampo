using System;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Datos.RepoSeguridad
{
    public class RepoSessionManager : RepositorioMaestro
    {
        public bool Login(string user, string pass)
        {
            try
            {
                string consultaSQL = "SELECT * FROM Usuarios WHERE Username COLLATE Latin1_General_CS_AS = @username COLLATE Latin1_General_CS_AS AND User_Password COLLATE Latin1_General_CS_AS = @password COLLATE Latin1_General_CS_AS;";
                parametros.Add(new SqlParameter("@username", user));
                parametros.Add(new SqlParameter("@password", pass));

                DataTable tablaUsuarios = ExecuteReader(consultaSQL);

                if (tablaUsuarios.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                // Manejar la excepción según sea necesario
                Console.WriteLine("Error en el proceso de inicio de sesión: " + ex.Message);
                throw; // Puedes relanzar la excepción o manejarla según tu lógica de aplicación
            }
        }

        public bool Logout(int userId)
        {
            try
            {
                string consultaSQL = "UPDATE SessionManager SET isLoggedIn = 0, sessionLogOut = GETDATE() WHERE userId = @userId";
                parametros.Add(new SqlParameter("@userId", userId));

                int filasAfectadas = ExecuteNonQuery(consultaSQL);

                return filasAfectadas > 0;
            }
            catch (SqlException ex)
            {
                // Manejar la excepción según sea necesario
                Console.WriteLine("Error al cerrar sesión: " + ex.Message);
                throw; // Puedes relanzar la excepción o manejarla según tu lógica de aplicación
            }
        }

        public bool ActualizarEstadoSesion(int sessionId, bool isLoggedIn)
        {
            try
            {
                string consultaSQL = "UPDATE SessionManager SET isLoggedIn = @isLoggedIn WHERE sessionId = @sessionId";
                parametros.Add(new SqlParameter("@isLoggedIn", isLoggedIn));
                parametros.Add(new SqlParameter("@sessionId", sessionId));

                int filasAfectadas = ExecuteNonQuery(consultaSQL);

                return filasAfectadas > 0;
            }
            catch (SqlException ex)
            {
                // Manejar la excepción según sea necesario
                Console.WriteLine("Error al actualizar estado de sesión: " + ex.Message);
                throw; // Puedes relanzar la excepción o manejarla según tu lógica de aplicación
            }
        }
    }
}


