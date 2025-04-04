using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TareasApp.Hubs;
using TareasApp.Models;

namespace TareasApp.Controllers
{
    public class TareasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<NotificationHub> _hubContext;

        public TareasController(ApplicationDbContext context, IHubContext<NotificationHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        // Crear tarea
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                tarea.FechaCreacion = DateTime.Now;
                _context.Tareas.Add(tarea);
                _context.SaveChanges();

                // Registrar en historial
                var historial = new HistorialTarea
                {
                    TareaID = tarea.TareaID,
                    UsuarioID = 1, // Asumiendo que el usuario tiene ID 1, lo ideal sería usar el ID del usuario autenticado
                    FechaCambio = DateTime.Now,
                    Observaciones = "Tarea creada"
                };
                _context.HistorialTareas.Add(historial);
                _context.SaveChanges();

                // Notificar a todos los usuarios sobre la creación
                _hubContext.Clients.All.SendAsync("RecibirNotificacion", "Tarea creada: " + tarea.Titulo);

                return RedirectToAction("Index");
            }

            return View(tarea);
        }

        // Consultar tareas de un usuario
        public IActionResult Index()
        {
            var usuarioId = 1; // Asume que el usuario está logueado, debes obtener su ID real
            var tareas = _context.Tareas.Where(t => t.UsuarioID == usuarioId).ToList();
            return View(tareas);
        }


        // Acción para mostrar las tareas asignadas a un usuario
        public async Task<IActionResult> TareasPorUsuario(int usuarioId)
        {
            if (usuarioId == 0)
            {
                return NotFound();
            }

            // Buscar el usuario
            var usuario = await _context.Usuarios
                .Where(u => u.UsuarioID == usuarioId)
                .FirstOrDefaultAsync();

            if (usuario == null)
            {
                return NotFound();
            }

            // Obtener las tareas asignadas al usuario
            var tareas = await _context.Tareas
                .Where(t => t.UsuarioID == usuarioId)
                .ToListAsync();

            // Crear el modelo de vista
            var viewModel = new TareasAsignadasViewModel
            {
                UsuarioID = usuario.UsuarioID,
                UsuarioNombre = usuario.Nombre,
                Tareas = tareas
            };

            return View(viewModel);
        }
    }
}
