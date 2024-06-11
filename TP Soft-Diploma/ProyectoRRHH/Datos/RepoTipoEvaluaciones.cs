using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Datos
{
    public class RepoTipoEvaluaciones : RepositorioMaestro
    {
        public List<Tipo_Evaluaciones> ObtenerTodosLosTipoEvaluaciones()
        {
            List<Tipo_Evaluaciones> tipoEvaluaciones = new List<Tipo_Evaluaciones>();
            string consultaSQL = "SELECT * FROM Tipo_Evaluaciones"; // Ajusta esto según el nombre de tu tabla de tipo evaluaciones

            DataTable tablaTipoEvaluaciones = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaTipoEvaluaciones.Rows)
            {
                Tipo_Evaluaciones tipoEvaluacion = new Tipo_Evaluaciones
                {
                    id = Convert.ToInt32(fila["id"]),
                    detalle = fila["detalle"].ToString(),
                    // Ajusta el mapeo de propiedades según tu clase Tipo_Evaluaciones
                };
                tipoEvaluaciones.Add(tipoEvaluacion);
            }
            return tipoEvaluaciones;
        }

        public Tipo_Evaluaciones ObtenerTipoEvaluacionPorId(int idTipoEvaluacion)
        {
            Tipo_Evaluaciones tipoEvaluacion = null;
            string consultaSQL = "SELECT * FROM Tipo_Evaluaciones WHERE id = @ID_Tipo_Evaluacion";
            parametros.Add(new SqlParameter("@ID_Tipo_Evaluacion", idTipoEvaluacion));
            DataTable tablaTipoEvaluaciones = ExecuteReader(consultaSQL);

            if (tablaTipoEvaluaciones.Rows.Count > 0)
            {
                DataRow fila = tablaTipoEvaluaciones.Rows[0];
                tipoEvaluacion = new Tipo_Evaluaciones
                {
                    id = Convert.ToInt32(fila["id"]),
                    detalle = fila["detalle"].ToString(),
                    // Ajusta el mapeo de propiedades según tu clase Tipo_Evaluaciones
                };
            }
            return tipoEvaluacion;
        }
    }
}

