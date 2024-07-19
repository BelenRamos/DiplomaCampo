using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Datos
{
    public class RepoTurnosReuniones
    {
        private string connectionString = "data source=.;initial catalog=db_RRHH;integrated security=True;encrypt=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework";

        public List<TurnosReuniones> ObtenerTurnosReuniones()
        {
            List<TurnosReuniones> turnosReunionesList = new List<TurnosReuniones>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM TurnosReuniones", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TurnosReuniones turnoReunion = new TurnosReuniones
                        {
                            fecha = reader.GetDateTime(0),
                            horario = reader.GetTimeSpan(1),
                            disponible = reader.IsDBNull(2) ? (byte?)null : reader.GetByte(2),
                            nro_reunion = reader.GetInt32(3),
                            id_cliente = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4)
                        };
                        turnosReunionesList.Add(turnoReunion);
                    }
                }
            }
            return turnosReunionesList;
        }
    }
}
