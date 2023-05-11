    using System.ComponentModel.DataAnnotations;

namespace TiendaAPi.Entidades
{
    public class Tienda

    {

        public int ID { get; set; }
        [Required]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Fecha de apertura")]
        [RegularExpression(@"\d{2}-\d{2}-\d{4}", ErrorMessage = "El formato de fecha debe ser dd-mm-yyyy")]
        public DateTime FechaApertura { get; set; }


        // Propiedad de navegación para los productos
        public ICollection<Producto> Productos { get; set; }
    }
}
