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
    
    public partial class Horarios_concurridos
    {
        public int IdHorarios_concurridos { get; set; }
        public string Dia { get; set; }
        public Nullable<int> Hora { get; set; }
        public Nullable<int> IdLugar { get; set; }
        public Nullable<int> cantidad { get; set; }
        public Nullable<System.DateTime> fecha_insercion { get; set; }
    
        public virtual Lugares Lugares { get; set; }
    }
}
