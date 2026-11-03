
using Microsoft.AspNetCore.Mvc;
using HuellitasFelices.Models;

namespace HuellitasFelices.Controllers
{
    public class CitasController : Controller
    {
        // Lista temporal para almacenar las citas
        private static List<Cita> citas = new List<Cita>();

        // GET: Citas
        // Muestra las citas registradas
        public IActionResult Index()
        {
            return View(citas);
        }

        // GET: Citas/Registrar
        // Muestra el formulario
        [HttpGet]
        public IActionResult Registrar()
        {
            var cita = new Cita
            {
                Fecha = DateTime.Today
            };

            return View(cita);
        }

        // POST: Citas/Registrar
        // Recibe y procesa los datos del formulario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registrar(Cita cita)
        {
            if (cita.Fecha.Date < DateTime.Today)
            {
                ModelState.AddModelError(
                    "Fecha",
                    "La fecha no puede ser anterior a hoy."
                );
            }

            if (ModelState.IsValid)
            {
                cita.Id = citas.Count + 1;

                citas.Add(cita);

                return View("Confirmacion", cita);
            }

            return View(cita);
        }
    }
}
