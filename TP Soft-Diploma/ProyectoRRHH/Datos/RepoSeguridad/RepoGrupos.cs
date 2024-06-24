using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Datos;
using Modelo;

namespace Datos.RepoSeguridad
{
    public class RepoGrupos : RepositorioMaestro
    {
        public List<Grupos> ObtenerTodosLosGrupos()
        {
            List<Grupos> grupos = new List<Grupos>();
            string consultaSQL = "SELECT * FROM Grupos";

            try
            {
                DataTable tablaGrupos = ExecuteReader(consultaSQL);
                grupos = ConvertirDataTableALista(tablaGrupos);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al obtener todos los grupos: " + ex.Message);
                throw;
            }

            return grupos;
        }

        public List<Grupos> ObtenerGruposPorUsuario(int userID)
        {
            List<Grupos> grupos = new List<Grupos>();
            string consultaSQL = "SELECT g.* FROM Grupos g INNER JOIN UxG u ON g.idGrupo = u.ID_Group WHERE u.ID_User = @UserID";

            try
            {
                parametros.Add(new SqlParameter("@UserID", userID));
                DataTable tablaGrupos = ExecuteReader(consultaSQL);
                grupos = ConvertirDataTableALista(tablaGrupos);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al obtener grupos por usuario: " + ex.Message);
                throw;
            }

            return grupos;
        }

        public List<Grupos> ObtenerGruposNoAsociadosAUsuario(int userID)
        {
            List<Grupos> grupos = new List<Grupos>();
            string consultaSQL = "SELECT g.* FROM Grupos g WHERE g.idGrupo NOT IN (SELECT ID_Group FROM UxG WHERE ID_User = @UserID)";

            try
            {
                parametros.Add(new SqlParameter("@UserID", userID));
                DataTable tablaGrupos = ExecuteReader(consultaSQL);
                grupos = ConvertirDataTableALista(tablaGrupos);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al obtener grupos no asociados a usuario: " + ex.Message);
                throw;
            }

            return grupos;
        }

        public Grupos ObtenerGrupoPorID(int idGrupo)
        {
            Grupos grupo = null;
            string consultaSQL = "SELECT * FROM Grupos WHERE idGrupo = @ID";

            try
            {
                parametros.Clear();
                parametros.Add(new SqlParameter("@ID", idGrupo));
                DataTable tablaGrupo = ExecuteReader(consultaSQL);
                if (tablaGrupo.Rows.Count > 0)
                {
                    grupo = ConvertirDataRowAGrupo(tablaGrupo.Rows[0]);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al obtener grupo por ID: " + ex.Message);
                throw;
            }

            return grupo;
        }

        public List<Grupos> ObtenerGruposAsociadosAPermiso(int permisoID)
        {
            List<Grupos> grupos = new List<Grupos>();
            string consultaSQL = "SELECT G.* FROM Grupos G JOIN PxG ON G.idGrupo = PxG.ID_Group WHERE PxG.ID_Permission = @permisoID";

            try
            {
                parametros.Add(new SqlParameter("@permisoID", permisoID));
                DataTable tablaGrupos = ExecuteReader(consultaSQL);
                grupos = ConvertirDataTableALista(tablaGrupos);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al obtener grupos asociados a permiso: " + ex.Message);
                throw;
            }

            return grupos;
        }

        public List<Grupos> ObtenerGruposNoAsociadosAPermiso(int permisoID)
        {
            List<Grupos> grupos = new List<Grupos>();
            string consultaSQL = "SELECT G.* FROM Grupos G LEFT JOIN PxG ON G.idGrupo = PxG.ID_Group AND PxG.ID_Permission = @permisoID WHERE PxG.ID_Group IS NULL";

            try
            {
                parametros.Add(new SqlParameter("@permisoID", permisoID));
                DataTable tablaGrupos = ExecuteReader(consultaSQL);
                grupos = ConvertirDataTableALista(tablaGrupos);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al obtener grupos no asociados a permiso: " + ex.Message);
                throw;
            }

            return grupos;
        }

        private List<Grupos> ConvertirDataTableALista(DataTable tabla)
        {
            List<Grupos> grupos = new List<Grupos>();

            foreach (DataRow fila in tabla.Rows)
            {
                grupos.Add(ConvertirDataRowAGrupo(fila));
            }

            return grupos;
        }

        private Grupos ConvertirDataRowAGrupo(DataRow fila)
        {
            return new Grupos
            {
                idGrupo = Convert.ToInt32(fila["idGrupo"]),
                nombreGrupo = fila["nombreGrupo"].ToString(),
                habilitado = fila["habilitado"] != DBNull.Value ? (byte?)Convert.ToByte(fila["habilitado"]) : null
            };
        }
    }
}

