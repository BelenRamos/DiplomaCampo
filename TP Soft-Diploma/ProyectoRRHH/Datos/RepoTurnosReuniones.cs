using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Datos
{
    public class RepoTurnosReuniones : RepositorioMaestro
    {
        public List<TurnosReuniones> ObtenerTodosLosTurnosReuniones()
        {
            List<TurnosReuniones> turnosReuniones = new List<TurnosReuniones>();
            string consultaSQL = "SELECT * FROM TurnosReuniones"; // Ajusta esto según el nombre de tu tabla de turnos de reuniones

            DataTable tablaTurnosReuniones = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaTurnosReuniones.Rows)
            {
                TurnosReuniones turnoReunion = new TurnosReuniones
                {
                    fecha = Convert.ToDateTime(fila["fecha"]),
                    horario = (TimeSpan)fila["horario"],
                    disponible = fila["disponible"] != DBNull.Value ? (byte?)Convert.ToByte(fila["disponible"]) : null,
                    nro_reunion = Convert.ToInt32(fila["nro_reunion"]),
                    id_cliente = fila["id_cliente"] != DBNull.Value ? (int?)Convert.ToInt32(fila["id_cliente"]) : null,
                    // Ajusta el mapeo de propiedades según tu clase TurnosReuniones
                };
                turnosReuniones.Add(turnoReunion);
            }
            return turnosReuniones;
        }

        public TurnosReuniones ObtenerTurnoReunionPorClave(DateTime fecha, TimeSpan horario, int nro_reunion)
        {
            TurnosReuniones turnoReunion = null;
            string consultaSQL = "SELECT * FROM TurnosReuniones WHERE fecha = @Fecha AND horario = @Horario AND nro_reunion = @Nro_Reunion";
            parametros.Add(new SqlParameter("@Fecha", fecha));
            parametros.Add(new SqlParameter("@Horario", horario));
            parametros.Add(new SqlParameter("@Nro_Reunion", nro_reunion));
            DataTable tablaTurnosReuniones = ExecuteReader(consultaSQL);

            if (tablaTurnosReuniones.Rows.Count > 0)
            {
                DataRow fila = tablaTurnosReuniones.Rows[0];
                turnoReunion = new TurnosReuniones
                {
                    fecha = Convert.ToDateTime(fila["fecha"]),
                    horario = (TimeSpan)fila["horario"],
                    disponible = fila["disponible"] != DBNull.Value ? (byte?)Convert.ToByte(fila["disponible"]) : null,
                    nro_reunion = Convert.ToInt32(fila["nro_reunion"]),
                    id_cliente = fila["id_cliente"] != DBNull.Value ? (int?)Convert.ToInt32(fila["id_cliente"]) : null,
                    // Ajusta el mapeo de propiedades según tu clase TurnosReuniones
                };
            }
            return turnoReunion;
        }
    }
}
