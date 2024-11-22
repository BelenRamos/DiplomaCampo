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
            // Guardar la oferta laboral
            repoOfertasLaborales.AgregarOfertaLaboral(ofertaLaboral);

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

        public bool AsignarPerfilAOferta(int numeroOferta, int idPerfil)
        {
            if (numeroOferta <= 0 || idPerfil <= 0)
            {
                throw new ArgumentException("Número de oferta e ID de perfil deben ser mayores a cero.");
            }

            return repoOfertasLaborales.AsignarPerfilAOferta(numeroOferta, idPerfil);
        }
    }
}
