using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Validar_Email.Models;


namespace Validar_Email.Controllers
{
    public class CredencialesController : Controller
    {
        // Guardaremos Todos Los Registros:
        private static List<Credenciales> Lista_Credenciales = new List<Credenciales>();


        // DIRECCIONA A VISTA:
        public IActionResult Registrar()
        {
            return View();
        }

        // GUARDAMOS SI ES VALIDO:
        [HttpPost]
        public IActionResult Registrar_Credencial(Credenciales credenciales)
        {
            bool Valido = Validar_Email(credenciales.Email);

            if(Valido)
            {
                // Encriptacion:
                credenciales.Password = BCrypt.Net.BCrypt.HashPassword(credenciales.Password);

                Lista_Credenciales.Add(credenciales);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Email_Invalido"] = "Error, Email es Invalido.";
                return View("Registrar", credenciales);
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
            Regex regex = new Regex(@"^[\w0-9._%+-]+@[\w0-9.-]+\.[\w]{3}$");

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


        // MANDA TODOS LOS REGISTROS:
        public IActionResult Credenciales_Registradas()
        {
            return View(Lista_Credenciales);
        }
    }
}
