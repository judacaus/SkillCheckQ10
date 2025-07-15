using Microsoft.AspNetCore.Mvc.Rendering;

namespace SkillCheckQ10.Models
{
    public class LOVS
    {
        public static List<SelectListItem> TiposDocumento => new()
        {
            new SelectListItem { Value = "CC", Text = "Cédula de Ciudadanía" },
            new SelectListItem { Value = "TI", Text = "Tarjeta de Identidad" },
            new SelectListItem { Value = "CE", Text = "Cédula de Extranjería" },
        };
    }
}
