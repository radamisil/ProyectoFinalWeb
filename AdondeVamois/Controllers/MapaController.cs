using AdondeVamos.Model;
using AdondeVamos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdondeVamos.Controllers
{
    public class MapaController : Controller
    {
        static Usuarios usuarioLogueado = new Usuarios();
        static Datos_Comercio datosComercio = new Datos_Comercio();
        private readonly MapaService _mapaService = new MapaService();
        // GET: Mapa

        [HttpGet]
        public ActionResult Mapa()
        {
            return View();
        }
        [HttpGet]
        public ActionResult indexComerciante()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Promociones()
        {
            return View();
        }
        [HttpGet]
        public ActionResult misPromociones()
        {
            return View();
        }
        [HttpGet]
        public ActionResult lugar()
        {
            return View();
        }
        [HttpGet]
        public ActionResult altaComerciante()
        {
            Datos_Comercio Datos_Comercio = new Datos_Comercio();
            return View(Datos_Comercio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  //Para prevenir ataques CSRF
        public ActionResult registrarComerciante(Datos_Comercio Datos_Comercio)
        {
            if (ModelState.IsValid)
            {

                if (_mapaService.SaveComercio(Datos_Comercio))
                {
                    ViewBag.Mensaje = "Usuario Generado con exito";
                }
                else
                {
                    ViewBag.Mensaje = _mapaService.mostrarMensajeDeError();
                }
            }
            return View("altaComerciante");
        }
    }
}
