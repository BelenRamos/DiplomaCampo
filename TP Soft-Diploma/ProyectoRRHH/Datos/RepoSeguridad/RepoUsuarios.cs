using Datos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Datos.RepoSeguridad
{
    public class RepoUsuarios : RepositorioMaestro
    {
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

        public Usuarios ObtenerUsuarioPorCredenciales(string username, string password)
        {
            try
            {
                parametros.Clear();
                string consultaSQL = "SELECT * FROM Usuarios WHERE nombreUsuario = @Username AND contrasenia = @Password";

                SqlParameter parametroUsername = new SqlParameter("@Username", SqlDbType.VarChar);
                parametroUsername.Value = username;
                parametros.Add(parametroUsername);

                SqlParameter parametroPassword = new SqlParameter("@Password", SqlDbType.VarChar);
                parametroPassword.Value = password;
                parametros.Add(parametroPassword);

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
                Console.WriteLine("Error al obtener usuario por credenciales: " + ex.Message);
                throw;
            }
        }

        public List<Usuarios> ObtenerUsuariosPorGrupo(int grupoID)
        {
            List<Usuarios> usuarios = new List<Usuarios>();
            string consultaSQL = "SELECT U.* FROM Usuarios U JOIN UxG ON U.idUsuario = UxG.idUsuario WHERE UxG.idGrupo = @grupoID";

            parametros.Add(new SqlParameter("@grupoID", grupoID));

            try
            {
                DataTable tablaUsuarios = ExecuteReader(consultaSQL);
                usuarios = ConvertirDataTableALista(tablaUsuarios);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al obtener usuarios por grupo: " + ex.Message);
                throw;
            }

            return usuarios;
        }

        public List<Usuarios> ObtenerUsuariosNoAsociadosAGrupo(int grupoID)
        {
            List<Usuarios> usuarios = new List<Usuarios>();
            string consultaSQL = "SELECT U.* FROM Usuarios U LEFT JOIN UxG ON U.idUsuario = UxG.idUsuario AND UxG.idGrupo = @grupoID WHERE UxG.idUsuario IS NULL";

            parametros.Add(new SqlParameter("@grupoID", grupoID));

            try
            {
                DataTable tablaUsuarios = ExecuteReader(consultaSQL);
                usuarios = ConvertirDataTableALista(tablaUsuarios);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al obtener usuarios no asociados a grupo: " + ex.Message);
                throw;
            }

            return usuarios;
        }

        public List<Usuarios> ObtenerUsuariosAsociadosAPermiso(int permisoID)
        {
            List<Usuarios> usuarios = new List<Usuarios>();
            string consultaSQL = "SELECT U.* FROM Usuarios U JOIN PxU ON U.idUsuario = PxU.idUsuario WHERE PxU.idPermiso = @permisoID";

            parametros.Add(new SqlParameter("@permisoID", permisoID));

            try
            {
                DataTable tablaUsuarios = ExecuteReader(consultaSQL);
                usuarios = ConvertirDataTableALista(tablaUsuarios);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al obtener usuarios asociados a permiso: " + ex.Message);
                throw;
            }

            return usuarios;
        }

        public List<Usuarios> ObtenerUsuariosNoAsociadosAPermiso(int permisoID)
        {
            List<Usuarios> usuarios = new List<Usuarios>();
            string consultaSQL = "SELECT U.* FROM Usuarios U LEFT JOIN PxU ON U.idUsuario = PxU.idUsuario AND PxU.idPermiso = @permisoID WHERE PxU.idUsuario IS NULL";

            parametros.Add(new SqlParameter("@permisoID", permisoID));

            try
            {
                DataTable tablaUsuarios = ExecuteReader(consultaSQL);
                usuarios = ConvertirDataTableALista(tablaUsuarios);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al obtener usuarios no asociados a permiso: " + ex.Message);
                throw;
            }

            return usuarios;
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
    }
}

