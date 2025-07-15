using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SkillCheckQ10.Models
{
    public class Persona
    {
        [Key]
        public required int Id { get; set; }

        [Display(Name = "Número Identificación")]
        public required int Numero_Documento { get; set; }

        [Required]
        [Display(Name = "Tipo Documento")]
        public required string Tipo_Documento { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public required string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        public required string Apellido { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime Fecha_Nacimiento { get; set; }

        // Por si a futuro se le va asignar un usuario al docente o estudiante

        //[Required]
        //public required string UsuarioId { get; set; }

        //[Required]
        //public required IdentityUser Usuario { get; set; }
    }
}
