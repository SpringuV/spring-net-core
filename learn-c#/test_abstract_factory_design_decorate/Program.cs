// ============================================
// DESIGN PATTERNS & UNIT TEST - C#
// ============================================
// 1. Abstract Factory Pattern - Tạo họ các đối tượng liên quan
// 2. Decorator Pattern - Thêm chức năng động cho đối tượng
// 3. Singleton Pattern - Đảm bảo chỉ có 1 instance duy nhất
// 4. Observer Pattern - Thông báo thay đổi cho các đối tượng quan sát
// 5. Strategy Pattern - Đóng gói thuật toán và dễ dàng thay đổi
// 6. Factory Method Pattern - Tạo đối tượng thông qua phương thức
// 7. Unit Test - Kiểm thử đơn vị

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("═══════════════════════════════════════════════");
        Console.WriteLine("   DESIGN PATTERNS & UNIT TEST");
        Console.WriteLine("═══════════════════════════════════════════════\n");

        // 1. ABSTRACT FACTORY PATTERN
        AbstractFactoryExample();

        // 2. DECORATOR PATTERN
        DecoratorExample();

        // 3. SINGLETON PATTERN
        SingletonExample();

        // 4. OBSERVER PATTERN
        ObserverExample();

        // 5. STRATEGY PATTERN
        StrategyExample();

        // 6. FACTORY METHOD PATTERN
        FactoryMethodExample();

        // 7. UNIT TEST (Manual testing - normally use xUnit/NUnit)
        UnitTestExample();

        Console.WriteLine("\n═══════════════════════════════════════════════");
        Console.WriteLine("   KẾT THÚC CHƯƠNG TRÌNH");
        Console.WriteLine("═══════════════════════════════════════════════");
        Console.ReadKey();
    }

    // ============================================
    // 1. ABSTRACT FACTORY PATTERN
    // ============================================
    static void AbstractFactoryExample()
    {
        Console.WriteLine("\n━━━ 1. ABSTRACT FACTORY PATTERN ━━━");
        Console.WriteLine("\n📚 KHÁI NIỆM:");
        Console.WriteLine("  - Cung cấp interface để tạo họ các đối tượng liên quan");
        Console.WriteLine("  - Không cần chỉ định class cụ thể");
        Console.WriteLine("  - Đảm bảo các sản phẩm cùng họ tương thích với nhau");
        Console.WriteLine("\n🎯 KHI NÀO DÙNG:");
        Console.WriteLine("  - Hệ thống cần độc lập với cách tạo, kết hợp sản phẩm");
        Console.WriteLine("  - Muốn đảm bảo các sản phẩm cùng họ được dùng cùng nhau");
        Console.WriteLine("  - Có nhiều họ sản phẩm (VD: Windows/Mac UI components)");

        Console.WriteLine("\n📋 VÍ DỤ THỰC TIỄN: HỆ THỐNG ĐẶT ĐỒ ĂN");
        Console.WriteLine("─────────────────────────────────────────────");

        // Tạo đơn hàng Pizza Ý
        IFoodFactory italianFactory = new ItalianFoodFactory();
        Order order1 = new Order(italianFactory);
        order1.CreateMeal();

        Console.WriteLine();

        // Tạo đơn hàng Pizza Mỹ
        IFoodFactory americanFactory = new AmericanFoodFactory();
        Order order2 = new Order(americanFactory);
        order2.CreateMeal();

        Console.WriteLine("\n✅ LỢI ÍCH:");
        Console.WriteLine("  - Dễ dàng thêm factory mới (VD: JapaneseFoodFactory)");
        Console.WriteLine("  - Đảm bảo các món ăn cùng style đi kèm nhau");
        Console.WriteLine("  - Tách biệt code tạo đối tượng khỏi code sử dụng");
    }

    // ============================================
    // 2. DECORATOR PATTERN
    // ============================================
    static void DecoratorExample()
    {
        Console.WriteLine("\n━━━ 2. DECORATOR PATTERN ━━━");
        Console.WriteLine("\n📚 KHÁI NIỆM:");
        Console.WriteLine("  - Thêm chức năng mới cho đối tượng một cách động");
        Console.WriteLine("  - Không thay đổi cấu trúc đối tượng gốc");
        Console.WriteLine("  - Alternative linh hoạt hơn kế thừa");
        Console.WriteLine("\n🎯 KHI NÀO DÙNG:");
        Console.WriteLine("  - Muốn thêm tính năng cho đối tượng tại runtime");
        Console.WriteLine("  - Tránh explosion của subclasses");
        Console.WriteLine("  - Có nhiều kết hợp tính năng có thể (VD: Coffee + Milk + Sugar)");

        Console.WriteLine("\n📋 VÍ DỤ THỰC TIỄN: HỆ THỐNG QUẢN LÝ THÔNG BÁO");
        Console.WriteLine("─────────────────────────────────────────────");

        // Notification cơ bản
        INotifier notifier = new BasicNotifier();
        notifier.Send("Đơn hàng của bạn đã được xác nhận");

        Console.WriteLine("\n• Thêm Email decorator:");
        notifier = new EmailDecorator(notifier);
        notifier.Send("Đơn hàng đã được giao");

        Console.WriteLine("\n• Thêm SMS decorator:");
        notifier = new SmsDecorator(notifier);
        notifier.Send("Đơn hàng đã hoàn thành");

        Console.WriteLine("\n• Thêm Slack decorator:");
        notifier = new SlackDecorator(notifier);
        notifier.Send("Có đơn hàng mới!");

        // Ví dụ 2: Coffee Shop
        Console.WriteLine("\n\n📋 VÍ DỤ 2: COFFEE SHOP");
        Console.WriteLine("─────────────────────────────────────────────");

        // Espresso đơn giản
        ICoffee coffee = new Espresso();
        Console.WriteLine($"{coffee.GetDescription()} - Giá: {coffee.GetCost():N0} VND");

        // Thêm sữa
        coffee = new MilkDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} - Giá: {coffee.GetCost():N0} VND");

        // Thêm đường
        coffee = new SugarDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} - Giá: {coffee.GetCost():N0} VND");

        // Thêm whipped cream
        coffee = new WhipDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} - Giá: {coffee.GetCost():N0} VND");

        Console.WriteLine("\n✅ LỢI ÍCH:");
        Console.WriteLine("  - Thêm/xóa tính năng dễ dàng tại runtime");
        Console.WriteLine("  - Tránh phải tạo vô số subclasses");
        Console.WriteLine("  - Tuân theo Single Responsibility Principle");
        Console.WriteLine("  - Tuân theo Open/Closed Principle");
    }

    // ============================================
    // 3. SINGLETON PATTERN
    // ============================================
    static void SingletonExample()
    {
        Console.WriteLine("\n━━━ 3. SINGLETON PATTERN ━━━");
        Console.WriteLine("\n📚 KHÁI NIỆM:");
        Console.WriteLine("  - Đảm bảo một class chỉ có DUY NHẤT 1 instance");
        Console.WriteLine("  - Cung cấp global access point đến instance đó");
        Console.WriteLine("  - Lazy initialization: Chỉ tạo khi cần dùng");
        Console.WriteLine("\n🎯 KHI NÀO DÙNG:");
        Console.WriteLine("- Quản lý kết nối database (connection pool)");
        Console.WriteLine("  - Configuration/Settings manager");
        Console.WriteLine("  - Logger, Cache manager");
        Console.WriteLine("  - Device managers (Printer, File manager)");

        Console.WriteLine("\n📋 VÍ DỤ THỰC TIỄN: DATABASE CONNECTION");
        Console.WriteLine("─────────────────────────────────────────────");

        // Lấy instance - lần 1
        DatabaseConnection db1 = DatabaseConnection.Instance;
        db1.Connect();
        db1.ExecuteQuery("SELECT * FROM Users");

        Console.WriteLine();

        // Lấy instance - lần 2 (vẫn là cùng 1 object)
        DatabaseConnection db2 = DatabaseConnection.Instance;
        db2.ExecuteQuery("SELECT * FROM Products");

        Console.WriteLine($"\n• db1 == db2? {object.ReferenceEquals(db1, db2)}");
        Console.WriteLine($"• db1 HashCode: {db1.GetHashCode()}");
        Console.WriteLine($"• db2 HashCode: {db2.GetHashCode()}");

        Console.WriteLine("\n📋 VÍ DỤ 2: LOGGER SYSTEM");
        Console.WriteLine("─────────────────────────────────────────────");

        Logger logger1 = Logger.Instance;
        logger1.Log("Application started");
        logger1.Log("User logged in");

        Logger logger2 = Logger.Instance;
        logger2.Log("Order created");

        Console.WriteLine($"\n• logger1 == logger2? {object.ReferenceEquals(logger1, logger2)}");

        Console.WriteLine("\n✅ LỢI ÍCH:");
        Console.WriteLine("  - Tiết kiệm tài nguyên (1 instance thay vì nhiều)");
        Console.WriteLine("  - Đảm bảo tính nhất quán dữ liệu");
        Console.WriteLine("  - Controlled access");
        Console.WriteLine("\n⚠️ LƯU Ý:");
        Console.WriteLine("  - Có thể gây khó khăn cho Unit Testing");
        Console.WriteLine("  - Vi phạm Single Responsibility Principle");
        Console.WriteLine("  - Cần cẩn thận với multi-threading");
    }

    // ============================================
    // 4. OBSERVER PATTERN
    // ============================================
    static void ObserverExample()
    {
        Console.WriteLine("\n━━━ 4. OBSERVER PATTERN ━━━");
        Console.WriteLine("\n📚 KHÁI NIỆM:");
        Console.WriteLine("  - Định nghĩa mối quan hệ 1-nhiều giữa các object");
        Console.WriteLine("  - Khi object thay đổi, tất cả dependents được thông báo");
        Console.WriteLine("  - Còn gọi là Pub-Sub (Publisher-Subscriber) pattern");
        Console.WriteLine("\n🎯 KHI NÀO DÙNG:");
        Console.WriteLine("  - Event handling systems");
        Console.WriteLine("  - Real-time notification systems");
        Console.WriteLine("  - MVC/MVVM architecture (Model thông báo View)");
        Console.WriteLine("  - Stock market, Weather apps");

        Console.WriteLine("\n📋 VÍ DỤ THỰC TIỄN: HỆ THỐNG THEO DÕI CỔ PHIẾU");
        Console.WriteLine("─────────────────────────────────────────────");

        // Tạo stock (Subject)
        Stock appleStock = new Stock("AAPL", 150.00m);

        // Tạo observers
        StockDisplay mobileApp = new StockDisplay("Mobile App");
        StockDisplay webPortal = new StockDisplay("Web Portal");
        StockAlert emailAlert = new StockAlert("Email Alert", 155.00m);

        // Subscribe observers
        appleStock.Attach(mobileApp);
        appleStock.Attach(webPortal);
        appleStock.Attach(emailAlert);

        // Thay đổi giá cổ phiếu
        Console.WriteLine("\n• Cập nhật giá lần 1:");
        appleStock.Price = 152.50m;

        Console.WriteLine("\n• Cập nhật giá lần 2:");
        appleStock.Price = 156.00m;

        Console.WriteLine("\n• Unsubscribe Mobile App:");
        appleStock.Detach(mobileApp);

        Console.WriteLine("\n• Cập nhật giá lần 3:");
        appleStock.Price = 158.75m;

        Console.WriteLine("\n✅ LỢI ÍCH:");
        Console.WriteLine("  - Loose coupling giữa Subject và Observers");
        Console.WriteLine("  - Dễ dàng thêm/xóa observers tại runtime");
        Console.WriteLine("  - Tuân theo Open/Closed Principle");
        Console.WriteLine("  - Hỗ trợ broadcast communication");
    }

    // ============================================
    // 5. STRATEGY PATTERN
    // ============================================
    static void StrategyExample()
    {
        Console.WriteLine("\n━━━ 5. STRATEGY PATTERN ━━━");
        Console.WriteLine("\n📚 KHÁI NIỆM:");
        Console.WriteLine("  - Định nghĩa họ các thuật toán");
        Console.WriteLine("  - Đóng gói từng thuật toán");
        Console.WriteLine("  - Cho phép thay đổi thuật toán tại runtime");
        Console.WriteLine("\n🎯 KHI NÀO DÙNG:");
        Console.WriteLine("  - Có nhiều cách làm cho cùng 1 việc");
        Console.WriteLine("  - Muốn tránh if-else/switch-case phức tạp");
        Console.WriteLine("  - Payment methods, Sorting algorithms, Compression");

        Console.WriteLine("\n📋 VÍ DỤ THỰC TIỄN: HỆ THỐNG THANH TOÁN");
        Console.WriteLine("─────────────────────────────────────────────");

        ShoppingCart cart = new ShoppingCart();

        // Thanh toán bằng Credit Card
        Console.WriteLine("• Khách hàng 1 - Thanh toán Credit Card:");
        cart.SetPaymentStrategy(new CreditCardPayment("1234-5678-9012-3456", "John Doe"));
        cart.Checkout(500000);

        Console.WriteLine("\n• Khách hàng 2 - Thanh toán PayPal:");
        cart.SetPaymentStrategy(new PayPalPayment("john@example.com"));
        cart.Checkout(750000);

        Console.WriteLine("\n• Khách hàng 3 - Thanh toán Cash:");
        cart.SetPaymentStrategy(new CashPayment());
        cart.Checkout(300000);

        Console.WriteLine("\n📋 VÍ DỤ 2: THUẬT TOÁN SẮP XẾP");
        Console.WriteLine("─────────────────────────────────────────────");

        var numbers = new List<int> { 5, 2, 8, 1, 9 };
        DataSorter sorter = new DataSorter();

        Console.WriteLine($"• Dữ liệu gốc: {string.Join(", ", numbers)}");

        sorter.SetSortStrategy(new QuickSort());
        sorter.Sort(numbers);

        sorter.SetSortStrategy(new BubbleSort());
        sorter.Sort(numbers);

        sorter.SetSortStrategy(new MergeSort());
        sorter.Sort(numbers);

        Console.WriteLine("\n✅ LỢI ÍCH:");
        Console.WriteLine("  - Loại bỏ conditional statements phức tạp");
        Console.WriteLine("  - Dễ dàng thêm strategy mới");
        Console.WriteLine("  - Thuật toán có thể thay đổi độc lập với client");
        Console.WriteLine("  - Tuân theo Open/Closed Principle");
    }

    // ============================================
    // 6. FACTORY METHOD PATTERN
    // ============================================
    static void FactoryMethodExample()
    {
        Console.WriteLine("\n━━━ 6. FACTORY METHOD PATTERN ━━━");
        Console.WriteLine("\n📚 KHÁI NIỆM:");
        Console.WriteLine("  - Định nghĩa interface để tạo object");
        Console.WriteLine("  - Subclass quyết định class nào sẽ được tạo");
        Console.WriteLine("  - Khác Abstract Factory: Tạo 1 sản phẩm thay vì họ sản phẩm");
        Console.WriteLine("\n🎯 KHI NÀO DÙNG:");
        Console.WriteLine("  - Class không biết trước loại object cần tạo");
        Console.WriteLine("  - Muốn delegate việc tạo object cho subclass");
        Console.WriteLine("  - Document frameworks, UI component libraries");

        Console.WriteLine("\n📋 VÍ DỤ THỰC TIỄN: HỆ THỐNG TẠO TÀI LIỆU");
        Console.WriteLine("─────────────────────────────────────────────");

        // Tạo PDF document
        DocumentCreator pdfCreator = new PdfDocumentCreator();
        pdfCreator.CreateAndPrintDocument();

        Console.WriteLine();

        // Tạo Word document
        DocumentCreator wordCreator = new WordDocumentCreator();
        wordCreator.CreateAndPrintDocument();

        Console.WriteLine();

        // Tạo Excel document
        DocumentCreator excelCreator = new ExcelDocumentCreator();
        excelCreator.CreateAndPrintDocument();

        Console.WriteLine("\n📋 VÍ DỤ 2: LOGISTICS SYSTEM");
        Console.WriteLine("─────────────────────────────────────────────");

        Logistics roadLogistics = new RoadLogistics();
        roadLogistics.PlanDelivery();

        Console.WriteLine();

        Logistics seaLogistics = new SeaLogistics();
        seaLogistics.PlanDelivery();

        Console.WriteLine();

        Logistics airLogistics = new AirLogistics();
        airLogistics.PlanDelivery();

        Console.WriteLine("\n✅ LỢI ÍCH:");
        Console.WriteLine("  - Tránh tight coupling giữa creator và concrete products");
        Console.WriteLine("  - Single Responsibility Principle");
        Console.WriteLine("  - Open/Closed Principle");
        Console.WriteLine("\n🔄 SO SÁNH VỚI ABSTRACT FACTORY:");
        Console.WriteLine("  Factory Method: Tạo 1 sản phẩm");
        Console.WriteLine("  Abstract Factory: Tạo họ sản phẩm liên quan");
    }

    // ============================================
    // 7. UNIT TEST
    // ============================================
    static void UnitTestExample()
    {
        Console.WriteLine("\n━━━ 3. UNIT TEST ━━━");
        Console.WriteLine("\n📚 KHÁI NIỆM:");
        Console.WriteLine("  - Kiểm thử từng đơn vị code nhỏ nhất (method, class)");
        Console.WriteLine("  - Tự động hóa quá trình testing");
        Console.WriteLine("  - Frameworks phổ biến: xUnit, NUnit, MSTest");
        Console.WriteLine("\n🎯 NGUYÊN TẮC:");
        Console.WriteLine("  - FAST: Nhanh");
        Console.WriteLine("  - INDEPENDENT: Độc lập");
        Console.WriteLine("  - REPEATABLE: Lặp lại được");
        Console.WriteLine("  - SELF-VALIDATING: Tự động đánh giá (pass/fail)");
        Console.WriteLine("  - TIMELY: Viết đúng lúc (TDD)");

        Console.WriteLine("\n📋 MANUAL UNIT TEST DEMO:");
        Console.WriteLine("─────────────────────────────────────────────");

        // Test Calculator
        SimpleUnitTest.TestAdd();
        SimpleUnitTest.TestSubtract();
        SimpleUnitTest.TestMultiply();
        SimpleUnitTest.TestDivide();
        SimpleUnitTest.TestDivideByZero();

        Console.WriteLine("\n📋 TEST PATTERN: ARRANGE-ACT-ASSERT");
        Console.WriteLine("─────────────────────────────────────────────");
        SimpleUnitTest.TestCalculatorWithPattern();

        Console.WriteLine("\n✅ LỢI ÍCH CỦA UNIT TEST:");
        Console.WriteLine("  - Phát hiện bug sớm");
        Console.WriteLine("  - Tự tin refactor code");
        Console.WriteLine("  - Documentation sống (test = specification)");
        Console.WriteLine("  - Giảm thời gian debug");
        Console.WriteLine("  - Tăng chất lượng code");

        Console.WriteLine("\n📝 THỰC TẾ:");
        Console.WriteLine("  Dùng frameworks như xUnit, NUnit để tự động hóa");
        Console.WriteLine("  Tích hợp vào CI/CD pipeline");
        Console.WriteLine("  Code coverage: Đo % code được test");
    }
}

