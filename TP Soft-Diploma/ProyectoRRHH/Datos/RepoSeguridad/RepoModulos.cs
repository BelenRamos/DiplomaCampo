using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Datos;
using Modelo;

namespace Datos.RepoSeguridad
{
    public class RepoModulos : RepositorioMaestro
    {
        public List<Modulos> ObtenerTodosLosModulos()
        {
            List<Modulos> modulos = new List<Modulos>();
            string consultaSQL = "SELECT * FROM Modulos";

            try
            {
                DataTable tablaModulos = ExecuteReader(consultaSQL);
                modulos = ConvertirDataTableALista(tablaModulos);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al obtener todos los módulos: " + ex.Message);
                throw;
            }

            return modulos;
        }

        public Modulos ObtenerModuloPorID(int idModulo)
        {
            Modulos modulo = null;
            string consultaSQL = "SELECT * FROM Modulos WHERE idModulo = @ID";

            try
            {
                parametros.Clear();
                parametros.Add(new SqlParameter("@ID", idModulo));
                DataTable tablaModulo = ExecuteReader(consultaSQL);
                if (tablaModulo.Rows.Count > 0)
                {
                    modulo = ConvertirDataRowAModulo(tablaModulo.Rows[0]);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al obtener módulo por ID: " + ex.Message);
                throw;
            }

            return modulo;
        }

        private List<Modulos> ConvertirDataTableALista(DataTable tabla)
        {
            List<Modulos> modulos = new List<Modulos>();

            foreach (DataRow fila in tabla.Rows)
            {
                modulos.Add(ConvertirDataRowAModulo(fila));
            }

            return modulos;
        }

        private Modulos ConvertirDataRowAModulo(DataRow fila)
        {
            return new Modulos
            {
                idModulo = Convert.ToInt32(fila["idModulo"]),
                nombreModulo = fila["nombreModulo"].ToString()
            };
        }
    }
}

