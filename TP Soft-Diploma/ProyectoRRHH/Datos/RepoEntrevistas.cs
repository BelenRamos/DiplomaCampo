using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Datos
{
    public class RepoEntrevistas : RepositorioMaestro
    {
        public List<Entrevistas> ObtenerTodasLasEntrevistas()
        {
            List<Entrevistas> entrevistas = new List<Entrevistas>();
            string consultaSQL = "SELECT * FROM Entrevistas"; // Ajusta esto según el nombre de tu tabla de entrevistas

            DataTable tablaEntrevistas = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaEntrevistas.Rows)
            {
                Entrevistas entrevista = new Entrevistas
                {
                    numero = Convert.ToInt32(fila["numero"]),
                    observaciones = fila["observaciones"].ToString(),
                    // Ajusta el mapeo de propiedades según tu clase Entrevistas
                };
                entrevistas.Add(entrevista);
            }
            return entrevistas;
        }

        public List<Entrevistas> ObtenerEntrevistaPorNumero(int numeroEntrevista)
        {
            List<Entrevistas> entrevistas = new List<Entrevistas>();
            string consultaSQL = "SELECT * FROM Entrevistas WHERE numero = @Numero_Entrevista";
            parametros.Add(new SqlParameter("@Numero_Entrevista", numeroEntrevista));
            DataTable tablaEntrevistas = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaEntrevistas.Rows)
            {
                Entrevistas entrevista = new Entrevistas
                {
                    numero = Convert.ToInt32(fila["numero"]),
                    observaciones = fila["observaciones"].ToString(),
                    // Ajusta el mapeo de propiedades según tu clase Entrevistas
                };
                entrevistas.Add(entrevista);
            }
            return entrevistas;
        }
    }
}
