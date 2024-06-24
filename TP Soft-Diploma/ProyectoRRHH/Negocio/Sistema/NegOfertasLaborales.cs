using Modelo;
using System;
using System.Collections.Generic;
using Datos;

namespace Negocio
{
    public class NegOfertasLaborales
    {
        private static NegOfertasLaborales instancia;
        private RepoOfertasLaborales repositorio;
        private List<Ofertas_Laborales> ofertasLaborales;

        private NegOfertasLaborales()
        {
            repositorio = new RepoOfertasLaborales();
            ofertasLaborales = new List<Ofertas_Laborales>();
        }

        public static NegOfertasLaborales ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegOfertasLaborales();
            }
            return instancia;
        }

        public List<Ofertas_Laborales> ObtenerTodasLasOfertasLaborales()
        {
            try
            {
                if (ofertasLaborales.Count > 0)
                {
                    return ofertasLaborales;
                }
                else
                {
                    ofertasLaborales = repositorio.ObtenerTodasLasOfertasLaborales();
                    return ofertasLaborales;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las ofertas laborales.", ex);
            }
        }

        public int AltaOfertaLaboral(Ofertas_Laborales oferta, List<int> clienteIds, List<int> estadoIds, List<int> perfilIds, List<int> requisitoIds)
        {
            try
            {
                int resultado = repositorio.AltaOfertaLaboral(oferta, clienteIds, estadoIds, perfilIds, requisitoIds);
                ofertasLaborales.Add(oferta); // Actualizar lista en memoria si es necesario
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta la oferta laboral.", ex);
            }
        }

        public int BajaOfertaLaboral(int numero)
        {
            try
            {
                int resultado = repositorio.BajaOfertaLaboral(numero);
                ofertasLaborales.RemoveAll(o => o.numero == numero); // Actualizar lista en memoria si es necesario
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de baja la oferta laboral.", ex);
            }
        }

        public int ModificarOfertaLaboral(Ofertas_Laborales oferta)
        {
            try
            {
                int resultado = repositorio.ModificarOfertaLaboral(oferta);
                int index = ofertasLaborales.FindIndex(o => o.numero == oferta.numero);
                if (index >= 0)
                {
                    ofertasLaborales[index] = oferta; // Actualizar lista en memoria si es necesario
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar la oferta laboral.", ex);
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
                throw new Exception("Error al obtener el último número de oferta laboral.", ex);
            }
        }
    }
}
