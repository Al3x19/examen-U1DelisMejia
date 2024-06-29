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
        public async Task<bool> CreateAsyn(CrearProducto dto)
        {
            var categoriesDtos = await ReadCategoriesFromFileAsync();

            var categoryDto = new ProductosDto
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Cantidad = dto.Cantidad,
                Precio = dto.Precio,
            };

            categoriesDtos.Add(categoryDto);

            // Pasar de CategoryDto a Category
            var categories = categoriesDtos.Select(x => new Categoria
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            await WriteCategoriesToFileAsync(categories);
            return true;
        }
        public async Task<bool> EditAsync(ActualizarDto dto, Guid id)
        {
            var categories = await ReadCategoriesFromFileAsync();

            var existingCategory = categories.FirstOrDefault(category => category.Id == id);
            if (existingCategory is null)
            {
                return false;
            }

            for (int i = 0; i < categories.Count; i++)
            {
                if (categories[i].Id == id)
                {
                    categories[i].Name = dto.Name;
                    categories[i].Cantidad = dto.Cantidad;
                    categories[i].Precio = dto.Precio;
                }
            }

            await WriteCategoriesToFileAsync(categories);
            return true;
        }

        private async Task WriteCategoriesToFileAsync(List<ProductosDto> categories)
        {
            throw new NotImplementedException();
        }

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
