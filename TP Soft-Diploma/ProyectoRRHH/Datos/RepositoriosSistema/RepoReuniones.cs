﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Datos
{
    public class RepoReuniones : RepositorioMaestro
    {
        private string connectionString = "data source=.;initial catalog=db_RRHH;integrated security=True;encrypt=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework";
        public List<Reuniones> ObtenerTodasLasReuniones()
        {
            List<Reuniones> reuniones = new List<Reuniones>();
            string consultaSQL = "SELECT * FROM Reuniones"; // Ajusta esto según el nombre de tu tabla de reuniones

            DataTable tablaReuniones = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaReuniones.Rows)
            {
                Reuniones reunion = new Reuniones
                {
                    numero = Convert.ToInt32(fila["numero"]),
                    observaciones = fila["observaciones"].ToString(),
                    // Ajusta el mapeo de propiedades según tu clase Reuniones
                };
                reuniones.Add(reunion);
            }
            return reuniones;
        }

        public Reuniones ObtenerReunionPorNumero(int numeroReunion)
        {
            Reuniones reunion = null;
            string consultaSQL = "SELECT * FROM Reuniones WHERE numero = @Numero_Reunion";
            parametros.Add(new SqlParameter("@Numero_Reunion", numeroReunion));
            DataTable tablaReuniones = ExecuteReader(consultaSQL);

            if (tablaReuniones.Rows.Count > 0)
            {
                DataRow fila = tablaReuniones.Rows[0];
                reunion = new Reuniones
                {
                    numero = Convert.ToInt32(fila["numero"]),
                    observaciones = fila["observaciones"].ToString(),
                    // Ajusta el mapeo de propiedades según tu clase Reuniones
                };
            }
            return reunion;
        }
        public void AgregarReunion(int nroReunion)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Reuniones (numero) VALUES (@numero)", conn))
                {
                    cmd.Parameters.AddWithValue("@numero", nroReunion);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
