using Modelo;
using System;
using System.Collections.Generic;
using Datos;

namespace Negocio
{
    public class NegPostulantes
    {
        private static NegPostulantes instancia;
        private RepoPostulantes repositorio;

        private NegPostulantes()
        {
            repositorio = new RepoPostulantes();
        }

        public static NegPostulantes ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegPostulantes();
            }
            return instancia;
        }

        public List<Postulantes> ObtenerTodosLosPostulantes()
        {
            try
            {
                return repositorio.ObtenerTodosLosPostulantes();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los postulantes.", ex);
            }
        }

        public int AltaPostulante(Postulantes postulante)
        {
            try
            {
                return repositorio.AltaPostulante(postulante);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el postulante.", ex);
            }
        }

        public int BajaPostulante(int numero)
        {
            try
            {
                return repositorio.BajaPostulante(numero);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de baja el postulante.", ex);
            }
        }

        public int ModificarPostulante(Postulantes postulante)
        {
            try
            {
                return repositorio.ModificarPostulante(postulante);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el postulante.", ex);
            }
        }

        public int ObtenerUltimoNumero()
        {
            try
            {
                return repositorio.ObtenerUltimoNumero();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el último número de postulante.", ex);
            }
        }

        public int ObtenerPorcentajePostulantes(int maxPostulantes)
        {
            int totalPostulantes = repositorio.ObtenerTotalPostulantes();
            return (int)((float)totalPostulantes / maxPostulantes * 100);
        }

        public List<Postulantes> ObtenerPostulantesFiltrados(string filtro)
        {
            try
            {
                return repositorio.ObtenerPostulantesFiltrados(filtro);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los postulantes filtrados.", ex);
            }
        }
    }
}
