using Modelo;
using System;
using System.Collections.Generic;
using Datos;

namespace Negocio
{
    public class NegRequisitos
    {
        private static NegRequisitos instancia;
        private RepoRequisitos repositorio;
        private List<Requisitos> requisitos;

        private NegRequisitos()
        {
            repositorio = new RepoRequisitos();
            requisitos = new List<Requisitos>();
        }

        public static NegRequisitos ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegRequisitos();
            }
            return instancia;
        }

        public List<Requisitos> ObtenerRequisitos()
        {
            try
            {
                return repositorio.ObtenerRequisitos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los requisitos.", ex);
            }
        }

        public Requisitos ObtenerRequisitoPorID(int idRequisito)
        {
            try
            {
                return repositorio.ObtenerRequisitoPorID(idRequisito);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el requisito por ID.", ex);
            }
        }

        public List<string> ObtenerDescripcionesRequisitos()
        {
            try
            {
                return repositorio.ObtenerDescripcionesRequisitos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las descripciones de los requisitos.", ex);
            }
        }

        public int AgregarRequisitoAOferta(int ofertaLaboralId, int requisitoId)
        {
            try
            {
                return repositorio.AgregarRequisitoAOferta(ofertaLaboralId, requisitoId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el requisito a la oferta laboral.", ex);
            }
        }

        public int EliminarRequisitoDeOferta(int ofertaLaboralId, int requisitoId)
        {
            try
            {
                return repositorio.EliminarRequisitoDeOferta(ofertaLaboralId, requisitoId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el requisito de la oferta laboral.", ex);
            }
        }

        public List<int> ObtenerRequisitosPorOferta(int ofertaLaboralId)
        {
            try
            {
                return repositorio.ObtenerRequisitosPorOferta(ofertaLaboralId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los requisitos de la oferta laboral.", ex);
            }
        }
    }
}


//{
//    public class NegRequisitos
//    {
//        private static NegRequisitos instancia;
//        private RepoRequisitos repositorioRequisitos;

//        private NegRequisitos()
//        {
//            repositorioRequisitos = new RepoRequisitos();
//        }

//        public static NegRequisitos ObtenerInstancia()
//        {
//            if (instancia == null)
//            {
//                instancia = new NegRequisitos();
//            }
//            return instancia;
//        }

//        public List<(int Id, string Descripcion)> ObtenerRequisitos()
//        {
//            try
//            {
//                return repositorioRequisitos.ObtenerRequisitos();
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }


//        public Requisitos ObtenerRequisitoPorID(int idRequisito)
//        {
//            try
//            {
//                return repositorioRequisitos.ObtenerRequisitoPorID(idRequisito);
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public List<string> ObtenerDescripcionesRequisitos()
//        {
//            try
//            {
//                return repositorioRequisitos.ObtenerDescripcionesRequisitos();
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }
//    }
//}
