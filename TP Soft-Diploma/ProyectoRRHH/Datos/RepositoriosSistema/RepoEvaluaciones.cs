using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Datos
{
    public class RepoEvaluaciones : RepositorioMaestro
    {
        public List<Evaluaciones> ObtenerTodasLasEvaluaciones()
        {
            List<Evaluaciones> evaluaciones = new List<Evaluaciones>();
            string consultaSQL = "SELECT * FROM Evaluaciones"; // Ajusta esto según el nombre de tu tabla de evaluaciones

            DataTable tablaEvaluaciones = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaEvaluaciones.Rows)
            {
                Evaluaciones evaluacion = new Evaluaciones
                {
                    numero = Convert.ToInt32(fila["numero"]),
                    descripcion = fila["descripcion"].ToString(),
                    resultado = fila["resultado"].ToString(),
                    fechaEvaluacion = fila["fechaEvaluacion"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(fila["fechaEvaluacion"]) : null,
                    profesional = fila["profesional"].ToString(),
                    // Ajusta el mapeo de propiedades según tu clase Evaluaciones
                };
                evaluaciones.Add(evaluacion);
            }
            return evaluaciones;
        }

        public List<Evaluaciones> ObtenerEvaluacionPorNumero(int numeroEvaluacion)
        {
            List<Evaluaciones> evaluaciones = new List<Evaluaciones>();
            string consultaSQL = "SELECT * FROM Evaluaciones WHERE numero = @Numero_Evaluacion";
            parametros.Add(new SqlParameter("@Numero_Evaluacion", numeroEvaluacion));
            DataTable tablaEvaluaciones = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaEvaluaciones.Rows)
            {
                Evaluaciones evaluacion = new Evaluaciones
                {
                    numero = Convert.ToInt32(fila["numero"]),
                    descripcion = fila["descripcion"].ToString(),
                    resultado = fila["resultado"].ToString(),
                    fechaEvaluacion = fila["fechaEvaluacion"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(fila["fechaEvaluacion"]) : null,
                    profesional = fila["profesional"].ToString(),
                    // Ajusta el mapeo de propiedades según tu clase Evaluaciones
                };
                evaluaciones.Add(evaluacion);
            }
            return evaluaciones;
        }
    }
}
