using System;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Datos.RepoSeguridad
{
    public class RepoSessionManager : RepositorioMaestro
    {
        public Usuarios Login(string email, string pass)
        {
            try
            {
                string consultaSQL = "SELECT * FROM Usuarios WHERE emailUsuario = @username AND contrasenia = @password;";
                parametros.Add(new SqlParameter("@username", email));
                parametros.Add(new SqlParameter("@password", pass));

                DataTable tablaUsuarios = ExecuteReader(consultaSQL);

                if (tablaUsuarios.Rows.Count > 0)
                {
                    DataRow row = tablaUsuarios.Rows[0];
                    return new Usuarios
                    {
                        idUsuario = Convert.ToInt32(row["idUsuario"]),
                        nombreUsuario = row["nombreUsuario"].ToString(),
                        contrasenia = row["contrasenia"].ToString(),
                        emailUsuario = row["emailUsuario"].ToString(),
                        habilitado = row["habilitado"] as byte?,
                        legajo = row["legajo"] as int?
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error en el proceso de inicio de sesión: " + ex.Message);
                throw;
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
                Console.WriteLine("Error al cerrar sesión: " + ex.Message);
                throw;
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
                Console.WriteLine("Error al actualizar estado de sesión: " + ex.Message);
                throw;
            }
        }
    }
}
