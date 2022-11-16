 using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PF2022_03_BlazorApp.Models
{
    public class Cliente
    {
        [Key]
        
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]

        public string? Nombres { get; set; }

        [Required(ErrorMessage = "La dirección es requerida")]

        public string? Direccion { get; set; }

        [RegularExpression(@"^\d{3}-\d{7}-\d{1}$")]
        [Required(ErrorMessage = "Favor de Ingresar cedula.Ejemplo 042-4277567-7")]
        public string? Cedula { get; set; }

        [Remote(action: "VerifyEmail", controller: "Users")]
        [EmailAddress(ErrorMessage = "digite correctamente el Email.")]

        public string? Email { get; set; }
         
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
        [Phone(ErrorMessage = "Digite correctamente el numero Telefonico. Ejemplo 809-244-9957")]

        public string? Telefono { get; set; }

         [RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
        [Phone(ErrorMessage = "Digite correctamente el numero de su celular. Ejemplo 809-244-9957")]

        public string? Celular { get; set; }
    }
}
