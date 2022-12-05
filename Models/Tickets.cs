using System.ComponentModel.DataAnnotations;

namespace PF2022_03_BlazorApp.Models
{
    public class Tickets
    {
        [Key]
        public int TicketId { get; set; }

        [Required(ErrorMessage = "La Fecha es requerida")]
        public DateTime Fecha { get; set; }

        [Range(minimum:1 , maximum:10000000000, ErrorMessage ="Debe ingresar el Id del Cliente")]
        public int ClienteId { get; set; }

        [Range(minimum: 1, maximum: 10000000000, ErrorMessage = "Debe ingresar el Id del Sistema")]
        public int SistemaId { get; set; }

        [Range(minimum: 1, maximum: 10000000000, ErrorMessage = "Debe ingresar el un Tipo")]
        public int TipoId { get; set; }

        [Range(minimum: 1, maximum: 10000000000, ErrorMessage = "Debe ingresar una Prioridad")]
        public int PrioridadId { get; set; }

        [Required(ErrorMessage = "El Asunto es requerido ")]
        public string Asunto { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        public string Descripcion { get; set; }

        [Range(minimum: 0, maximum: 10000000000, ErrorMessage = "Debe ingresar el id de un Técnico")]
        public int TecnicoId { get; set; }

        public string Estado { get; set; }
    }
}