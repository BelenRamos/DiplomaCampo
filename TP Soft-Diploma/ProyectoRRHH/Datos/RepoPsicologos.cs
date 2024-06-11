using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Datos
{
    public class RepoPsicologos : RepositorioMaestro
    {
        public List<Psicologos> ObtenerTodosLosPsicologos()
        {
            List<Psicologos> psicologos = new List<Psicologos>();
            string consultaSQL = "SELECT * FROM Psicologos"; // Ajusta esto según el nombre de tu tabla de psicólogos

            DataTable tablaPsicologos = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaPsicologos.Rows)
            {
                Psicologos psicologo = new Psicologos
                {
                    matricula = Convert.ToInt32(fila["matricula"]),
                    nombre = fila["nombre"].ToString(),
                    apellido = fila["apellido"].ToString(),
                    // Ajusta el mapeo de propiedades según tu clase Psicologos
                };
                psicologos.Add(psicologo);
            }
            return psicologos;
        }

        public Psicologos ObtenerPsicologoPorMatricula(int matriculaPsicologo)
        {
            Psicologos psicologo = null;
            string consultaSQL = "SELECT * FROM Psicologos WHERE matricula = @Matricula_Psicologo";
            parametros.Add(new SqlParameter("@Matricula_Psicologo", matriculaPsicologo));
            DataTable tablaPsicologos = ExecuteReader(consultaSQL);

            if (tablaPsicologos.Rows.Count > 0)
            {
                DataRow fila = tablaPsicologos.Rows[0];
                psicologo = new Psicologos
                {
                    matricula = Convert.ToInt32(fila["matricula"]),
                    nombre = fila["nombre"].ToString(),
                    apellido = fila["apellido"].ToString(),
                    // Ajusta el mapeo de propiedades según tu clase Psicologos
                };
            }
            return psicologo;
        }
    }
}

