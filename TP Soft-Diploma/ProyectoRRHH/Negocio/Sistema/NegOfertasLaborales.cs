using System;
using System.Collections.Generic;
using Datos;
using Modelo;

namespace Negocio
{
    public class NegOfertasLaborales
    {
        private RepoOfertasLaborales repositorio;
        private static NegOfertasLaborales instancia;

       
        private NegOfertasLaborales()
        {
            repositorio = new RepoOfertasLaborales();
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
            return repositorio.ObtenerOfertasLaborales();
        }

        public Ofertas_Laborales ObtenerOfertaLaboralPorNumero(int numero)
        {
            return repositorio.ObtenerOfertaLaboralPorNumero(numero);
        }

        public void AltaOfertaLaboral(Ofertas_Laborales ofertaLaboral, List<int> clienteIds, List<int> estadoIds, List<int> postulanteIds, List<int> requisitoIds)
        {
            // Guardar la oferta laboral
            repositorio.AgregarOfertaLaboral(ofertaLaboral);

            // Guardar los requisitos asociados a la oferta laboral
            foreach (int requisitoId in requisitoIds)
            {
                NegRequisitos.ObtenerInstancia().AgregarRequisitoAOferta(ofertaLaboral.numero, requisitoId);
            }
        }

        public void BajaOfertaLaboral(int numero)
        {
            // Eliminar los requisitos asociados a la oferta laboral
            var negRequisitos = NegRequisitos.ObtenerInstancia();
            var negPerfiles = NegPerfiles.ObtenerInstancia();
            negRequisitos.EliminarRequisitosDeOferta(numero);
            negPerfiles.EliminarPerfilDeOferta(numero);

            // Luego eliminar la oferta laboral
            repositorio.EliminarOfertaLaboral(numero);
        }

        public void ModificarOfertaLaboral(Ofertas_Laborales ofertaLaboral)
        {
            repositorio.ActualizarOfertaLaboral(ofertaLaboral);
        }

        public int ObtenerUltimoNumero()
        {
            return repositorio.ObtenerUltimoNumero();
        }

        public List<Ofertas_Laborales> ObtenerOfertasPorEstado(int codigoEstado)
        {
            return repositorio.ObtenerOfertasPorEstado(codigoEstado);
        }

        public void CerrarOfertaLaboral(int numero)
        {
            repositorio.CerrarOfertaLaboral(numero);
        }

        public void PublicarOfertaLaboral(int numero, DateTime fechaPublicacion)
        {
            repositorio.PublicarOfertaLaboral(numero, fechaPublicacion);
        }

        public void PublicarOfertaLaboral(int numero)
        {
            throw new NotImplementedException();
        }

        public bool AsignarPerfilAOferta(int numeroOferta, int idPerfil)
        {
            if (numeroOferta <= 0 || idPerfil <= 0)
            {
                throw new ArgumentException("Número de oferta e ID de perfil deben ser mayores a cero.");
            }

            return repositorio.AsignarPerfilAOferta(numeroOferta, idPerfil);
        }

    }
}
