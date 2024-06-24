using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Datos
{
    public class RepoRequisitos : RepositorioMaestro
    {
        private string connectionString;

        public RepoRequisitos()
        {
            // Obtener la cadena de conexión desde la configuración
            connectionString = ConfigurationManager.ConnectionStrings["Modelo"].ConnectionString;
        }

        public List<Requisitos> ObtenerRequisitos()
        {
            List<Requisitos> requisitos = new List<Requisitos>();
            string consultaSQL = "SELECT id, descripcion FROM Requisitos";

            DataTable tablaRequisitos = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaRequisitos.Rows)
            {
                Requisitos requisito = new Requisitos
                {
                    id = Convert.ToInt32(fila["id"]),
                    descripcion = fila["descripcion"].ToString()
                };
                requisitos.Add(requisito);
            }
            return requisitos;
        }

        public Requisitos ObtenerRequisitoPorID(int idRequisito)
        {
            Requisitos requisito = null;
            string consultaSQL = "SELECT * FROM Requisitos WHERE id = @ID_Requisito";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@ID_Requisito", idRequisito)
            };
            DataTable tablaRequisitos = ExecuteReader(consultaSQL, parametros);

            if (tablaRequisitos.Rows.Count > 0)
            {
                DataRow fila = tablaRequisitos.Rows[0];
                requisito = new Requisitos
                {
                    id = Convert.ToInt32(fila["id"]),
                    descripcion = fila["descripcion"].ToString(),
                };
            }
            return requisito;
        }

        public List<string> ObtenerDescripcionesRequisitos()
        {
            List<string> descripciones = new List<string>();
            string consultaSQL = "SELECT descripcion FROM Requisitos";

            DataTable tablaDescripciones = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaDescripciones.Rows)
            {
                string descripcion = fila["descripcion"].ToString();
                descripciones.Add(descripcion);
            }
            return descripciones;
        }

        // Métodos para gestionar la tabla intermedia OL_Requisitos
        public int AgregarRequisitoAOferta(int ofertaLaboralId, int requisitoId)
        {
            string consultaSQL = "INSERT INTO OL_Requisitos (nro_OL, id_requisito) VALUES (@OfertaLaboralId, @RequisitoId)";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@OfertaLaboralId", ofertaLaboralId),
                new SqlParameter("@RequisitoId", requisitoId)
            };

            try
            {
                return ExecuteNonQuery(consultaSQL, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el requisito a la oferta laboral.", ex);
            }
        }

        public int EliminarRequisitoDeOferta(int ofertaLaboralId, int requisitoId)
        {
            string consultaSQL = "DELETE FROM OL_Requisitos WHERE nro_OL = @OfertaLaboralId AND id_requisito = @RequisitoId";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@OfertaLaboralId", ofertaLaboralId),
                new SqlParameter("@RequisitoId", requisitoId)
            };

            try
            {
                return ExecuteNonQuery(consultaSQL, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el requisito de la oferta laboral.", ex);
            }
        }

        public List<int> ObtenerRequisitosPorOferta(int ofertaLaboralId)
        {
            List<int> requisitos = new List<int>();
            string consultaSQL = "SELECT id_requisito FROM OL_Requisitos WHERE nro_OL = @OfertaLaboralId";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@OfertaLaboralId", ofertaLaboralId)
            };

            DataTable tablaRequisitos = ExecuteReader(consultaSQL, parametros);

            foreach (DataRow fila in tablaRequisitos.Rows)
            {
                int requisitoId = Convert.ToInt32(fila["id_requisito"]);
                requisitos.Add(requisitoId);
            }
            return requisitos;
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
//    public class RepoRequisitos : RepositorioMaestro
//    {
//        private string connectionString;

//        public RepoRequisitos()
//        {
//            // Obtener la cadena de conexión desde la configuración
//            connectionString = ConfigurationManager.ConnectionStrings["Modelo"].ConnectionString;
//        }

//        public List<(int Id, string Descripcion)> ObtenerRequisitos()
//        {
//            List<(int Id, string Descripcion)> requisitos = new List<(int Id, string Descripcion)>();
//            string consultaSQL = "SELECT id, descripcion FROM Requisitos";

//            DataTable tablaRequisitos = ExecuteReader(consultaSQL);

//            foreach (DataRow fila in tablaRequisitos.Rows)
//            {
//                int id = Convert.ToInt32(fila["id"]);
//                string descripcion = fila["descripcion"].ToString();
//                requisitos.Add((id, descripcion));
//            }
//            return requisitos;
//        }


//        public Requisitos ObtenerRequisitoPorID(int idRequisito)
//        {
//            Requisitos requisito = null;
//            string consultaSQL = "SELECT * FROM Requisitos WHERE id = @ID_Requisito";
//            List<SqlParameter> parametros = new List<SqlParameter>
//            {
//                new SqlParameter("@ID_Requisito", idRequisito)
//            };
//            DataTable tablaRequisitos = ExecuteReader(consultaSQL, parametros);

//            if (tablaRequisitos.Rows.Count > 0)
//            {
//                DataRow fila = tablaRequisitos.Rows[0];
//                requisito = new Requisitos
//                {
//                    id = Convert.ToInt32(fila["id"]),
//                    descripcion = fila["descripcion"].ToString(),
//                };
//            }
//            return requisito;
//        }

//        public List<string> ObtenerDescripcionesRequisitos()
//        {
//            List<string> descripciones = new List<string>();
//            string consultaSQL = "SELECT descripcion FROM Requisitos";

//            DataTable tablaDescripciones = ExecuteReader(consultaSQL);

//            foreach (DataRow fila in tablaDescripciones.Rows)
//            {
//                string descripcion = fila["descripcion"].ToString();
//                descripciones.Add(descripcion);
//            }
//            return descripciones;

//        }

//        private DataTable ExecuteReader(string consultaSQL, List<SqlParameter> parametros = null)
//        {
//            DataTable tablaResultados = new DataTable();

//            using (SqlConnection conexion = new SqlConnection(connectionString))
//            {
//                using (SqlCommand comando = new SqlCommand(consultaSQL, conexion))
//                {
//                    if (parametros != null)
//                    {
//                        comando.Parameters.AddRange(parametros.ToArray());
//                    }

//                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
//                    adaptador.Fill(tablaResultados);
//                }
//            }

//            return tablaResultados;
//        }
//    }
//}

