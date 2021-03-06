﻿using AdondeVamos.Model;
using AdondeVamos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdondeVamois.Controllers
{
    public class HomeController : Controller
    {
        private readonly UsuarioService _usuarioService = new UsuarioService();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Error()
        {
            ClsSesion.EliminarSesion();
            return View();
        }

        public ActionResult Productos()
        {
            return View();
        }

        public ActionResult Nosotros()
        {
            return View();
        }


        //Pantalla Login
        [HttpGet]
        public ActionResult Login()
        {
            Usuarios usr = new Usuarios();
            return View(usr);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Loguear(Usuarios usr)
        {
            Usuarios usrLogueado;

            if (ModelState.IsValid)
            {
                usrLogueado = _usuarioService.loguearUsuarioPorEmail(usr);
                

                if (usrLogueado == null)
                {
                    ViewBag.Mensaje = _usuarioService.mostrarMensajeDeError();
                    return View("Login", usr);
                }
                else
                {
                    //agregar redirect to action a HomeUsuario
                    ViewBag.Mensaje = "Usuario logueado:" + usrLogueado.Email;
                    ViewBag.Usuario = usrLogueado.Email;
                    TempData["usuario"] = usrLogueado.Email;
                    Session["usuario"] = usrLogueado.Email;
                    ClsSesion.SetUsuarioLogueado(usrLogueado);
                    
                    return RedirectToAction("Mapa", "Mapa");
                }
            }
            else { return View("Login", usr); }
        }

        [HttpGet]
        public ActionResult Registracion()
        {
            Usuarios usr = new Usuarios();
            return View(usr);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  //Para prevenir ataques CSRF
        public ActionResult RegistrarUsuario(Usuarios usr)
        {
            if (ModelState.IsValid)
            {
                String pass2 = Request["pass2"];

                if (_usuarioService.SaveUsuario(usr, pass2))
                {
                    ViewBag.Mensaje = "Usuario Generado con exito";
                }
                else
                {
                    ViewBag.Mensaje = _usuarioService.mostrarMensajeDeError();
                }
            }
            return View("Registracion");
        }

        [HttpGet]
        public ActionResult Salir()
        {
            if (ClsSesion.VerificarLogueo(ClsSesion.GetUsuarioLogueado()))
            {
                ClsSesion.EliminarSesion();
                Session["Usuario"] = null;
            }
            return RedirectToAction("Index");
        }
    }
}