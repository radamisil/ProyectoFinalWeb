
namespace AdondeVamos.Models
{
    using System;
    using System.Collections.Generic;
    
    public class Promociones
    {
        public int idPromocion { get; set; }
        public string Descripcion { get; set; }
        public int IdUsuario { get; set; }
        public int IdLugar { get; set; }
    
        public virtual Lugares Lugares { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
