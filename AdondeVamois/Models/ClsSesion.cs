﻿using AdondeVamos.Models.Entities;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AdondeVamos.Models
{
    public static class ClsSesion
    {
        public static string GetEmailLogueado()
        {
            string email = "";

            if (HttpContext.Current != null &&
                HttpContext.Current.Session != null &&
                HttpContext.Current.Session["UserId"] != null)
            {
                email = (HttpContext.Current.Session["UserEmail"].ToString());
            }

            return email;
        }


        public static bool VerificarLogueo(Usuarios usuario)
        {
            bool resp = false;

            if (HttpContext.Current != null &&
                HttpContext.Current.Session != null &&
                HttpContext.Current.Session["UserId"] != null)
            {
                if (usuario.Email == (HttpContext.Current.Session["UserEmail"].ToString()))
                    if (usuario.IdUsuario == int.Parse(HttpContext.Current.Session["UserId"].ToString()))
                        resp = true;
            }

            return resp;
        }


        public static Usuarios GetUsuarioLogueado()
        {
            Usuarios usuario = new Usuarios();

            if (HttpContext.Current != null &&
                HttpContext.Current.Session != null &&
                HttpContext.Current.Session["UserId"] != null)
            {
                usuario.IdUsuario = int.Parse((HttpContext.Current.Session["UserId"].ToString()));
                usuario.Email = (HttpContext.Current.Session["UserEmail"].ToString());
            }
            else
            { usuario = null; }

            return usuario;
        }

        public static void SetUsuarioLogueado(Usuarios usuario)
        {
            if (HttpContext.Current != null &&
                HttpContext.Current.Session != null &&
                HttpContext.Current.Session["UserId"] == null)
            {
                HttpContext.Current.Session.Add("UserId", usuario.IdUsuario);
                HttpContext.Current.Session.Add("UserEmail", usuario.Email);
            }
        }

        public static void EliminarSesion()
        {
            if (HttpContext.Current != null &&
                HttpContext.Current.Session != null &&
                HttpContext.Current.Session["UserId"] != null)
            {
                HttpContext.Current.Session.Remove("UserId");
                HttpContext.Current.Session.Remove("UserEmail");
            }
        }
    }
}