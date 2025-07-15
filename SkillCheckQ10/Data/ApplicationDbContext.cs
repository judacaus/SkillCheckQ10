using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkillCheckQ10.Models;
using SkillCheckQ10.Models;

namespace SkillCheckQ10.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<SkillCheckQ10.Models.Estudiante> Estudiante { get; set; } = default!;

    public DbSet<SkillCheckQ10.Models.Materia> Materia { get; set; } = default!;

    public DbSet<SkillCheckQ10.Models.Docente> Docente { get; set; } = default!;

    public DbSet<SkillCheckQ10.Models.GrupoEstudiante> GrupoEstudiante { get; set; } = default!;
}
