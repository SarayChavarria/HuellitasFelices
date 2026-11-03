
using System.ComponentModel.DataAnnotations;

namespace HuellitasFelices.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La categoría es obligatoria")]
        public string Categoria { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        [Range(0.01, 100000000,
            ErrorMessage = "El precio debe ser mayor a cero")]
        public decimal Precio { get; set; }

        public string Imagen { get; set; } = string.Empty;

        [Range(0, 10000)]
        public int Stock { get; set; }
    }
}