// ═══════════════════════════════════════════════════════════
// ABSTRACT FACTORY PATTERN - FOOD ORDERING SYSTEM
// ═══════════════════════════════════════════════════════════

// === ABSTRACT PRODUCTS ===
// Interface cho Pizza
interface IPizza
{
    void Prepare();
    void Bake();
    void Cut();
}

// Interface cho Pasta
interface IPasta
{
    void Cook();
    void Serve();
}

// Interface cho Dessert
interface IDessert
{
    void Make();
    void Present();
}

// === CONCRETE PRODUCTS - ITALIAN ===
class ItalianPizza : IPizza
{
    public void Prepare() => Console.WriteLine("  🍕 Chuẩn bị Pizza Ý: Bột mỏng, sốt cà chua tươi, phô mai Mozzarella");
    public void Bake() => Console.WriteLine("  🔥 Nướng trong lò củi 400°C");
    public void Cut() => Console.WriteLine("  🔪 Cắt thành 8 miếng");
}

class ItalianPasta : IPasta
{
    public void Cook() => Console.WriteLine("  🍝 Nấu Pasta Ý: Mì Spaghetti al dente với sốt Carbonara");
    public void Serve() => Console.WriteLine("  🍽️ Trang trí với phô mai Parmesan và rau húng quế");
}

