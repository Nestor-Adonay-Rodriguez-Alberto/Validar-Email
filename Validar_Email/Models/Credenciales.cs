using System;
using System.ComponentModel.DataAnnotations;


namespace Validar_Email.Models
{
    public class Credenciales
    {
        // ATRIBUTOS:
        [Required(ErrorMessage ="Ingrese un Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Lo Ingresado No Es Un Email.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Ingrese Una Contraseña Segura.")]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "La Contraseña Debe Tener Entre 5 y 10 Caracteres.")]
        public string Password { get; set; }

    }
}
