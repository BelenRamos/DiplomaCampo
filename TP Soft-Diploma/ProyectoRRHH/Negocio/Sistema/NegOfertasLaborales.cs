using System;
using System.Collections.Generic;
using Datos;
using Modelo;

namespace Negocio
{
    public class NegOfertasLaborales
    {
        private RepoOfertasLaborales repoOfertasLaborales;
        private static NegOfertasLaborales instancia;

        private NegOfertasLaborales()
        {
            repoOfertasLaborales = new RepoOfertasLaborales();
        }

        public static NegOfertasLaborales ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegOfertasLaborales();
            }
            return instancia;
        }

        public List<Ofertas_Laborales> ObtenerOfertasLaborales()
        {
            return repoOfertasLaborales.ObtenerOfertasLaborales();
        }

        public Ofertas_Laborales ObtenerOfertaLaboralPorNumero(int numero)
        {
            return repoOfertasLaborales.ObtenerOfertaLaboralPorNumero(numero);
        }

        public void AltaOfertaLaboral(Ofertas_Laborales ofertaLaboral, List<int> clienteIds, List<int> estadoIds, List<int> postulanteIds, List<int> requisitoIds)
        {
            repoOfertasLaborales.AgregarOfertaLaboral(ofertaLaboral);
            // Agregar lógica adicional para manejar relaciones (clientes, estados, postulantes, requisitos)
        }

        public void BajaOfertaLaboral(int numero)
        {
            repoOfertasLaborales.EliminarOfertaLaboral(numero);
        }

        public void ModificarOfertaLaboral(Ofertas_Laborales ofertaLaboral)
        {
            repoOfertasLaborales.ActualizarOfertaLaboral(ofertaLaboral);
        }

        public int ObtenerUltimoNumero()
        {
            return repoOfertasLaborales.ObtenerUltimoNumero();
        }

        public List<Ofertas_Laborales> ObtenerOfertasPorEstado(int codigoEstado)
        {
            return repoOfertasLaborales.ObtenerOfertasPorEstado(codigoEstado);
        }

        public void CerrarOfertaLaboral(int numero)
        {
            repoOfertasLaborales.CerrarOfertaLaboral(numero);
        }

        public void PublicarOfertaLaboral(int numero, DateTime fechaPublicacion)
        {
            repoOfertasLaborales.PublicarOfertaLaboral(numero, fechaPublicacion);
        }

        public void PublicarOfertaLaboral(int numero)
        {
            throw new NotImplementedException();
        }
    }
}
