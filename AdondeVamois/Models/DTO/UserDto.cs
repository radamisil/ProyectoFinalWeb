
using System.ComponentModel.DataAnnotations;

namespace AdondeVamos.Models.DTO
{
    public class UserDto
    {
        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}