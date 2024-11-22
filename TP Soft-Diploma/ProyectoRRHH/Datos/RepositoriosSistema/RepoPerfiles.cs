using Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class RepoPerfiles : RepositorioMaestro
    {
        private string connectionString;

        public RepoPerfiles()
        {
            // Obtener la cadena de conexión desde la configuración
            connectionString = ConfigurationManager.ConnectionStrings["Modelo"].ConnectionString;
        }

        public List<Perfiles> ObtenerTodosLosPerfiles()
        {
            List<Perfiles> perfiles = new List<Perfiles>();
            string consultaSQL = "SELECT * FROM Perfiles";

            try
            {
                DataTable tablaPerfiles = ExecuteReader(consultaSQL);

                foreach (DataRow fila in tablaPerfiles.Rows)
                {
                    Perfiles perfil = new Perfiles
                    {
                        id = Convert.ToInt32(fila["id"]),
                        nombre = fila["nombre"].ToString(),
                        descripcion = fila["descripcion"].ToString()
                    };
                    perfiles.Add(perfil);
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al obtener los perfiles", ex);
            }

            return perfiles;
        }

        public Perfiles ObtenerPerfilPorId(int id)
        {
            Perfiles perfil = null;
            string consultaSQL = "SELECT * FROM Perfiles WHERE id = @id";

            parametros.Clear();
            parametros.Add(new SqlParameter("@id", id));

            try
            {
                DataTable tablaPerfil = ExecuteReader(consultaSQL);

                if (tablaPerfil.Rows.Count > 0)
                {
                    DataRow fila = tablaPerfil.Rows[0];
                    perfil = new Perfiles
                    {
                        id = Convert.ToInt32(fila["id"]),
                        nombre = fila["nombre"].ToString(),
                        descripcion = fila["descripcion"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al obtener el perfil por ID", ex);
            }

            return perfil;
        }

        public int AltaPerfil(Perfiles perfil)
        {
            string consultaSQL = @"INSERT INTO Perfiles (id, nombre, descripcion) 
                                   VALUES (@id, @nombre, @descripcion)";

            parametros.Clear();
            parametros.Add(new SqlParameter("@id", perfil.id));
            parametros.Add(new SqlParameter("@nombre", perfil.nombre ?? (object)DBNull.Value));
            parametros.Add(new SqlParameter("@descripcion", perfil.descripcion ?? (object)DBNull.Value));

            try
            {
                return ExecuteNonQuery(consultaSQL);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al dar de alta el perfil", ex);
            }
        }

        public int BajaPerfil(int id)
        {
            string consultaSQL = "DELETE FROM Perfiles WHERE id = @id";

            parametros.Clear();
            parametros.Add(new SqlParameter("@id", id));

            try
            {
                return ExecuteNonQuery(consultaSQL);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al dar de baja el perfil", ex);
            }
        }


        public int ModificarPerfil(Perfiles perfil)
        {
            string consultaSQL = @"UPDATE Perfiles 
                                   SET nombre = @nombre, 
                                       descripcion = @descripcion 
                                   WHERE id = @id";

            parametros.Clear();
            parametros.Add(new SqlParameter("@id", perfil.id));
            parametros.Add(new SqlParameter("@nombre", perfil.nombre ?? (object)DBNull.Value));
            parametros.Add(new SqlParameter("@descripcion", perfil.descripcion ?? (object)DBNull.Value));

            try
            {
                return ExecuteNonQuery(consultaSQL);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al modificar el perfil", ex);
            }
        }

        public int ObtenerUltimoId()
        {
            string consultaSQL = "SELECT ISNULL(MAX(id), 0) FROM Perfiles";
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
                throw new Exception("Error al obtener el último ID de perfil", ex);
            }
        }

        public Perfiles ObtenerPerfilPorNombre(string nombre)
        {
            Perfiles perfil = null;
            string consultaSQL = "SELECT * FROM Perfiles WHERE nombre = @nombre";

            parametros.Clear();
            parametros.Add(new SqlParameter("@nombre", nombre));

            try
            {
                DataTable tablaPerfil = ExecuteReader(consultaSQL);

                if (tablaPerfil.Rows.Count > 0)
                {
                    DataRow fila = tablaPerfil.Rows[0];
                    perfil = new Perfiles
                    {
                        id = Convert.ToInt32(fila["id"]),
                        nombre = fila["nombre"].ToString(),
                        descripcion = fila["descripcion"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al obtener el perfil por nombre", ex);
            }

            return perfil;
        }

        public int EliminarPerfilDeOferta(int idOferta)
        {
            string consultaSQL = "DELETE FROM OL_Perfiles WHERE nro_OL = @nro_OL";

            parametros.Clear();
            parametros.Add(new SqlParameter("@nro_OL", idOferta));

            try
            {
                return ExecuteNonQuery(consultaSQL);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al eliminar perfiles asociados a la oferta laboral", ex);
            }
        }


    }
}
