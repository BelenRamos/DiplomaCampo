using Modelo;
using Datos.RepoSeguridad;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class NegUsuarios
    {
        private static NegUsuarios instancia;
        private RepoUsuarios repositorio;
        private List<Usuarios> usuarios;

        public NegUsuarios()
        {
            repositorio = new RepoUsuarios();
            usuarios = new List<Usuarios>();
        }

        public static NegUsuarios ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new NegUsuarios();
            }
            return instancia;
        }

        public List<Usuarios> ObtenerTodosLosUsuarios()
        {
            try
            {
                if (usuarios.Count > 0)
                {
                    return usuarios;
                }
                else
                {
                    usuarios = repositorio.ObtenerTodosLosUsuarios();
                    return usuarios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los usuarios.", ex);
            }
        }

        public Usuarios ObtenerUsuarioPorID(int idUsuario)
        {
            try
            {
                return repositorio.ObtenerUsuarioPorID(idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario por ID.", ex);
            }
        }

        public int AltaUsuario(Usuarios usuario)
        {
            try
            {
                int resultado = repositorio.AltaUsuarioSimple(usuario);
                if (resultado > 0)
                {
                    usuarios.Add(usuario); // Agregar a la lista local si la inserción fue exitosa
                }
                return resultado;
            }
            catch (Exception ex)
            {
                // Agregar más información del error
                string mensajeError = $"Error al dar de alta el usuario. {ex.Message}";
                if (ex.InnerException != null)
                {
                    mensajeError += $"\nDetalles internos: {ex.InnerException.Message}";
                }
                mensajeError += $"\nPila de llamadas: {ex.StackTrace}";
                throw new Exception(mensajeError, ex);
            }
        }

        public int ModificarUsuario(Usuarios usuario)
        {
            try
            {
                int resultado = repositorio.ModificarUsuario(usuario);
                if (resultado > 0)
                {
                    // Actualizar la lista local de usuarios
                    Usuarios usuarioExistente = usuarios.Find(u => u.idUsuario == usuario.idUsuario);
                    if (usuarioExistente != null)
                    {
                        usuarios[usuarios.IndexOf(usuarioExistente)] = usuario;
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el usuario.", ex);
            }
        }

        public int BajaUsuario(int idUsuario)
        {
            try
            {
                int resultado = repositorio.BajaUsuario(idUsuario);
                if (resultado > 0)
                {
                    // Remover de la lista local si la eliminación fue exitosa
                    Usuarios usuarioExistente = usuarios.Find(u => u.idUsuario == idUsuario);
                    if (usuarioExistente != null)
                    {
                        usuarios.Remove(usuarioExistente);
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de baja el usuario.", ex);
            }
        }

        public List<Permisos> ObtenerPermisosPorUsuario(int idUsuario)
        {
            return repositorio.ObtenerPermisosPorUsuario(idUsuario);
        }

        public Usuarios ValidarUsuario(string email, string contrasenia)
        {
            return repositorio.ValidarUsuario(email, contrasenia);
        }

    }
}


