using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Datos
{
    public class RepoTurnos
    {
        private string connectionString = "data source=.;initial catalog=db_RRHH;integrated security=True;encrypt=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework";

        public List<Turnos> ObtenerTurnos()
        {
            List<Turnos> turnosList = new List<Turnos>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Turnos", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Turnos turno = new Turnos
                        {
                            fecha = reader.GetDateTime(0),
                            horario = reader.GetTimeSpan(1),
                            disponible = reader.IsDBNull(2) ? (byte?)null : reader.GetByte(2),
                            nro_entrevista = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3),
                            mat_psicologo = reader.GetInt32(4)
                        };
                        turnosList.Add(turno);
                    }
                }
            }
            return turnosList;
        }
    }
}
