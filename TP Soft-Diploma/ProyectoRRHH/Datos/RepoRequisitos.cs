using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Modelo;

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

        public List<(int Id, string Descripcion)> ObtenerRequisitos()
        {
            List<(int Id, string Descripcion)> requisitos = new List<(int Id, string Descripcion)>();
            string consultaSQL = "SELECT id, descripcion FROM Requisitos";

            DataTable tablaRequisitos = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaRequisitos.Rows)
            {
                int id = Convert.ToInt32(fila["id"]);
                string descripcion = fila["descripcion"].ToString();
                requisitos.Add((id, descripcion));
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

        //public int ObtenerIdPorDescripcion(string descripcion)
        //{
        //    int idRequisito = 0;
        //    string consultaSQL = "SELECT id FROM Requisitos WHERE descripcion = @Descripcion";
        //    List<SqlParameter> parametros = new List<SqlParameter>
        //    {
        //        new SqlParameter("@Descripcion", descripcion)
        //    };
        //    DataTable tablaRequisitos = ExecuteReader(consultaSQL, parametros);

        //    if (tablaRequisitos.Rows.Count > 0)
        //    {
        //        idRequisito = Convert.ToInt32(tablaRequisitos.Rows[0]["id"]);
        //    }
        //    return idRequisito;
        //}

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

