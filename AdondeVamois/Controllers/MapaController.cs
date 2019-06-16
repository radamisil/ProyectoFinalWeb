using AdondeVamos.Models;
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
        private readonly UsuarioServicio _usuarioServicio = new UsuarioServicio();
        // GET: Mapa

        [HttpGet]
        public ActionResult Mapa()
        {
            return View();
        }
    }
}
