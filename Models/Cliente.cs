 using System.ComponentModel.DataAnnotations;

namespace PF2022_03_BlazorApp.Models
{
    public class Cliente
    {
        [Key]
        
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]

        public string? Nombres { get; set; }

        public string? Direccion { get; set; }

        public string? Cedula { get; set; }

        public string? Email { get; set; }

        public string? Telefono { get; set; }

        public string? Celular { get; set; }
    }
}
