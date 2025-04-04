using TareasApp.Models;

namespace TareasApp.TareaFactory
{
    public class TareaUrgenteFactory : TareaFactory
    {
        public override Tarea CrearTarea()
        {
            return new Tarea { Titulo = "Tarea Urgente", EstadoTarea = EstadoTarea.Pendiente };
        }
    }
}
