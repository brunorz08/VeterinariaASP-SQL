using Microsoft.EntityFrameworkCore;
using Veterinaria.Models;

namespace Veterinaria.Context
{
    public class VeterinariaContext : DbContext
    {
        


        public virtual DbSet<Animal> Animales { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Especialidad> Especialidades { get; set; }
        public VeterinariaContext(DbContextOptions<VeterinariaContext> options) : base(options)
        {
        }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Medico>()
                    .HasOne(m => m.Especialidad)
                    .WithMany(e => e.Medicos)
                    .HasForeignKey(m => m.EspecialidadId);
            }
        


    }
}
