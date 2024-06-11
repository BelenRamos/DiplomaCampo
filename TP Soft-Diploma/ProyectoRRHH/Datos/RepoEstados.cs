using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Modelo;

namespace Datos
{
    public class RepoEstados : RepositorioMaestro
    {
        public List<Estados> ObtenerTodosLosEstados()
        {
            List<Estados> estados = new List<Estados>();
            string consultaSQL = "SELECT * FROM Estados";

            DataTable tablaEstados = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaEstados.Rows)
            {
                Estados estado = new Estados
                {
                    codigo = Convert.ToInt32(fila["codigo"]),
                    designacion = fila["designacion"].ToString(),
                };
                estados.Add(estado);
            }
            return estados;
        }

        public List<Estados> ObtenerEstadoPorCodigo(int codigoEstado)
        {
            List<Estados> estados = new List<Estados>();
            string consultaSQL = "SELECT * FROM Estados WHERE codigo = @CodigoEstado";
            parametros.Add(new SqlParameter("@CodigoEstado", codigoEstado));
            DataTable tablaEstados = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaEstados.Rows)
            {
                Estados estado = new Estados
                {
                    codigo = Convert.ToInt32(fila["codigo"]),
                    designacion = fila["designacion"].ToString(),
                };
                estados.Add(estado);
            }
            return estados;
        }
    }
}

