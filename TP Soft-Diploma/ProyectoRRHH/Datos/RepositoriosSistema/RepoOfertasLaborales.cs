using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
                var command = new SqlCommand("INSERT INTO Ofertas_Laborales (numero, titulo, descripcion, fechaCreacion) VALUES (@numero, @titulo, @descripcion, @fechaCreacion)", connection);
                command.Parameters.AddWithValue("@numero", ofertaLaboral.numero);
                command.Parameters.AddWithValue("@titulo", ofertaLaboral.titulo ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@descripcion", ofertaLaboral.descripcion ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@fechaCreacion", ofertaLaboral.fechaCreacion ?? (object)DBNull.Value);
                connection.Open();
                command.ExecuteNonQuery();
            }

            foreach (var requisitoId in requisitos)
            {
                var repoRequisitos = new RepoRequisitos();
                repoRequisitos.AgregarRequisitoAOferta(ofertaLaboral.numero, requisitoId);
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
            string consultaSQL = "DELETE FROM Ofertas_Laborales WHERE numero = @OfertaLaboralId";

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(consultaSQL, connection))
                {
                    command.Parameters.AddWithValue("@OfertaLaboralId", ofertaLaboralId);
                    connection.Open();
                    command.ExecuteNonQuery();
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

        //public List<int> ObtenerEstadosPorOferta(int numeroOferta)
        //{
        //    var estados = new List<int>();

        //    using (var connection = new SqlConnection(connectionString))
        //    {
        //        var command = new SqlCommand("SELECT codigo_estado FROM OL_Estados WHERE nro_OL = @numeroOferta", connection);
        //        command.Parameters.AddWithValue("@numeroOferta", numeroOferta);
        //        connection.Open();
        //        using (var reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                estados.Add(reader.GetInt32(0));
        //            }
        //        }
        //    }

        //    return estados;
        //}

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
                string query = "INSERT INTO OL_Perfiles (nro_OL, id_perfil) VALUES (@nro_OL, @id_perfil)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nro_OL", numeroOferta);
                command.Parameters.AddWithValue("@id_perfil", idPerfil);

                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    // Loguear el error si es necesario.
                    throw new Exception("Error al asignar el perfil a la oferta laboral: " + ex.Message);
                }
            }

        }
    }

}
