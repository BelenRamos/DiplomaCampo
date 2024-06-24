using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Datos;
using Modelo;

namespace Datos.RepoSeguridad
{
    public class RepoFormularios : RepositorioMaestro
    {
        public List<Formularios> ObtenerTodosLosFormularios()
        {
            List<Formularios> formularios = new List<Formularios>();
            string consultaSQL = "SELECT idForm, nombreForm, idModulo FROM Formularios";

            try
            {
                DataTable tablaFormularios = ExecuteReader(consultaSQL);

                foreach (DataRow fila in tablaFormularios.Rows)
                {
                    Formularios formulario = new Formularios
                    {
                        idForm = Convert.ToInt32(fila["idForm"]),
                        nombreForm = fila["nombreForm"].ToString(),
                        idModulo = fila["idModulo"] != DBNull.Value ? Convert.ToInt32(fila["idModulo"]) : (int?)null
                    };
                    formularios.Add(formulario);
                }
            }
            catch (SqlException ex)
            {
                // Manejar la excepción aquí según sea necesario
                Console.WriteLine("Error al obtener formularios: " + ex.Message);
                throw; // Puedes relanzar la excepción o manejarla según tu lógica de aplicación
            }

            return formularios;
        }
    }
}


