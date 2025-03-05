namespace CompanyApp
{
    public class Product
    {
        public string Name = string.Empty;
        public decimal Price;
        public int Stock;
        public bool IsAvailable;

        public Product(string name, decimal price, int stock, bool isAvailable)
        {
            Name = name;
            Price = price;
            Stock = stock;
            IsAvailable = isAvailable;
        }
    }
}
