using AdondeVamos.ActionFilters;
using AdondeVamos.Facade;
using AdondeVamos.Model;
using AdondeVamos.Model.DTO;
using AdondeVamos.Services;
using System;
using System.Web.Http;

namespace AdondeVamos.Controllers
{

    [AxValidateDataBinding]
    [RoutePrefix("api")]

    public class ApisController : ApiController
    {
         /*private readonly IUsuarioFacade UsuarioFacade;
        
         public ApisController(IUsuarioFacade usuarioFacade)
         {
             UsuarioFacade = usuarioFacade;
         }
         */

        ApiService Api = new ApiService();
        /// <summary>
        /// GET promociones
        /// </summary>

        [Route("Promotions")]
        public IHttpActionResult GetPromotions([FromUri]string filterPlace = "", [FromUri]string filterUser = "")
        {            
            //try
            {
                var list = Api.GetPromocion(filterPlace, filterUser);
                return Ok(new PageResultDTO<PromocionDTO>(list));
            }
            //catch (Exception e) { LogError("GetPromociones", filterDescription, e); }
            return null;
        }

        /// <summary>
        /// GET Usuarios Registrados
        /// </summary>
        [HttpGet]
        [Route("User")]
        public IHttpActionResult GetUser([FromUri]string filter = "")
        {
            //try
            {
                var list = Api.GetUsuario(filter);
                return Ok(new PageResultDTO<UserDto>(list));
            }
            //catch (Exception e) { LogError("GetUsuarios", filterDescription, e); }
            return null;
        }          

        /// <summary>
        /// POST graban usuarios nuevos
        /// </summary>
        [HttpPost]
        [Route("Register")]
        public void Register([FromBody]UserDto loginPost)
        {
            if (loginPost != null)
            {
               // UsuarioFacade.AddUsuario(loginPost);
            }
        }

        /*private void LogError(string v, string filterDescription, Exception e)
        {
            throw new NotImplementedException();
        }

        private IHttpActionResult Ok(PageResultDTO<UserDto> pageResultDTO)
        {
            throw new NotImplementedException();
        }
        */
    }
}




