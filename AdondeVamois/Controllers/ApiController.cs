using AdondeVamos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace AdondeVamos.Controllers
{ 
[RoutePrefix("api/adondevamos")]

    public class ApiController : Controller
    {
        /// <summary>
        /// GET promociones
        /// </summary>
        [Route("promociones")]
        public IHttpActionResult GetPromociones([FromUri]string filterId = "", [FromUri]string filterDescription = "")
        {
            var list = ApiService.GetPromocion(filterId, filterDescription);
        }
        return null;
    }

}
