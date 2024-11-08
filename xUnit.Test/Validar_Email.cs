using System;
using Microsoft.AspNetCore.Mvc;
using Validar_Email.Controllers;
using Validar_Email.Models;


namespace xUnit.Test
{
    public class Validar_Email
    {

        [Fact]
        public void Email_Valido()
        {
            // Arange:
            CredencialesController Controlador = new CredencialesController();
            Credenciales credenciales = new Credenciales()
            {
                Email = "Hola@gmail.com",
                Password="1234567"
            };


            // Act:
            var result = Controlador.Registrar(credenciales) as RedirectToActionResult;


            // Assert:
            Assert.Equal("Pagina_Inicio", result.ActionName);
            Assert.Equal("Credenciales", result.ControllerName);
        }
    }
}
