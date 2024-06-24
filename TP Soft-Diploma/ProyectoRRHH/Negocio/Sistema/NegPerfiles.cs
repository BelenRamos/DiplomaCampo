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
                throw new Exception("Error al obtener los perfiles.", ex);
            }
        }

        public Perfiles ObtenerPerfilPorId(int idPerfil)
        {
            try
            {
                return repositorio.ObtenerPerfilPorId(idPerfil);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el perfil por ID.", ex);
            }
        }

        public int AgregarPerfilAOferta(int ofertaLaboralId, int perfilId)
        {
            try
            {
                return repositorio.AgregarPerfilAOferta(ofertaLaboralId, perfilId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el perfil a la oferta laboral.", ex);
            }
        }

        public int EliminarPerfilDeOferta(int ofertaLaboralId, int perfilId)
        {
            try
            {
                return repositorio.EliminarPerfilDeOferta(ofertaLaboralId, perfilId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el perfil de la oferta laboral.", ex);
            }
        }

        public List<int> ObtenerPerfilesPorOferta(int ofertaLaboralId)
        {
            try
            {
                return repositorio.ObtenerPerfilesPorOferta(ofertaLaboralId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los perfiles de la oferta laboral.", ex);
            }
        }
    }
}


//namespace Negocio
//{
//    public class NegPerfiles
//    {
//        private static NegPerfiles instancia;
//        private RepoPerfiles repositorioPerfiles;

//        private NegPerfiles()
//        {
//            repositorioPerfiles = new RepoPerfiles();
//        }

//        public static NegPerfiles ObtenerInstancia()
//        {
//            if (instancia == null)
//            {
//                instancia = new NegPerfiles();
//            }
//            return instancia;
//        }

//        public List<Perfiles> ObtenerTodosLosPerfiles()
//        {
//            try
//            {
//                return repositorioPerfiles.ObtenerTodosLosPerfiles();
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public Perfiles ObtenerPerfilPorId(int idPerfil)
//        {
//            try
//            {
//                return repositorioPerfiles.ObtenerPerfilPorId(idPerfil);
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }
//    }
//}

