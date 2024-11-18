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

        public int EliminarRequisitosDeOferta(int ofertaLaboralId)
        {
            try
            {
                int filasEliminadas = repositorio.EliminarRequisitoDeOferta(ofertaLaboralId);
                if (filasEliminadas == 0)
                {
                    throw new Exception("No se encontraron requisitos para eliminar en la oferta laboral.");
                }
                return filasEliminadas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar los requisitos de la oferta laboral.", ex);
            }
        }
        public List<Requisitos> ObtenerRequisitosPorOferta(int numeroOferta)
        {
            return repositorio.ObtenerRequisitosPorOferta(numeroOferta);
        }
    }
}

