using AdondeVamos.DAL;
using AdondeVamos.Model.UnitOfWork;
using AdondeVamos.Models;
using AdondeVamos.Models.DTO;
using AutoMapper;

namespace AdondeVamos.Facade
{
    public class UsuarioFacade : BaseFacade, IUsuarioFacade
    {        
        public UsuarioFacade(IUnitOfWork unitOfWork, IMapper mapper) : base (unitOfWork, mapper)
        {           
        }
        protected IMapper mapper;
       
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
            Usuarios usariosGrabar = mapper.Map<Usuarios>(loginPost);    
            SaveChanges();

            return loginPost;
        }
    }
}