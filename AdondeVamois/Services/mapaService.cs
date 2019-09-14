using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Validation;
using AdondeVamos.Model;

namespace AdondeVamos.Services
{
    public class MapaService
    {
        private A_DONDE_VAMOSEntities2 condb = new A_DONDE_VAMOSEntities2();

        //Variables para mostrar los mensajes de error
        private static string MENSAJE_MAIL_PASS_INCORRECTOS = "E-mail y/o contraseña incorrectos, por favor intentá nuevamente";
        private static string MENSAJE_MAIL_EXISTENTE = "Ese e-mail no está disponible, por favor ingresá otro";
        private static string MENSAJE_ERROR_INESPERADO = "Ocurrio un error inesperado en la aplicación. Por favor, Intentelo más tarde";

        //Codigo de error a asignar - Registro
        private int codigoErrorRegistro = 0;

        public Datos_Comercio GetComercios(int id)
        {

            var user = (from u in condb.Datos_Comercio
                        where u.IdDatos_comercio == id
                        select u)
                        .FirstOrDefault();

            return user;
        }


        //public Usuarios GetUsuario(string email)
        //{
        //    Usuarios usuarioEncontrado = new Usuarios();

        //    usuarioEncontrado = condb.Usuarios.Where(u => u.Email == email).SingleOrDefault();

        //    return usuarioEncontrado;
        //}


        public bool SaveComercio(Datos_Comercio comercio)
        {
            //Datos_Comercio Datos_Comercio = null;
            bool ok = false;


                    try
                    {
                         condb.Datos_Comercio.Add(comercio);
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
                

            return ok;
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