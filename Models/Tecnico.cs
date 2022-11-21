using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

public class Tecnicos
{
    [Key]
    public int TecnicoId { get; set; }
    [Required(ErrorMessage = "Favor de Ingresar el nombre.")]
    public string? Nombres { get; set; }
    [Required(ErrorMessage = "Favor de Ingresar la direccion.")]
    public string? Direccion { get; set; }
    [RegularExpression(@"^\d{3}-\d{7}-\d{1}$")]
    [Required(ErrorMessage = "Favor de Ingresar cedula.Ejemplo 123-1234567-8")]
    public string? Cedula { get; set; }
    [Remote(action: "VerifyEmail", controller: "Users")]
    [EmailAddress(ErrorMessage = "Ingrese correctamente el Email.")]
    public string? Email { get; set; }
    [RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
    [Phone(ErrorMessage = "Favor de ingresar correctamente el numero Telefonico.Ejemplo 123-123-1234")]
    public string? Telefono { get; set; }
    [RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
    [Phone(ErrorMessage = "Favor de ingresar correctamente el numero de celular.Ejemplo 123-123-1234")]
    public string? Celular { get; set; }
    [Required(ErrorMessage = "Favor de Ingresar el usuario.")]
    public string? usuario { get; set; }
    [Required(ErrorMessage = "Favor de Ingresar la clave.")]
    public string? Clave { get; set; }
}