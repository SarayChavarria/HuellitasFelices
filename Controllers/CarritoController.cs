
using Microsoft.AspNetCore.Mvc;

namespace HuellitasFelices.Controllers
{
    public class CarritoController : Controller
    {
        // GET: Carrito
        // Muestra la página del carrito de compras
        public IActionResult Index()
        {
            return View();
        }
    }
}