class ItalianDessert : IDessert
{
    public void Make() => Console.WriteLine("  🍰 Làm Tiramisu: Bánh ngón tay, cà phê espresso, mascarpone");
    public void Present() => Console.WriteLine("  ✨ Rắc bột cacao lên trên");
}

// === CONCRETE PRODUCTS - AMERICAN ===
class AmericanPizza : IPizza
{
    public void Prepare() => Console.WriteLine("  🍕 Chuẩn bị Pizza Mỹ: Bột dày, sốt BBQ, thịt xông khói");
    public void Bake() => Console.WriteLine("  🔥 Nướng lò điện 180°C");
    public void Cut() => Console.WriteLine("  🔪 Cắt thành 6 miếng lớn");
}

class AmericanPasta : IPasta
{
    public void Cook() => Console.WriteLine("  🍝 Nấu Pasta Mỹ: Mì Macaroni với phô mai Cheddar");
    public void Serve() => Console.WriteLine("  🍽️ Thêm bacon và breadcrumbs");
}

class AmericanDessert : IDessert
{
    public void Make() => Console.WriteLine("  🍰 Làm Cheesecake: Bánh phô mai New York style");
    public void Present() => Console.WriteLine("  ✨ Thêm topping dâu tây");
}

// === ABSTRACT FACTORY ===
interface IFoodFactory
{
    IPizza CreatePizza();
    IPasta CreatePasta();
    IDessert CreateDessert();
}

