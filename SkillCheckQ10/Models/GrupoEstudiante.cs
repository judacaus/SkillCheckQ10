using SkillCheckQ10.Models;
using System.ComponentModel.DataAnnotations;

namespace SkillCheckQ10.Models
{
    public class GrupoEstudiante
    {
        [Key]
        [Display(Name = "Codigo Grupo")]
        public required int Id { get; set; }

        [Required]
        [Display(Name = "Materia")]
        public int MateriaId { get; set; }
        public Materia? Materia { get; set; }

        [Required]
        [Display(Name = "Docente")]
        public int DocenteId { get; set; }
        public Docente? Docente { get; set; }

        [Required]
        [Display(Name = "Estudiante")]
        public int EstudianteId { get; set; }
        public Estudiante? Estudiante { get; set; }
    }

}
