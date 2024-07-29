using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Modelo;

namespace Negocio
{
    public class NegOfertasLaborales
    {
        private RepoOfertasLaborales repoOfertasLaborales;
        private static NegOfertasLaborales instancia;
        private RepoEstados repoEstados;

        private NegOfertasLaborales()
        {
            repoOfertasLaborales = new RepoOfertasLaborales();
            repoEstados = new RepoEstados();
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

        //public List<Ofertas_Laborales> ObtenerOfertasConEstados()
        //{
        //    var ofertas = repoOfertasLaborales.ObtenerOfertasLaborales();
        //    var ofertasConEstados = new List<Ofertas_Laborales>();

        //    foreach (var oferta in ofertas)
        //    {
        //        var estados = repoOfertasLaborales.ObtenerEstadosPorOferta(oferta.numero);
        //        ofertasConEstados.Add(new Ofertas_Laborales
        //        {
        //            ofertaLaboral = oferta,
        //            Estados = (ICollection<Estados>)estados.Select(e => repoEstados.ObtenerEstadoPorCodigo(e)).ToList() 
        //        });
        //    }

        //    return ofertasConEstados;
        //}

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
