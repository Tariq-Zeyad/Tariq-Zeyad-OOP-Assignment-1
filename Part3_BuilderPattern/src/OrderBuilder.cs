using System;

namespace Object_OrientedOOP.Part3_BuilderPattern.src
{
    public class OrderBuilder
    {
        private int? _invoiceId;

        private string _customerName;
        private string _customerEmail;
        private string _customerPhone;

        private Address _billingAddress;
        private Address _shippingAddress;

        private DateTime? _orderDate;
        private string _paymentMethod;
        private string _currency;

        private decimal? _subTotal;
        private decimal _discountAmount;
        private decimal _taxAmount;
        private decimal? _totalAmount;

        public OrderBuilder SetInvoiceId(int invoiceId)
        {
            _invoiceId = invoiceId;
            return this;
        }

        public OrderBuilder SetCustomerName(string customerName)
        {
            _customerName = customerName;
            return this;
        }

        public OrderBuilder SetCustomerEmail(string customerEmail)
        {
            _customerEmail = customerEmail;
            return this;
        }

        public OrderBuilder SetCustomerPhone(string customerPhone)
        {
            _customerPhone = customerPhone;
            return this;
        }

        public OrderBuilder SetBillingAddress(Address billingAddress)
        {
            _billingAddress = billingAddress;
            return this;
        }

        public OrderBuilder SetShippingAddress(Address shippingAddress)
        {
            _shippingAddress = shippingAddress;
            return this;
        }

        public OrderBuilder SetOrderDate(DateTime orderDate)
        {
            _orderDate = orderDate;
            return this;
        }

        public OrderBuilder SetPaymentMethod(string paymentMethod)
        {
            _paymentMethod = paymentMethod;
            return this;
        }

        public OrderBuilder SetCurrency(string currency)
        {
            _currency = currency;
            return this;
        }

        public OrderBuilder SetSubTotal(decimal subTotal)
        {
            _subTotal = subTotal;
            return this;
        }

        public OrderBuilder SetDiscountAmount(decimal discountAmount)
        {
            _discountAmount = discountAmount;
            return this;
        }

        public OrderBuilder SetTaxAmount(decimal taxAmount)
        {
            _taxAmount = taxAmount;
            return this;
        }

        public OrderBuilder SetTotalAmount(decimal totalAmount)
        {
            _totalAmount = totalAmount;
            return this;
        }

        public Invoice Build()
        {
            if (!_invoiceId.HasValue)
                throw new InvalidOperationException("Invoice ID is required.");

            if (string.IsNullOrWhiteSpace(_customerName))
                throw new InvalidOperationException("Customer name is required.");

            if (string.IsNullOrWhiteSpace(_customerEmail))
                throw new InvalidOperationException("Customer email is required.");

            if (!_orderDate.HasValue)
                throw new InvalidOperationException("Order date is required.");

            if (string.IsNullOrWhiteSpace(_paymentMethod))
                throw new InvalidOperationException("Payment method is required.");

            if (string.IsNullOrWhiteSpace(_currency))
                throw new InvalidOperationException("Currency is required.");

            if (!_subTotal.HasValue)
                throw new InvalidOperationException("Subtotal is required.");

            if (!_totalAmount.HasValue)
                throw new InvalidOperationException("Total amount is required.");

            if (_invoiceId <= 0)
                throw new InvalidOperationException("Invoice ID must be greater than zero.");

            if (_subTotal < 0)
                throw new InvalidOperationException("Subtotal cannot be negative.");

            if (_discountAmount < 0)
                throw new InvalidOperationException("Discount amount cannot be negative.");

            if (_taxAmount < 0)
                throw new InvalidOperationException("Tax amount cannot be negative.");

            if (_totalAmount < 0)
                throw new InvalidOperationException("Total amount cannot be negative.");

            return new Invoice(
                _invoiceId.Value,
                _customerName,
                _customerEmail,
                _customerPhone,
                _billingAddress,
                _shippingAddress,
                _orderDate.Value,
                _paymentMethod,
                _currency,
                _subTotal.Value,
                _discountAmount,
                _taxAmount,
                _totalAmount.Value);
        }
    }
}