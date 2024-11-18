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

        public int AgregarRequisitoAOferta(int ofertaLaboralId, int requisitoId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO OL_Requisitos (nro_OL, id_requisito) VALUES (@ofertaLaboralId, @requisitoId)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ofertaLaboralId", ofertaLaboralId);
                    command.Parameters.AddWithValue("@requisitoId", requisitoId);

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }
        private object ExecuteScalar(string consultaExistente, List<SqlParameter> parametrosExistentes)
        {
            throw new NotImplementedException();
        }
        public int EliminarRequisitoDeOferta(int ofertaLaboralId)
        {
            string consultaSQL = @"DELETE OL_Requisitos
                                   FROM Ofertas_Laborales
                                   INNER JOIN OL_Requisitos ON Ofertas_Laborales.numero = OL_Requisitos.nro_OL
                                   WHERE Ofertas_Laborales.numero = @OfertaLaboralId";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand(consultaSQL, connection))
                    {
                        command.Parameters.AddWithValue("@OfertaLaboralId", ofertaLaboralId);
                        connection.Open();
                        int filasAfectadas = command.ExecuteNonQuery();
                        return filasAfectadas;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar los requisitos de la oferta laboral.", ex);
            }
        }
    
    public List<Requisitos> ObtenerRequisitosPorOferta(int ofertaLaboralId)
        {
            List<Requisitos> requisitos = new List<Requisitos>();
            string consultaSQL = "SELECT r.id, r.descripcion FROM Requisitos r " +
                                 "INNER JOIN OL_Requisitos olr ON r.id = olr.id_requisito " +
                                 "WHERE olr.nro_OL = @OfertaLaboralId";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@OfertaLaboralId", ofertaLaboralId)
            };

            DataTable tablaRequisitos = ExecuteReader(consultaSQL, parametros);

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
