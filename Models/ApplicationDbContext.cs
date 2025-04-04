using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TareasApp.Models;

namespace TareasApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        public DbSet<EstadoTarea> EstadosTareas { get; set; }  // Tabla de estados

        public DbSet<HistorialTarea> HistorialTareas { get; set; }

        // Configuración de las relaciones entre las entidades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación de uno a muchos entre Usuario y Tareas
            modelBuilder.Entity<Tarea>()
                .HasOne(t => t.Usuario)
                .WithMany(u => u.Tarea)
                .HasForeignKey(t => t.UsuarioID);

            // Relación entre Tarea y HistorialTarea
            modelBuilder.Entity<HistorialTarea>()
                .HasOne(ht => ht.Tarea)
                .WithMany()
                .HasForeignKey(ht => ht.TareaID);

            modelBuilder.Entity<HistorialTarea>()
                .HasOne(ht => ht.Usuario)
                .WithMany()
                .HasForeignKey(ht => ht.UsuarioID);

            // Relación de uno a muchos entre Usuario y Tareas
            modelBuilder.Entity<Tarea>()
                .HasOne(t => t.Usuario)
                .WithMany(u => u.Tarea)
                .HasForeignKey(t => t.UsuarioID);

            // Relación de muchos a uno entre Tarea y EstadoTarea
            modelBuilder.Entity<Tarea>()
                .HasOne(t => t.EstadoTarea)
                .WithMany()
                .HasForeignKey(t => t.EstadoTareaID);

            // Insertar estados predeterminados
            modelBuilder.Entity<EstadoTarea>().HasData(
                new EstadoTarea { EstadoTareaID = 1, Descripcion = "Pendiente" },
                new EstadoTarea { EstadoTareaID = 2, Descripcion = "En Progreso" },
                new EstadoTarea { EstadoTareaID = 3, Descripcion = "Bloqueada" },
                new EstadoTarea { EstadoTareaID = 4, Descripcion = "Completada" },
                new EstadoTarea { EstadoTareaID = 5, Descripcion = "Cancelada" },
                new EstadoTarea { EstadoTareaID = 6, Descripcion = "Pospuesta" },
                new EstadoTarea { EstadoTareaID = 7, Descripcion = "En Revisión" },
                new EstadoTarea { EstadoTareaID = 8, Descripcion = "Aprobada" }
            );
        }
    }
}
