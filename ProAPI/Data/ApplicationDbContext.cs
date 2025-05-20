using System.Reflection.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestAPI.Models.Entity;

namespace RestAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relaciones múltiples entre Reserva y Usuario
            modelBuilder.Entity<ReservaEntity>()
                .HasOne(r => r.Profesor)
                .WithMany(u => u.Reservas)
                .HasForeignKey(r => r.ProfesorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Clave primaria personalizada (email o GUID como string)
            modelBuilder.Entity<UsuarioEntity>()
                .HasKey(u => u.Id);
        }
        //Add models here
        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<ReservaEntity> Reservas { get; set; }
        public DbSet<FranjaHorariaEntity> FranjasHorarias { get; set; }
        public DbSet<DiaEntity> DiasNoLectivos { get; set; }

    }
}
