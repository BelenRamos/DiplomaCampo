using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class RepoOfertasLaborales : RepositorioMaestro
    {
        public int AltaOfertaLaboral(Ofertas_Laborales oferta, List<int> clienteIds, List<int> estadoIds, List<int> perfilIds, List<int> requisitoIds)
        {
            string consultaSQL = @"INSERT INTO Ofertas_Laborales (numero, titulo, descripcion, fechaCreacion, fechaPublicacion, fechaCierre) 
                                   VALUES (@numero, @titulo, @descripcion, @fechaCreacion, @fechaPublicacion, @fechaCierre);
                                   SELECT SCOPE_IDENTITY();";

            parametros.Clear();
            parametros.Add(new SqlParameter("@numero", oferta.numero));
            parametros.Add(new SqlParameter("@titulo", oferta.titulo ?? (object)DBNull.Value));
            parametros.Add(new SqlParameter("@descripcion", oferta.descripcion ?? (object)DBNull.Value));
            parametros.Add(new SqlParameter("@fechaCreacion", oferta.fechaCreacion.HasValue ? (object)oferta.fechaCreacion.Value : DBNull.Value));
            parametros.Add(new SqlParameter("@fechaPublicacion", oferta.fechaPublicacion.HasValue ? (object)oferta.fechaPublicacion.Value : DBNull.Value));
            parametros.Add(new SqlParameter("@fechaCierre", oferta.fechaCierre.HasValue ? (object)oferta.fechaCierre.Value : DBNull.Value));

            try
            {
                int ofertaId = Convert.ToInt32(ExecuteScalar(consultaSQL)); // Asumiendo que ExecuteScalar devuelve el ID de la nueva oferta

                InsertarRelaciones(ofertaId, "Clientes_Ofertas", "clienteId", clienteIds);
                InsertarRelaciones(ofertaId, "Estados_Ofertas", "estadoId", estadoIds);
                InsertarRelaciones(ofertaId, "Perfiles_Ofertas", "perfilId", perfilIds);
                InsertarRelaciones(ofertaId, "Requisitos_Ofertas", "requisitoId", requisitoIds);

                return ofertaId;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta la oferta laboral", ex);
            }
        }

        private object ExecuteScalar(string consultaSQL)
        {
            throw new NotImplementedException();
        }

        private void InsertarRelaciones(int ofertaId, string tabla, string columnaRelacion, List<int> ids)
        {
            if (ids != null)
            {
                foreach (int id in ids)
                {
                    string consultaSQL = $"INSERT INTO {tabla} (ofertaId, {columnaRelacion}) VALUES (@ofertaId, @{columnaRelacion})";
                    var parametrosRelacion = new List<SqlParameter>
                    {
                        new SqlParameter("@ofertaId", ofertaId),
                        new SqlParameter($"@{columnaRelacion}", id)
                    };
                    ExecuteNonQuery(consultaSQL, parametrosRelacion);

                }
            }
        }

        public List<Ofertas_Laborales> ObtenerTodasLasOfertasLaborales()
        {
            List<Ofertas_Laborales> ofertasLaborales = new List<Ofertas_Laborales>();
            string consultaSQL = "SELECT * FROM Ofertas_Laborales";

            try
            {
                DataTable tablaOfertas = ExecuteReader(consultaSQL);

                foreach (DataRow fila in tablaOfertas.Rows)
                {
                    Ofertas_Laborales oferta = new Ofertas_Laborales
                    {
                        numero = Convert.ToInt32(fila["numero"]),
                        titulo = fila["titulo"].ToString(),
                        descripcion = fila["descripcion"].ToString(),
                        fechaCreacion = fila["fechaCreacion"] != DBNull.Value ? Convert.ToDateTime(fila["fechaCreacion"]) : (DateTime?)null,
                        fechaPublicacion = fila["fechaPublicacion"] != DBNull.Value ? Convert.ToDateTime(fila["fechaPublicacion"]) : (DateTime?)null,
                        fechaCierre = fila["fechaCierre"] != DBNull.Value ? Convert.ToDateTime(fila["fechaCierre"]) : (DateTime?)null
                    };
                    ofertasLaborales.Add(oferta);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las ofertas laborales", ex);
            }

            return ofertasLaborales;
        }

        public int BajaOfertaLaboral(int numero)
        {
            string consultaSQL = "DELETE FROM Ofertas_Laborales WHERE numero = @numero";

            parametros.Clear();
            parametros.Add(new SqlParameter("@numero", numero));

            try
            {
                return ExecuteNonQuery(consultaSQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de baja la oferta laboral", ex);
            }
        }

        public int ModificarOfertaLaboral(Ofertas_Laborales oferta)
        {
            string consultaSQL = @"UPDATE Ofertas_Laborales 
                                   SET titulo = @titulo, 
                                       descripcion = @descripcion, 
                                       fechaCreacion = @fechaCreacion, 
                                       fechaPublicacion = @fechaPublicacion, 
                                       fechaCierre = @fechaCierre 
                                   WHERE numero = @numero";

            parametros.Clear();
            parametros.Add(new SqlParameter("@numero", oferta.numero));
            parametros.Add(new SqlParameter("@titulo", oferta.titulo ?? (object)DBNull.Value));
            parametros.Add(new SqlParameter("@descripcion", oferta.descripcion ?? (object)DBNull.Value));
            parametros.Add(new SqlParameter("@fechaCreacion", oferta.fechaCreacion.HasValue ? (object)oferta.fechaCreacion.Value : DBNull.Value));
            parametros.Add(new SqlParameter("@fechaPublicacion", oferta.fechaPublicacion.HasValue ? (object)oferta.fechaPublicacion.Value : DBNull.Value));
            parametros.Add(new SqlParameter("@fechaCierre", oferta.fechaCierre.HasValue ? (object)oferta.fechaCierre.Value : DBNull.Value));

            try
            {
                return ExecuteNonQuery(consultaSQL);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar la oferta laboral", ex);
            }
        }

        public int ObtenerUltimoNumero()
        {
            string consultaSQL = "SELECT ISNULL(MAX(numero), 0) FROM Ofertas_Laborales";
            try
            {
                DataTable result = ExecuteReader(consultaSQL);
                if (result.Rows.Count > 0)
                {
                    return Convert.ToInt32(result.Rows[0][0]);
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el último número de oferta laboral", ex);
            }
        }

        private int ExecuteNonQuery(string consultaSQL, List<SqlParameter> parametros)
        {
            int filasAfectadas = 0;
            string connectionString = "data source=.;initial catalog=db_RRHH;integrated security=True;encrypt=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework";

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

        private object ExecuteScalar(string consultaSQL, List<SqlParameter> parametros)
        {
            object resultado = null;
            string connectionString = "data source=.;initial catalog=db_RRHH;integrated security=True;encrypt=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(consultaSQL, conexion))
                {
                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros.ToArray());
                    }
                    conexion.Open();
                    resultado = comando.ExecuteScalar();
                }
            }
            return resultado;
        }
    }
}





