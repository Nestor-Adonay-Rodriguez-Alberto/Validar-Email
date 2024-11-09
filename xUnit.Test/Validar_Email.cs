using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
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
            RedirectToActionResult? result = Controlador.Registrar_Credencial(credenciales) as RedirectToActionResult;

             
            // Assert:
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Home", result.ControllerName);
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

            // Iniciar TempData:
            var tempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());
            Controlador.TempData = tempData;

            // Act:
            var result = Controlador.Registrar_Credencial(credenciales) as ViewResult;

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
            Assert.Throws<Exception>(() => Controlador.Registrar_Credencial(credenciales));
        }

    }
}