// === CONCRETE FACTORIES ===
class ItalianFoodFactory : IFoodFactory
{
    public IPizza CreatePizza() => new ItalianPizza();
    public IPasta CreatePasta() => new ItalianPasta();
    public IDessert CreateDessert() => new ItalianDessert();
}

class AmericanFoodFactory : IFoodFactory
{
    public IPizza CreatePizza() => new AmericanPizza();
    public IPasta CreatePasta() => new AmericanPasta();
    public IDessert CreateDessert() => new AmericanDessert();
}

// === CLIENT CODE ===
class Order
{
    private IPizza pizza;
    private IPasta pasta;
    private IDessert dessert;

    public Order(IFoodFactory factory)
    {
        // Factory tạo cả bộ sản phẩm cùng style
        pizza = factory.CreatePizza();
        pasta = factory.CreatePasta();
        dessert = factory.CreateDessert();
    }

    public void CreateMeal()
    {
        Console.WriteLine("PIZZA:");
        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();

        Console.WriteLine("\nPASTA:");
        pasta.Cook();
        pasta.Serve();

        Console.WriteLine("\nDESSERT:");
        dessert.Make();
        dessert.Present();
    }
}

// ═══════════════════════════════════════════════════════════
// DECORATOR PATTERN - NOTIFICATION SYSTEM
// ═══════════════════════════════════════════════════════════

