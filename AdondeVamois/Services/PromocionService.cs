using AdondeVamos.Models;
using System.Collections.Generic;
using System.Linq;


namespace AdondeVamos.Services
{
    public class PromocionService
    {
        private A_DONDE_VAMOS ctx = new A_DONDE_VAMOS();

        public Promociones ObtenerPromocionPorId(int? id)
        {
            var promocion = (from p in ctx.Promociones
                             where p.idPromocion == id
                             select p)
                               .FirstOrDefault();
            return promocion;
        }

        public Promociones CrearPromocion(Promociones datapromo, Usuarios usuarioActual)
        {

            Promociones nuevaPromocion = new Promociones
            {
                idPromocion = datapromo.idPromocion,                
                Descripcion = datapromo.Descripcion,                
            };

            usuarioActual.Promociones.Add(nuevaPromocion);
            ctx.Promociones.Add(nuevaPromocion);
            ctx.SaveChanges();

            return nuevaPromocion;
        }

        public List<Promociones> ObtenerPromocionesPorUsuario(int usuarioId)
        {
            var promociones = (from l in ctx.Promociones
                           where l.IdUsuario == usuarioId
                           orderby l.Descripcion ascending
                           select l)
                            .ToList();

            return promociones;
        }

        public Promociones EditarPromocionExistente(Promociones Promocion)
        {
            Promociones promocionActualizada = ObtenerPromocionPorId(Promocion.idPromocion);
            
            promocionActualizada.Descripcion = Promocion.Descripcion;            

            ctx.SaveChanges();

            return promocionActualizada;
        }

        public void EliminarPromocion(int promocionId)
        {
            Promociones promociones = ObtenerPromocionPorId(promocionId);

            if (promociones != null)
            {
                ctx.Promociones.Remove(promociones);

                ctx.SaveChanges();
            }
        }
      
        public void SavePromocion(Promociones promocion)
        {
            ctx.Promociones.Add(promocion);
            ctx.SaveChanges();
        }
    }
}