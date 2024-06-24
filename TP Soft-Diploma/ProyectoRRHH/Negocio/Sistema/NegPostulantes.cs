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
        private List<Postulantes> postulantes;

        private NegPostulantes()
        {
            repositorio = new RepoPostulantes();
            postulantes = new List<Postulantes>();
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
                if (postulantes.Count > 0)
                {
                    return postulantes;
                }
                else
                {
                    postulantes = repositorio.ObtenerTodosLosPostulantes();
                    return postulantes;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
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
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
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
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
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
                // Manejo de excepciones, puedes lanzarla nuevamente o manejarla de otra manera según tus necesidades.
                throw new Exception("Error al modificar el postulante.", ex);
            }
        }
       
    
        public int ObtenerUltimoNumero()
        {
            try
            {
                // Aquí deberías llamar a algún método de tu repositorio para obtener el último número de postulante.
                // Por ejemplo, si tu repositorio tiene un método ObtenerUltimoNumeroPostulante(), lo llamarías de la siguiente manera:
                return repositorio.ObtenerUltimoNumero();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception("Error al obtener el último número de postulante.", ex);
            }
        }
        }
    }