// === COMPONENT INTERFACE ===
interface INotifier
{
    void Send(string message);
}

// === CONCRETE COMPONENT ===
class BasicNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine($"  📱 Basic Notification: {message}");
    }
}

// === BASE DECORATOR ===
abstract class NotifierDecorator : INotifier
{
    protected INotifier wrappedNotifier;

    public NotifierDecorator(INotifier notifier)
    {
        wrappedNotifier = notifier;
    }

    public virtual void Send(string message)
    {
        wrappedNotifier.Send(message);
    }
}

// === CONCRETE DECORATORS ===
class EmailDecorator : NotifierDecorator
{
    public EmailDecorator(INotifier notifier) : base(notifier) { }

    public override void Send(string message)
    {
        base.Send(message);
        SendEmail(message);
    }

    private void SendEmail(string message)
    {
        Console.WriteLine($"  📧 Email: Đã gửi email với nội dung: {message}");
    }
}

class SmsDecorator : NotifierDecorator
{
    public SmsDecorator(INotifier notifier) : base(notifier) { }

    public override void Send(string message)
    {
        base.Send(message);
        SendSms(message);
    }

    private void SendSms(string message)
    {
        Console.WriteLine($"  📱 SMS: Đã gửi tin nhắn: {message}");
    }
}

class SlackDecorator : NotifierDecorator
{
    public SlackDecorator(INotifier notifier) : base(notifier) { }

    public override void Send(string message)
    {
        base.Send(message);
        SendSlack(message);
    }

    private void SendSlack(string message)
    {
        Console.WriteLine($"  💬 Slack: Đã post lên channel: {message}");
    }
}

// ═══════════════════════════════════════════════════════════
// DECORATOR PATTERN - COFFEE SHOP
// ═══════════════════════════════════════════════════════════

// === COMPONENT INTERFACE ===
interface ICoffee
{
    string GetDescription();
    decimal GetCost();
}

// === CONCRETE COMPONENT ===
class Espresso : ICoffee
{
    public string GetDescription() => "Espresso";
    public decimal GetCost() => 30000;
}

class Latte : ICoffee
{
    public string GetDescription() => "Latte";
    public decimal GetCost() => 40000;
}

// === BASE DECORATOR ===
abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee coffee;

    public CoffeeDecorator(ICoffee coffee)
    {
        this.coffee = coffee;
    }

    public virtual string GetDescription() => coffee.GetDescription();
    public virtual decimal GetCost() => coffee.GetCost();
}

// === CONCRETE DECORATORS ===
class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription() => coffee.GetDescription() + " + Sữa";
    public override decimal GetCost() => coffee.GetCost() + 5000;
}

class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription() => coffee.GetDescription() + " + Đường";
    public override decimal GetCost() => coffee.GetCost() + 2000;
}

class WhipDecorator : CoffeeDecorator
{
    public WhipDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription() => coffee.GetDescription() + " + Whipped Cream";
    public override decimal GetCost() => coffee.GetCost() + 8000;
}

// ═══════════════════════════════════════════════════════════
// UNIT TEST - SIMPLE MANUAL TESTING
// ═══════════════════════════════════════════════════════════

// === CLASS CẦN TEST ===
class Calculator
{
    public int Add(int a, int b) => a + b;
    public int Subtract(int a, int b) => a - b;
    public int Multiply(int a, int b) => a * b;
    public int Divide(int a, int b)
    {
        if (b == 0)
            throw new DivideByZeroException("Không thể chia cho 0");
        return a / b;
    }
}

// === SIMPLE UNIT TEST CLASS ===
static class SimpleUnitTest
{
    private static int passedTests = 0;
    private static int failedTests = 0;

    // Test method Add
    public static void TestAdd()
    {
        // Arrange - Chuẩn bị
        Calculator calc = new Calculator();
        int expected = 8;

        // Act - Thực hiện
        int actual = calc.Add(5, 3);

        // Assert - Kiểm tra
        AssertEqual(expected, actual, "TestAdd");
    }

