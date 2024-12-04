using Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Datos.RepoSeguridad
{
    public class RepoUsuarios : RepositorioMaestro
    {
        private string connectionString;
        public RepoUsuarios()
        {
            // Obtener la cadena de conexión desde la configuración
            connectionString = ConfigurationManager.ConnectionStrings["Modelo"].ConnectionString;
        }

        public List<Usuarios> ObtenerTodosLosUsuarios()
        {
            List<Usuarios> usuarios = new List<Usuarios>();
            string consultaSQL = "SELECT * FROM Usuarios"; // Ajusta esto según el nombre de tu tabla de usuarios

            try
            {
                DataTable tablaUsuarios = ExecuteReader(consultaSQL);
                usuarios = ConvertirDataTableALista(tablaUsuarios);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al obtener todos los usuarios: " + ex.Message);
                throw;
            }

            return usuarios;
        }

        public Usuarios ObtenerUsuarioPorID(int idUsuario)
        {
            try
            {
                parametros.Clear();
                string consultaSQL = "SELECT * FROM Usuarios WHERE idUsuario = @ID";

                SqlParameter parametroID = new SqlParameter("@ID", SqlDbType.Int);
                parametroID.Value = idUsuario;
                parametros.Add(parametroID);

                DataTable tablaUsuario = ExecuteReader(consultaSQL);

                if (tablaUsuario.Rows.Count > 0)
                {
                    DataRow fila = tablaUsuario.Rows[0];
                    return ConvertirDataRowAUsuario(fila);
                }
                else
                {
                    return null; // Retorna null si no se encuentra el usuario
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener usuario por ID: " + ex.Message);
                throw;
            }
        }

        public List<Permisos> ObtenerPermisosPorUsuario(int idUsuario)
        {
            List<Permisos> permisos = new List<Permisos>();

            string consultaSQL = @"SELECT P.* 
                               FROM Permisos P
                               JOIN Usuarios_Permisos UP ON P.idPermiso = UP.idPermiso
                               WHERE UP.idUsuario = @idUsuario";

            parametros.Clear();
            parametros.Add(new SqlParameter("@idUsuario", idUsuario));

            try
            {
                DataTable tablaPermisos = ExecuteReader(consultaSQL);

                foreach (DataRow fila in tablaPermisos.Rows)
                {
                    Permisos permiso = new Permisos
                    {
                        idPermiso = Convert.ToInt32(fila["idPermiso"]),
                        nombrePermiso = fila["nombrePermiso"].ToString()
                    };
                    permisos.Add(permiso);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los permisos del usuario", ex);
            }

            return permisos;
        }
        private List<Usuarios> ConvertirDataTableALista(DataTable tabla)
        {
            List<Usuarios> usuarios = new List<Usuarios>();

            foreach (DataRow fila in tabla.Rows)
            {
                usuarios.Add(ConvertirDataRowAUsuario(fila));
            }

            return usuarios;
        }

        private Usuarios ConvertirDataRowAUsuario(DataRow fila)
        {
            return new Usuarios
            {
                idUsuario = Convert.ToInt32(fila["idUsuario"]),
                nombreUsuario = fila["nombreUsuario"].ToString(),
                contrasenia = fila["contrasenia"].ToString(),
                emailUsuario = fila["emailUsuario"].ToString(),
                habilitado = fila["habilitado"] != DBNull.Value ? (byte?)Convert.ToByte(fila["habilitado"]) : null,
                legajo = fila["legajo"] != DBNull.Value ? (int?)Convert.ToInt32(fila["legajo"]) : null
            };
        }
        public int ModificarUsuario(Usuarios usuario)
        {
            string consultaSQL = @"UPDATE Usuarios 
                           SET nombreUsuario = @nombreUsuario, 
                               contrasenia = @contrasenia, 
                               emailUsuario = @emailUsuario, 
                               habilitado = @habilitado, 
                               legajo = @legajo 
                           WHERE idUsuario = @idUsuario";

            parametros.Clear();
            parametros.Add(new SqlParameter("@idUsuario", usuario.idUsuario));
            parametros.Add(new SqlParameter("@nombreUsuario", usuario.nombreUsuario ?? (object)DBNull.Value));
            parametros.Add(new SqlParameter("@contrasenia", usuario.contrasenia ?? (object)DBNull.Value));
            parametros.Add(new SqlParameter("@emailUsuario", usuario.emailUsuario ?? (object)DBNull.Value));
            parametros.Add(new SqlParameter("@habilitado", usuario.habilitado ?? (object)DBNull.Value));
            parametros.Add(new SqlParameter("@legajo", usuario.legajo ?? (object)DBNull.Value));

            try
            {
                return ExecuteNonQuery(consultaSQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar al usuario", ex);
            }
        }


        public int BajaUsuario(int idUsuario)
        {
            string consultaSQL = "DELETE FROM Usuarios WHERE idUsuario = @idUsuario";

            parametros.Clear();
            parametros.Add(new SqlParameter("@idUsuario", idUsuario));

            try
            {
                return ExecuteNonQuery(consultaSQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de baja al usuario", ex);
            }
        }


        public int ObtenerUltimoIDUsuario()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT MAX(idUsuario) FROM Usuarios", connection);
                    object result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el último ID de usuario.", ex);
            }
        }

        public int AltaUsuarioSimple(Usuarios usuario)
        {
            string consultaSQL = @"INSERT INTO Usuarios (idUsuario, nombreUsuario, contrasenia, emailUsuario, habilitado, legajo) 
                           VALUES (@idUsuario, @nombreUsuario, @contrasenia, @emailUsuario, @habilitado, @legajo)";

            parametros.Clear();
            parametros.Add(new SqlParameter("@idUsuario", usuario.idUsuario));
            parametros.Add(new SqlParameter("@nombreUsuario", usuario.nombreUsuario ?? (object)DBNull.Value));
            parametros.Add(new SqlParameter("@contrasenia", usuario.contrasenia ?? (object)DBNull.Value));
            parametros.Add(new SqlParameter("@emailUsuario", usuario.emailUsuario ?? (object)DBNull.Value));
            parametros.Add(new SqlParameter("@habilitado", usuario.habilitado ?? (object)DBNull.Value));
            parametros.Add(new SqlParameter("@legajo", usuario.legajo ?? (object)DBNull.Value));

            try
            {
                return ExecuteNonQuery(consultaSQL);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al dar de alta al usuario", ex);
            }
        }

        public Usuarios ValidarUsuario(string email, string contrasenia)
        {
            Usuarios usuario = null;
            string consultaSQL = "SELECT * FROM Usuarios WHERE emailUsuario = @Email AND contrasenia = @Contrasenia";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(consultaSQL, connection);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Contrasenia", contrasenia);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        usuario = new Usuarios
                        {
                            idUsuario = (int)reader["idUsuario"],
                            nombreUsuario = reader["nombreUsuario"].ToString(),
                            contrasenia = reader["contrasenia"].ToString(),
                            emailUsuario = reader["emailUsuario"].ToString(),
                            habilitado = reader["habilitado"] != DBNull.Value ? (byte?)Convert.ToByte(reader["habilitado"]) : null,
                            legajo = reader["legajo"] != DBNull.Value ? (int?)Convert.ToInt32(reader["legajo"]) : null
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al validar usuario: " + ex.Message);
                throw;
            }

            return usuario;
        }

        public List<Permisos> ObtenerPermisosUsuario(int idUsuario)
        {
            List<Permisos> permisos = new List<Permisos>();
            string connectionString = "tu cadena de conexión";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT p.idPermiso, p.nombrePermiso FROM Permisos p " +
                               "JOIN Usuarios_Permisos up ON p.idPermiso = up.idPermiso " +
                               "WHERE up.idUsuario = @idUsuario";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idUsuario", idUsuario);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Permisos permiso = new Permisos
                    {
                        idPermiso = (int)reader["idPermiso"],
                        nombrePermiso = (string)reader["nombrePermiso"]
                    };
                    permisos.Add(permiso);
                }
            }
            return permisos;
        }

        public int ObtenerGrupoUsuario(int idUsuario)
        {
            int idGrupo = 0; // Valor por defecto si no se encuentra el grupo
            string consultaSQL = @"SELECT TOP 1 g.idGrupo
                           FROM Grupos g
                           JOIN Usuarios_Grupos ug ON g.idGrupo = ug.idGrupo
                           WHERE ug.idUsuario = @idUsuario";

            parametros.Clear();
            parametros.Add(new SqlParameter("@idUsuario", idUsuario));

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(consultaSQL, connection);
                    command.Parameters.AddWithValue("@idUsuario", idUsuario);
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        idGrupo = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el grupo del usuario.", ex);
            }

            return idGrupo;
        }

        //////Cambio contraseña
        public int CambiarContraseña(string emailUsuario, string nuevaContrasenia, string confirmaContrasenia)
        {
            // Verificar que la nueva contraseña y la confirmación coincidan
            if (nuevaContrasenia != confirmaContrasenia)
            {
                throw new ArgumentException("Las contraseñas no coinciden.");
            }

            string consultaSQL = @"UPDATE Usuarios 
                           SET contrasenia = @nuevaContrasenia 
                           WHERE emailUsuario = @Email";

            parametros.Clear();
            parametros.Add(new SqlParameter("@Email", emailUsuario));
            parametros.Add(new SqlParameter("@nuevaContrasenia", nuevaContrasenia));

            try
            {
                return ExecuteNonQuery(consultaSQL); // Retorna el número de filas afectadas
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cambiar la contraseña del usuario", ex);
            }
        }

    }

}
