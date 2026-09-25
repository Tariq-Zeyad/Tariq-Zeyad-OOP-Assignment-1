# Part 1 — Problems in the Original C++ Code

After reading the original C++ code I found several problems in the design that make the system harder to understand debug and modify

## Global Variables

The first problem is the use of global variables

For example

```cpp
int customerCount = 0;
int customerIds[MAX_CUSTOMERS];
string customerNames[MAX_CUSTOMERS];

int productCount = 0;
int productIds[MAX_PRODUCTS];

int orderCount = 0;
int orderIds[MAX_ORDERS];
```

Almost every function can access and modify these variables

This makes debugging harder because if something goes wrong it can be difficult to know which function changed the data

It also means that the data does not have a clear owner

A better approach is to let each object own its own data

## Data Is Stored in Separate Arrays

Another problem is that the data is stored in separate arrays

For example customer information is split between

```cpp
int customerIds[MAX_CUSTOMERS];
string customerNames[MAX_CUSTOMERS];
string customerEmails[MAX_CUSTOMERS];
string customerCities[MAX_CUSTOMERS];
bool customerIsVip[MAX_CUSTOMERS];
```

All of these values belong to one Customer but they are stored separately

This makes the code harder to understand and there is also a risk of the arrays becoming inconsistent because they depend on the same indexes

A Customer class would keep all of this information together

## Heavy Use of Indexes

The code also uses indexes to connect different parts of the system

For example

```cpp
int orderCustomerIndexes[MAX_ORDERS];
```

and

```cpp
int lineProductIndexes[MAX_ORDERS][MAX_LINES_PER_ORDER];
```

The Order does not directly have a Customer and the Order Line does not directly have a Product

Instead the program stores indexes and uses them to find the related data

This makes the relationships between the objects harder to understand and makes the code more difficult to maintain

## Tight Coupling

There is also tight coupling between different parts of the code

For example calculateOrderTotal depends on several global arrays such as lineProductIndexes lineQuantities productPrices orderCustomerIndexes and customerIsVip

If the way one of these parts is stored changes then calculateOrderTotal may also need to change

This makes the code harder to modify and increases the chance of introducing bugs when changing one part of the system

## No Real Encapsulation

There is no real encapsulation in the current design

For example product stock is stored in a global array

```cpp
int productStock[MAX_PRODUCTS];
```

There is no Product object that controls how its stock can be changed

The same thing happens with the order payment status

```cpp
bool orderIsPaid[MAX_ORDERS];
```

The data is separated from the behavior that should control it

In an object oriented design the Product should manage its own stock and the Order should manage its own payment status

## Functions Have Too Many Responsibilities

Some functions are also doing too many things

For example addLineToOrder checks if the order exists checks if the order is already paid checks the maximum number of lines checks if the product exists checks the quantity checks the stock changes the stock and finally adds the order line

This makes the function harder to understand test and modify

Some of these responsibilities should be moved into the related classes

## Business Logic Is Mixed With Console Output

Another problem is that business logic is directly mixed with console output

For example

```cpp
if (quantity <= 0)
{
    cout << "ERROR: quantity must be positive.\n";
    return;
}
```

The function is doing the validation and also deciding how the error should be displayed

This makes the code less reusable because the same business logic would be harder to use in another application such as a Web API or a different user interface

The business logic should be separated from the console

## Fixed Size Arrays

The program also uses fixed size arrays

```cpp
const int MAX_CUSTOMERS = 50;
const int MAX_PRODUCTS = 50;
const int MAX_ORDERS = 100;
const int MAX_LINES_PER_ORDER = 20;
```

This means the system has hard limits

For example if there are already 50 customers no more customers can be added

This makes the system less flexible and makes future changes harder

Using collections in C# would make this easier to manage


## Error Handling Is Mixed With the UI

Error handling is also directly connected to the console

For example

```cpp
if (findOrderIndexById(orderId) == -1)
{
    cout << "ERROR: order id " << orderId << " not found.\n";
    return;
}
```

The function finds the error and immediately prints it

This works for the current console application but it makes the business logic dependent on the console

A better design would separate the business logic from how errors are displayed

## Relationships Between Objects Are Not Clear

The program clearly has different concepts such as Customer Product Order and OrderLine

However these concepts are not represented as classes

For example an Order belongs to a Customer and contains OrderLines

An OrderLine belongs to a Product

In the current code these relationships are hidden inside arrays and indexes

This makes the code harder to understand

Using classes would make these relationships much clearer

## Changes Can Affect Different Parts of the System

There are also side effects that can make debugging harder

For example when adding a line to an order the function also changes the product stock

```cpp
productStock[productIndex] -= quantity;
```

So one operation is changing both the order data and the product data

If something goes wrong with the order it can also affect the stock

With objects the responsibilities and state changes can be controlled more clearly

## Conclusion

The main problems in the original code are global state separate arrays heavy use of indexes tight coupling lack of encapsulation functions with too many responsibilities business logic mixed with console output fixed size arrays using double for money and unclear relationships between the main entities

The goal of the C# refactoring is to solve these problems by creating real classes for Customer Product Order and OrderLine

Each class will own the data that belongs to it and the related behavior will be moved into the appropriate class

This should make the code easier to understand debug test and modify
