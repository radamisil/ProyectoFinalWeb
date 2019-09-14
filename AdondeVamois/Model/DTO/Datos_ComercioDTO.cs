using System.ComponentModel.DataAnnotations;

namespace AdondeVamos.Controllers
{
    public class Datos_ComercioDTO
    {
        [Required]
        public string IdDatos_Comercio { get; set; }

        public string direecion { get; set; }

        public string telefono { get; set; }

        public string capacidad { get; set; }

        public string nombre { get; set; }
    }
}