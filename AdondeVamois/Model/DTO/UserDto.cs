
using System;
using System.ComponentModel.DataAnnotations;

namespace AdondeVamos.Model.DTO
{
    public class UserDto
    {
        //[Required]
        //public int IdUsuario { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime Fecha_nac { get; set; }

        //public string Foto { get; set; }

        public int Tipo { get; set; }
    }
}