    public static void TestSubtract()
    {
        Calculator calc = new Calculator();
        int expected = 2;
        int actual = calc.Subtract(5, 3);
        AssertEqual(expected, actual, "TestSubtract");
    }

    public static void TestMultiply()
    {
        Calculator calc = new Calculator();
        int expected = 15;
        int actual = calc.Multiply(5, 3);
        AssertEqual(expected, actual, "TestMultiply");
    }

    public static void TestDivide()
    {
        Calculator calc = new Calculator();
        int expected = 2;
        int actual = calc.Divide(6, 3);
        AssertEqual(expected, actual, "TestDivide");
    }

    public static void TestDivideByZero()
    {
        Calculator calc = new Calculator();
        bool exceptionThrown = false;

        try
        {
            calc.Divide(5, 0);
        }
        catch (DivideByZeroException)
        {
            exceptionThrown = true;
        }

        if (exceptionThrown)
        {
            Console.WriteLine($"  ✅ TestDivideByZero: PASSED");
            passedTests++;
        }
        else
        {
            Console.WriteLine($"  ❌ TestDivideByZero: FAILED - Expected exception");
            failedTests++;
        }
    }

    // Test với pattern AAA (Arrange-Act-Assert) rõ ràng
    public static void TestCalculatorWithPattern()
    {
        Console.WriteLine("\n• Test: Add Two Positive Numbers");

        // ARRANGE - Chuẩn bị dữ liệu test
        Console.WriteLine("  [Arrange] Tạo Calculator và dữ liệu test");
        Calculator calculator = new Calculator();
        int number1 = 10;
        int number2 = 20;
        int expectedSum = 30;

        // ACT - Thực hiện hành động cần test
        Console.WriteLine($"  [Act] Gọi Add({number1}, {number2})");
        int actualSum = calculator.Add(number1, number2);

        // ASSERT - Kiểm tra kết quả
        Console.WriteLine($"[Assert] Expected: {expectedSum}, Actual: {actualSum}");
        if (expectedSum == actualSum)
        {
            Console.WriteLine("  ✅ TEST PASSED");
            passedTests++;
        }
        else
        {
            Console.WriteLine("  ❌ TEST FAILED");
            failedTests++;
        }

        // Summary
        Console.WriteLine($"\n📊 TEST SUMMARY: {passedTests} passed, {failedTests} failed");
    }

    // Helper method
    private static void AssertEqual(int expected, int actual, string testName)
    {
        if (expected == actual)
        {
            Console.WriteLine($"  ✅ {testName}: PASSED (Expected: {expected}, Actual: {actual})");
            passedTests++;
        }
        else
        {
            Console.WriteLine($"  ❌ {testName}: FAILED (Expected: {expected}, Actual: {actual})");
            failedTests++;
        }
    }
}

// ═══════════════════════════════════════════════════════════
// BONUS: REAL WORLD UNIT TEST EXAMPLE (USING xUnit SYNTAX)
// ═══════════════════════════════════════════════════════════

/* 
// Để dùng xUnit, cài package: dotnet add package xUnit

using Xunit;

public class CalculatorTests
{
    [Fact] // Đánh dấu đây là test method
    public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
    {
        // Arrange
      var calculator = new Calculator();
   
        // Act
        var result = calculator.Add(5, 3);
        
        // Assert
        Assert.Equal(8, result);
    }
    
    [Theory] // Test với nhiều bộ dữ liệu
    [InlineData(5, 3, 8)]
    [InlineData(10, 20, 30)]
    [InlineData(-5, 5, 0)]
    public void Add_VariousInputs_ReturnsCorrectSum(int a, int b, int expected)
    {
        // Arrange
     var calculator = new Calculator();
        
  // Act
        var result = calculator.Add(a, b);
        
 // Assert
Assert.Equal(expected, result);
    }
    
    [Fact]
    public void Divide_ByZero_ThrowsException()
    {
        // Arrange
        var calculator = new Calculator();
     
        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => calculator.Divide(5, 0));
    }
}
*/

// ═══════════════════════════════════════════════════════════
// SINGLETON PATTERN - DATABASE CONNECTION
// ═══════════════════════════════════════════════════════════

// === THREAD-SAFE SINGLETON ===
class DatabaseConnection
{
    // Static instance (lazy initialization)
    private static DatabaseConnection _instance;
    private static readonly object _lock = new object();

    private string connectionString;
    private int connectionCount = 0;

    // Private constructor - ngăn tạo instance từ bên ngoài
    private DatabaseConnection()
    {
        connectionString = "Server=localhost;Database=MyDB;";
        Console.WriteLine("  🔧 [Constructor] DatabaseConnection instance được tạo");
    }

    // Public static method để lấy instance
    public static DatabaseConnection Instance
    {
        get
        {
            // Double-check locking cho thread-safe
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DatabaseConnection();
                    }
                }
            }
            return _instance;
        }
    }

    public void Connect()
    {
        connectionCount++;
        Console.WriteLine($"  ✅ Kết nối database thành công (Connection #{connectionCount})");
        Console.WriteLine($"     Connection String: {connectionString}");
    }

    public void ExecuteQuery(string query)
    {
        Console.WriteLine($"  📊 Thực thi query: {query}");
    }
}

// === LOGGER SINGLETON ===
class Logger
{
    private static Logger _instance;
    private static readonly object _lock = new object();
    private List<string> logs = new List<string>();

    private Logger()
    {
        Console.WriteLine("  📝 [Constructor] Logger instance được tạo");
    }

