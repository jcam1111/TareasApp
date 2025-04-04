using Microsoft.AspNetCore.SignalR;

namespace TareasApp.Hubs
{
    public class NotificationHub : Hub
    {
        // Método para notificar a todos los usuarios
        public async Task EnviarNotificacion(string mensaje)
        {
            await Clients.All.SendAsync("RecibirNotificacion", mensaje);
        }
    }
}
