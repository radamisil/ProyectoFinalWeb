using AdondeVamos.Model;
using AdondeVamos.Model.DTO;
using AdondeVamos.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AdondeVamos.Services
{
    public class ApiService : BaseService, IApiService
    {

        /// <summary>
        /// se reciben datos del SP_ obtenido y se mapea contra el DTO
        /// </summary>
        public List<PromocionDTO> GetPromocion(string filterPlace, string filterUser)
        {
            var promocionDtoList = new List<PromocionDTO>();
            var promocionList = GetPromocionesByTable(filterPlace, filterUser);

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
        public IList<Promociones> GetPromocionesByTable(string filterPlace, string filterUser)
        {         
            var parameters = GetParameters(filterPlace, filterUser);
            var promociones = GetDataTable("SP_GetPromociones", parameters);
            var promocionesQueryable = (from promocion in promociones.AsEnumerable()
                                        select new Promociones
                                        {
                                           idPromocion = promocion.Field<int>("Id"),
                                           Descripcion = promocion.Field<string>("Descripción")
                                        }).ToList();

            return promocionesQueryable;
        }

        public List<UserDto> GetUsuario(string filter)
        {
            var usuarioDtoList = new List<UserDto>();
            var usuarioList = GetUsuarioByTable(filter);

            if ((usuarioList != null) && (usuarioList.Count > 0))
                foreach (Usuarios usuario in usuarioList)
                {
                    UserDto usuarioDto = new UserDto();
                    usuarioDto.Email = usuario.Email;
                    usuarioDto.Nombre = usuario.Nombre;
                    usuarioDto.Apellido = usuario.Apellido;
                    usuarioDto.Password = usuario.Password;

                    usuarioDtoList.Add(usuarioDto);
                }
            return usuarioDtoList;
        }

        public IList<Usuarios> GetUsuarioByTable(string filter)
        {
            var parameters = GetParametersUser(filter);
            var usuarios = GetDataTable("SP_GetUsuarios", parameters);
            var usuariosQueryable = (from usuario in usuarios.AsEnumerable()
                                        select new Usuarios
                                        {
                                            IdUsuario = usuario.Field<int>("IdUsuario"),
                                            Nombre = usuario.Field<string>("Nombre"),
                                            Apellido = usuario.Field<string>("Apellido"),
                                            Email = usuario.Field<string>("Email"),
                                            Password = usuario.Field<string>("Password")

                                        }).ToList();

            return usuariosQueryable;
        }
    }   
}
