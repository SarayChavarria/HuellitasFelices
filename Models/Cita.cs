
using System.ComponentModel.DataAnnotations;

namespace HuellitasFelices.Models
{
    public class Cita
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del propietario es obligatorio")]
        public string NombrePropietario { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre de la mascota es obligatorio")]
        public string NombreMascota { get; set; } = string.Empty;

        [Required(ErrorMessage = "Selecciona la especie")]
        public string Especie { get; set; } = string.Empty;

        [Required(ErrorMessage = "Selecciona un servicio")]
        public string Servicio { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [Phone(ErrorMessage = "Ingresa un teléfono válido")]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "Selecciona una fecha")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public string Observaciones { get; set; } = string.Empty;
    }
}
