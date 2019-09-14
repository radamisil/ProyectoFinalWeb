using System.ComponentModel.DataAnnotations;

namespace AdondeVamos.Controllers
{
    public class ImagenDTO
    {
        [Required]
        public string imagenbase64 { get; set; }
    }
}