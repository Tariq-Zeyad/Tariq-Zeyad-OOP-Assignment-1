using System;

namespace Object_OrientedOOP.Part1_ProceduralToOOP.src 
{
    public class Order
    {
        private const int MaxLinesPerOrder = 20;
        private const int MinimumValidId = 1;

        public int Id { get; }
        public Customer Customer { get; }
        public DateTime Date { get; }
        public bool IsPaid { get; private set; }

        private readonly OrderLine[] _lines;
        private int _lineCount;

        public Order(int id, Customer customer, DateTime date)
        {
            if (id < MinimumValidId)
            {
                throw new ArgumentException(
                    $"Id must be at least {MinimumValidId}");
            }

            if (customer == null)
            {
                throw new ArgumentException("Customer cannot be null");
            }

            Id = id;
            Customer = customer;
            Date = date;
            IsPaid = false;

            _lines = new OrderLine[MaxLinesPerOrder];
            _lineCount = 0;
        }

        public void AddLine(OrderLine line)
        {
            if (IsPaid)
            {
                throw new InvalidOperationException(
                    "Cannot change a paid order");
            }

            if (_lineCount >= MaxLinesPerOrder)
            {
                throw new InvalidOperationException(
                    "Order has too many lines");
            }

            if (line == null)
            {
                throw new ArgumentException(
                    "Order line cannot be null");
            }

            _lines[_lineCount] = line;
            _lineCount++;
        }

        public void MarkAsPaid()
        {
            if (_lineCount == 0)
            {
                throw new InvalidOperationException(
                    "Cannot pay an empty order");
            }

            IsPaid = true;
        }
        public decimal CalculateOrderTotal()
        {
            decimal total = 0;

            for (int i = 0; i < _lineCount; i++)
            {
                total += _lines[i].Product.Price * _lines[i].Quantity;
            }

            if (Customer.IsVip)
            {
                total *= 0.90m;
            }

            return total;
        }
        public void PrintOrder()
        {
            Console.WriteLine($"Order Id: {Id}");
            Console.WriteLine($"Customer: {Customer.Name}");
            Console.WriteLine($"Date: {Date:yyyy-MM-dd}");
            Console.WriteLine($"Paid: {IsPaid}");

            for (int i = 0; i < _lineCount; i++)
            {
                Console.WriteLine(
                    $"{_lines[i].Product.Name} - " +
                    $"Quantity: {_lines[i].Quantity} - " +
                    $"Price: {_lines[i].Product.Price}");
            }

            Console.WriteLine($"Total: {CalculateOrderTotal()}");
        }
    }
}