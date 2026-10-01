namespace Object_OrientedOOP.Part1_ProceduralToOOP.src
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; }
        public decimal Price { get; }
        public int Stock { get; private set; }

        public Product(int id, string name, decimal price, int stock)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be greater than 0");
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            if (price < 0)
            {
                throw new ArgumentException("Price cannot be negative");
            }

            if (stock < 0)
            {
                throw new ArgumentException("Stock cannot be negative");
            }
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }

        public void ReduceStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.");

            if (quantity > Stock)
                throw new ArgumentException("Not enough stock.");

            Stock -= quantity;
        }
    }
}