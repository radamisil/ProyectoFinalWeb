using AdondeVamos.Models;
using AdondeVamos.Services;
using System.Web.Mvc;

namespace AdondeVamos.Controllers
{
    public class PromocionesController : Controller
    {
        PromocionService ps = new PromocionService();

        [HttpGet]
        public ActionResult AltaPromocion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AltaPromocion(Promociones promocion, Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                ps.CrearPromocion(promocion, usuario);
            }
            else
            { }
            return RedirectToAction("AltaPromocion");
        }
    }
}
