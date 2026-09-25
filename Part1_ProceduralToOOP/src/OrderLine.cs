namespace Object_OrientedOOP.Part1_ProceduralToOOP.src
{
    public class OrderLine
    {
        public Product Product { get; }
        public int Quantity { get; }

        public OrderLine(Product product, int quantity)
        {
            if (product == null)
                throw new ArgumentException("Product cannot be null");

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive");

            Product = product;
            Quantity = quantity;
        }
    }
}