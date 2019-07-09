using AdondeVamos.Model;
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

        [HttpGet]
        public ActionResult Modificar(int promocionId)
        {
            Promociones promociones = ps.ObtenerPromocionPorId(promocionId);
            return View("");
        }

        [HttpPost]
        public ActionResult Modificar(Promociones promociones)
        {
            ps.EditarPromocionExistente(promociones);

            return RedirectToAction("Listado", "Promociones");
        }

        public ActionResult Eliminar(int promocionId)
        {
            ps.EliminarPromocion(promocionId);

            return RedirectToAction("Listado", "Promociones");
        }        
    }
}
