using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GestorAduana_v1.Context
{
    public class GestorAduanasContext : DbContext
    {
        public GestorAduanasContext() : base("DefaultConnection")
        {
            // Opcional: Configurar el inicializador de la base de datos si es necesario
            // Database.SetInitializer(new CreateDatabaseIfNotExists<GestorAduanasContext>());
        }

        public DbSet<Camionero> Camioneros { get; set; }
        public DbSet<BackOffice> BackOffices { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Opcional: Remover la pluralización automática de los nombres de las tablas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Configuración de relaciones y restricciones adicionales

            // Configuración de la relación entre Camionero y Empresa
            modelBuilder.Entity<Camionero>()
                .HasRequired(c => c.Empresa)
                .WithMany(e => e.Camioneros)
                .HasForeignKey(c => c.EmpresaId);

            // Configuración de la relación entre BackOffice y Camionero (si aplica)
            // modelBuilder.Entity<BackOffice>()
            //     .HasRequired(bo => bo.Camionero)
            //     .WithMany()
            //     .HasForeignKey(bo => bo.CamioneroId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
