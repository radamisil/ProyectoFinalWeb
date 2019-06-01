using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdondeVamos.Models.Entities;
using System.Data.Entity.Validation;

namespace AdondeVamos.Services
{
    public class UsuarioServicio
    {
        private A_DONDE_VAMOSEntities1 condb = new A_DONDE_VAMOSEntities1();
        //Variables para mostrar los mensajes de error
        private static string MENSAJE_MAIL_PASS_INCORRECTOS = "E-mail y/o contraseña incorrectos, por favor intentá nuevamente";
        private static string MENSAJE_MAIL_EXISTENTE = "Ese e-mail no está disponible, por favor ingresá otro";
        private static string MENSAJE_ERROR_INESPERADO = "Ocurrio un error inesperado en la aplicación. Por favor, Intentelo más tarde";

        //Codigo de error a asignar - Registro
        private int codigoErrorRegistro = 0;

        public Usuarios GetUsuario(int id)
        {

            var user = (from u in condb.Usuarios
                        where u.IdUsuario == id
                        select u)
                        .FirstOrDefault();

            return user;
        }

        public List<Usuarios> GetAll()
        {

            List<Usuarios> users = (from u in condb.Usuarios select u).ToList();

            return users;

        }

        public Usuarios loguearUsuarioPorEmail(Usuarios usuario)
        {
            Usuarios usuarioOK = new Usuarios();

            usuarioOK = condb.Usuarios.Where(u => u.Email == usuario.Email
                                              && u.Password == usuario.Password).SingleOrDefault();
            if (usuarioOK == null)
            {
                codigoErrorRegistro = 0;
            }

            return usuarioOK;
        }


        public Usuarios GetUsuario(string email)
        {
            Usuarios usuarioEncontrado = new Usuarios();

            usuarioEncontrado = condb.Usuarios.Where(u => u.Email == email).SingleOrDefault();

            return usuarioEncontrado;
        }


        public bool SaveUsuario(Usuarios usuario, string pass2)
        {
            Usuarios usuarioNuevo = null;
            bool ok = false;
            if (chequearSiMailsCoinciden(usuario.Password, pass2))
            {
                //usuarioNuevo = new Usuarios(usuario);

                if (chequearSiExisteEmail(usuario.Email))
                {//el email ya esta registrado
                    codigoErrorRegistro = 1;
                    ok = false;
                }
                else
                {
                    try
                    {
                        condb.Usuarios.Add(usuario);
                        condb.SaveChanges();
                        ok = true;
                    }
                    catch (DbEntityValidationException ex)
                    {
                        ok = false;
                        codigoErrorRegistro = 2;
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                System.Diagnostics.Debug.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                            }
                        }
                    }
                }
            }
            else
            {
                //Para mostrar algo si no coinciden los emails
                codigoErrorRegistro = 0;
                ok = false;
            }
            return ok;
        }

        public bool chequearSiMailsCoinciden(string pass1, string pass2)
        {
            if (pass2.Equals(pass1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool chequearSiExisteEmail(string email)
        {
            //var usuario = context.Usuarios.Where(u => u.Email == email).Select(u1 => u1).First();
            Usuarios usuario = (from u in condb.Usuarios
                                where u.Email == email
                               select u).FirstOrDefault();
            if (usuario != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void activarRegistroUsuarioExistente(Usuarios usuario)
        {
            //var usuarioExistente = context.Usuarios.Where(u => u.IdUsuario == usuario.IdUsuario).First();
            Usuarios usuarioExistente = (from u in condb.Usuarios
                                         where u.Email == usuario.Email
                                        select u).First();

            usuarioExistente.Password = usuario.Password;
            condb.SaveChanges();

            //return usuarioExistente;
        }

        public String mostrarMensajeDeError()
        {
            string mensaje = "";
            if (codigoErrorRegistro == 0)
            {
                mensaje = MENSAJE_MAIL_PASS_INCORRECTOS;
            }
            else if (codigoErrorRegistro == 1)
            {
                mensaje = MENSAJE_MAIL_EXISTENTE;
            }
            else if (codigoErrorRegistro == 2)
            {
                mensaje = MENSAJE_ERROR_INESPERADO;
            }
            return mensaje;
        }

    }
}