using System;
using Microsoft.AspNetCore.Mvc;
using Validar_Email.Controllers;
using Validar_Email.Models;


namespace xUnit.Test
{
    public class Validar_Email
    {

        // TEST #1: CREDENCIALES CORRECTAS:
        [Fact]
        public void Email_Valido()
        {
            // Arange:
            CredencialesController Controlador = new CredencialesController();
            Credenciales credenciales = new Credenciales()
            {
                Email = "Nestor@icloud.com",
                Password="123456"
            };


            // Act:
            RedirectToActionResult? result = Controlador.Registrar(credenciales) as RedirectToActionResult;


            // Assert:
            Assert.Equal("Pagina_Inicio", result.ActionName);
            Assert.Equal("Credenciales", result.ControllerName);
        }


        // TEST #2: CREDENCIALES INCORRECTAS:
        [Fact]
        public void Email_NoValido()
        {
            // Arange:
            CredencialesController Controlador = new CredencialesController();
            Credenciales credenciales = new Credenciales()
            {
                Email = "Nestor@Email.com",
                Password = "123456"
            };


            // Act:
            var result = Controlador.Registrar(credenciales) as ViewResult;

            // Assert:
            Assert.Equal("Registrar", result.ViewName); 
           
        }


        // TEST #3: CREDENCIALES VASIAS:
        [Fact]
        public void Email_Vasio()
        {
            // Arange:
            CredencialesController Controlador = new CredencialesController();
            Credenciales credenciales = new Credenciales()
            {
                Email = "",
                Password = ""
            };


            // Act:
            Assert.Throws<Exception>(() => Controlador.Registrar(credenciales));
        }

    }
}
