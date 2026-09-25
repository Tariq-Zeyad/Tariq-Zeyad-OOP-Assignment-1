using System;

namespace Object_OrientedOOP.Part1_ProceduralToOOP.src
{
    public class OrderSystem
    {
        private const int MaxCustomers = 50;
        private const int MaxProducts = 50;
        private const int MaxOrders = 100;

        private Customer[] _customers = new Customer[MaxCustomers];
        private Product[] _products = new Product[MaxProducts];
        private Order[] _orders = new Order[MaxOrders];

        private int _customerCount;
        private int _productCount;
        private int _orderCount;

        public void AddCustomer(Customer customer)
        {
            if (_customerCount >= MaxCustomers)
            {
                throw new InvalidOperationException("Customer list is full.");
            }

            if (FindCustomer(customer.Id) != null)
            {
                throw new ArgumentException("Customer ID already exists.");
            }

            _customers[_customerCount] = customer;
            _customerCount++;
        }

        public Customer FindCustomer(int id)
        {
            for (int i = 0; i < _customerCount; i++)
            {
                if (_customers[i].Id == id)
                {
                    return _customers[i];
                }
            }

            return null;
        }

        public void AddProduct(Product product)
        {
            if (_productCount >= MaxProducts)
            {
                throw new InvalidOperationException("Product list is full.");
            }

            if (FindProduct(product.Id) != null)
            {
                throw new ArgumentException("Product ID already exists.");
            }

            _products[_productCount] = product;
            _productCount++;
        }

        public Product FindProduct(int id)
        {
            for (int i = 0; i < _productCount; i++)
            {
                if (_products[i].Id == id)
                {
                    return _products[i];
                }
            }

            return null;
        }

        public void AddOrder(Order order)
        {
            if (_orderCount >= MaxOrders)
            {
                throw new InvalidOperationException("Order list is full.");
            }

            if (FindOrder(order.Id) != null)
            {
                throw new ArgumentException("Order ID already exists.");
            }

            _orders[_orderCount] = order;
            _orderCount++;
        }

        public Order FindOrder(int id)
        {
            for (int i = 0; i < _orderCount; i++)
            {
                if (_orders[i].Id == id)
                {
                    return _orders[i];
                }
            }

            return null;
        }

        public void CreateOrder(int orderId, int customerId, DateTime date)
        {
            Customer customer = FindCustomer(customerId);

            if (customer == null)
            {
                throw new ArgumentException("Customer not found.");
            }

            if (FindOrder(orderId) != null)
            {
                throw new ArgumentException("Order ID already exists.");
            }

            Order order = new Order(orderId, customer, date);

            AddOrder(order);
        }

        public void AddLineToOrder(int orderId, int productId, int quantity)
        {
            Order order = FindOrder(orderId);

            if (order == null)
            {
                throw new ArgumentException("Order not found.");
            }

            Product product = FindProduct(productId);

            if (product == null)
            {
                throw new ArgumentException("Product not found.");
            }

            OrderLine line = new OrderLine(product, quantity);

            product.ReduceStock(quantity);

            order.AddLine(line);
        }

        public void MarkOrderAsPaid(int orderId)
        {
            Order order = FindOrder(orderId);

            if (order == null)
            {
                throw new ArgumentException("Order not found.");
            }

            order.MarkAsPaid();
        }
        public decimal TotalSalesPaidOnly()
        {
            decimal total = 0;

            for (int i = 0; i < _orderCount; i++)
            {
                if (_orders[i].IsPaid)
                {
                    total += _orders[i].CalculateOrderTotal();
                }
            }

            return total;
        }
        public void PrintCustomers()
        {
            for (int i = 0; i < _customerCount; i++)
            {
                Console.WriteLine(
                    $"Id: {_customers[i].Id}, " +
                    $"Name: {_customers[i].Name}, " +
                    $"Email: {_customers[i].Email}, " +
                    $"City: {_customers[i].City}, " +
                    $"VIP: {_customers[i].IsVip}");
            }
        }
        public void PrintProducts()
        {
            for (int i = 0; i < _productCount; i++)
            {
                Console.WriteLine(
                    $"Id: {_products[i].Id}, " +
                    $"Name: {_products[i].Name}, " +
                    $"Price: {_products[i].Price}, " +
                    $"Stock: {_products[i].Stock}");
            }
        }
        public void PrintAllOrders()
        {
            for (int i = 0; i < _orderCount; i++)
            {
                _orders[i].PrintOrder();
                Console.WriteLine();
            }
        }

    }
}