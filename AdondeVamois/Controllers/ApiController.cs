using AdondeVamos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdondeVamos.Controllers
{ 
[RoutePrefix("api/adondevamos")]

    public class ApiController : Controller
    {
        // GET: Api
        [Route("promociones")]
        public IHttpActionResult GetPromociones()
        {
            var list = ApiService.GetPromocion();
        }

    }


}
