using AdondeVamos.Model;
using AdondeVamos.Model.DTO;
using System.Collections.Generic;

namespace AdondeVamos.Services.Interfaces
{
    public interface IApiService
    {   
        List<PromocionDTO> GetPromocion(string filterPlace, string filterUser);

        IList<Promociones> GetPromocionesByTable(string filterPlace, string filterUser);

        List<UserDto> GetUsuario(string filter);

        IList<Usuarios> GetUsuarioByTable(string filter);
    }
}