    public static Logger Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                }
            }
            return _instance;
        }
    }

    public void Log(string message)
    {
        string logEntry = $"[{DateTime.Now:HH:mm:ss}] {message}";
        logs.Add(logEntry);
        Console.WriteLine($"  📝 LOG: {logEntry}");
    }

    public void ShowAllLogs()
    {
        Console.WriteLine("\n  === ALL LOGS ===");
        foreach (var log in logs)
        {
            Console.WriteLine($"  {log}");
        }
    }
}

// ═══════════════════════════════════════════════════════════
// OBSERVER PATTERN - STOCK MONITORING SYSTEM
// ═══════════════════════════════════════════════════════════

// === OBSERVER INTERFACE ===
interface IObserver
{
    void Update(string stockSymbol, decimal price);
}

// === SUBJECT INTERFACE ===
interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

// === CONCRETE SUBJECT ===
class Stock : ISubject
{
    private List<IObserver> observers = new List<IObserver>();
    private string symbol;
    private decimal price;

    public Stock(string symbol, decimal initialPrice)
    {
        this.symbol = symbol;
        this.price = initialPrice;
        Console.WriteLine($"  📈 Stock {symbol} khởi tạo với giá: {initialPrice:C}");
    }

    public decimal Price
    {
        get => price;
        set
        {
            if (price != value)
            {
                price = value;
                Console.WriteLine($"  💰 {symbol} price changed to: {price:C}");
                Notify();
            }
        }
    }

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
        Console.WriteLine($"  ➕ Observer attached to {symbol}");
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
        Console.WriteLine($"  ➖ Observer detached from {symbol}");
    }

    public void Notify()
    {
        foreach (var observer in observers)
        {
            observer.Update(symbol, price);
        }
    }
}

// === CONCRETE OBSERVERS ===
class StockDisplay : IObserver
{
    private string name;

    public StockDisplay(string name)
    {
        this.name = name;
    }

    public void Update(string stockSymbol, decimal price)
    {
        Console.WriteLine($"     📱 [{name}] Hiển thị: {stockSymbol} = {price:C}");
    }
}

class StockAlert : IObserver
{
    private string name;
    private decimal alertThreshold;

    public StockAlert(string name, decimal threshold)
    {
        this.name = name;
        this.alertThreshold = threshold;
    }

    public void Update(string stockSymbol, decimal price)
    {
        if (price >= alertThreshold)
        {
            Console.WriteLine($"     🚨 [{name}] CẢNH BÁO: {stockSymbol} vượt ngưỡng {alertThreshold:C}! Giá hiện tại: {price:C}");
        }
    }
}

// ═══════════════════════════════════════════════════════════
// STRATEGY PATTERN - PAYMENT SYSTEM
// ═══════════════════════════════════════════════════════════

// === STRATEGY INTERFACE ===
interface IPaymentStrategy
{
    void Pay(decimal amount);
}

// === CONCRETE STRATEGIES ===
class CreditCardPayment : IPaymentStrategy
{
    private string cardNumber;
    private string cardHolder;

    public CreditCardPayment(string cardNumber, string cardHolder)
    {
        this.cardNumber = cardNumber;
        this.cardHolder = cardHolder;
    }

    public void Pay(decimal amount)
    {
        Console.WriteLine($"  💳 Thanh toán {amount:N0} VND bằng Credit Card");
        Console.WriteLine($"     Thẻ: {cardNumber}");
        Console.WriteLine($"     Chủ thẻ: {cardHolder}");
        Console.WriteLine("     ✅ Giao dịch thành công!");
    }
}

class PayPalPayment : IPaymentStrategy
{
    private string email;

    public PayPalPayment(string email)
    {
        this.email = email;
    }

    public void Pay(decimal amount)
    {
        Console.WriteLine($"  🅿️ Thanh toán {amount:N0} VND qua PayPal");
        Console.WriteLine($"     Email: {email}");
        Console.WriteLine("     ✅ Chuyển khoản thành công!");
    }
}

class CashPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"  💵 Thanh toán {amount:N0} VND bằng tiền mặt");
        Console.WriteLine("     ✅ Đã nhận tiền!");
    }
}

// === CONTEXT ===
class ShoppingCart
{
    private IPaymentStrategy paymentStrategy;

    public void SetPaymentStrategy(IPaymentStrategy strategy)
    {
        this.paymentStrategy = strategy;
    }

    public void Checkout(decimal amount)
    {
        if (paymentStrategy == null)
        {
            Console.WriteLine("  ❌ Vui lòng chọn phương thức thanh toán!");
            return;
        }
        paymentStrategy.Pay(amount);
    }
}

// === STRATEGY PATTERN - SORTING ===
interface ISortStrategy
{
    void Sort(List<int> data);
}

class QuickSort : ISortStrategy
{
    public void Sort(List<int> data)
    {
        Console.WriteLine("  ⚡ Sử dụng Quick Sort - O(n log n) average");
    }
}

class BubbleSort : ISortStrategy
{
    public void Sort(List<int> data)
    {
        Console.WriteLine("  🫧 Sử dụng Bubble Sort - O(n²) worst case");
    }
}

class MergeSort : ISortStrategy
{
    public void Sort(List<int> data)
    {
        Console.WriteLine("  🔀 Sử dụng Merge Sort - O(n log n) guaranteed");
    }
}

class DataSorter
{
    private ISortStrategy sortStrategy;

    public void SetSortStrategy(ISortStrategy strategy)
    {
        this.sortStrategy = strategy;
    }

    public void Sort(List<int> data)
    {
        if (sortStrategy == null)
        {
            Console.WriteLine("  ❌ Chưa chọn thuật toán sắp xếp!");
            return;
        }
        sortStrategy.Sort(data);
    }
}

