namespace TareasApp.Servicios
{
    public class NotificationService
    {
        private static NotificationService _instance;
        private NotificationService() { }

        public static NotificationService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new NotificationService();
            }
            return _instance;
        }

        public void Notify(string message)
        {
            // Lógica de notificación
        }
    }

}
