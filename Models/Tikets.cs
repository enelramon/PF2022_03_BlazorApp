using System.ComponentModel.DataAnnotations;

namespace PF2022_03_BlazorApp.Models
{
    public class Tikets
    {
        [Key]
        public int tiketId { get; set; }

        public String Descripcion { get; set; }
    }
}
