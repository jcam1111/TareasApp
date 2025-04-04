create database GestionTareas
go

-- Tabla de Usuarios
CREATE TABLE Usuarios (
    UsuarioID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
Correo NVARCHAR(255) NULL,
 Activo BIT NULL,
 FechaCreacion DATETIME DEFAULT GETDATE(),
    FechaModificacion DATETIME NULL
);
go

-- Tabla de Estados
CREATE TABLE [dbo].[EstadoTarea](
	[EstadoTareaID] [int] NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EstadoTareaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




CREATE TABLE [dbo].[Tareas](
	[TareaID] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](255) NOT NULL,
	[Descripcion] [nvarchar](1000) NULL,
	[FechaCreacion] [datetime] NULL,
	[FechaVencimiento] [datetime] NULL,
	[EstadoTareaID] [int] NULL,
	[UsuarioID] [int] NULL,
	[FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[TareaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Tareas] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO

ALTER TABLE [dbo].[Tareas]  WITH CHECK ADD FOREIGN KEY([EstadoTareaID])
REFERENCES [dbo].[EstadoTarea] ([EstadoTareaID])
GO

ALTER TABLE [dbo].[Tareas]  WITH CHECK ADD FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuarios] ([UsuarioID])
GO

CREATE TABLE [dbo].[HistorialTareas](
	[HistorialID] [int] IDENTITY(1,1) NOT NULL,
	[TareaID] [int] NULL,
	[UsuarioID] [int] NULL,
	[EstadoID] [int] NULL,
	[FechaCambio] [datetime] NULL,
	[Observaciones] [nvarchar](1000) NULL,
	[FechaModificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[HistorialID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[HistorialTareas] ADD  DEFAULT (getdate()) FOR [FechaCambio]
GO

ALTER TABLE [dbo].[HistorialTareas]  WITH CHECK ADD FOREIGN KEY([EstadoID])
REFERENCES [dbo].[EstadoTarea] ([EstadoTareaID])
GO

ALTER TABLE [dbo].[HistorialTareas]  WITH CHECK ADD FOREIGN KEY([TareaID])
REFERENCES [dbo].[Tareas] ([TareaID])
GO

ALTER TABLE [dbo].[HistorialTareas]  WITH CHECK ADD FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuarios] ([UsuarioID])
GO

-- Insertar los posibles estados
INSERT INTO [EstadoTarea] (EstadoTareaID, Descripcion)
VALUES 
(1, 'Pendiente'),
(2, 'En Progreso'),
(3, 'Bloqueada'),
(4, 'Completada'),
(5, 'Cancelada'),
(6, 'Pospuesta'),
(7, 'En Revisión'),
(8, 'Aprobada');
go

