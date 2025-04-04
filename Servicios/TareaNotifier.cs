using TareasApp.Models;

namespace TareasApp.Servicios
{
    public class TareaNotifier : IObserver<Tarea>
    {
        private IObservable<Tarea> _tareaSource;

        public TareaNotifier(IObservable<Tarea> tareaSource)
        {
            _tareaSource = tareaSource;
            _tareaSource.Subscribe(this);
        }

        public void OnNext(Tarea tarea)
        {
            // Notificar a los usuarios que la tarea ha sido actualizada
        }

        public void OnError(Exception error) { }
        public void OnCompleted() { }
    }

}
