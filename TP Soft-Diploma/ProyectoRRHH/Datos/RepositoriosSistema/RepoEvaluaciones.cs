using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class RepoEvaluaciones
    {
        private string connectionString;
        public RepoEvaluaciones()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Modelo"].ConnectionString;
        }

        public List<(string NombrePostulante, string ResultadoEvaluacion)> ObtenerPostulantesConEvaluacion(int numeroOL)
        {
            var postulantesConEvaluacion = new List<(string NombrePostulante, string ResultadoEvaluacion)>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT p.nombre + ' ' + p.apellido AS NombrePostulante, e.resultado AS ResultadoEvaluacion
            FROM Postulantes p
            JOIN OL_Postulantes olp ON p.numero = olp.nro_postulante
            JOIN Evaluciones_Postulantes ep ON p.numero = ep.nro_postulante
            JOIN Evaluaciones e ON ep.nro_evaluacion = e.numero
            WHERE olp.nro_OL = @numeroOL";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@numeroOL", numeroOL);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombrePostulante = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                            string resultadoEvaluacion = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);

                            postulantesConEvaluacion.Add((nombrePostulante, resultadoEvaluacion));
                        }
                    }
                }
            }

            return postulantesConEvaluacion;
        }

    }
}
