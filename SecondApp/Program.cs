using System;

class Program
{
    static void Main(string[] args)
    {
        Company courierCompany = new Company("Быстрая доставка", "fastdelivery@email.com", "88005553535");

        PickPoint pickPoint = new PickPoint("PickPoint центр", "Октябрьская, 11");

        Company Shop = new Company("Доставка в магазин", "Ленина, 15", "89137141471");

        Order<HomeDelivery, Company> homeOrder = new Order<HomeDelivery, Company>(
            new HomeDelivery("Калинина 48", courierCompany), 12345, "Домашний заказ");

        homeOrder.AddProduct(new Product("Ноутбук", 1000, 1));
        homeOrder.AddProduct(new Product("Мышка", 500, 1));

        Console.WriteLine("Детали заказа на дом:");
        Console.WriteLine($"Номер заказа: {homeOrder.Number}");
        Console.WriteLine($"Описание: {homeOrder.Description}");
        homeOrder.DisplayAddress();
        Console.WriteLine($"Общая стоимость: {homeOrder.CalculateTotalCost():C2}");

        Order<PickPointDelivery, PickPoint> pickPointOrder = new Order<PickPointDelivery, PickPoint>(
            new PickPointDelivery("Московская, 3", pickPoint), 56789, "PickPoint заказ");

        pickPointOrder.AddProduct(new Product("Клавиатура", 1200, 1));
        pickPointOrder.AddProduct(new Product("Монитор", 2100, 1));

        Console.WriteLine("\nДетали заказа PickPoint:");
        Console.WriteLine($"Номер заказа: {pickPointOrder.Number}");
        Console.WriteLine($"Описание: {pickPointOrder.Description}");
        pickPointOrder.DisplayAddress();
        Console.WriteLine($"Общая стоимость: {pickPointOrder.CalculateTotalCost():C2}");

        Order<ShopDelivery, Company> ShopOrder = new Order<ShopDelivery, Company>(
            new ShopDelivery("Ленина 17", Shop), 75814, "Заказ в магазин");

        ShopOrder.AddProduct(new Product("Блок питания", 3000, 1));
        ShopOrder.AddProduct(new Product("Видеокарта", 10000, 1));

        Console.WriteLine("\nДетали заказа в магазин:");
        Console.WriteLine($"Номер заказа: {ShopOrder.Number}");
        Console.WriteLine($"Описание: {ShopOrder.Description}");
        ShopOrder.DisplayAddress();
        Console.WriteLine($"Общая стоимость: {ShopOrder.CalculateTotalCost():C2}");

        Console.ReadKey();
    }
}
abstract class Delivery
{
    public string Address;

    public Delivery(string address)
    {
        Address = address;
    }
}

class HomeDelivery : Delivery
{
    public Company CourierCompany {  get; set; }

    public HomeDelivery(string Address, Company courierCompany) : base(Address)
    {
        CourierCompany = courierCompany;
    }
}

class PickPointDelivery : Delivery
{
    public PickPoint PickPoint { get; set; }

    public PickPointDelivery(string Address, PickPoint pickPoint) : base(Address)
    {
        PickPoint = pickPoint;
    }
}

class ShopDelivery : Delivery
{
    public Company Shop { get; set; }

    public ShopDelivery(string Address, Company shop) : base(Address)
    {
        Shop = shop;
    }
}

class Order<TDelivery, TStruct> where TDelivery : Delivery
{
    public TDelivery Delivery;

    public int Number;

    public string Description;

    public List<Product> Products { get; set; } = new List<Product>();

    public Order(TDelivery delivery, int number, string description)
    {
        Delivery = delivery;
        Number = number;
        Description = description;
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }
    public decimal CalculateTotalCost()
    {
        decimal totalCost = 0;
        foreach (Product product in Products)
        {
            totalCost += product.Price;
        }
        return totalCost;
    }
    public void DisplayAddress()
    {
        Console.WriteLine($"Адрес доставки: {Delivery.Address}");
    }
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

class PickPoint
{
    public string Name { get; set; }    

    public string Address { get; set; }

    public PickPoint (string name, string address)
    {
        Name = name;
        Address = address;
    }
}

class CourierCompany
{
    public string Name { get; set; }

    public string Address { get; set; }

    public CourierCompany(string name, string address)
    {
        Name = name;
        Address = address;
    }
}




