using Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class RepoClientesTels : RepositorioMaestro
    {
        private string connectionString;

        public RepoClientesTels()
        {
            // Obtener la cadena de conexión desde la configuración
            connectionString = ConfigurationManager.ConnectionStrings["Modelo"].ConnectionString;
        }

        public void AgregarTelefono(Clientes_Telefonos clienteTelefono)
        {
            string consultaSQL = @"INSERT INTO Clientes_Telefonos (id_cliente, telefono) 
                                   VALUES (@id_cliente, @telefono)";

            parametros.Clear();
            parametros.Add(new SqlParameter("@id_cliente", clienteTelefono.id_cliente));
            parametros.Add(new SqlParameter("@telefono", clienteTelefono.telefono ?? (object)DBNull.Value));

            try
            {
                ExecuteNonQuery(consultaSQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el teléfono del cliente", ex);
            }
        }

        public List<Clientes_Telefonos> ObtenerTelefonosPorCliente(int clienteId)
        {
            List<Clientes_Telefonos> telefonos = new List<Clientes_Telefonos>();
            string consultaSQL = "SELECT * FROM Clientes_Telefonos WHERE id_cliente = @id_cliente";

            parametros.Clear();
            parametros.Add(new SqlParameter("@id_cliente", clienteId));

            try
            {
                DataTable tablaTelefonos = ExecuteReader(consultaSQL);

                foreach (DataRow fila in tablaTelefonos.Rows)
                {
                    Clientes_Telefonos telefono = new Clientes_Telefonos
                    {
                        id_cliente = Convert.ToInt32(fila["id_cliente"]),
                        telefono = fila["telefono"].ToString()
                    };
                    telefonos.Add(telefono);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los teléfonos del cliente", ex);
            }

            return telefonos;
        }

        public void EliminarTelefonosPorClienteId(int clienteId)
        {
            string consultaSQL = "DELETE FROM Clientes_Telefonos WHERE id_cliente = @id_cliente";

            parametros.Clear();
            parametros.Add(new SqlParameter("@id_cliente", clienteId));

            try
            {
                ExecuteNonQuery(consultaSQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar los teléfonos del cliente", ex);
            }
        }
    }
}
