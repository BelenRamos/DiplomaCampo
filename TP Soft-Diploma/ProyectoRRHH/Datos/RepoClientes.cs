using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Datos
{
    public class RepoClientes : RepositorioMaestro
    {
        public List<Clientes> ObtenerTodosLosClientes()
        {
            List<Clientes> clientes = new List<Clientes>();
            string consultaSQL = "SELECT * FROM Clientes"; // Ajusta esto según el nombre de tu tabla de clientes

            DataTable tablaClientes = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaClientes.Rows)
            {
                Clientes cliente = new Clientes
                {
                    id = Convert.ToInt32(fila["id"]),
                    nombre = fila["nombre"].ToString(),
                    // Ajusta el mapeo de propiedades según tu clase Clientes
                };
                clientes.Add(cliente);
            }
            return clientes;
        }

        public List<Clientes> ObtenerClientePorID(int idCliente)
        {
            List<Clientes> clientes = new List<Clientes>();
            string consultaSQL = "SELECT * FROM Clientes WHERE id = @ID_Cliente";
            parametros.Add(new SqlParameter("@ID_Cliente", idCliente));
            DataTable tablaClientes = ExecuteReader(consultaSQL);

            foreach (DataRow fila in tablaClientes.Rows)
            {
                Clientes cliente = new Clientes
                {
                    id = Convert.ToInt32(fila["id"]),
                    nombre = fila["nombre"].ToString(),
                    // Ajusta el mapeo de propiedades según tu clase Clientes
                };
                clientes.Add(cliente);
            }
            return clientes;
        }
    }
}
