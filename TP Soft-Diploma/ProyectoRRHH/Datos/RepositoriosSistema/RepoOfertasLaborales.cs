using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Modelo;

namespace Datos
{
    public class RepoOfertasLaborales
    {
        private string connectionString;
        private List<int> requisitos = new List<int>();  // Inicializando como una lista vacía
        public RepoOfertasLaborales()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Modelo"].ConnectionString;
        }
        public List<Ofertas_Laborales> ObtenerOfertasLaborales()
        {
            var ofertasLaborales = new List<Ofertas_Laborales>();

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT numero, titulo, descripcion, fechaCreacion, fechaPublicacion, fechaCierre FROM Ofertas_Laborales", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ofertaLaboral = new Ofertas_Laborales
                        {
                            numero = reader.GetInt32(0),
                            titulo = reader.IsDBNull(1) ? null : reader.GetString(1),
                            descripcion = reader.IsDBNull(2) ? null : reader.GetString(2),
                            fechaCreacion = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                            fechaPublicacion = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4),
                            fechaCierre = reader.IsDBNull(5) ? (DateTime?)null : reader.GetDateTime(5)
                        };
                        ofertasLaborales.Add(ofertaLaboral);
                    }
                }
            }

            return ofertasLaborales;
        }

        public Ofertas_Laborales ObtenerOfertaLaboralPorNumero(int numero)
        {
            Ofertas_Laborales ofertaLaboral = null;

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT numero, titulo, descripcion, fechaCreacion, fechaPublicacion, fechaCierre FROM Ofertas_Laborales WHERE numero = @numero", connection);
                command.Parameters.AddWithValue("@numero", numero);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ofertaLaboral = new Ofertas_Laborales
                        {
                            numero = reader.GetInt32(0),
                            titulo = reader.IsDBNull(1) ? null : reader.GetString(1),
                            descripcion = reader.IsDBNull(2) ? null : reader.GetString(2),
                            fechaCreacion = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                            fechaPublicacion = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4),
                            fechaCierre = reader.IsDBNull(5) ? (DateTime?)null : reader.GetDateTime(5)


                        };
                    }
                }
            }

            return ofertaLaboral;
        }

        public void AgregarOfertaLaboral(Ofertas_Laborales ofertaLaboral)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open(); // Abre la conexión antes de cualquier operación

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insertar la oferta laboral
                        var command = new SqlCommand(
                            @"INSERT INTO Ofertas_Laborales (numero, titulo, descripcion, fechaCreacion) 
                      VALUES (@numero, @titulo, @descripcion, @fechaCreacion)",
                            connection,
                            transaction);

                        command.Parameters.AddWithValue("@numero", ofertaLaboral.numero);
                        command.Parameters.AddWithValue("@titulo", ofertaLaboral.titulo ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@descripcion", ofertaLaboral.descripcion ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@fechaCreacion", ofertaLaboral.fechaCreacion ?? DateTime.Now);

                        command.ExecuteNonQuery();

                        // Insertar el estado inicial (abierta)
                        var commandEstado = new SqlCommand(
                            @"INSERT INTO OL_Estados (nro_OL, codigo_estado) 
                      VALUES (@nro_OL, 2);",
                            connection,
                            transaction);

                        commandEstado.Parameters.AddWithValue("@nro_OL", ofertaLaboral.numero);
                        commandEstado.ExecuteNonQuery();

                        // Asignar requisitos
                        foreach (var requisitoId in requisitos)
                        {
                            var repoRequisitos = new RepoRequisitos();
                            repoRequisitos.AgregarRequisitoAOferta(ofertaLaboral.numero, requisitoId);
                        }


                        transaction.Commit(); 
                    }
                    catch
                    {
                        transaction.Rollback(); 
                        throw; 
                    }
                }
            }
        }


        public void ActualizarOfertaLaboral(Ofertas_Laborales ofertaLaboral)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("UPDATE Ofertas_Laborales SET titulo = @titulo, descripcion = @descripcion, fechaCreacion = @fechaCreacion, fechaPublicacion = @fechaPublicacion, fechaCierre = @fechaCierre WHERE numero = @numero", connection);
                command.Parameters.AddWithValue("@numero", ofertaLaboral.numero);
                command.Parameters.AddWithValue("@titulo", ofertaLaboral.titulo ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@descripcion", ofertaLaboral.descripcion ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@fechaCreacion", ofertaLaboral.fechaCreacion ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@fechaPublicacion", ofertaLaboral.fechaPublicacion ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@fechaCierre", ofertaLaboral.fechaCierre ?? (object)DBNull.Value);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void EliminarOfertaLaboral(int ofertaLaboralId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open(); // Abre la conexión antes de las operaciones

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Eliminar de OL_Estados
                        string consultaEliminarEstados = "DELETE FROM OL_Estados WHERE nro_OL = @OfertaLaboralId";
                        using (var commandEstados = new SqlCommand(consultaEliminarEstados, connection, transaction))
                        {
                            commandEstados.Parameters.AddWithValue("@OfertaLaboralId", ofertaLaboralId);
                            commandEstados.ExecuteNonQuery();
                        }

                        // Eliminar de Ofertas_Laborales
                        string consultaEliminarOferta = "DELETE FROM Ofertas_Laborales WHERE numero = @OfertaLaboralId";
                        using (var commandOferta = new SqlCommand(consultaEliminarOferta, connection, transaction))
                        {
                            commandOferta.Parameters.AddWithValue("@OfertaLaboralId", ofertaLaboralId);
                            commandOferta.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al eliminar la oferta laboral: " + ex.Message);
                    }
                }
            }
        }
        public int ObtenerUltimoNumero()
        {
            string consultaSQL = "SELECT ISNULL(MAX(numero), 0) FROM Ofertas_Laborales";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand(consultaSQL, connection);
                    connection.Open();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el último número de oferta laboral", ex);
            }
        }

        public List<Ofertas_Laborales> ObtenerOfertasPorEstado(int codigoEstado)
        {
            var ofertasLaborales = new List<Ofertas_Laborales>();

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT numero, titulo, descripcion, fechaCreacion, fechaPublicacion, fechaCierre FROM Ofertas_Laborales WHERE estado = @codigoEstado", connection);
                command.Parameters.AddWithValue("@codigoEstado", codigoEstado);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ofertaLaboral = new Ofertas_Laborales
                        {
                            numero = reader.GetInt32(0),
                            titulo = reader.IsDBNull(1) ? null : reader.GetString(1),
                            descripcion = reader.IsDBNull(2) ? null : reader.GetString(2),
                            fechaCreacion = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                            fechaPublicacion = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4),
                            fechaCierre = reader.IsDBNull(5) ? (DateTime?)null : reader.GetDateTime(5)
                        };
                        ofertasLaborales.Add(ofertaLaboral);
                    }
                }
            }

            return ofertasLaborales;
        }

        public void PublicarOfertaLaboral(int numero, DateTime fechaPublicacion)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("UPDATE Ofertas_Laborales SET fechaPublicacion = @fechaPublicacion, estado = @estado WHERE numero = @numero", connection);
                command.Parameters.AddWithValue("@numero", numero);
                command.Parameters.AddWithValue("@fechaPublicacion", fechaPublicacion);
                //command.Parameters.AddWithValue("@estado", 4); // Código para "Publicación"

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void CerrarOfertaLaboral(int numero)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("UPDATE Ofertas_Laborales SET estado = @estado WHERE numero = @numero", connection);
                command.Parameters.AddWithValue("@numero", numero);
                //command.Parameters.AddWithValue("@estado", 5); // Código para "Recepción de candidaturas" (o el código correspondiente)

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public bool AsignarPerfilAOferta(int numeroOferta, int idPerfil)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); // Abre la conexión al inicio
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insertar en OL_Perfiles
                        string queryPerfil = "INSERT INTO OL_Perfiles (nro_OL, id_perfil) VALUES (@nro_OL, @id_perfil)";
                        var commandPerfil = new SqlCommand(queryPerfil, connection, transaction);
                        commandPerfil.Parameters.AddWithValue("@nro_OL", numeroOferta);
                        commandPerfil.Parameters.AddWithValue("@id_perfil", idPerfil);
                        commandPerfil.ExecuteNonQuery();

                        // Actualizar el estado a 3 (perfilada) en OL_Estados
                        string queryEstado = @"UPDATE OL_Estados 
                                       SET codigo_estado = 3 
                                       WHERE nro_OL = @nro_OL";
                        var commandEstado = new SqlCommand(queryEstado, connection, transaction);
                        commandEstado.Parameters.AddWithValue("@nro_OL", numeroOferta);
                        commandEstado.ExecuteNonQuery();

                        transaction.Commit(); // Confirma la transacción
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); // Revierte la transacción en caso de error
                                                // Loguear el error si es necesario
                        throw new Exception("Error al asignar el perfil a la oferta laboral: " + ex.Message);
                    }
                }
            }
        }
        public object ObtenerEstadosPorOfertas()
        {
            throw new NotImplementedException();
        }

        //Reporte
        public List<(string Estado, int Cantidad, int Porcentaje)> ObtenerOfertasPorEstadoConPorcentajes()
        {
            var resultados = new Dictionary<string, int>();
            int totalOfertas = 0;

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(
                    @"SELECT E.designacion AS Estado, COUNT(O.numero) AS Cantidad
              FROM Ofertas_Laborales O
              INNER JOIN OL_Estados OE ON O.numero = OE.nro_OL
              INNER JOIN Estados E ON OE.codigo_estado = E.codigo
              GROUP BY E.designacion",
                    connection);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string estado = reader["Estado"].ToString();
                        int cantidad = Convert.ToInt32(reader["Cantidad"]);
                        resultados[estado] = cantidad;
                        totalOfertas += cantidad;
                    }
                }
            }

            // Calcular porcentajes
            var resultadosConPorcentaje = resultados.Select(kvp =>
                (Estado: kvp.Key,
                 Cantidad: kvp.Value,
                 Porcentaje: (int)Math.Round((kvp.Value / (double)totalOfertas) * 100))
            ).ToList();

            return resultadosConPorcentaje;
        }




    }

}
