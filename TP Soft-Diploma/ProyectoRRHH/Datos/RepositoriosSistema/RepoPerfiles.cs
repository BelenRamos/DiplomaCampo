using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Datos
{
    public class RepoPerfiles : RepositorioMaestro
    {
        private string connectionString;

        public RepoPerfiles()
        {
            // Obtener la cadena de conexión desde la configuración
            connectionString = ConfigurationManager.ConnectionStrings["Modelo"].ConnectionString;
        }

        public List<Perfiles> ObtenerTodosLosPerfiles()
        {
            List<Perfiles> perfiles = new List<Perfiles>();
            string consultaSQL = "SELECT * FROM Perfiles"; // Ajusta esto según el nombre de tu tabla de perfiles

            DataTable tablaPerfiles = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaPerfiles.Rows)
            {
                Perfiles perfil = new Perfiles
                {
                    id = Convert.ToInt32(fila["id"]),
                    nombre = fila["nombre"].ToString(),
                    descripcion = fila["descripcion"].ToString(),
                    // Ajusta el mapeo de propiedades según tu clase Perfiles
                };
                perfiles.Add(perfil);
            }
            return perfiles;
        }

        public Perfiles ObtenerPerfilPorId(int idPerfil)
        {
            Perfiles perfil = null;
            string consultaSQL = "SELECT * FROM Perfiles WHERE id = @ID_Perfil";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@ID_Perfil", idPerfil)
            };
            DataTable tablaPerfiles = ExecuteReader(consultaSQL, parametros);

            if (tablaPerfiles.Rows.Count > 0)
            {
                DataRow fila = tablaPerfiles.Rows[0];
                perfil = new Perfiles
                {
                    id = Convert.ToInt32(fila["id"]),
                    nombre = fila["nombre"].ToString(),
                    descripcion = fila["descripcion"].ToString(),
                    // Ajusta el mapeo de propiedades según tu clase Perfiles
                };
            }
            return perfil;
        }

        // Métodos para gestionar la tabla intermedia OL_Perfiles
        public int AgregarPerfilAOferta(int ofertaLaboralId, int perfilId)
        {
            string consultaSQL = "INSERT INTO OL_Perfiles (nro_OL, id_perfil) VALUES (@OfertaLaboralId, @PerfilId)";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@OfertaLaboralId", ofertaLaboralId),
                new SqlParameter("@PerfilId", perfilId)
            };

            try
            {
                return ExecuteNonQuery(consultaSQL, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el perfil a la oferta laboral.", ex);
            }
        }

        public int EliminarPerfilDeOferta(int ofertaLaboralId, int perfilId)
        {
            string consultaSQL = "DELETE FROM OL_Perfiles WHERE nro_OL = @OfertaLaboralId AND id_perfil = @PerfilId";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@OfertaLaboralId", ofertaLaboralId),
                new SqlParameter("@PerfilId", perfilId)
            };

            try
            {
                return ExecuteNonQuery(consultaSQL, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el perfil de la oferta laboral.", ex);
            }
        }

        public List<int> ObtenerPerfilesPorOferta(int ofertaLaboralId)
        {
            List<int> perfiles = new List<int>();
            string consultaSQL = "SELECT id_perfil FROM OL_Perfiles WHERE nro_OL = @OfertaLaboralId";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@OfertaLaboralId", ofertaLaboralId)
            };

            DataTable tablaPerfiles = ExecuteReader(consultaSQL, parametros);

            foreach (DataRow fila in tablaPerfiles.Rows)
            {
                int perfilId = Convert.ToInt32(fila["id_perfil"]);
                perfiles.Add(perfilId);
            }
            return perfiles;
        }

        private DataTable ExecuteReader(string consultaSQL, List<SqlParameter> parametros = null)
        {
            DataTable tablaResultados = new DataTable();

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(consultaSQL, conexion))
                {
                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros.ToArray());
                    }

                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    adaptador.Fill(tablaResultados);
                }
            }

            return tablaResultados;
        }

        private int ExecuteNonQuery(string consultaSQL, List<SqlParameter> parametros)
        {
            int filasAfectadas = 0;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(consultaSQL, conexion))
                {
                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros.ToArray());
                    }

                    conexion.Open();
                    filasAfectadas = comando.ExecuteNonQuery();
                }
            }

            return filasAfectadas;
        }
    }
}

//namespace Datos
//{
//    public class RepoPerfiles : RepositorioMaestro
//    {
//        public List<Perfiles> ObtenerTodosLosPerfiles()
//        {
//            List<Perfiles> perfiles = new List<Perfiles>();
//            string consultaSQL = "SELECT * FROM Perfiles"; // Ajusta esto según el nombre de tu tabla de perfiles

//            DataTable tablaPerfiles = ExecuteReader(consultaSQL);

//            foreach (DataRow fila in tablaPerfiles.Rows)
//            {
//                Perfiles perfil = new Perfiles
//                {
//                    id = Convert.ToInt32(fila["id"]),
//                    nombre = fila["nombre"].ToString(),
//                    descripcion = fila["descripcion"].ToString(),
//                    // Ajusta el mapeo de propiedades según tu clase Perfiles
//                };
//                perfiles.Add(perfil);
//            }
//            return perfiles;
//        }

//        public Perfiles ObtenerPerfilPorId(int idPerfil)
//        {
//            Perfiles perfil = null;
//            string consultaSQL = "SELECT * FROM Perfiles WHERE id = @ID_Perfil";
//            parametros.Add(new SqlParameter("@ID_Perfil", idPerfil));
//            DataTable tablaPerfiles = ExecuteReader(consultaSQL);

//            if (tablaPerfiles.Rows.Count > 0)
//            {
//                DataRow fila = tablaPerfiles.Rows[0];
//                perfil = new Perfiles
//                {
//                    id = Convert.ToInt32(fila["id"]),
//                    nombre = fila["nombre"].ToString(),
//                    descripcion = fila["descripcion"].ToString(),
//                    // Ajusta el mapeo de propiedades según tu clase Perfiles
//                };
//            }
//            return perfil;
//        }
//    }
//}

