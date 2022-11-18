using System.ComponentModel.DataAnnotations;

namespace PF2022_03_BlazorApp.Models
{
    public class Tikets
    {
        [Key]
        public int TiketId { get; set; }

        [Required(ErrorMessage = "La fecha es requerida")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "el id del del cliente es Requerido ")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El id de sistemas es requerido ")]
        public int SistemaId { get; set; }

        [Required(ErrorMessage = "El tipoId es requerido")]
        public int TipoId { get; set; }

        [Required(ErrorMessage = "La Prioridad es requeridad")]
        public int PrioridadId { get; set; }

        [Required(ErrorMessage = "El Asunto es requerido ")]
        public string? Asunto { get; set; }

        [Required(ErrorMessage = "La descripcion es requerida")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El Id del Tecnico es requirido")]
        public int TecnicoId { get; set; }

        public string? Estado { get; set; }
    }
}
