
namespace AdondeVamos.Models.DTO
{
    public class UserDto
    {
        public int IdUsuario { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public PromocionDTO Promocion { get; set; }
    }
}