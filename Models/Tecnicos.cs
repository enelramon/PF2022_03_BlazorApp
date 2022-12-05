using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

public class Tecnicos
{
    [Key]
    public int TecnicoId { get; set; }
    [Required(ErrorMessage = "Favor de Ingresar el nombre.")]
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,85}$", ErrorMessage = "Caracteres no permitidos solo mayuscula y minuscula.")]
    public string Nombres { get; set; } = null!;
    [Required(ErrorMessage = "Favor de Ingresar la direccion.")]
    public string Direccion { get; set; } = null!;
    [RegularExpression(@"^\d{3}-\d{7}-\d{1}$")]
    [Required(ErrorMessage = "Favor de Ingresar cedula.Ejemplo 123-1234567-8")]
    public string Cedula { get; set; } = null!;
    [Remote(action: "VerifyEmail", controller: "Users")]
    [EmailAddress(ErrorMessage = "Ingrese Email Valido.")]
    [Required(ErrorMessage = "Por Favor Ingrese Email")]
    public string Email { get; set; } = null!;
    [RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
    [Phone(ErrorMessage = "Favor de ingresar correctamente el numero Telefonico.Ejemplo 123-123-1234")]
    [Required(ErrorMessage = "Favor introducir su telefono.")]
    public string Telefono { get; set; } = null!;
    [RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
    [Phone(ErrorMessage = "Favor de ingresar correctamente el numero de celular.Ejemplo 123-123-1234")]
    [Required(ErrorMessage = "Favor introducir su celular.")]
    public string Celular { get; set; } = null!;
    [Required(ErrorMessage = "Favor de Ingresar el usuario.")]
    [RegularExpression(@"^[a-zA-Z123456789''-'\s]{10,40}$", ErrorMessage = "Debe introducir entre 10 y 40 caracteres para su usuario.(Solo mayuscula,minuscula y numeros)")]
    public string usuario { get; set; } = null!;
    [RegularExpression(@"^.{12,}$", ErrorMessage = "La clave debe contar con al menos 12 carácteres")]
    [Required(ErrorMessage = "Favor de introducir una clave")]
    [DataType(DataType.Password)]
    public string Clave { get; set; } = null!;
    [Required(ErrorMessage = "Favor de Ingresar la Fecha")]
    public DateTime Fecha { get; set; } = DateTime.Now;
}

