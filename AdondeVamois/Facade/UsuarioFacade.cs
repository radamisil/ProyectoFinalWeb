﻿using AdondeVamos.DAL;
using AdondeVamos.Model.UnitOfWork;
using AdondeVamos.Model;
using AdondeVamos.Model.DTO;
using AutoMapper;

namespace AdondeVamos.Facade
{

    public class UsuarioFacade : BaseFacade, IUsuarioFacade
    {
        private A_DONDE_VAMOSEntities2 ctx = new A_DONDE_VAMOSEntities2();

        private readonly IMapper Mapper;

        public UsuarioFacade(IUnitOfWork unitOfWork, IMapper mapper) : base (unitOfWork, mapper)
        {
            Mapper = mapper;
        }
            
        public UserDto AddUsuario(UserDto loginPost)
        {
            int saveResult;
            return PerformTransactional<UserDto>(() =>
            {
                return InternalAddUsuario(loginPost);               
            },
            out saveResult);
        }

        private UserDto InternalAddUsuario(UserDto loginPost)
        {
            Usuarios addUsuario = new Usuarios();

            if (loginPost != null)
            {
                addUsuario.Nombre = loginPost.Nombre;
                addUsuario.Apellido = loginPost.Apellido;
                addUsuario.Email = loginPost.Email;
                addUsuario.Password = loginPost.Password;
                addUsuario.Fecha_nac = loginPost.Fecha_nac;
                addUsuario.Foto = loginPost.Foto;
                addUsuario.IdTipo = loginPost.Tipo;
            }

            ctx.Usuarios.Add(addUsuario);
            ctx.SaveChanges();
           
            return loginPost;
        }
    }
}