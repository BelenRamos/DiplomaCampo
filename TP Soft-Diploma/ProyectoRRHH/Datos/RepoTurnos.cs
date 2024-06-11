using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Datos
{
    public class RepoTurnos : RepositorioMaestro
    {
        public List<Turnos> ObtenerTodosLosTurnos()
        {
            List<Turnos> turnos = new List<Turnos>();
            string consultaSQL = "SELECT * FROM Turnos"; // Ajusta esto según el nombre de tu tabla de turnos

            DataTable tablaTurnos = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaTurnos.Rows)
            {
                Turnos turno = new Turnos
                {
                    fecha = Convert.ToDateTime(fila["fecha"]),
                    horario = (TimeSpan)fila["horario"],
                    disponible = fila["disponible"] != DBNull.Value ? (byte?)Convert.ToByte(fila["disponible"]) : null,
                    nro_entrevista = fila["nro_entrevista"] != DBNull.Value ? (int?)Convert.ToInt32(fila["nro_entrevista"]) : null,
                    mat_psicologo = Convert.ToInt32(fila["mat_psicologo"]),
                    // Ajusta el mapeo de propiedades según tu clase Turnos
                };
                turnos.Add(turno);
            }
            return turnos;
        }

        public Turnos ObtenerTurnoPorClave(DateTime fecha, TimeSpan horario, int mat_psicologo)
        {
            Turnos turno = null;
            string consultaSQL = "SELECT * FROM Turnos WHERE fecha = @Fecha AND horario = @Horario AND mat_psicologo = @Mat_Psicologo";
            parametros.Add(new SqlParameter("@Fecha", fecha));
            parametros.Add(new SqlParameter("@Horario", horario));
            parametros.Add(new SqlParameter("@Mat_Psicologo", mat_psicologo));
            DataTable tablaTurnos = ExecuteReader(consultaSQL);

            if (tablaTurnos.Rows.Count > 0)
            {
                DataRow fila = tablaTurnos.Rows[0];
                turno = new Turnos
                {
                    fecha = Convert.ToDateTime(fila["fecha"]),
                    horario = (TimeSpan)fila["horario"],
                    disponible = fila["disponible"] != DBNull.Value ? (byte?)Convert.ToByte(fila["disponible"]) : null,
                    nro_entrevista = fila["nro_entrevista"] != DBNull.Value ? (int?)Convert.ToInt32(fila["nro_entrevista"]) : null,
                    mat_psicologo = Convert.ToInt32(fila["mat_psicologo"]),
                    // Ajusta el mapeo de propiedades según tu clase Turnos
                };
            }
            return turno;
        }
    }
}
