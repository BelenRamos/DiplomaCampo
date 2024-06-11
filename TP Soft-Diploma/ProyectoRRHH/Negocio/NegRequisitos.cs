using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Datos;

namespace Negocio
{
    public class NegRequisitos
    {
        private static NegRequisitos instancia;
        private RepoRequisitos repositorioRequisitos;

        private NegRequisitos()
        {
            repositorioRequisitos = new RepoRequisitos();
        }

        public static NegRequisitos ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegRequisitos();
            }
            return instancia;
        }

        public List<(int Id, string Descripcion)> ObtenerRequisitos()
        {
            try
            {
                return repositorioRequisitos.ObtenerRequisitos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Requisitos ObtenerRequisitoPorID(int idRequisito)
        {
            try
            {
                return repositorioRequisitos.ObtenerRequisitoPorID(idRequisito);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> ObtenerDescripcionesRequisitos()
        {
            try
            {
                return repositorioRequisitos.ObtenerDescripcionesRequisitos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public int ObtenerIdPorDescripcion(string descripcion)
        //{
        //    try
        //    {
        //        return repositorioRequisitos.ObtenerIdPorDescripcion(descripcion);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
