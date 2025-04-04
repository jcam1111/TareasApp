namespace TareasApp.Models
{
    public class TareasAsignadasViewModel
    {
        public int UsuarioID { get; set; }
        public string UsuarioNombre { get; set; }
        public List<Tarea> Tareas { get; set; }
    }
}
