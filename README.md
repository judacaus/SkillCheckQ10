# SkillCheckQ10

Pruebas de habilidades para aplicaciones desarrolladas en ASP.NET MVC 8.0 Entity Framework Core y SQL Server, con basededatos configurara den **MSSQLLocalDB**

Diseñada como parte de una prueba técnica. 

Permite la gestión de estudiantes, materias y su inscripción (relación a través de la tabla GrupoEstudiante) respetando restricciones de créditos por estudiante.

Ningun modulo en la aplicacion requiere logueo unicamente se dejo funcional lo solicitado para que se registren estudiantes, docentes, materias y la matricula

# Instrucciones 

1. Clonar repositorio

2. Configurar la conexion  de la base de datos en el appsettings.json de la aplicacion

  "ConnectionStrings": {

    "DefaultConnection": "Server=(localdb)\\**MSSQLLocalDB**;Database=**aspnet-SkillCheckQ10-c94811e8-367b-480d-8fd8-24f6c2cfa556**;Trusted_Connection=True;MultipleActiveResultSets=true"

  }

3. Desde el Package Managet Console (PM) ejecutar el comando **Update-Database** para instalar y crear la base de datos
4. Se debe localizar el archivo proyecto SkillCheckQ10.csproj, compilar y ejecutar mediante los comandos
   
     dotnet clean
   
     dotnet build
   
     dotnet run
   
6. Se abre en el navegador la ruta  http://localhost:#### variando el puerto
