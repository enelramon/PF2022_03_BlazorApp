using System.ComponentModel.DataAnnotations;

namespace PF2022_03_BlazorApp.Models
{
    public class Prioridades
    {
        [Key]
        public int PrioridadId { get; set; }

        public string ?Descripcion { get; set; }

        public string ?Orden { get; set; }
    }
}
