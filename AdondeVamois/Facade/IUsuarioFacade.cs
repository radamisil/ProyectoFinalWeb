using AdondeVamos.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdondeVamos.Facade
{
    public interface IUsuarioFacade
    {
        int SaveChanges();

        UserDto AddUsuario(UserDto loginPost);
    }
}