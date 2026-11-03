
using Microsoft.AspNetCore.Mvc;
using HuellitasFelices.Models;
using System.Linq;

namespace HuellitasFelices.Controllers
{
    public class ProductosController : Controller
    {
        // Lista de productos de nuestra tienda
        private static List<Producto> productos = new List<Producto>
        {
            new Producto
            {
                Id = 1,
                Nombre = "Concentrado para perros",
                Categoria = "Alimentos",
                Descripcion = "Alimento nutritivo para perros adultos.",
                Precio = 85000,
                Imagen = "🐶",
                Stock = 20
            },

            new Producto
            {
                Id = 2,
                Nombre = "Concentrado para gatos",
                Categoria = "Alimentos",
                Descripcion = "Alimento balanceado para gatos.",
                Precio = 65000,
                Imagen = "🐱",
                Stock = 15
            },

            new Producto
            {
                Id = 3,
                Nombre = "Collar para mascotas",
                Categoria = "Accesorios",
                Descripcion = "Collar cómodo y resistente.",
                Precio = 25000,
                Imagen = "🦴",
                Stock = 12
            },

            new Producto
            {
                Id = 4,
                Nombre = "Juguete mordedor",
                Categoria = "Juguetes",
                Descripcion = "Ideal para jugar y entretener a tu mascota.",
                Precio = 18000,
                Imagen = "🎾",
                Stock = 10
            },

            new Producto
            {
                Id = 5,
                Nombre = "Cama para mascotas",
                Categoria = "Accesorios",
                Descripcion = "Cama suave para el descanso de tu compañero.",
                Precio = 95000,
                Imagen = "🛏️",
                Stock = 8
            },

            new Producto
            {
                Id = 6,
                Nombre = "Arena para gatos",
                Categoria = "Higiene",
                Descripcion = "Arena absorbente para el cuidado de tu gato.",
                Precio = 30000,
                Imagen = "🐾",
                Stock = 25
            }
        };

        // GET: Productos
        // Muestra el catálogo de productos
        public IActionResult Index(string? categoria)
        {
            var productosFiltrados = productos;

            if (!string.IsNullOrEmpty(categoria))
            {
                productosFiltrados = productos
                    .Where(p => p.Categoria == categoria)
                    .ToList();
            }

            return View(productosFiltrados);
        }
    }
}
