using examenu1_DelisMejia.Dtos.Categories;

namespace examenu1_DelisMejia.Servicios.Interfaz
{
    public interface ICategoriServicio
    {
        Task<List<CrearProducto>> GetCrearProductoList();

        Task<ProductosDto> GetProductos(Guid id);

        Task<bool> CreateAsync(CrearProducto dto);
    }
}
