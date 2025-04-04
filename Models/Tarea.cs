using System.ComponentModel.DataAnnotations;

namespace TareasApp.Models
{
    public class Tarea
    {
        public int TareaID { get; set; }

        [Required]
        [StringLength(255)]
        public string Titulo { get; set; }

        [StringLength(1000)]
        public string Descripcion { get; set; }

        public DateTime FechaVencimiento { get; set; }

        // Relación con la tabla de Estados
        public int EstadoTareaID { get; set; }  // Identificador de la relación con EstadoTarea
        public EstadoTarea EstadoTarea { get; set; }  // Relación con el modelo EstadoTarea

        public int UsuarioID { get; set; }
        public Usuario Usuario { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }
    }
}
