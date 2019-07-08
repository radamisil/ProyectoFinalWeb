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
        private readonly UsuarioService _usuarioService = new UsuarioService();
        // GET: Mapa

        [HttpGet]
        public ActionResult Mapa()
        {
            return View();
        }
    }
}
