﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class A_DONDE_VAMOSEntities2 : DbContext
    {
        public A_DONDE_VAMOSEntities2()
            : base("name=A_DONDE_VAMOSEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Datos_Comercio> Datos_Comercio { get; set; }
        public virtual DbSet<Horarios_concurridos> Horarios_concurridos { get; set; }
        public virtual DbSet<Lugares> Lugares { get; set; }
        public virtual DbSet<Promociones> Promociones { get; set; }
        public virtual DbSet<Seguidores> Seguidores { get; set; }
        public virtual DbSet<Tipo_Comercio> Tipo_Comercio { get; set; }
        public virtual DbSet<Tipo_Usuarios> Tipo_Usuarios { get; set; }
        public virtual DbSet<Usuario_lugar_historial> Usuario_lugar_historial { get; set; }
        public virtual DbSet<Usuario_lugares> Usuario_lugares { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }
    
        public virtual int SP_GetPromociones(string filterPlace, string filterUser)
        {
            var filterPlaceParameter = filterPlace != null ?
                new ObjectParameter("filterPlace", filterPlace) :
                new ObjectParameter("filterPlace", typeof(string));
    
            var filterUserParameter = filterUser != null ?
                new ObjectParameter("filterUser", filterUser) :
                new ObjectParameter("filterUser", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_GetPromociones", filterPlaceParameter, filterUserParameter);
        }
    
        public virtual int SP_GetUsuarios(string filter)
        {
            var filterParameter = filter != null ?
                new ObjectParameter("filter", filter) :
                new ObjectParameter("filter", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_GetUsuarios", filterParameter);
        }
    }
}
