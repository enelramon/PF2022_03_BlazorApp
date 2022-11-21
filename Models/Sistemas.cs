using System.ComponentModel.DataAnnotations;

namespace PF2022_03_BlazorApp.Models
{
    public class Sistemas
    {

       [Key]

        public int SistemaID {get; set; }

        [Required(ErrorMessage = "La Descripcion es Obligatoria")]

        public String?  Descripcion {get; set; }


    }
}