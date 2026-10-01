# Part 3 - Builder Pattern

## Task 3.1 - Understanding the Problem

### 1. Why is a constructor with around 20 parameters a problem?

Having a constructor with around 20 parameters makes the code difficult to read and use correctly.

The main problem is that many parameters may have the same type, such as `string`, `int`, or `decimal`. This makes it easy to accidentally pass values in the wrong order, and the compiler may not detect the mistake.

It also makes the code harder to maintain. For example, if we add another property to the `Invoice` class, we may need to change the constructor and update every place where it is used.

The Builder Pattern solves this problem by allowing us to provide values step by step using meaningful method names.

For example:

```csharp
Invoice invoice = new InvoiceBuilder()
    .SetCustomerName("Ahmad Ali")
    .SetCustomerEmail("ahmad@email.com")
    .SetCurrency("USD")
    .Build();
```

This is much easier to understand than passing many parameters directly to a constructor.

### 2. Is the problem only that the constructor is too long?

No. The problem is not only the length of the constructor. There is also a design problem.

An `Invoice` can contain different types of information, such as:

* Customer information
* Billing address
* Shipping address
* Order information
* Payment information

Putting all of this information into one large object can make the class harder to understand, validate, and maintain.

A better approach is to group related information together.

For example, billing and shipping information can be represented using an `Address` class. An `AddressBuilder` can then be reused to create both billing and shipping addresses.

---

## Task 3.2 - Fluent Builder

The Builder Pattern can be used to create an `Invoice` step by step.

### Mandatory Properties

The following properties are considered mandatory:

* `InvoiceId`
* `CustomerName`
* `CustomerEmail`
* `OrderDate`
* `PaymentMethod`
* `Currency`
* `SubTotal`
* `TotalAmount`

The `InvoiceBuilder` should make sure that all mandatory properties are provided before creating the final `Invoice` object.

### Optional Properties

The following properties are optional:

* `CustomerPhone`
* `DiscountAmount`
* `TaxAmount`
* `BillingAddress`
* `ShippingAddress`

The builder allows the caller to set these properties only when they are needed.

### Example

```csharp
Invoice invoice = new InvoiceBuilder()
    .SetInvoiceId(1)
    .SetCustomerName("Ahmad Ali")
    .SetCustomerEmail("ahmad@email.com")
    .SetOrderDate(DateTime.Now)
    .SetPaymentMethod("Credit Card")
    .SetCurrency("USD")
    .SetSubTotal(100)
    .SetTotalAmount(95)
    .Build();
```

The `Build()` method should validate the required properties before creating the object.

If a required property is missing, the builder should throw a clear exception instead of creating an invalid `Invoice`.

For example:

```csharp
if (string.IsNullOrWhiteSpace(_customerName))
{
    throw new InvalidOperationException("Customer name is required.");
}
```

This makes errors easier to find because the problem is detected when the `Invoice` is being built.

---

## Task 3.3 - Splitting the Builders

Instead of putting all the building logic into one builder, we can split it into separate builders.

### AddressBuilder

The `AddressBuilder` is responsible for creating and validating an `Address`.

The same builder can be reused for both:

* Billing address
* Shipping address

For example:

```csharp
Address billingAddress = new AddressBuilder()
    .SetStreet("Main Street")
    .SetCity("Nablus")
    .SetState("West Bank")
    .SetZipCode("00970")
    .SetCountry("Palestine")
    .Build();

Address shippingAddress = new AddressBuilder()
    .SetStreet("University Street")
    .SetCity("Ramallah")
    .SetState("West Bank")
    .SetZipCode("00970")
    .SetCountry("Palestine")
    .Build();
```

The two addresses are created independently, but the same `AddressBuilder` can be used for both.

### OrderBuilder

The `OrderBuilder` is responsible for creating the final `Invoice` and handling the order and payment information.

It can receive the billing and shipping addresses that were already created by `AddressBuilder`.

For example:

```csharp
Invoice invoice = new OrderBuilder()
    .SetInvoiceId(1)
    .SetCustomerName("Ahmad Ali")
    .SetCustomerEmail("ahmad@email.com")
    .SetBillingAddress(billingAddress)
    .SetShippingAddress(shippingAddress)
    .SetOrderDate(DateTime.Now)
    .SetPaymentMethod("Credit Card")
    .SetCurrency("USD")
    .SetSubTotal(100)
    .SetTotalAmount(95)
    .Build();
```

### Why is the composed version better?

The composed version is better because each builder has a clear responsibility.

* `AddressBuilder` is responsible for creating and validating addresses.
* `OrderBuilder` is responsible for creating the invoice and handling order-related information.
* `AddressBuilder` can be reused for both billing and shipping addresses.
* Validation is separated, which makes it easier to understand and maintain.
* Related properties are grouped together, making the code easier to read.

This approach also follows the **Single Responsibility Principle (SRP)** because each builder has a specific responsibility.

Overall, using separate builders makes the code easier to maintain and gives us more flexibility if the system needs to change in the future.
