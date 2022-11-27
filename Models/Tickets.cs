using System.ComponentModel.DataAnnotations;

namespace PF2022_03_BlazorApp.Models
{
    public class Tickets
    {
        [Key]
        public int TicketId { get; set; }

        [Required(ErrorMessage = "La Fecha es requerida")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Debe ingresar el id de un cliente ")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Debe ingresar el id de un Sistema  ")]
        public int SistemaId { get; set; }

        [Required(ErrorMessage = "Debe ingresar un tipo ")]
        public int TipoId { get; set; }

        [Required(ErrorMessage = "Debe ingresar la prioridad")]
        public int PrioridadId { get; set; }

        [Required(ErrorMessage = "El Asunto es requerido ")]
        public string Asunto { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El Id del Tecnico es requirido")]
        public int TecnicoId { get; set; }

        public string Estado { get; set; }
    }
}