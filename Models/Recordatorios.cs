using System.ComponentModel.DataAnnotations;

namespace PF2022_03_BlazorApp.Models
{
    public class Recordatorios
    {
        [Key]
        public int RecordatorioId { get; set; }

        [Required(ErrorMessage = "Ingrese la Descripcion")]
        public string? Descripción { get; set; }

        [Range(minimum: 1, maximum: 31, ErrorMessage = "El Dia no esta dentro del rango requerido (entre 1 y 31)")]
        public int Dia { get; set; } 

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime FroximaFecha { get; set; }
        public int ClienteId { get; set; }
        public int TecnicoId { get; set; }
    }
}