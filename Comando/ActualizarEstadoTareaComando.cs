using TareasApp.Models;

namespace TareasApp.Comando
{
    public class ActualizarEstadoTareaComando : IComando
    {
        private Tarea _tarea;
        private EstadoTarea _nuevoEstado;

        public ActualizarEstadoTareaComando(Tarea tarea, EstadoTarea nuevoEstado)
        {
            _tarea = tarea;
            _nuevoEstado = nuevoEstado;
        }

        public void Ejecutar()
        {
            _tarea.EstadoTarea = _nuevoEstado;
            // Guardar en la base de datos
        }
    }
}
