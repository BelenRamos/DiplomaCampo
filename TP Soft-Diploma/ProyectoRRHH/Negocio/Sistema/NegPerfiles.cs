using Modelo;
using System;
using System.Collections.Generic;
using Datos;

namespace Negocio
{
    public class NegPerfiles
    {
        private static NegPerfiles instancia;
        private RepoPerfiles repositorio;
        private List<Perfiles> perfiles;

        private NegPerfiles()
        {
            repositorio = new RepoPerfiles();
            perfiles = new List<Perfiles>();
        }

        public static NegPerfiles ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegPerfiles();
            }
            return instancia;
        }

        public List<Perfiles> ObtenerTodosLosPerfiles()
        {
            try
            {
                return repositorio.ObtenerTodosLosPerfiles();
            
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al obtener los perfiles.", ex);
            }
        }

        public Perfiles ObtenerPerfilPorId(int id)
        {
            try
            {
                return repositorio.ObtenerPerfilPorId(id);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al obtener el perfil por ID.", ex);
            }
        }

        public int AltaPerfil(Perfiles perfil)
        {
            try
            {
                perfil.id = repositorio.ObtenerUltimoId() + 1;
                return repositorio.AltaPerfil(perfil);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el perfil.", ex);
            }
        }

        public int BajaPerfil(int id)
        {
            try
            {
                return repositorio.BajaPerfil(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de baja el perfil.", ex);
            }
        }


        public int ModificarPerfil(Perfiles perfil)
        {
            try
            {
                return repositorio.ModificarPerfil(perfil);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al modificar el perfil.", ex);
            }
        }

        public Perfiles ObtenerPerfilPorNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ArgumentException("El nombre del perfil no puede estar vacío.");
            }

            return repositorio.ObtenerPerfilPorNombre(nombre);
        }

        public int EliminarPerfilDeOferta(int ofertaLaboralId)
        {
            try
            {
                int filasEliminadas = repositorio.EliminarPerfilDeOferta(ofertaLaboralId);
                if (filasEliminadas == 0)
                {
                    throw new Exception("No se encuentra el perfil para eliminar en la oferta laboral.");
                }
                return filasEliminadas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el perfil de la oferta laboral.", ex);
            }
        }
    }
}
