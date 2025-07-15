using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SkillCheckQ10.Models
{
    public class Estudiante : Persona
    {
        [Display(Name = "Creditos Disponibles")]
        [DefaultValue(6)]
        public int Creditos { get; set; }
    }
}
