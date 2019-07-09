
using AdondeVamos.Model.GenericClass;
using System;
using System.ComponentModel.DataAnnotations;

namespace AdondeVamos.Model.DTO
{
    public class UserDto
    {
        //[Required]
        //public int IdUsuario { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Apellido { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime Fecha_nac { get; set; }

        public string Foto { get; set; }

        [MinValue(0, "{0} must be greater than or equal to zero")]
        public int Tipo { get; set; }
    }
}