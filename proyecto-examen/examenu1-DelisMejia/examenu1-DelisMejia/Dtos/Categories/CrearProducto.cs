using System.ComponentModel.DataAnnotations;

namespace examenu1_DelisMejia.Dtos.Categories
{
    public class CrearProducto
    {
        public Guid Id { get; set; }

        [Display(Name = "nombre")]
        [Required(ErrorMessage = "El {0} de la categoria es Requerido.")]

        public string Name { get; set; }

        public int Cantidad { get; set; }

        public int Precio { get; set; }
    }
}
