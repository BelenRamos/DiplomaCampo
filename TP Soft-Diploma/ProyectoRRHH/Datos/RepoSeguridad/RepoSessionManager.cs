﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Datos.RepoSeguridad
{
    public class RepoSessionManager : RepositorioMaestro, ISessionManager
    {
        private string connectionString;
        public RepoSessionManager()
        {
            // Obtener la cadena de conexión desde la configuración
            connectionString = ConfigurationManager.ConnectionStrings["Modelo"].ConnectionString;
        }
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

        //public bool Logout(int userId)
        //{
        //    try
        //    {
        //        string consultaSQL = "UPDATE SessionManager SET isLoggedIn = 0, sessionLogOut = GETDATE() WHERE userId = @userId";
        //        parametros.Add(new SqlParameter("@userId", userId));

        //        int filasAfectadas = ExecuteNonQuery(consultaSQL);

        //        return filasAfectadas > 0;
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine("Error al cerrar sesión: " + ex.Message);
        //        throw;
        //    }
        //}

        public bool Logout(int sessionId)
        {
            parametros.Clear(); // Limpia antes de agregar nuevos parámetros
            try
            {
                string consultaSQL = "UPDATE SessionManager SET isLoggedIn = 0, sessionLogOut = GETDATE() WHERE sessionId = @sessionId";
                parametros.Add(new SqlParameter("@sessionId", sessionId));
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

        public int GuardarSession(SessionManager session)
        {
            try
            {
                // Obtener el último sessionId y sumar 1
                string consultaObtenerMaxId = "SELECT ISNULL(MAX(sessionId), 0) + 1 FROM SessionManager";
                object resultadoId = ExecuteScalar(consultaObtenerMaxId);
                int nuevoSessionId = Convert.ToInt32(resultadoId);

                // Insertar la nueva sesión con el sessionId generado manualmente
                string consultaSQL = "INSERT INTO SessionManager (sessionId, userId, sessionLogIn, isLoggedIn) VALUES (@sessionId, @userId, GETDATE(), 1)";
                parametros.Add(new SqlParameter("@sessionId", nuevoSessionId));
                parametros.Add(new SqlParameter("@userId", session.userId));

                int filasAfectadas = ExecuteNonQuery(consultaSQL);

                return filasAfectadas > 0 ? nuevoSessionId : -1;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al guardar la sesión: " + ex.Message);
                throw;
            }
        }



        private object ExecuteScalar(string consultaSQL)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(consultaSQL, conexion))
                {
                    try
                    {
                        conexion.Open();
                        // Asigna los parámetros al comando
                        foreach (var param in parametros)
                        {
                            comando.Parameters.Add(param);
                        }

                        // Ejecuta la consulta y devuelve el resultado
                        return comando.ExecuteScalar();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error al ejecutar la consulta ExecuteScalar: " + ex.Message);
                        throw;
                    }
                    finally
                    {
                        parametros.Clear(); // Limpiamos los parámetros después de cada ejecución
                    }
                }
            }
        }


        public SessionManager ObtenerSession(int sessionId)
        {
            try
            {
                string consultaSQL = "SELECT * FROM SessionManager WHERE sessionId = @sessionId";
                parametros.Add(new SqlParameter("@sessionId", sessionId));

                DataTable tablaSesiones = ExecuteReader(consultaSQL);

                if (tablaSesiones.Rows.Count > 0)
                {
                    DataRow row = tablaSesiones.Rows[0];
                    return new SessionManager
                    {
                        sessionId = Convert.ToInt32(row["sessionId"]),
                        userId = Convert.ToInt32(row["userId"]),
                        sessionLogIn = Convert.ToDateTime(row["sessionLogIn"]),
                        sessionLogOut = row["sessionLogOut"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["sessionLogOut"]) : null,
                        isLoggedIn = Convert.ToByte(row["isLoggedIn"])
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al obtener la sesión: " + ex.Message);
                throw;
            }
        }

        public void ActualizarEstadoSesion(int sessionId, byte isLoggedIn)
        {
            throw new NotImplementedException();
        }

        public DataTable ObtenerReporteSesiones()
        {
            try
            {
                string consultaSQL = @"
            SELECT 
                SM.sessionId, 
                U.nombreUsuario AS Usuario, 
                SM.sessionLogIn AS InicioSesion, 
                SM.sessionLogOut AS CierreSesion, 
                CASE SM.isLoggedIn 
                    WHEN 1 THEN 'Activo'
                    ELSE 'Inactivo'
                END AS EstadoSesion
            FROM SessionManager SM
            INNER JOIN Usuarios U ON SM.userId = U.idUsuario
            ORDER BY SM.sessionLogIn DESC";

                return ExecuteReader(consultaSQL);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al obtener el reporte de sesiones: " + ex.Message);
                throw;
            }
        }

    }
}
