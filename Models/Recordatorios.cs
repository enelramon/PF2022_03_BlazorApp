using System.ComponentModel.DataAnnotations;

namespace PF2022_03_BlazorApp.Models
{
    public class Recordatorios
    {
        [Key]
        public int RecordatorioId { get; set; }
        public String? Descripcion { get; set; }
        public int Dia { get; set; } 
        public DateTime FroximaFecha { get; set; }
    }
}
