//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdondeVamos.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Seguidores
    {
        public int Idseguidor { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public Nullable<int> IdLugar { get; set; }
    
        public virtual Lugares Lugares { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
