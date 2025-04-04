namespace TareasApp.Models
{
    public class HistorialTarea
    {
        public int HistorialTareaID { get; set; }

        public int TareaID { get; set; }
        public Tarea Tarea { get; set; }

        public int UsuarioID { get; set; }
        public Usuario Usuario { get; set; }

        public DateTime FechaCambio { get; set; }

        public string Observaciones { get; set; }
    }
}
