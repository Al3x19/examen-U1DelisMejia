using examenu1_DelisMejia.Database;
using examenu1_DelisMejia.Dtos.Categories;
using examenu1_DelisMejia.Servicios.Interfaz;
using Microsoft.AspNetCore.Mvc;
namespace examenu1_DelisMejia.Controllers
{
    [ApiController]
    [Route("examen/categorias")]
    public class ExamenController : ControllerBase
    {
        private readonly ICategoriServicio _CategoriaServicio;

        public List<Producto> _Productos { get; set; }

        public ExamenController(ICategoriServicio categoriaServicio) {

            this._CategoriaServicio = categoriaServicio;
        }


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _CategoriaServicio.GetCrearProductoList());
        }
        [HttpPost]
        public async Task<ActionResult> Create(CrearProducto dto)
        {
            await _CategoriaServicio.CreateAsync(dto);

            return StatusCode(201);
        }
    }
}
