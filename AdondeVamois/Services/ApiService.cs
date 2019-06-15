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
        public List<PromocionDTO> GetPromocion(int filterId, string filterDescription)
        {
            var promocionDtoList = new List<PromocionDTO>();
            var promocionList = ApiService.GetPromocionesByTable(filterId, filterDescription);

            if ((promocionDtoList != null) && (promocionDtoList.Count > 0))
                foreach (Promociones promocion in promocionDtoList)
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
        public IList<PromocionDTO> GetPromocionesByTable(int filterId, string filterDescription)
        {         
            var parameters = GetParameters(filterId, filterDescription);
            var promociones = GetDataTable("SP_GetPromocion", parameters);
            var promocionesQueryable = (from promocion in promociones.AsEnumerable()
                                        select new Promociones
                                        {
                                            idPromocion = promocion.Field<int>("Id"),
                                            Descripcion = promocion.Field<string>("Descripción")
                                        }).ToList();

            return promocionesQueryable.ToList();
        }        
    }   
}
