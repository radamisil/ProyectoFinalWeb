using AdondeVamos.Model;
using System.Data.Entity;
using System.Web.Configuration;

namespace AdondeVamos.DAL
{
    public class aDondeVamosContext
        : DbContext, IDbContext
    {
        #region Constructor
        public aDondeVamosContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<aDondeVamosContext>());
            Database.Connection.ConnectionString = GetConnectionString();
        }
        #endregion

        protected virtual string GetConnectionString()
        {
            //return "Password=Axoft2010;Persist Security Info=True;User ID=sa;Data Source=AVALON;Initial Catalog=AxNexoTiendasTest;";
            return WebConfigurationManager.ConnectionStrings["DBConn"].ToString();
        }

        public virtual DbSet<TEntity> SetEx<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<string>()
            .Configure(s => s.HasColumnType("varchar"));
                       
            /*modelBuilder.Entity<Usuarios>()
                .HasRequired(u => u.Nombre)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Promociones>()
                .HasRequired(p => p.Descripcion)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Seguidores>()
                .HasRequired(s => s.Usuarios)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Lugares>()
               .HasRequired(l => l.)
               .WithMany()
               .WillCascadeOnDelete(true);*/
        }

        #region IDbContext
        public virtual bool CanUpdate()
        {
            return true;
        }

        Database IDbContext.Database()
        {
            return Database;
        }

        IDbSet<TEntity> IDbContext.Set<TEntity>()
        {
            return SetEx<TEntity>();
        }
        #endregion

        #region DbSets

        public virtual DbSet<Usuarios> Usuarios { get; set; }

        public virtual DbSet<Lugares> Lugares { get; set; }

        public virtual DbSet<Promociones> Promociones { get; set; }       

        public virtual DbSet<Usuario_lugares> Usuario_lugares { get; set; }

        public virtual DbSet<Horarios_concurridos> Horarios_concurridos { get; set; }        

        public virtual DbSet<Tipo_Usuarios> Tipo_Usuarios { get; set; }

        public virtual DbSet<Seguidores> Seguidores { get; set; }

        public virtual DbSet<Usuario_lugar_historial> Usuario_lugar_historial { get; set; }

        #endregion
    }
}