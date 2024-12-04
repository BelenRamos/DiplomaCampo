using Modelo;
using System;
using System.Collections.Generic;
using Datos;
using Modelo.Sistema;
using Negocio.Sistema;
using Microsoft.SqlServer.Server;

namespace Negocio
{
    public class NegPostulantes
    {
        private static NegPostulantes instancia;
        private RepoPostulantes repositorio;
        private NegAuditoriaPostulantes negAuditoria;
        private NegUsuarios negUsuarios;

        private NegPostulantes()
        {
            repositorio = new RepoPostulantes();
            negAuditoria = NegAuditoriaPostulantes.ObtenerInstancia();
            negUsuarios = NegUsuarios.ObtenerInstancia();
        }

        public static NegPostulantes ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegPostulantes();
            }
            return instancia;
        }

        public Usuarios ObtenerUsuarioActual()
        {
            try
            {
                return negUsuarios.UsuarioActual;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario actual.", ex);
            }
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
                int resultado;

                try
                {
                    resultado = repositorio.AltaPostulante(postulante);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en RepoPostulantes.AltaPostulante.", ex);
                }

                Usuarios usuarioActual;
                try
                {
                    usuarioActual = ObtenerUsuarioActual();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el usuario actual en AltaPostulante.", ex);
                }

                try
                {
                    var auditoria = new AuditoriaPostulantes
                    {
                        accion = "INSERT",
                        usuario = usuarioActual?.nombreUsuario,
                        valoresOriginales = null,
                        valoresNuevos = $"{{'nombre': '{postulante.nombre}', 'apellido': '{postulante.apellido}'}}"
                    };
                    negAuditoria.CrearRegistroAuditoria(auditoria);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al crear el registro de auditoría en AltaPostulante.", ex);
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el postulante. Holis", ex);
            }
        }


        public int BajaPostulante(int numero)
        {
            try
            {
                Console.WriteLine("Obteniendo usuario actual...");
                Usuarios usuarioActual = ObtenerUsuarioActual();
                Console.WriteLine($"Usuario actual: {usuarioActual?.nombreUsuario}");
                string usuario = usuarioActual?.nombreUsuario;

                Console.WriteLine("Registrando auditoría...");
                negAuditoria.Eliminar(numero, usuario);

                Console.WriteLine("Eliminando registro del postulante...");
                int resultado = repositorio.BajaPostulante(numero);
                Console.WriteLine($"Resultado de la eliminación: {resultado}");

                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
                throw new Exception($"Error al dar de baja el postulante con ID {numero}.", ex);
            }
        }

        public int ModificarPostulante(Postulantes postulante)
        {
            try
            {
                var valoresOriginales = negAuditoria.ObtenerValoresOriginales(postulante.numero);
                if (string.IsNullOrEmpty(valoresOriginales))
                {
                    throw new Exception("No se encontraron valores originales para el postulante.");
                }

                // Auditoría de la modificación
                var usuarioActual = ObtenerUsuarioActual();
                var auditoria = new AuditoriaPostulantes
                {
                    accion = "UPDATE",
                    usuario = usuarioActual?.nombreUsuario,
                    valoresOriginales = valoresOriginales,
                    valoresNuevos = $"{{\"nombre\": \"{postulante.nombre}\", \"apellido\": \"{postulante.apellido}\"}}"
                };

                negAuditoria.ActualizarAuditoria(auditoria);

                int resultado = repositorio.ModificarPostulante(postulante);

                return resultado;
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
