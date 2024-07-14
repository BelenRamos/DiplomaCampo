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

        private NegUsuarios()
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

        public Usuarios ObtenerUsuarioPorCredenciales(string username, string password)
        {
            try
            {
                return repositorio.ObtenerUsuarioPorCredenciales(username, password);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario por credenciales.", ex);
            }
        }

        public int AltaUsuario(Usuarios usuario)
        {
            try
            {
                return repositorio.AltaUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el usuario.", ex);
            }
        }

        public int ModificarUsuario(Usuarios usuario)
        {
            try
            {
                return repositorio.ModificarUsuario(usuario);
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
                return repositorio.BajaUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de baja el usuario.", ex);
            }
        }
    }
}