// ═══════════════════════════════════════════════════════════
// FACTORY METHOD PATTERN - DOCUMENT CREATOR
// ═══════════════════════════════════════════════════════════

// === PRODUCT INTERFACE ===
interface IDocument
{
    void Open();
    void Save();
    void Close();
}

// === CONCRETE PRODUCTS ===
class PdfDocument : IDocument
{
    public void Open() => Console.WriteLine("  📄 Mở PDF document");
    public void Save() => Console.WriteLine("  💾 Lưu file .pdf");
    public void Close() => Console.WriteLine("  ❌ Đóng PDF document");
}

class WordDocument : IDocument
{
    public void Open() => Console.WriteLine("  📝 Mở Word document");
    public void Save() => Console.WriteLine("  💾 Lưu file .docx");
    public void Close() => Console.WriteLine("  ❌ Đóng Word document");
}

class ExcelDocument : IDocument
{
    public void Open() => Console.WriteLine("  📊 Mở Excel document");
    public void Save() => Console.WriteLine("  💾 Lưu file .xlsx");
    public void Close() => Console.WriteLine("  ❌ Đóng Excel document");
}

// === CREATOR ABSTRACT CLASS ===
abstract class DocumentCreator
{
    // Factory Method - Subclass sẽ override
    public abstract IDocument CreateDocument();

    // Template method sử dụng Factory Method
    public void CreateAndPrintDocument()
    {
        IDocument doc = CreateDocument();
        doc.Open();
        doc.Save();
        doc.Close();
    }
}

// === CONCRETE CREATORS ===
class PdfDocumentCreator : DocumentCreator
{
    public override IDocument CreateDocument()
    {
        Console.WriteLine("  🏭 Factory: Tạo PDF Document");
        return new PdfDocument();
    }
}

class WordDocumentCreator : DocumentCreator
{
    public override IDocument CreateDocument()
    {
        Console.WriteLine("  🏭 Factory: Tạo Word Document");
        return new WordDocument();
    }
}

class ExcelDocumentCreator : DocumentCreator
{
    public override IDocument CreateDocument()
    {
        Console.WriteLine("🏭 Factory: Tạo Excel Document");
        return new ExcelDocument();
    }
}

// === FACTORY METHOD - LOGISTICS EXAMPLE ===
interface ITransport
{
    void Deliver();
}

class Truck : ITransport
{
    public void Deliver() => Console.WriteLine("  🚚 Giao hàng bằng xe tải trên đường bộ");
}

class Ship : ITransport
{
    public void Deliver() => Console.WriteLine("  🚢 Giao hàng bằng tàu thủy đường biển");
}

class Airplane : ITransport
{
    public void Deliver() => Console.WriteLine("  ✈️ Giao hàng bằng máy bay đường hàng không");
}

abstract class Logistics
{
    public abstract ITransport CreateTransport();

    public void PlanDelivery()
    {
        ITransport transport = CreateTransport();
        Console.WriteLine("  📦 Lên kế hoạch giao hàng...");
        transport.Deliver();
    }
}

class RoadLogistics : Logistics
{
    public override ITransport CreateTransport()
    {
        Console.WriteLine("  🏭 Logistics: Chọn vận chuyển đường bộ");
        return new Truck();
    }
}

class SeaLogistics : Logistics
{
    public override ITransport CreateTransport()
    {
        Console.WriteLine("  🏭 Logistics: Chọn vận chuyển đường biển");
        return new Ship();
    }
}

class AirLogistics : Logistics
{
    public override ITransport CreateTransport()
    {
        Console.WriteLine("  🏭 Logistics: Chọn vận chuyển đường hàng không");
        return new Airplane();
    }
}

// ...existing Decorator, Unit Test code...
//📦 Các Design Patterns Đã Thêm:
//3.Singleton Pattern 🔐
//•	Ví dụ 1: Database Connection - Đảm bảo chỉ có 1 kết nối duy nhất
//•	Ví dụ 2: Logger System - Ghi log tập trung
//•	Đặc điểm: Thread - safe với double-check locking
//4. Observer Pattern 👀
//•	Ví dụ: Hệ thống theo dõi cổ phiếu
//•	Khi giá cổ phiếu thay đổi → tất cả observers (Mobile App, Web Portal, Email Alert) được thông báo tự động
//•	Minh họa rõ mối quan hệ 1-nhiều
//5. Strategy Pattern 🎯
//•	Ví dụ 1: Hệ thống thanh toán (Credit Card, PayPal, Cash)
//•	Ví dụ 2: Thuật toán sắp xếp (Quick Sort, Bubble Sort, Merge Sort)
//•	Cho phép thay đổi thuật toán linh hoạt tại runtime
//6. Factory Method Pattern 🏭
//•	Ví dụ 1: Tạo tài liệu (PDF, Word, Excel)
//•	Ví dụ 2: Hệ thống logistics (Truck, Ship, Airplane)
//•	Khác Abstract Factory: Tạo 1 sản phẩm thay vì họ sản phẩm
//✨ Điểm Nổi Bật:
//✅ Mỗi pattern có:
//•	📚 Khái niệm rõ ràng
//•	🎯 Khi nào nên dùng
//•	📋 Ví dụ thực tế dễ hiểu
//•	✅ Lợi ích cụ thể
//•	⚠️ Lưu ý (nếu có)
//✅ Code được format đẹp với Unicode icons ✅ Vietnamese comments đầy đủ ✅ Tuân thủ SOLID principles