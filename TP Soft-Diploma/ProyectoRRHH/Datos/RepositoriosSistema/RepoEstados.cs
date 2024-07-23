using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Datos
{
    public class RepoEstados : RepositorioMaestro
    {
        private string connectionString;

        public RepoEstados()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Modelo"].ConnectionString;
        }

        public List<Estados> ObtenerEstados()
        {
            List<Estados> estados = new List<Estados>();
            string consultaSQL = "SELECT * FROM Estados";

            DataTable tablaEstados = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaEstados.Rows)
            {
                Estados estado = new Estados
                {
                    codigo = Convert.ToInt32(fila["codigo"]),
                    designacion = fila["designacion"].ToString(),
                };
                estados.Add(estado);
            }
            return estados;
        }

        public Estados ObtenerEstadoPorDesignacion(string designacion)
        {
            Estados estado = null;
            string consultaSQL = "SELECT * FROM Estados WHERE designacion = @Designacion";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Designacion", designacion)
            };
            DataTable tablaEstados = ExecuteReader(consultaSQL, parametros);

            if (tablaEstados.Rows.Count > 0)
            {
                DataRow fila = tablaEstados.Rows[0];
                estado = new Estados
                {
                    codigo = Convert.ToInt32(fila["codigo"]),
                    designacion = fila["designacion"].ToString()
                };
            }
            return estado;
        }

        public List<Estados> ObtenerEstadoPorCodigo(int codigoEstado)
        {
            List<Estados> estados = new List<Estados>();
            string consultaSQL = "SELECT * FROM Estados WHERE codigo = @CodigoEstado";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@CodigoEstado", codigoEstado)
            };
            DataTable tablaEstados = ExecuteReader(consultaSQL, parametros);

            foreach (DataRow fila in tablaEstados.Rows)
            {
                Estados estado = new Estados
                {
                    codigo = Convert.ToInt32(fila["codigo"]),
                    designacion = fila["designacion"].ToString(),
                };
                estados.Add(estado);
            }
            return estados;
        }



        public List<int> ObtenerEstadosPorOferta(int ofertaLaboralId)
        {
            List<int> estados = new List<int>();
            string consultaSQL = "SELECT codigo_estado FROM OL_Estados WHERE nro_OL = @OfertaLaboralId";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@OfertaLaboralId", ofertaLaboralId)
            };

            DataTable tablaEstados = ExecuteReader(consultaSQL, parametros);

            foreach (DataRow fila in tablaEstados.Rows)
            {
                int estadoId = Convert.ToInt32(fila["codigo_estado"]);
                estados.Add(estadoId);
            }
            return estados;
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

    }
}