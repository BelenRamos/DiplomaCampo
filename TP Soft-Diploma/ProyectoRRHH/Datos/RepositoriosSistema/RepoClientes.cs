using Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Datos
{
    public class RepoClientes : RepositorioMaestro
    {
        private string connectionString;

        public RepoClientes()
        {
            // Obtener la cadena de conexión desde la configuración
            connectionString = ConfigurationManager.ConnectionStrings["Modelo"].ConnectionString;
        }

        public List<Clientes> ObtenerTodosLosClientes()
        {
            List<Clientes> clientes = new List<Clientes>();
            string consultaSQL = "SELECT * FROM Clientes";

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
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@ID_Cliente", idCliente)
            };
            DataTable tablaClientes = ExecuteReader(consultaSQL, parametros);

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

        // Métodos para gestionar la tabla intermedia OL_Clientes
        public int AgregarClienteAOferta(int ofertaLaboralId, int clienteId)
        {
            string consultaSQL = "INSERT INTO OL_Clientes (nro_OL, id_cliente) VALUES (@OfertaLaboralId, @ClienteId)";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@OfertaLaboralId", ofertaLaboralId),
                new SqlParameter("@ClienteId", clienteId)
            };

            try
            {
                return ExecuteNonQuery(consultaSQL, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el cliente a la oferta laboral.", ex);
            }
        }

        public int EliminarClienteDeOferta(int ofertaLaboralId, int clienteId)
        {
            string consultaSQL = "DELETE FROM OL_Clientes WHERE nro_OL = @OfertaLaboralId AND id_cliente = @ClienteId";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@OfertaLaboralId", ofertaLaboralId),
                new SqlParameter("@ClienteId", clienteId)
            };

            try
            {
                return ExecuteNonQuery(consultaSQL, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el cliente de la oferta laboral.", ex);
            }
        }

        public List<int> ObtenerClientesPorOferta(int ofertaLaboralId)
        {
            List<int> clientes = new List<int>();
            string consultaSQL = "SELECT id_cliente FROM OL_Clientes WHERE nro_OL = @OfertaLaboralId";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@OfertaLaboralId", ofertaLaboralId)
            };

            DataTable tablaClientes = ExecuteReader(consultaSQL, parametros);

            foreach (DataRow fila in tablaClientes.Rows)
            {
                int clienteId = Convert.ToInt32(fila["id_cliente"]);
                clientes.Add(clienteId);
            }
            return clientes;
        }

        private DataTable ExecuteReader(string consultaSQL, List<SqlParameter> parametros = null)
        {
            DataTable tablaResultados = new DataTable();

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(consultaSQL, conexion))
                {
                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros.ToArray());
                    }

                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    adaptador.Fill(tablaResultados);
                }
            }

            return tablaResultados;
        }

        private int ExecuteNonQuery(string consultaSQL, List<SqlParameter> parametros)
        {
            int filasAfectadas = 0;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(consultaSQL, conexion))
                {
                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros.ToArray());
                    }

                    conexion.Open();
                    filasAfectadas = comando.ExecuteNonQuery();
                }
            }

            return filasAfectadas;
        }

        public int ObtenerTotalClientes()
        {
            string consultaSQL = "SELECT COUNT(*) FROM Clientes";
            int totalClientes = 0;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(consultaSQL, conexion))
                {
                    conexion.Open();
                    totalClientes = (int)comando.ExecuteScalar();
                }
            }

            return totalClientes;
        }

    }
}




//namespace Datos
//{
//    public class RepoClientes : RepositorioMaestro
//    {
//        public List<Clientes> ObtenerTodosLosClientes()
//        {
//            List<Clientes> clientes = new List<Clientes>();
//            string consultaSQL = "SELECT * FROM Clientes"; // Ajusta esto según el nombre de tu tabla de clientes

//            DataTable tablaClientes = ExecuteReader(consultaSQL);

//            foreach (DataRow fila in tablaClientes.Rows)
//            {
//                Clientes cliente = new Clientes
//                {
//                    id = Convert.ToInt32(fila["id"]),
//                    nombre = fila["nombre"].ToString(),
//                    // Ajusta el mapeo de propiedades según tu clase Clientes
//                };
//                clientes.Add(cliente);
//            }
//            return clientes;
//        }

//        public List<Clientes> ObtenerClientePorID(int idCliente)
//        {
//            List<Clientes> clientes = new List<Clientes>();
//            string consultaSQL = "SELECT * FROM Clientes WHERE id = @ID_Cliente";
//            parametros.Add(new SqlParameter("@ID_Cliente", idCliente));
//            DataTable tablaClientes = ExecuteReader(consultaSQL);

//            foreach (DataRow fila in tablaClientes.Rows)
//            {
//                Clientes cliente = new Clientes
//                {
//                    id = Convert.ToInt32(fila["id"]),
//                    nombre = fila["nombre"].ToString(),
//                    // Ajusta el mapeo de propiedades según tu clase Clientes
//                };
//                clientes.Add(cliente);
//            }
//            return clientes;
//        }
//    }
//}
