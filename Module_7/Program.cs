class Program
{   // Проверяю код
    static void Main(string[] args)
    {   //пример с доставкой на дом курьером
        //создаю экземпляр класса и заполняю параметры
        var delivery1 = new HomeDelivery("ул. Советская, д. 100", "Иванов Иван Иванович"); //тип достави с адресом и магазином
        var order1 = new Order<HomeDelivery>(delivery1, 123, "Продукты");  //создаю заказ. присваиваю тип доставки, номер и описание товаров

        order1.AddProduct(new Product("Кофе", 1000)); // в список товаров добавляю товар
        order1.AddProduct(new Product("Чай", 500));
        order1.AddProduct(new Product("Рыба", 2000));
        order1.AddProduct(new Product("Мясо", 1200));

        order1.DisplayOrderDetails(); //вывожу на экран данные по заказу

        delivery1.Deliver(); //выводит способ доставки и адрес

        Console.WriteLine();//перенос строки

        //пример с доставкой до пункта выдачи
        ////создаю экземпляр класса и заполняю параметры
        var delivery2 = new PickPointDelivery("мкр 6, д. 14/1", "ТЦ 'Глобус' 1й эт.", "Яндекс-Доставка"); // тип достави с адресом и магазином
        var order2 = new Order<PickPointDelivery>(delivery2, 456, "Товары для дома");  //создаю заказ. присваиваю тип доставки, номер и описание товаров

        order2.AddProduct(new Product("Кошачи", 4500)); // в список товаров добавляю товар
        order2.AddProduct(new Product("Чайник", 2500));

        order2.DisplayOrderDetails(); //вывожу на экран данные по заказу

        delivery2.Deliver(); //выводит способ доставки и адрес

        Console.WriteLine(); //перенос строки

        //пример с доставкой до магазина
        //создаю экземпляр класса и заполняю параметры
        var delivery3 = new ShopDelivery("ул. Ленина, д. 11", "МВидео"); // тип достави с адресом и магазином
        var order3 = new Order<ShopDelivery>(delivery3, 789, "Электронная техника"); //создаю заказ. присваиваю тип доставки, номер и описание товаров

        order3.AddProduct(new Product("Телевизор", 34500)); // в список товаров добавляю товар

        order3.DisplayOrderDetails(); //вывожу на экран данные по заказу

        delivery3.Deliver(); //выводит способ доставки и адрес

    }
}

// Абстрактный класс доставки
abstract class Delivery
{
    public string Address { get; set; }     //публичное свойство

    public Delivery(string address) //конструктор класса
    {
        Address = address;
    }

    public abstract void Deliver(); //абстрактный метод 
}

// Доставка на дом
class HomeDelivery : Delivery //наследований класс
{
    public string CourierName { get; set; }     //публичное свойство

    public HomeDelivery(string address, string courierName) : base(address) //конструктор класса. поле "address" берется из базового класса "Delivery"
    {
        CourierName = courierName; //название/имя курьера
    }

    public override void Deliver() //переопределенный метод
    {
        Console.WriteLine($"Доставка на дом по адресу {Address}. Курьер: {CourierName}.");
    }
}

// Доставка в пункт выдачи
class PickPointDelivery : Delivery //наследований класс
{
    public string PickPointName { get; set; }   //публичное свойство
    public string Company { get; set; }         //публичное свойство

    public PickPointDelivery(string address, string pickPointName, string company) : base(address) //конструктор класса. поле "address" берется из базового класса "Delivery"
    {
        PickPointName = pickPointName; //пункт выдачи
        Company = company;
    }

    public override void Deliver() //переопределенный метод
    {
        Console.WriteLine($"Доставка в пункт выдачи {PickPointName} по адресу {Address}. Компания: {Company}.");
    }
}

// Доставка в магазин
class ShopDelivery : Delivery  //наследований класс
{
    public string ShopName { get; set; }        //публичное свойство

    public ShopDelivery(string address, string shopName) : base(address) //конструктор класса. поле "address" из класса Delivery
    {
        ShopName = shopName;
    }

    public override void Deliver()      //переопределенный метод
    {
        Console.WriteLine($"Доставка в магазин {ShopName} по адресу {Address}.");
    }
}

// Класс товара
class Product
{
    public string Name { get; set; }
    public float Price { get; set; }

    public Product(string name, float price)   //конструктор класса. Принимает название и цену
    {
        Name = name;
        Price = price;
    }
}

// Класс заказа. (ОСНОВНОЙ КЛАСС)
class Order<TDelivery> where TDelivery : Delivery //
{
    public TDelivery Delivery { get; private set; } //свойство с типом доставки
    public List<Product> Products { get; private set; } = new List<Product>(); //свойство со списом товаров (пустой)
    public int Number; //номер заказа
    public string Description { get; set; } //описание товара

    public Order(TDelivery delivery, int number, string description)//конструктор класса
    {
        Delivery = delivery;            //присвоение типа доставки
        Number = number;                //присвоение значения номера заказа
        Description = description;      //присваиваю описание товара
    }

    public void AddProduct(Product product) //метод для добавления товара в сптсок товаров. 
    {
        Products.Add(product); 
    }

    public float CalculateTotalPrice() //метод суммирует стоимость товаров из списка товаров
    {
        float totalPrice = 0;

        foreach (var product in Products)
        {
            totalPrice += product.Price;
        }

        return totalPrice;
    }

    public void DisplayOrderDetails() //вывод данных на экран
    {
        Console.WriteLine($"Номер заказа: {Number}");
        Console.WriteLine($"Описание: {Description}");
        Console.WriteLine($"Адрес доставки: {Delivery.Address}");
        Console.WriteLine("Список товаров:");

        foreach (var product in Products) //перебирает продукты из списка продуктов
        {
            Console.WriteLine($"- {product.Name}: {product.Price}");
        }

        Console.WriteLine($"Итоговая стоимость: {CalculateTotalPrice()}"); 
    }
}
