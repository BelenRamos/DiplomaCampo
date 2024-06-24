using Datos;
using System.Collections.Generic;
using System;
using Modelo;



namespace Negocio
{
    public class NegEstados
    {
        private static NegEstados instancia;
        private RepoEstados repositorio;

        private NegEstados()
        {
            repositorio = new RepoEstados();
        }

        public static NegEstados ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegEstados();
            }
            return instancia;
        }

        public List<Modelo.Estados> ObtenerTodosLosEstados()
        {
            try
            {
                return repositorio.ObtenerTodosLosEstados();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los estados.", ex);
            }
        }

        public List<Modelo.Estados> ObtenerEstadoPorCodigo(int codigoEstado)
        {
            try
            {
                return repositorio.ObtenerEstadoPorCodigo(codigoEstado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el estado por código.", ex);
            }
        }

        public int AgregarEstadoAOferta(int ofertaLaboralId, int estadoId)
        {
            try
            {
                return repositorio.AgregarEstadoAOferta(ofertaLaboralId, estadoId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el estado a la oferta laboral.", ex);
            }
        }

        public int EliminarEstadoDeOferta(int ofertaLaboralId, int estadoId)
        {
            try
            {
                return repositorio.EliminarEstadoDeOferta(ofertaLaboralId, estadoId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el estado de la oferta laboral.", ex);
            }
        }

        public List<int> ObtenerEstadosPorOferta(int ofertaLaboralId)
        {
            try
            {
                return repositorio.ObtenerEstadosPorOferta(ofertaLaboralId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los estados de la oferta laboral.", ex);
            }
        }

        public Estados ObtenerEstadoPorDesignacion(string designacionEstado)
        {
            try
            {
                return repositorio.ObtenerEstadoPorDesignacion(designacionEstado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el estado por designación.", ex);
            }
        }

    //    public int GuardarOfertaLaboral(Ofertas_Laborales oferta)
    //    {
    //        try
    //        {
    //            // Aquí va la lógica para guardar la oferta laboral en el repositorio correspondiente
    //            return repositorio.GuardarOfertaLaboral(oferta);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception("Error al guardar la oferta laboral.", ex);
    //        }
    //    }

    }
}



//namespace Negocio
//{
//    public class NegEstados
//    {
//        private static NegEstados instancia;
//        private RepoEstados repositorioEstados;

//        private NegEstados()
//        {
//            repositorioEstados = new RepoEstados();
//        }

//        public static NegEstados ObtenerInstancia()
//        {
//            if (instancia == null)
//            {
//                instancia = new NegEstados();
//            }
//            return instancia;
//        }

//        public List<Estados> ObtenerTodosLosEstados()
//        {
//            try
//            {
//                return repositorioEstados.ObtenerTodosLosEstados();
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public List<Estados> ObtenerEstadoPorCodigo(int codigoEstado)
//        {
//            try
//            {
//                return repositorioEstados.ObtenerEstadoPorCodigo(codigoEstado);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//    }
//}

