using System.ComponentModel.DataAnnotations;

namespace PF2022_03_BlazorApp.Models
{
    public class Asignaciones
    {
        [Key]
        public int AsignacionId { get; set; }

        [Required(ErrorMessage = "Este campoes requerido")]
        public int TecnicoId { get; set; }

        [Required(ErrorMessage = "Este campoes requerido")]
        public int OrdenId { get; set; }

        [Required(ErrorMessage = "Este campoes requerido")]
        public int TicketId { get; set; }


    }
}
