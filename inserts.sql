USE [aspnet-SkillCheckQ10-c94811e8-367b-480d-8fd8-24f6c2cfa556]
GO
SET IDENTITY_INSERT [dbo].[Docente] ON 
GO
INSERT [dbo].[Docente] ([Id], [Numero_Documento], [Tipo_Documento], [Nombre], [Apellido], [Fecha_Nacimiento]) VALUES (1, 14564819, N'CC', N'Marta', N'Sucre', CAST(N'1980-12-04T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Docente] ([Id], [Numero_Documento], [Tipo_Documento], [Nombre], [Apellido], [Fecha_Nacimiento]) VALUES (2, 1241558346, N'CC', N'Enrique', N'Gutierrez', CAST(N'2000-05-08T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Docente] ([Id], [Numero_Documento], [Tipo_Documento], [Nombre], [Apellido], [Fecha_Nacimiento]) VALUES (3, 10251749, N'CC', N'Mateo', N'Arias', CAST(N'2002-12-21T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Docente] OFF
GO
SET IDENTITY_INSERT [dbo].[Estudiante] ON 
GO
INSERT [dbo].[Estudiante] ([Id], [Creditos], [Numero_Documento], [Tipo_Documento], [Nombre], [Apellido], [Fecha_Nacimiento]) VALUES (1, 10, 100012564, N'CC', N'Juan', N'Castaño', CAST(N'2002-09-12T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Estudiante] ([Id], [Creditos], [Numero_Documento], [Tipo_Documento], [Nombre], [Apellido], [Fecha_Nacimiento]) VALUES (2, 30, 653265983, N'CC', N'David', N'Usuga', CAST(N'2000-12-12T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Estudiante] ([Id], [Creditos], [Numero_Documento], [Tipo_Documento], [Nombre], [Apellido], [Fecha_Nacimiento]) VALUES (3, 9, 78945612, N'CE', N'Paola', N'Ezequiel', CAST(N'1998-12-05T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Estudiante] ([Id], [Creditos], [Numero_Documento], [Tipo_Documento], [Nombre], [Apellido], [Fecha_Nacimiento]) VALUES (4, 16, 789456132, N'TI', N'Jaime', N'Abendaño', CAST(N'2009-04-05T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Estudiante] OFF
GO
SET IDENTITY_INSERT [dbo].[Materia] ON 
GO
INSERT [dbo].[Materia] ([Id], [Nombre], [Creditos]) VALUES (1, N'Programación Lineal', 4)
GO
INSERT [dbo].[Materia] ([Id], [Nombre], [Creditos]) VALUES (2, N'Calculo Diferencial', 4)
GO
INSERT [dbo].[Materia] ([Id], [Nombre], [Creditos]) VALUES (3, N'Física Mecanica', 2)
GO
INSERT [dbo].[Materia] ([Id], [Nombre], [Creditos]) VALUES (4, N'Calculo Integral', 4)
GO
INSERT [dbo].[Materia] ([Id], [Nombre], [Creditos]) VALUES (5, N'Complementaria', 1)
GO
INSERT [dbo].[Materia] ([Id], [Nombre], [Creditos]) VALUES (6, N'Algebra LIneal', 4)
GO
SET IDENTITY_INSERT [dbo].[Materia] OFF
GO
SET IDENTITY_INSERT [dbo].[GrupoEstudiante] ON 
GO
INSERT [dbo].[GrupoEstudiante] ([Id], [MateriaId], [DocenteId], [EstudianteId]) VALUES (1, 1, 1, 1)
GO
INSERT [dbo].[GrupoEstudiante] ([Id], [MateriaId], [DocenteId], [EstudianteId]) VALUES (2, 2, 1, 1)
GO
INSERT [dbo].[GrupoEstudiante] ([Id], [MateriaId], [DocenteId], [EstudianteId]) VALUES (3, 3, 1, 1)
GO
INSERT [dbo].[GrupoEstudiante] ([Id], [MateriaId], [DocenteId], [EstudianteId]) VALUES (4, 1, 1, 4)
GO
INSERT [dbo].[GrupoEstudiante] ([Id], [MateriaId], [DocenteId], [EstudianteId]) VALUES (5, 2, 1, 2)
GO
INSERT [dbo].[GrupoEstudiante] ([Id], [MateriaId], [DocenteId], [EstudianteId]) VALUES (6, 4, 1, 2)
GO
INSERT [dbo].[GrupoEstudiante] ([Id], [MateriaId], [DocenteId], [EstudianteId]) VALUES (7, 1, 1, 2)
GO
INSERT [dbo].[GrupoEstudiante] ([Id], [MateriaId], [DocenteId], [EstudianteId]) VALUES (8, 3, 3, 2)
GO
SET IDENTITY_INSERT [dbo].[GrupoEstudiante] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'00000000000000_CreateIdentitySchema', N'8.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250714223844_Inicial', N'8.0.13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250715054642_Tablas', N'8.0.13')
GO
