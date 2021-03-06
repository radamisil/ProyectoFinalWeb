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
    
    public partial class Usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuarios()
        {
            this.Promociones = new HashSet<Promociones>();
            this.Seguidores = new HashSet<Seguidores>();
            this.Usuario_lugar_historial = new HashSet<Usuario_lugar_historial>();
            this.Usuario_lugares = new HashSet<Usuario_lugares>();
        }
    
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public System.DateTime Fecha_nac { get; set; }
        public string Foto { get; set; }
        public Nullable<int> IdTipo { get; set; }
        public Nullable<int> IdTipo_comercio { get; set; }
        public Nullable<int> IdDatos_comercio { get; set; }
    
        public virtual Datos_Comercio Datos_Comercio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Promociones> Promociones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Seguidores> Seguidores { get; set; }
        public virtual Tipo_Comercio Tipo_Comercio { get; set; }
        public virtual Tipo_Usuarios Tipo_Usuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario_lugar_historial> Usuario_lugar_historial { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario_lugares> Usuario_lugares { get; set; }
    }
}
