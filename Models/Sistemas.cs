using System.ComponentModel.DataAnnotations;

namespace PF2022_03_BlazorApp.Models
{
    public class Sistemas
    {
        [Key]
        public int SistemaId {get; set; }
        
        [Required(ErrorMessage = "La Descripción es Obligatoria")]
        public String?  Descripcion {get; set; }
    }
}