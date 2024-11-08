using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Validar_Email.Models;


namespace Validar_Email.Controllers
{
    public class CredencialesController : Controller
    {
        // Guardaremos Todos Los Registros:
        private static List<Credenciales> Lista_Credenciales;

        // Constructor:
        public CredencialesController()
        {
            Lista_Credenciales = new List<Credenciales>();
        }


        // Mostraremos las Opciones a Realizar
        public IActionResult Pagina_Inicio()
        {
            return View();
        }

        // GUARDAMOS SI ES VALIDO:
        public IActionResult Registrar(Credenciales credenciales)
        {
            bool Valido = Validar_Email(credenciales.Email);

            if(Valido)
            {
                Lista_Credenciales.Add(credenciales);

                return RedirectToAction("Pagina_Inicio", "Credenciales");
            }
            else
            {
                TempData["Email_Invalido"] = "No es un Email con domino valido";
                return View(credenciales);
            }
        }


        // VERIDICAMOS QUE SEA UN EMAIL CON DOMINIO VALIDO:
        private bool Validar_Email(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                throw new Exception();
            }

            // Patron:
            Regex regex = new Regex(@"^[\w0-9._%+-]+@[\w0-9.-]+\.[\w]{2,6}$");

            if (regex.IsMatch(Email))
            {
                // Dominios de Email:
                List<string> Dominios = new List<string>()
                {
                "@gmail.com",
                "@outlook.com",
                "@yahoo.com",
                "@icloud.com"
                };

                return Dominios.Any(x => Email.Contains(x)) ? true : false;
            }
            else
            {
                return false;
            }

        }


    }
}
