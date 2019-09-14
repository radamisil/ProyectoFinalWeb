using AdondeVamos.ActionFilters;
using AdondeVamos.Facade;
using AdondeVamos.Model;
using AdondeVamos.Model.DTO;
using AdondeVamos.Model.GenericClass;
using AdondeVamos.Services;
using System;
using System.Web.Http;
using AdondeVamos.Model.Exception;
using System.Net.Http;
using RestSharp;
using Newtonsoft.Json;
using RestSharp;

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
            string MENSAJE = "No se pudo Registrar el nuevo Usuario";

            //try
            UserDto usuarioAgregado = new UserDto();

            if (loginPost != null)
            {
                usuarioAgregado = UsuarioFacade.AddUsuario(loginPost);
            }
            else
            {
                //return MENSAJE;
            }
            return usuarioAgregado;
        }
        /// <summary>
        /// POST contra IA localhost:5000/webhook
        /// </summary>        
        [Route("calculateIA")]
        public object CalculateIA([FromBody]ImagenDTO imagen)
        {

            string imagenstring = imagen.imagenbase64.ToString();
            var client = new RestClient("http://40.84.190.225:5000/webhook");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("Content-Length", "120889");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Cookie", "__RequestVerificationToken=WEDM7Tk3zf5Cfk7qX0EieOvRZnqYQa16YlH7BK47mIrmP0B3oN2kJEhOebbELQ7iXp0G3ZYgjVSMhqI_-VUkZahWDodmmfSIljKRUDKyuBc1");
            request.AddHeader("Host", "40.84.190.225:5000");
            /*BORRAR KEY POSTMAN LUEGO DE QUE FUNCIONE*/
            request.AddHeader("Postman-Token", "e253d782-6a01-4625-9376-c1e5f5abf419,449fda2c-a13e-4c4c-ad32-d24b1d93d0f5");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("User-Agent", "PostmanRuntime/7.15.2");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\n\t\"imagen\":\" "+imagenstring+" \"\n}\n", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var countPerson = JsonConvert.DeserializeObject(response.Content);
            return countPerson;


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





