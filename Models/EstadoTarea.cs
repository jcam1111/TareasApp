namespace TareasApp.Models
{
    public class EstadoTarea
    {
        public int EstadoTareaID { get; set; } // Identificador único del estado de tarea

        //public string Nombre { get; set; }  // Nombre del estado de la tarea (ej. Pendiente, En Progreso, etc.)

        public string Descripcion { get; set; } // Descripción del estado (opcional)

        //public DateTime FechaCreacion { get; set; }  // Fecha de creación del estado

        //public DateTime FechaModificacion { get; set; }  // Fecha de la última modificación del estado

        // Relación con las tareas que tienen este estado
        public ICollection<Tarea> Tareas { get; set; }
    }
}
