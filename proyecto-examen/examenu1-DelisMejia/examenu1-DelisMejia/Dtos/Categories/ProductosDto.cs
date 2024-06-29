namespace examenu1_DelisMejia.Dtos.Categories
{
    public class ProductosDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Cantidad { get; set; }

        public int Precio { get; set; }

        internal static object FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
