using examenu1_DelisMejia.Database;
using examenu1_DelisMejia.Dtos.Categories;
using examenu1_DelisMejia.Servicios.Interfaz;
using Newtonsoft.Json;

namespace examenu1_DelisMejia.Servicios
{
    public class CategoriServicios : ICategoriServicio
    {
        public readonly string _JSON_FILE;

        public CategoriServicios()
        {
            _JSON_FILE = "SeedData/productos.json";
        }

        public Task<bool> CreateAsync(CrearProducto dto)
        {
            throw new NotImplementedException();
        }

        public Task<List<CrearProducto>> GetCrearProductoList()
        {
            throw new NotImplementedException();
        }

        public Task<ProductosDto> GetProductos(Guid id)
        {
            throw new NotImplementedException();
        }

        //public async Task<bool> EditAsync(ActualizarDto dto, Guid id)
        //{
        //    var categoriesDto = await ReadCategoriesFromFileAsync();

        //    var existingCategory = ProductosDto.FirstOrDefault(Categoria => Categoria.Id == id);
        //    if (existingCategory is null)
        //    {
        //        return false;
        //    }

        //    for (int i = 0; i < categoriesDto.Count; i++)
        //    {
        //        if (categoriesDto[i].Id == id)
        //        {
        //            categoriesDto[i].Name = dto.Name;
        //            categoriesDto[i].Cantidad = dto.Cantidad;
                    
        //        }
        //    }

        //    var categories = categoriesDto.Select(x => new Category
        //    {
        //        Id = x.Id,
        //        Name = x.Name,
        //        Description = x.Description,
        //    }).ToList();

        //    await WriteCategoriesToFileAsync(categories);
        //    return true;
        //}
        public async Task<bool> DeleteAsync(Guid id)
        {
            var categoriesDto = await ReadCategoriesFromFileAsync();
            var categoryToDelete = categoriesDto.FirstOrDefault(x => x.Id == id);

            if (categoryToDelete is null)
            {
                return false;
            }

            categoriesDto.Remove(categoryToDelete);

            var categories = categoriesDto.Select(x => new Producto
            {
                Id = x.Id,
                Name = x.Name,
                Cantidad = x.Cantidad,
                Precio = x.Precio,
            }).ToList();

            await WriteCategoriesToFileAsync(categories);

            return true;
        }

        private async Task WriteCategoriesToFileAsync(List<Producto> categories)
        {
            throw new NotImplementedException();
        }

        private async Task<List<ProductosDto>> ReadCategoriesFromFileAsync()
        {
            if (!File.Exists(_JSON_FILE))
            {
                return new List<ProductosDto>();
            }

            var json = await File.ReadAllTextAsync(_JSON_FILE);

            var categories = JsonConvert.DeserializeObject<List<Categoria>>(json);

            var dtos = categories.Select(x => new ProductosDto
            {
                Id = x.Id,
                Name = x.Name,
                Cantidad = x.Cantidad,
                Precio = x.Precio,
            }).ToList();

            return dtos;
        }
        private async Task WriteCategoriesToFileAsync(List<Categoria> categories)
        {
            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            if (File.Exists(_JSON_FILE))
            {
                await File.WriteAllTextAsync(_JSON_FILE, json);
            }

        }
    }
}
