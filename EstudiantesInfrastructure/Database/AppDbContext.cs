using EstudiantesCore.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudiantesInfrastructure.Database
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Estudiantes> Estudiante { get; set; }
        public DbSet<EstadoEstudiante> EstadoEstudiante { get; set; }
        public DbSet<EstadoMateria> EstadoMateria { get; set; }
        public DbSet<EstadoProfesor> EstadoProfesore {  get; set; }
        public DbSet<EstudiantesXMateria> EstudiantesXMaterias { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<ProfesorXMaterias> ProfesorXMaterias { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiantes>()
                .HasIndex(b => b.Documento)
                .IsUnique(true);
            modelBuilder.Entity<Profesor>()
                .HasIndex(b => b.Documento)
                .IsUnique(true);
            modelBuilder.Entity<Materia>()
                .HasIndex(b => b.Code)
                .IsUnique(true);

        }

    }
}
