using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Datos;
using Modelo;

namespace Datos.RepoSeguridad
{
    public class RepoPermisos : RepositorioMaestro
    {
        public List<Permisos> ObtenerTodosLosPermisos()
        {
            List<Permisos> permisos = new List<Permisos>();
            string consultaSQL = "SELECT * FROM Permisos";

            try
            {
                DataTable tablaPermisos = ExecuteReader(consultaSQL);
                permisos = ConvertirDataTableALista(tablaPermisos);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al obtener todos los permisos: " + ex.Message);
                throw;
            }

            return permisos;
        }

        public List<Permisos> ObtenerPermisosDeUsuario(int userID)
        {
            List<Permisos> permisos = new List<Permisos>();
            string consultaSQL = "SELECT DISTINCT P.* FROM PERMISOS P JOIN PxU ON P.idPermiso = PxU.idPermiso JOIN USUARIOS U ON PxU.idUsuario = U.idUsuario WHERE U.idUsuario = @UserID";
            parametros.Add(new SqlParameter("@UserID", userID));

            try
            {
                DataTable tablaPermisos = ExecuteReader(consultaSQL);
                permisos = ConvertirDataTableALista(tablaPermisos);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al obtener permisos de usuario: " + ex.Message);
                throw;
            }

            return permisos;
        }

        public List<Permisos> ObtenerPermisosDeGruposPorID_User(int userID)
        {
            List<Permisos> permisos = new List<Permisos>();
            string consultaSQL = "SELECT P.* FROM PERMISOS P JOIN PxG ON P.idPermiso = PxG.idPermiso JOIN GRUPOS G ON PxG.idGrupo = G.idGrupo JOIN UxG ON G.idGrupo = UxG.idGrupo JOIN USUARIOS U ON UxG.idUsuario = U.idUsuario WHERE U.idUsuario = @UserID";
            parametros.Add(new SqlParameter("@UserID", userID));

            try
            {
                DataTable tablaPermisos = ExecuteReader(consultaSQL);
                permisos = ConvertirDataTableALista(tablaPermisos);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al obtener permisos de grupos por ID de usuario: " + ex.Message);
                throw;
            }

            return permisos;
        }

        public List<Permisos> ObtenerPermisosDeGrupoPorID_Group(int grupoID)
        {
            List<Permisos> permisos = new List<Permisos>();
            string consultaSQL = "SELECT PERMISOS.* FROM PERMISOS JOIN PxG ON PERMISOS.idPermiso = PxG.idPermiso WHERE PxG.idGrupo = @grupoID";
            parametros.Add(new SqlParameter("@grupoID", grupoID));

            try
            {
                DataTable tablaPermisos = ExecuteReader(consultaSQL);
                permisos = ConvertirDataTableALista(tablaPermisos);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al obtener permisos de grupo por ID de grupo: " + ex.Message);
                throw;
            }

            return permisos;
        }

        public int QuitarTodosLosUsuariosAsociadosAPermiso(int permisoId)
        {
            string consultaSQL = "DELETE FROM PxU WHERE idPermiso = @permisoId";
            parametros.Add(new SqlParameter("@permisoId", permisoId));

            try
            {
                return ExecuteNonQuery(consultaSQL);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al quitar todos los usuarios asociados al permiso: " + ex.Message);
                throw;
            }
        }

        public int QuitarTodosLosGruposAsociadosAPermiso(int permisoId)
        {
            string consultaSQL = "DELETE FROM PxG WHERE idPermiso = @permisoId";
            parametros.Add(new SqlParameter("@permisoId", permisoId));

            try
            {
                return ExecuteNonQuery(consultaSQL);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al quitar todos los grupos asociados al permiso: " + ex.Message);
                throw;
            }
        }

        public int AgregarATablaPxU(int permisoId, int usuarioId)
        {
            string consultaSQL = "INSERT INTO PxU (idPermiso, idUsuario) VALUES (@permisoId, @usuarioId)";
            parametros.Add(new SqlParameter("@permisoId", permisoId));
            parametros.Add(new SqlParameter("@usuarioId", usuarioId));

            try
            {
                return ExecuteNonQuery(consultaSQL);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al agregar a la tabla PxU: " + ex.Message);
                throw;
            }
        }

        public int AgregarATablaPxG(int permisoId, int grupoId)
        {
            string consultaSQL = "INSERT INTO PxG (idPermiso, idGrupo) VALUES (@permisoId, @grupoId)";
            parametros.Add(new SqlParameter("@permisoId", permisoId));
            parametros.Add(new SqlParameter("@grupoId", grupoId));

            try
            {
                return ExecuteNonQuery(consultaSQL);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al agregar a la tabla PxG: " + ex.Message);
                throw;
            }
        }

        private List<Permisos> ConvertirDataTableALista(DataTable tabla)
        {
            List<Permisos> permisos = new List<Permisos>();

            foreach (DataRow fila in tabla.Rows)
            {
                permisos.Add(ConvertirDataRowAPermiso(fila));
            }

            return permisos;
        }

        private Permisos ConvertirDataRowAPermiso(DataRow fila)
        {
            return new Permisos
            {
                idPermiso = Convert.ToInt32(fila["idPermiso"]),
                nombrePermiso = fila["nombrePermiso"].ToString(),
                idForm = fila["idForm"] != DBNull.Value ? Convert.ToInt32(fila["idForm"]) : (int?)null
            };
        }
    }
}

