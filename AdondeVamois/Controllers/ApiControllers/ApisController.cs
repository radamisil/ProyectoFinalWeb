using AdondeVamos.ActionFilters;
using AdondeVamos.Facade;
using AdondeVamos.Model;
using AdondeVamos.Model.DTO;
using AdondeVamos.Model.GenericClass;
using AdondeVamos.Services;
using System;
using System.Web.Http;
using AdondeVamos.Model.Exception;

namespace AdondeVamos.Controllers
{

    [AxValidateDataBinding]
    [RoutePrefix("api")]

    public class ApisController : ApiController
    {
        private readonly IUsuarioFacade UsuarioFacade;
        //private readonly APIResponse APIResponse;

        public ApisController(IUsuarioFacade usuarioFacade)//, APIResponse aPIResponse)
         {
            UsuarioFacade = usuarioFacade;
            //APIResponse = aPIResponse;
         }
        
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
        [Route("Register")]
        public UserDto Register([FromBody]UserDto loginPost)
        {
            //try
            UserDto usuarioAgregado = new UserDto();

            if (loginPost != null)
            {
                usuarioAgregado = UsuarioFacade.AddUsuario(loginPost);
            }
            return usuarioAgregado;
        }
    }
}
/*  else
  {
      //return APIResponse.Error("No se pudo Registrar el nuevo Usuario");
  }
}
catch (ApertureValidationException apertureExc)
{
  return APIResponse.Error(apertureExc.Message);
}
return APIResponse.OK($"Usuario Ingresado Correctamente: {loginPost.Nombre} {loginPost.Apellido}");*/


/*private void LogError(string v, string filterDescription, Exception e)
{
    throw new NotImplementedException();
}

private IHttpActionResult Ok(PageResultDTO<UserDto> pageResultDTO)
{
    throw new NotImplementedException();
}
*/





