using AdondeVamos.Models;
using AdondeVamos.Models.DTO;
using AdondeVamos.Services;
using System;
using System.Web.Http;

namespace AdondeVamos.Controllers
{
    [RoutePrefix("api/adondevamos")]

    public class ApiController
    {
        ApiService Api = new ApiService();
        /// <summary>
        /// GET promociones
        /// </summary>
        [Route("promociones")]
        public IHttpActionResult GetPromociones([FromUri]string filterDescription = "")
        {            
            try
            {
                var list = Api.GetPromocion(filterDescription);
                return Ok(new PageResultDTO<PromocionDTO>(list));
            }
            catch (Exception e) { LogError("GetPromociones", filterDescription, e); }
            return null;
        }

        private void LogError(string v, string filterDescription, Exception e)
        {
            throw new NotImplementedException();
        }

        private IHttpActionResult Ok(PageResultDTO<PromocionDTO> pageResultDTO)
        {
            throw new NotImplementedException();
        }
    }
}




