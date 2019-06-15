using AdondeVamos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdondeVamos.Services
{
    public class ApiService
    {
    }

    public List<PromocionDTO> GetPromocion()
    {
        var promocionDtoList = new List<PromocionDTO>();

        var promocionList = ApiService.GetPromocionesByTable();

        if ((promocionDtoList != null) && (promocionDtoList.Count > 0))
            foreach (Promociones promocion in promocionDtoList)
            {
                PromocionDTO promoDto = new PromocionDTO();
                promoDto.idPromocion = promocion.idPromocion;
                promoDto.Descripcion = promocion.Descripcion;


                promocionDtoList.Add(promoDto);
            }
        return promocionDtoList;
    }


    public IList<PromocionDTO> GetPromocionesByTable()
    {       
        //var parameters = GetParameters(idTiendaSistema, pageNumber, pageSize, filter);
        var promociones = GetDataTable("SP_GetPromocion");
        var promocionesQueryable = (from promocion in Promociones.AsEnumerable()
                                  select new Promociones
                                  {
                                      idPromocion = promocion.Field<int>("Id"),
                                      Descripcion = promocion.Field<string>("Descripción")                                      
                                  }).ToList();
                
        return promocionesQueryable.ToList();
    }
}