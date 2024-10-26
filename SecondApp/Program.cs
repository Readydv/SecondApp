abstract class Delivery
{
    public string Address;
}

class HomeDelivery : Delivery
{
    
}

class PickPointDelivery : Delivery
{
    /* ... */
}

class ShopDelivery : Delivery
{
    /* ... */
}

class Order <TDelivery, TStruct> where TDelivery : Delivery
{
    public TDelivery Delivery;

    public int Number;

    public string Description;

    public void DisplayAddress()
    {
        Console.WriteLine(Delivery.Address);
    }

    // ... Другие поля
}

class Product
{
    public string Name { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public Product (string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}

class Company
{
    public string Name { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public Company (string name, string email, string phone)
    {
        Name = name;
        Email = email;
        Phone = phone;
    }
}