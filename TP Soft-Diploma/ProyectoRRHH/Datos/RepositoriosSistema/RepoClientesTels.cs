using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Datos
{
    public class RepoClientesTels : RepositorioMaestro
    {
        public List<Clientes_Telefonos> ObtenerTodosLosTelefonos()
        {
            List<Clientes_Telefonos> telefonos = new List<Clientes_Telefonos>();
            string consultaSQL = "SELECT * FROM Clientes_Telefonos"; // Ajusta esto según el nombre de tu tabla de teléfonos de clientes

            DataTable tablaTelefonos = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaTelefonos.Rows)
            {
                Clientes_Telefonos telefono = new Clientes_Telefonos
                {
                    id_cliente = Convert.ToInt32(fila["id_cliente"]),
                    telefono = fila["telefono"].ToString(),
                    // Ajusta el mapeo de propiedades según tu clase Clientes_Telefonos
                };
                telefonos.Add(telefono);
            }
            return telefonos;
        }

        public List<Clientes_Telefonos> ObtenerTelefonosPorIDCliente(int idCliente)
        {
            List<Clientes_Telefonos> telefonos = new List<Clientes_Telefonos>();
            string consultaSQL = "SELECT * FROM Clientes_Telefonos WHERE id_cliente = @ID_Cliente";
            parametros.Add(new SqlParameter("@ID_Cliente", idCliente));
            DataTable tablaTelefonos = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaTelefonos.Rows)
            {
                Clientes_Telefonos telefono = new Clientes_Telefonos
                {
                    id_cliente = Convert.ToInt32(fila["id_cliente"]),
                    telefono = fila["telefono"].ToString(),
                    // Ajusta el mapeo de propiedades según tu clase Clientes_Telefonos
                };
                telefonos.Add(telefono);
            }
            return telefonos;
        }
    }
}

