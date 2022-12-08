using System.ComponentModel.DataAnnotations;
public class Seguimientos
{
    [Key]
    public int SeguimientoId { get; set; }

    [Required(ErrorMessage = "Favor ingresar la fecha")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Elija un Cliente")]
    public int ClienteId { get; set; }

    [Required(ErrorMessage = "Escriba un mensaje")]
    public string? Mensaje { get; set; }

    [Required(ErrorMessage = "Elija un tecnico")]
    public int TecnicoId { get; set; }

    [Required(ErrorMessage = "Elija una opcion")]
    public string? TipoContacto { get; set; }

    [Required(ErrorMessage = "Elija una opcion")]
    public string? TipoSeguimiento { get; set; }
}