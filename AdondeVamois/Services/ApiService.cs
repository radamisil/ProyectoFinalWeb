using AdondeVamos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdondeVamos.Services
{
    public class ApiService : BaseService
    {

        /// <summary>
        /// se reciben datos del SP_ obtenido y se mapea contra el DTO
        /// </summary>
        public List<PromocionDTO> GetPromocion(string filterDescription)
        {
            var promocionDtoList = new List<PromocionDTO>();
            var promocionList = GetPromocionesByTable(filterDescription);

            if ((promocionList != null) && (promocionList.Count > 0))            
                foreach(Promociones promocion in promocionList)
                {
                    PromocionDTO promoDto = new PromocionDTO();
                    promoDto.idPromotion = promocion.idPromocion;
                    promoDto.Description = promocion.Descripcion;


                    promocionDtoList.Add(promoDto);
                }
            return promocionDtoList;
        }

        /// <summary>
        /// se ejecuta SP_ y se reciben datos de la tabla activa.
        /// </summary>
        public IList<Promociones> GetPromocionesByTable(string filterDescription)
        {         
            var parameters = GetParameters(filterDescription);
            var promociones = GetDataTable("SP_GetPromocion", parameters);
            var promocionesQueryable = (from promocion in promociones.AsEnumerable()
                                        select new Promociones
                                        {
                                           idPromocion = promocion.Field<int>("Id"),
                                           Descripcion = promocion.Field<string>("Descripción")
                                        }).ToList();

            return promocionesQueryable;
        }        
    }   
}
