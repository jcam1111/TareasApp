TareasApp - Gestión de Tareas y Notificaciones en Tiempo Real

TareasApp es una aplicación web construida utilizando ASP.NET Core MVC que permite gestionar tareas, usuarios, y estados de tareas en tiempo real utilizando SignalR. Los usuarios pueden crear, editar, consultar y eliminar tareas, y los cambios realizados en las tareas son notificados a todos los usuarios en tiempo real.

🛠️ Instrucciones para instalar y correr el proyecto
1. Clonar el repositorio

Clona este repositorio a tu máquina local usando el siguiente comando:

git clone https://github.com/tu-usuario/TareasApp.git

2. Instalar las dependencias

Asegúrate de tener .NET SDK instalado. Si no lo tienes, puedes descargarlo desde aquí.

Después de clonar el repositorio, navega a la carpeta del proyecto en la terminal y ejecuta el siguiente comando para restaurar las dependencias:
cd TareasApp
dotnet restore

3. Configurar la base de datos

Asegúrate de tener una base de datos de SQL Server configurada. Si estás utilizando SQL Server en tu máquina local, puedes usar la cadena de conexión predeterminada, o configurar tu archivo appsettings.json con la cadena de conexión adecuada.

"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TareasAppDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}

4. Aplicar las migraciones de la base de datos

Para aplicar las migraciones y crear la base de datos, ejecuta el siguiente comando:

dotnet ef database update

5. Ejecutar el proyecto

Para ejecutar el proyecto en modo de desarrollo, usa el siguiente comando:

dotnet run

El proyecto debería estar disponible en https://localhost:5001.

Decisiones Técnicas y Tecnologías Utilizadas

    ASP.NET Core MVC: El patrón Modelo-Vista-Controlador se utiliza para estructurar la aplicación y separar las preocupaciones. Las tareas y los usuarios están gestionados a través de modelos que interactúan con la base de datos.

    SignalR: Para notificar a los usuarios en tiempo real sobre los cambios en las tareas. SignalR facilita la comunicación bidireccional entre el servidor y el cliente sin necesidad de actualizaciones constantes de la página.

    Entity Framework Core (EF Core): Se utiliza para gestionar el acceso a la base de datos de manera eficiente y con un enfoque de código primero. Se aplican migraciones para crear y mantener la estructura de la base de datos.

    Bootstrap: Se usa para el diseño responsivo de la aplicación, permitiendo que sea accesible y funcional en dispositivos de diferentes tamaños.

    Validaciones: Se implementan tanto en el backend como en el frontend para asegurar que los datos sean correctos antes de ser procesados o almacenados en la base de datos.
	
	🧑‍💻 Descripción Breve de Cada Endpoint del API

A continuación, se presenta una breve descripción de los principales endpoints de la API que gestionan las tareas y usuarios:
1. Usuarios

    POST /api/usuarios/register

        Descripción: Registra un nuevo usuario en el sistema.

        Cuerpo:
		{
  "nombre": "Juan Pérez",
  "correo": "juan@ejemplo.com",
  "contrasena": "password123"
}

POST /api/usuarios/login

    Descripción: Permite a un usuario iniciar sesión en el sistema.

    Cuerpo:
	{
  "correo": "juan@ejemplo.com",
  "contrasena": "password123"
}

GET /api/usuarios/{id}

    Descripción: Obtiene los detalles de un usuario específico por su ID.

    Respuesta:
	{
  "id": 1,
  "nombre": "Juan Pérez",
  "correo": "juan@ejemplo.com",
  "estado": true
}
2. Tareas

    POST /api/tareas

        Descripción: Crea una nueva tarea asignada a un usuario.

        Cuerpo:
		{
  "titulo": "Revisar documentación",
  "descripcion": "Revisar los documentos del proyecto",
  "usuarioId": 1,
  "estadoTareaId": 1,
  "fechaVencimiento": "2025-04-05"
}
GET /api/tareas/{id}

    Descripción: Obtiene los detalles de una tarea específica por su ID.

    Respuesta:
	
	{
  "id": 1,
  "titulo": "Revisar documentación",
  "descripcion": "Revisar los documentos del proyecto",
  "usuarioId": 1,
  "estadoTareaId": 1,
  "fechaVencimiento": "2025-04-05",
  "estadoTarea": {
    "id": 1,
    "nombre": "Pendiente"
  }
}

GET /api/tareas/usuario/{usuarioId}

    Descripción: Obtiene todas las tareas asignadas a un usuario específico por su ID.

    Respuesta:
	
	[
  {
    "id": 1,
    "titulo": "Revisar documentación",
    "estado": "Pendiente",
    "fechaVencimiento": "2025-04-05"
  },
  {
    "id": 2,
    "titulo": "Preparar informe",
    "estado": "En Progreso",
    "fechaVencimiento": "2025-04-07"
  }
]

PUT /api/tareas/{id}

    Descripción: Actualiza los detalles de una tarea existente.

    Cuerpo:
	
	{
  "titulo": "Revisar documentación y actualizar",
  "descripcion": "Actualizar los documentos del proyecto",
  "estadoTareaId": 2
}

DELETE /api/tareas/{id}

    Descripción: Elimina una tarea específica por su ID.
	
	3. Historial de Tareas

    GET /api/historial/tareas/{tareaId}

        Descripción: Obtiene el historial de cambios realizados en una tarea específica.

        Respuesta:
		[
  {
    "fecha": "2025-04-01T12:00:00",
    "descripcion": "Tarea creada"
  },
  {
    "fecha": "2025-04-02T15:00:00",
    "descripcion": "Estado cambiado a 'En Progreso'"
  }
]

 Configuración de SignalR para Notificaciones en Tiempo Real

El sistema utiliza SignalR para proporcionar notificaciones en tiempo real sobre los cambios en las tareas. Puedes implementar un Hub de SignalR para manejar las notificaciones y conectar a los usuarios a través de WebSockets. Asegúrate de configurar SignalR en el archivo Startup.cs:

public void ConfigureServices(IServiceCollection services)
{
    services.AddSignalR();
    // Otros servicios...
}

public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    app.UseSignalR(routes =>
    {
        routes.MapHub<TareaHub>("/tareaHub");
    });
    // Otros middleware...
}

📝 Licencia

Este proyecto está licenciado bajo la licencia MIT.