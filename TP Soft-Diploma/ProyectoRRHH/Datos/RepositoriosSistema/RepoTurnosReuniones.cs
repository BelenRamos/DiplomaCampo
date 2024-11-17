using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Modelo;

namespace Datos
{
    public class RepoTurnosReuniones
    {
        RepoReuniones repoReuniones = new RepoReuniones();
        
      

        private string connectionString = "data source=.;initial catalog=db_RRHH;integrated security=True;encrypt=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework";

        public int ObtenerUltimoNumeroReunion()
        {
            int ultimoNumero = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(nro_reunion), 0) FROM TurnosReuniones", conn))
                {
                    ultimoNumero = (int)cmd.ExecuteScalar();
                }
            }
            return ultimoNumero;
        }


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

        public void AgregarTurnoReunion(TurnosReuniones turno)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Obtener el último número de reunión
                int ultimoNumero = ObtenerUltimoNumeroReunion();
                turno.nro_reunion = ultimoNumero + 1;

                // Usar RepoReuniones para agregar la reunión
                repoReuniones.AgregarReunion(turno.nro_reunion);

                // Insertar en TurnosReuniones
                using (SqlCommand cmd = new SqlCommand(
                    "INSERT INTO TurnosReuniones (nro_reunion, fecha, horario, disponible, id_cliente) " +
                    "VALUES (@nro_reunion, @fecha, @horario, @disponible, @id_cliente)", conn))
                {
                    cmd.Parameters.AddWithValue("@nro_reunion", turno.nro_reunion);
                    cmd.Parameters.AddWithValue("@fecha", turno.fecha);
                    cmd.Parameters.AddWithValue("@horario", turno.horario);
                    cmd.Parameters.AddWithValue("@disponible", turno.disponible.HasValue ? (object)turno.disponible.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_cliente", turno.id_cliente.HasValue ? (object)turno.id_cliente.Value : DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void ActualizarTurnoReunion(TurnosReuniones turnoReunion)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE TurnosReuniones SET fecha = @fecha, horario = @horario, disponible = @disponible, id_cliente = @id_cliente WHERE nro_reunion = @nro_reunion", conn))
                {
                    cmd.Parameters.AddWithValue("@fecha", turnoReunion.fecha);
                    cmd.Parameters.AddWithValue("@horario", turnoReunion.horario);
                    cmd.Parameters.AddWithValue("@disponible", turnoReunion.disponible ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_cliente", turnoReunion.id_cliente ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@nro_reunion", turnoReunion.nro_reunion);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarTurnoReunion(int nroReunion)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM TurnosReuniones WHERE nro_reunion = @nro_reunion", conn))
                {
                    cmd.Parameters.AddWithValue("@nro_reunion", nroReunion);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public TurnosReuniones ObtenerTurnoReunionPorId(int nroReunion)
        {
            TurnosReuniones turnoReunion = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM TurnosReuniones WHERE nro_reunion = @nro_reunion", conn))
                {
                    cmd.Parameters.AddWithValue("@nro_reunion", nroReunion);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        turnoReunion = new TurnosReuniones
                        {
                            fecha = reader.GetDateTime(0),
                            horario = reader.GetTimeSpan(1),
                            disponible = reader.IsDBNull(2) ? (byte?)null : reader.GetByte(2),
                            nro_reunion = reader.GetInt32(3),
                            id_cliente = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4)
                        };
                    }
                }
            }
            return turnoReunion;
        }
    }
}
