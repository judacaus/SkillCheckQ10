using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SkillCheckQ10.Models
{
    public class Materia
    {
        [Key]
        public required int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public required string Nombre { get; set; }


        [Display(Name = "Creditos")]
        public required int Creditos { get; set; }


    }
}
