using System.ComponentModel.DataAnnotations;

namespace PF2022_03_BlazorApp.Models
{
    public class Prioridades
    {
        [Key]
        public int PrioridadId { get; set; }

        [Required(ErrorMessage = "Este campo debe completarse")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage ="Este campo debe completarse")]
        public string? Orden { get; set; }
    }
}

