using AdondeVamos.DAL;
using AdondeVamos.Model.UnitOfWork;
using AdondeVamos.Model;
using AdondeVamos.Model.DTO;
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
            Usuarios addUsuario = new Usuarios();

            addUsuario.IdUsuario = loginPost.IdUsuario;
            addUsuario.Nombre = loginPost.Nombre;
            addUsuario.Apellido = loginPost.Apellido;
            addUsuario.Email = loginPost.Email;
            addUsuario.Password = loginPost.Password;
            addUsuario.Fecha_nac = loginPost.Fecha_nac;
            addUsuario.Foto = loginPost.Foto;
            addUsuario.IdTipo = loginPost.Tipo;



            SaveChanges();

            return loginPost;
        }
    }
}