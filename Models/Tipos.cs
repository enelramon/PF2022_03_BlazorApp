using System.ComponentModel.DataAnnotations;

namespace PF2022_03_BlazorApp.Models
{
    public class Tipos
    {
        [Key]
        public int TipoId { get; set; }
        [Required(ErrorMessage ="La descripcion es obligatoria")]
        public string? Descripcion { get; set; }
    }
}
