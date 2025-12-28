// ============================================
// LẬP TRÌNH HƯỚNG ĐỐI TƯỢNG (OOP) - C#
// ============================================
// OOP là phương pháp lập trình tổ chức code thành các đối tượng (objects)
// Mỗi object chứa dữ liệu (properties/fields) và hành vi (methods)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;           // Hỗ trợ Thread
using System.Threading.Tasks;  // Hỗ trợ Async/Await
using System.Reflection;    // Hỗ trợ Reflection (đọc metadata tại runtime)

class Program
{
    static void Main(string[] args)
    {
        // Thiết lập encoding để hiển thị tiếng Việt
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("═══════════════════════════════════════════════");
        Console.WriteLine("   LẬP TRÌNH HƯỚNG ĐỐI TƯỢNG (OOP) - C#");
        Console.WriteLine("═══════════════════════════════════════════════\n");

        // 1. 4 TÍNH CHẤT CƠ BẢN CỦA OOP
        FourPillarsOfOOP();

        // 2. CLASS VÀ OBJECT
        // Class = bản thiết kế (blueprint), Object = thực thể cụ thể
        ClassAndObject();

        // 3. ABSTRACT CLASS
        // Class trừu tượng: không thể tạo instance, chỉ để kế thừa
        AbstractClassExample();

        // 4. INTERFACE
        // Contract định nghĩa hành vi, class phải implement
        InterfaceExample();

        // 5. POLYMORPHISM (ĐA HÌNH)
        // Một hành vi có nhiều hình thái khác nhau
        PolymorphismExample();

        // 6. STATIC
        // Thuộc về class, không thuộc về instance cụ thể
        StaticExample();

        // 7. DEPENDENCY INJECTION
        // Kỹ thuật giảm sự phụ thuộc giữa các class
        DependencyInjectionExample();

        // 8. ATTRIBUTE
        // Metadata gắn vào code (class, method, property...)
        AttributeExample();

        // 9. REFLECTION
        // Đọc và thao tác code tại runtime
        ReflectionExample();

        // 10. THREAD & ASYNC
        // Xử lý đa luồng và bất đồng bộ
        ThreadExample();
        AsyncExample().Wait();

        Console.WriteLine("\n═══════════════════════════════════════════════");
        Console.WriteLine("   KẾT THÚC CHƯƠNG TRÌNH");
        Console.WriteLine("═══════════════════════════════════════════════");
        Console.ReadKey();
    }

    // ============================================
    // 1. 4 TÍNH CHẤT CƠ BẢN CỦA OOP
    // ============================================
    static void FourPillarsOfOOP()
    {
        Console.WriteLine("\n━━━ 1. 4 TÍNH CHẤT CƠ BẢN CỦA OOP ━━━");
        Console.WriteLine("\n📚 4 Trụ cột của OOP:");

        // 1. ENCAPSULATION (Đóng gói)
        // - Ẩn dữ liệu bên trong class, chỉ cho phép truy cập qua public methods
        // - Dùng access modifiers: private, protected, public
        Console.WriteLine("  1. ENCAPSULATION (Đóng gói)");

        // 2. INHERITANCE (Kế thừa)
        // - Class con kế thừa properties và methods từ class cha
        // - Tái sử dụng code, tránh lặp lại
        Console.WriteLine("  2. INHERITANCE (Kế thừa)");

        // 3. POLYMORPHISM (Đa hình)
        // - Cùng một hành vi nhưng có nhiều cách thực hiện khác nhau
        // - Gồm: Overriding (runtime) và Overloading (compile-time)
        Console.WriteLine("  3. POLYMORPHISM (Đa hình)");

        // 4. ABSTRACTION (Trừu tượng)
        // - Ẩn chi tiết phức tạp, chỉ hiển thị những gì cần thiết
        // - Dùng abstract class hoặc interface
        Console.WriteLine("  4. ABSTRACTION (Trừu tượng)");
    }

    // ============================================
    // 2. CLASS VÀ OBJECT
    // ============================================
    static void ClassAndObject()
    {
        Console.WriteLine("\n━━━ 2. CLASS VÀ OBJECT ━━━");

        // Tạo object từ class BankAccount
        // new = tạo instance mới trong memory
        BankAccount account1 = new BankAccount("123456", "Nguyễn Văn A", 1000000);

        // Gọi methods của object
        account1.Deposit(500000);    // Nạp tiền
        account1.Withdraw(200000);   // Rút tiền
        account1.DisplayInfo();      // Hiển thị thông tin

        // Constructor overloading: Nhiều cách khởi tạo khác nhau
        BankAccount account2 = new BankAccount("789012", "Trần Thị B");
        account2.DisplayInfo();
    }

    // ============================================
    // 3. ABSTRACT CLASS
    // ============================================
    static void AbstractClassExample()
    {
        Console.WriteLine("\n━━━ 3. ABSTRACT CLASS ━━━");

        // ABSTRACT CLASS:
        // - Không thể tạo instance trực tiếp (không thể new Shape())
        // - Chứa abstract methods (không có body) và concrete methods (có body)
        // - Dùng để định nghĩa base class cho các class con
        // - Class con BẮT BUỘC phải implement tất cả abstract methods

        // Không thể tạo instance của abstract class
        // Shape shape = new Shape(); // ❌ ERROR! Cannot create instance

        // Tạo instance của class con (Circle kế thừa Shape)
        Shape circle = new Circle(5);
        Console.WriteLine($"Hình tròn - Diện tích: {circle.CalculateArea():F2}");
        circle.Draw();

        // Tạo instance của class con khác (Rectangle kế thừa Shape)
        Shape rectangle = new Rectangle(4, 6);
        Console.WriteLine($"Hình chữ nhật - Diện tích: {rectangle.CalculateArea():F2}");
        rectangle.Draw();

        // Lợi ích: Code chung ở Shape, logic riêng ở Circle/Rectangle
    }

    // ============================================
    // 4. INTERFACE
    // ============================================
    static void InterfaceExample()
    {
        Console.WriteLine("\n━━━ 4. INTERFACE ━━━");

        // INTERFACE:
        // - Định nghĩa "contract" (hợp đồng) mà class phải tuân theo
        // - Chỉ chứa signature (không có implementation, trừ default methods)
        // - Class có thể implement nhiều interfaces (không giống abstract class)
        // - Dùng để tạo loose coupling (giảm phụ thuộc)

        // Interface implementation
        ILogger fileLogger = new FileLogger();
        fileLogger.Log("Ghi log vào file");
        fileLogger.LogError("Lỗi trong file");

        ILogger consoleLogger = new ConsoleLogger();
        consoleLogger.Log("Ghi log ra console");
        consoleLogger.LogError("Lỗi trong console");

        // Multiple interfaces: Một class có thể implement nhiều interfaces
        IEmailService emailService = new EmailService();
        emailService.SendEmail("test@example.com", "Hello!");

        // Cast để sử dụng interface khác
        ((ILogger)emailService).Log("Email đã gửi");

        // Lợi ích: Dễ thay đổi implementation mà không ảnh hưởng code khác
    }

    // ============================================
    // 5. POLYMORPHISM (ĐA HÌNH)
    // ============================================
    static void PolymorphismExample()
    {
        Console.WriteLine("\n━━━ 5. POLYMORPHISM (ĐA HÌNH) ━━━");

        // ĐA HÌNH (POLYMORPHISM):
        // - Một tên gọi, nhiều hành vi khác nhau
        // - 2 loại:
        //   + Runtime Polymorphism (Method Overriding): virtual/override
        //   + Compile-time Polymorphism (Method Overloading): Cùng tên, khác tham số

        // === 1. METHOD OVERRIDING (Runtime Polymorphism) ===
        // Base class reference, nhưng gọi method của derived class
        Animal[] animals = new Animal[]
        {
            new Dog(),    // Dog override MakeSound()
            new Cat(),    // Cat override MakeSound()
            new Bird()    // Bird override MakeSound()
        };

        // Cùng gọi MakeSound() nhưng mỗi con vật kêu khác nhau
        foreach (Animal animal in animals)
        {
            animal.MakeSound();  // Polymorphism: Gọi đúng method của từng class
            animal.Move();
        }

        // === 2. METHOD OVERLOADING (Compile-time Polymorphism) ===
        // Cùng tên method nhưng khác số lượng/kiểu tham số
        Calculator calc = new Calculator();
        Console.WriteLine($"\nCộng 2 số: {calc.Add(5, 3)}");      // Gọi Add(int, int)
        Console.WriteLine($"Cộng 3 số: {calc.Add(5, 3, 2)}");        // Gọi Add(int, int, int)
        Console.WriteLine($"Cộng double: {calc.Add(5.5, 3.2)}");    // Gọi Add(double, double)

        // Compiler tự động chọn method phù hợp dựa vào tham số
    }

    // ============================================
    // CLASS: BANK ACCOUNT (ENCAPSULATION)
    // ============================================
    // Ví dụ về ENCAPSULATION - Đóng gói dữ liệu
    class BankAccount
    {
        // === ENCAPSULATION ===
        // Private fields: Ẩn dữ liệu, không cho truy cập trực tiếp từ bên ngoài
        // Chỉ truy cập qua public properties/methods
        private string accountNumber;  // Chỉ đọc được trong class này
        private string ownerName;
        private decimal balance;       // Không cho thay đổi trực tiếp từ ngoài

        // === STATIC MEMBERS ===
        // Thuộc về class, dùng chung cho tất cả instances
        public static string BankName { get; } = "ABC Bank";  // Read-only static property
        public static int TotalAccounts { get; private set; } = 0;  // Đếm tổng số tài khoản

        // === CONSTRUCTOR ===
        // Hàm khởi tạo, tự động chạy khi tạo object mới
        public BankAccount(string accountNumber, string ownerName, decimal initialBalance = 0)
        {
            this.accountNumber = accountNumber;  // this: tham chiếu đến instance hiện tại
            this.ownerName = ownerName;
            this.balance = initialBalance;
            TotalAccounts++;  // Tăng biến static mỗi khi tạo tài khoản mới
        }

        // === PUBLIC PROPERTIES (Read-only) ===
        // Expression-bodied properties (C# 6.0+)
        // Cho phép đọc nhưng không cho ghi từ bên ngoài
        public string AccountNumber => accountNumber;  // Chỉ get, không set
        public string OwnerName => ownerName;
        public decimal Balance => balance;

        // === PUBLIC METHODS ===
        // Các method public để thao tác với private fields

        // Nạp tiền vào tài khoản
        public void Deposit(decimal amount)
        {
            // Validation logic - Kiểm tra dữ liệu hợp lệ
            if (amount > 0)
            {
                balance += amount;  // Thay đổi private field
                Console.WriteLine($"Nạp {amount:N0} VND. Số dư: {balance:N0} VND");
            }
        }

        // Rút tiền từ tài khoản
        public void Withdraw(decimal amount)
        {
            // Business logic - Logic nghiệp vụ
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Rút {amount:N0} VND. Số dư: {balance:N0} VND");
            }
            else
            {
                Console.WriteLine("Số dư không đủ!");
            }
        }

        // Hiển thị thông tin tài khoản
        public void DisplayInfo()
        {
            Console.WriteLine($"TK: {accountNumber} - Chủ TK: {ownerName} - Số dư: {balance:N0} VND");
        }

        // === STATIC METHOD ===
        // Gọi qua tên class, không cần tạo instance
        // Utility method - Hàm tiện ích
        public static double CalculateInterest(double amount, double rate)
        {
            return amount * rate;
        }

        // LỢI ÍCH CỦA ENCAPSULATION:
        // 1. Bảo vệ dữ liệu - Không cho thay đổi tuỳ tiện
        // 2. Validation - Kiểm tra dữ liệu trước khi ghi
        // 3. Maintainability - Dễ bảo trì, thay đổi implementation
        // 4. Security - Ẩn logic phức tạp bên trong
    }
    // ============================================
    // 6. STATIC
    // ============================================
    static void StaticExample()
    {
        Console.WriteLine("\n━━━ 6. STATIC ━━━");

        // STATIC:
        // - Thuộc về CLASS, không thuộc về INSTANCE
        // - Chỉ có 1 bản copy duy nhất trong memory
        // - Truy cập qua tên class, không cần tạo object
        // - Static members: properties, methods, fields, constructors

        // === STATIC PROPERTY ===
        // Truy cập qua tên class: BankAccount.BankName
        // Tất cả instances dùng chung giá trị này
        Console.WriteLine($"Tên ngân hàng: {BankAccount.BankName}");
        Console.WriteLine($"Số tài khoản: {BankAccount.TotalAccounts}");

        // === STATIC METHOD ===
        // Gọi trực tiếp qua class, không cần tạo object
        double interest = BankAccount.CalculateInterest(1000000, 0.05);
        Console.WriteLine($"Lãi suất: {interest:N0} VND");

        // === STATIC CLASS ===
        // Class chỉ chứa static members, không thể tạo instance
        // VD: Math, Console, String...
        Console.WriteLine($"PI: {MathHelper.PI}");
        Console.WriteLine($"Bình phương 5: {MathHelper.Square(5)}");
        Console.WriteLine($"Lập phương 3: {MathHelper.Cube(3)}");

        // Lợi ích: Tiết kiệm memory, tiện lợi cho utility functions
    }

    // ============================================
    // 7. DEPENDENCY INJECTION
    // ============================================
    static void DependencyInjectionExample()
    {
        Console.WriteLine("\n━━━ 7. DEPENDENCY INJECTION ━━━");

        // DEPENDENCY INJECTION (DI):
        // - Kỹ thuật cung cấp dependencies từ bên ngoài vào class
        // - Mục đích: Loose coupling, dễ test, dễ thay đổi implementation
        // - 3 loại: Constructor, Property, Method Injection

        // === 1. CONSTRUCTOR INJECTION ===
        // Inject dependency qua constructor (khuyên dùng nhất)
        Console.WriteLine("\n• Constructor Injection:");
        INotificationService emailNotification = new EmailNotificationService();
        UserService userService1 = new UserService(emailNotification);
        userService1.RegisterUser("user@example.com");
        // Lợi ích: Dependency rõ ràng, không thể null

        // === 2. PROPERTY INJECTION ===
        // Inject dependency qua public property
        Console.WriteLine("\n• Property Injection:");
        UserService userService2 = new UserService();
        userService2.NotificationService = new SmsNotificationService();  // Set từ bên ngoài
        userService2.RegisterUser("0123456789");
        // Lợi ích: Optional dependency, có thể thay đổi sau

        // === 3. METHOD INJECTION ===
        // Inject dependency qua tham số method
        Console.WriteLine("\n• Method Injection:");
        UserService userService3 = new UserService();
        userService3.RegisterUser("push@example.com", new PushNotificationService());
        // Lợi ích: Dependency thay đổi theo từng lần gọi

        // Tổng kết: DI giúp code dễ test (mock dependencies) và linh hoạt
    }

    // ============================================
    // 8. ATTRIBUTE
    // ============================================
    static void AttributeExample()
    {
        Console.WriteLine("\n━━━ 8. ATTRIBUTE ━━━");

        // ATTRIBUTE:
        // - Metadata gắn vào code elements (class, method, property...)
        // - Đọc bằng Reflection tại runtime
        // - Built-in attributes: [Obsolete], [Serializable], [JsonIgnore]...
        // - Custom attributes: Tự định nghĩa

        // Built-in attributes
        var product = new Product
        {
            Id = 1,
            Name = "Laptop",
            Price = 15000000,
            InternalCode = "SECRET123" // [JsonIgnore] - Sẽ không serialize
        };

        // === OBSOLETE ATTRIBUTE ===
        // Đánh dấu code đã lỗi thời, cảnh báo khi dùng
        Console.WriteLine("\n• Sử dụng Obsolete Attribute:");
        product.OldMethod(); // ⚠️ Cảnh báo compiler

        // === CUSTOM ATTRIBUTE ===
        // Đọc attribute của class bằng Reflection
        Console.WriteLine("\n• Custom Attribute:");
        Type type = typeof(Product);
        var attributes = type.GetCustomAttributes(typeof(TableAttribute), false);
        if (attributes.Length > 0)
        {
            TableAttribute tableAttr = (TableAttribute)attributes[0];
            Console.WriteLine($"Tên bảng: {tableAttr.TableName}");  // Products
        }

        // Đọc attribute của property
        PropertyInfo prop = type.GetProperty("Name");
        var propAttrs = prop.GetCustomAttributes(typeof(RequiredAttribute), false);
        if (propAttrs.Length > 0)
        {
            Console.WriteLine($"Property 'Name' là bắt buộc");  // [Required]
        }

        // Lợi ích: Validation, Serialization, ORM mapping, Documentation...
    }

    // ============================================
    // 9. REFLECTION
    // ============================================
    static void ReflectionExample()
    {
        Console.WriteLine("\n━━━ 9. REFLECTION ━━━");

        // REFLECTION:
        // - Khả năng đọc và thao tác code tại RUNTIME
        // - Đọc metadata: type, properties, methods, attributes...
        // - Tạo instance động, gọi method động
        // - Dùng namespace: System.Reflection
        // - Lưu ý: Chậm hơn so với code thông thường

        Type type = typeof(Product);  // Lấy Type của Product class

        // === ĐỌC THÔNG TIN TYPE ===
        Console.WriteLine($"\n• Type Name: {type.Name}");           // Product
        Console.WriteLine($"• Full Name: {type.FullName}");      // Namespace.Product
        Console.WriteLine($"• Namespace: {type.Namespace}");        // Namespace

        // === ĐỌC PROPERTIES ===
        Console.WriteLine("\n• Properties:");
        foreach (PropertyInfo prop in type.GetProperties())
        {
            Console.WriteLine($"  - {prop.Name} ({prop.PropertyType.Name})");
        }

        // === ĐỌC METHODS ===
        Console.WriteLine("\n• Methods:");
        foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
        {
            Console.WriteLine($"  - {method.Name}");
        }

        // === TẠO INSTANCE ĐỘNG ===
        // Không cần biết trước kiểu cụ thể tại compile-time
        object instance = Activator.CreateInstance(type);  // Tạo Product mới 
        Console.WriteLine($"  - Instance of {type.Name} was created.");

        // === SET/GET GIÁ TRỊ ĐỘNG ===
        PropertyInfo nameProp = type.GetProperty("Name");
        nameProp.SetValue(instance, "iPhone");  // Set Name = "iPhone"
        Console.WriteLine($"\n• Giá trị Name: {nameProp.GetValue(instance)}");

        // Lợi ích: Plugin system, Serialization, ORM, Dependency Injection...
        // Nhược điểm: Chậm, không type-safe, dễ lỗi runtime
    }

    // ============================================
    // 10. THREAD
    // ============================================
    static void ThreadExample()
    {
        Console.WriteLine("\n━━━ 10. THREAD ━━━");

        // THREAD:
        // - Luồng xử lý độc lập, chạy song song với main thread
        // - Mỗi thread có stack riêng nhưng dùng chung heap
        // - Dùng để xử lý đồng thời (concurrent processing)
        // - Cẩn thận: Race condition, Deadlock

        // === 1. THREAD CƠ BẢN ===
        Console.WriteLine("\n• Thread cơ bản:");
        Thread thread1 = new Thread(PrintNumbers);  // Tạo thread
        Thread thread2 = new Thread(PrintLetters);

        thread1.Start();  // Bắt đầu thread
        thread2.Start();

        thread1.Join(); // Đợi thread1 hoàn thành trước khi tiếp tục
        thread2.Join(); // Đợi thread2 hoàn thành

        // === 2. THREAD VỚI LAMBDA ===
        Console.WriteLine("\n• Thread với lambda:");
        Thread thread3 = new Thread(() =>
              {
                  for (int i = 0; i < 3; i++)
                  {
                      Console.WriteLine($"Lambda thread: {i}");
                      Thread.Sleep(100);  // Ngủ 100ms
                  }
              });
        thread3.Start();
        thread3.Join();

        // === 3. THREADPOOL ===
        // Quản lý pool của threads, tái sử dụng thay vì tạo mới
        Console.WriteLine("\n• ThreadPool:");
        for (int i = 0; i < 3; i++)
        {
            int taskNumber = i;
            ThreadPool.QueueUserWorkItem(state =>  // Thêm task vào queue
               {
                   Console.WriteLine($"  ThreadPool task {taskNumber}");
                   Thread.Sleep(100);
               });
        }
        Thread.Sleep(500); // Đợi ThreadPool hoàn thành

        // Lợi ích: Tăng performance, xử lý nhiều tác vụ cùng lúc
        // Nhược điểm: Phức tạp, dễ lỗi (race condition, deadlock)
    }

    static void PrintNumbers()
    {
        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine($"  Số: {i}");
            Thread.Sleep(100);  // Giả lập công việc mất thời gian
        }
    }

    static void PrintLetters()
    {
        for (char c = 'A'; c <= 'C'; c++)
        {
            Console.WriteLine($"  Chữ: {c}");
            Thread.Sleep(100);
        }
    }

    // ============================================
    // 11. ASYNC/AWAIT
    // ============================================
    static async Task AsyncExample()
    {
        Console.WriteLine("\n━━━ 11. ASYNC/AWAIT ━━━");

        // ASYNC/AWAIT:
        // - Lập trình bất đồng bộ (asynchronous programming)
        // - Không block main thread trong khi đợi I/O (file, network, DB...)
        // - Dùng Task và Task<T>
        // - async method phải return Task hoặc Task<T>
        // - await để đợi task hoàn thành

        // === 1. ASYNC METHOD ===
        Console.WriteLine("\n• Async method:");
        string result1 = await DownloadDataAsync("https://api.example.com/data1");
        Console.WriteLine(result1);  // Đợi download xong mới in

        // === 2. MULTIPLE ASYNC TASKS ===
        // Chạy nhiều tasks song song để tăng performance
        Console.WriteLine("\n• Multiple async tasks:");
        Task<string> task1 = DownloadDataAsync("https://api.example.com/data2");
        Task<string> task2 = DownloadDataAsync("https://api.example.com/data3");

        await Task.WhenAll(task1, task2);  // Đợi TẤT CẢ tasks hoàn thành
        Console.WriteLine(task1.Result);
        Console.WriteLine(task2.Result);

        // === 3. TASK.RUN ===
        // Chạy code đồng bộ trong background thread
        Console.WriteLine("\n• Task.Run:");
        int result = await Task.Run(() =>
        {
            Thread.Sleep(500);  // Công việc mất thời gian
            return 42;
        });
        Console.WriteLine($"  Kết quả từ Task.Run: {result}");

        // Lợi ích:
        // - UI không bị đơ (responsive UI)
        // - Tận dụng tốt resources (không block threads)
        // - Code dễ đọc hơn callback hell
    }

    static async Task<string> DownloadDataAsync(string url)
    {
        // Giả lập tải dữ liệu (I/O operation)
        await Task.Delay(200); // Delay 200ms không block thread
        return $"  Data from {url}";

        // Note: Trong thực tế dùng HttpClient, FileStream, DbContext...
    }
}

// ============================================
// ABSTRACT CLASS: SHAPE
// ============================================
// Abstract class: Class trừu tượng, không thể tạo instance trực tiếp
// Mục đích: Định nghĩa base class chung cho các class con
abstract class Shape
{
    // Concrete property - Thuộc tính thông thường
    public string Color { get; set; }

    // === ABSTRACT METHOD ===
    // Không có body (implementation)
    // Class con BẮT BUỘC phải override và implement
    public abstract double CalculateArea();

    // Abstract method khác
    public abstract void Draw();

    // === CONCRETE METHOD ===
    // Method có implementation sẵn
    // Class con có thể dùng trực tiếp hoặc override
    public void DisplayInfo()
    {
        Console.WriteLine($"Hình có màu: {Color}");
    }

    // KHI NÀO DÙNG ABSTRACT CLASS:
    // - Muốn chia sẻ code chung giữa các class liên quan
    // - Có một số methods phải implement, một số có sẵn implementation
    // - Muốn định nghĩa base class với default behavior
}

// === CLASS CON: CIRCLE ===
// Kế thừa từ Shape và implement tất cả abstract methods
class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
        Color = "Đỏ";  // Set property từ base class
    }

    // OVERRIDE abstract method - BẮT BUỘC
    public override double CalculateArea()
    {
        // Logic tính diện tích riêng cho hình tròn
        return Math.PI * Radius * Radius;  // πr²
    }

    public override void Draw()
    {
        Console.WriteLine($"Vẽ hình tròn bán kính {Radius}");
    }
}

// === CLASS CON: RECTANGLE ===
class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
        Color = "Xanh";
    }

    // OVERRIDE abstract method với logic khác
    public override double CalculateArea()
    {
        // Logic tính diện tích riêng cho hình chữ nhật
        return Width * Height;  // width × height
    }

    public override void Draw()
    {
        Console.WriteLine($"Vẽ hình chữ nhật {Width}x{Height}");
    }
}

// ============================================
// INTERFACE: LOGGER
// ============================================
// Interface: Contract định nghĩa hành vi mà class phải implement
// Chỉ chứa signatures (method names, parameters, return types)
interface ILogger
{
    // Method signatures - Không có body
    void Log(string message);
    void LogError(string error);

    // === DEFAULT IMPLEMENTATION (C# 8.0+) ===
    // Interface có thể có method với implementation mặc định
    // Class implement không bắt buộc phải override
    void LogWarning(string warning)
    {
        Console.WriteLine($"⚠️ WARNING: {warning}");
    }

    // KHI NÀO DÙNG INTERFACE:
    // - Muốn định nghĩa contract mà nhiều class không liên quan có thể implement
    // - Cần multiple inheritance (class có thể implement nhiều interfaces)
    // - Muốn loose coupling (giảm phụ thuộc giữa các class)
}

// === IMPLEMENTATION 1: FILE LOGGER ===
class FileLogger : ILogger
{
    // Implement tất cả methods của interface
    public void Log(string message)
    {
        Console.WriteLine($"📁 File Log: {message}");
        // Trong thực tế: Ghi vào file
    }

    public void LogError(string error)
    {
        Console.WriteLine($"📁 File Error: {error}");
        // Trong thực tế: Ghi error vào file
    }
}

// === IMPLEMENTATION 2: CONSOLE LOGGER ===
class ConsoleLogger : ILogger
{
    // Cùng interface nhưng implementation khác
    public void Log(string message)
    {
        Console.WriteLine($"🖥️ Console Log: {message}");
        // Ghi ra console thay vì file
    }

    public void LogError(string error)
    {
        Console.WriteLine($"🖥️ Console Error: {error}");
    }
}

// ============================================
// MULTIPLE INTERFACES
// ============================================
// Interface cho Email service
interface IEmailService
{
    void SendEmail(string to, string message);
}

// === CLASS IMPLEMENT NHIỀU INTERFACES ===
// C# không cho phép multiple inheritance (nhiều base classes)
// Nhưng cho phép implement nhiều interfaces
class EmailService : ILogger, IEmailService
{
    // Implement ILogger
    public void Log(string message)
    {
        Console.WriteLine($"📧 Email Log: {message}");
    }

    public void LogError(string error)
    {
        Console.WriteLine($"📧 Email Error: {error}");
    }

    // Implement IEmailService
    public void SendEmail(string to, string message)
    {
        Console.WriteLine($"📧 Gửi email đến {to}: {message}");
    }

    // Lợi ích: Class có thể đóng nhiều vai trò khác nhau
}

// SO SÁNH ABSTRACT CLASS VS INTERFACE:
// ┌─────────────────────┬───────────────────┬──────────────────┐
// │                     │ Abstract Class    │ Interface        │
// ├─────────────────────┼───────────────────┼──────────────────┤
// │ Constructor         │ Có                │ Không            │
// │ Fields              │ Có                │ Không            │
// │ Implementation      │ Có thể có         │ Không (trừ C# 8) │
// │ Multiple            │ Không             │ Có               │
// │ Access Modifiers    │ Có                │ Public only      │
// └─────────────────────┴───────────────────┴──────────────────┘

// ============================================
// POLYMORPHISM: ANIMAL
// ============================================
// Base class cho các loài động vật
class Animal
{
    // === VIRTUAL METHOD ===
    // Keyword "virtual": Method có thể bị override ở class con
    // Class con có thể ghi đè (override) hoặc giữ nguyên
    public virtual void MakeSound()
    {
        Console.WriteLine("🔊 Animal makes a sound");
        // Default implementation
    }

    public virtual void Move()
    {
        Console.WriteLine("🚶 Animal moves");
    }
}

// === DERIVED CLASS 1: DOG ===
class Dog : Animal
{
    // OVERRIDE: Ghi đè method của base class
    public override void MakeSound()
    {
        Console.WriteLine("🐕 Woof! Woof!");  // Logic riêng cho Dog
                                              // Không gọi base.MakeSound()
    }

    public override void Move()
    {
        Console.WriteLine("🐕 Dog runs");
    }
}

// === DERIVED CLASS 2: CAT ===
class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("🐈 Meow! Meow!");// Logic riêng cho Cat
    }

    public override void Move()
    {
        Console.WriteLine("🐈 Cat walks gracefully");
    }
}

// === DERIVED CLASS 3: BIRD ===
class Bird : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("🐦 Tweet! Tweet!");  // Logic riêng cho Bird
    }

    public override void Move()
    {
        Console.WriteLine("🐦 Bird flies");
    }
}

// POLYMORPHISM:
// - Animal reference có thể trỏ đến Dog, Cat, hoặc Bird
// - Gọi MakeSound() sẽ chạy đúng implementation của từng class
// - "Một interface, nhiều implementations"

// ============================================
// METHOD OVERLOADING
// ============================================
// Minh hoạ Compile-time Polymorphism
class Calculator
{
    // === OVERLOADING ===
    // Cùng tên method, khác signature (số lượng/kiểu tham số)
    // Compiler chọn method phù hợp dựa vào arguments

    // Version 1: 2 tham số int
    public int Add(int a, int b)
    {
        return a + b;
    }

    // Version 2: 3 tham số int
    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }

    // Version 3: 2 tham số double
    public double Add(double a, double b)
    {
        return a + b;
    }

    // Compiler tự động chọn:
    // Add(5, 3)     → gọi Add(int, int)
    // Add(5, 3, 2)  → gọi Add(int, int, int)
    // Add(5.5, 3.2) → gọi Add(double, double)
}

// ============================================
// STATIC CLASS
// ============================================
// Static class: Chỉ chứa static members, không thể tạo instance
// Dùng cho utility classes (Math, Console, String...)
//Static
//1. Biến static gắn liền với class chứa nó và được tạo duy nhất 1 lần, tồn tại đến khi kết thúc chương trình
//Biến không phải static sẽ gắn liền với object
//2. Khi khai báo hàm là static, chỉ có thể truy cập vào biến static (vì hàm static gắn liền với class, không gắn với một object cụ thể, trong khi biến bình thường gắn liền với object cụ thể)
//3. Constructor static được gọi tự động khi class được sử dụng lần đầu tiên
//4. Class static chỉ chứa các thành phần là static (hạn chế dùng, thường dùng khi viết extension method - là các method làm việc trên kiểu dữ liệu nào đó)
//5. Tạo extension method bằng cách: tạo một lớp static => tạo 1 hàm static, tham số nhận vào là this + kiểu dữ liệu + tên biến

//Reference type
//6. Phải gán giá trị cho kiểu reference type nếu nó không nullable (dùng require hoặc gán giá trị mặc định)

//Singleton
//7. Vấn đề khi sử dụng static: khó kiểm soát vì có thể truy cập từ bất kì đâu trong chương trình, nếu thay đổi giá trị của nó sẽ ảnh hưởng đến tất cả những nơi sử dụng biến static này => Dùng singleton pattern để khắc phục
//8. Singleton pattern giúp kiểm soát được: quản lý vòng đời, kiểm soát truy cập, sửa đổi, ...
//9. Nội dung: Thay vì cho người dùng truy cập thẳng vào biến static, thì ta bắt buộc phải thông qua 1 lớp đặc biệt, gọi là singleton
//10. Dùng singleton phải kiểm soát truy cập đồng thời từ nhiều thread 
//=> Dùng lock: Chỉ cho duy nhất 1 thread chạy vào vùng lock, nếu đang có thread chạy vào mà có thread chạy đến thì thread mới chạy đến phải chờ thread kia chạy xong vùng lock
static class MathHelper
{
    // CONST: Hằng số, không thay đổi được
    public const double PI = 3.14159;

    // STATIC METHOD: Gọi qua tên class
    public static int Square(int number)
    {
        return number * number;
    }

    public static int Cube(int number)
    {
        return number * number * number;
    }

    // Không thể:
    // - Tạo instance: new MathHelper() ❌
    // - Có constructor non-static
    // - Kế thừa hoặc implement interface

    // Lợi ích:
    // - Tiết kiệm memory (không tạo instance)
    // - Tiện lợi cho helper/utility functions
    // - Thread-safe nếu không có state
}

// ============================================
// DEPENDENCY INJECTION
// ============================================
// Interface cho notification service
interface INotificationService
{
    void SendNotification(string message);
}

// === IMPLEMENTATION 1: EMAIL ===
class EmailNotificationService : INotificationService
{
    public void SendNotification(string message)
    {
        Console.WriteLine($"📧 Email: {message}");
    }
}

// === IMPLEMENTATION 2: SMS ===
class SmsNotificationService : INotificationService
{
    public void SendNotification(string message)
    {
        Console.WriteLine($"📱 SMS: {message}");
    }
}

// === IMPLEMENTATION 3: PUSH ===
class PushNotificationService : INotificationService
{
    public void SendNotification(string message)
    {
        Console.WriteLine($"🔔 Push: {message}");
    }
}

// === CLASS SỬ DỤNG DEPENDENCY INJECTION ===
class UserService
{
    // Private field để lưu dependency
    private INotificationService notificationService;

    // === 1. CONSTRUCTOR INJECTION (Khuyên dùng) ===
    // Inject dependency qua constructor
    public UserService(INotificationService notificationService = null)
    {
        this.notificationService = notificationService;
    }

    // === 2. PROPERTY INJECTION ===
    // Inject dependency qua public property
    public INotificationService NotificationService { get; set; }

    public void RegisterUser(string contact)
    {
        Console.WriteLine($"Đăng ký user: {contact}");

        // Sử dụng dependency đã được inject
        if (notificationService != null)
        {
            notificationService.SendNotification($"Chào mừng {contact}!");
        }
        else if (NotificationService != null)
        {
            NotificationService.SendNotification($"Chào mừng {contact}!");
        }
    }

    // === 3. METHOD INJECTION ===
    // Inject dependency qua method parameter
    public void RegisterUser(string contact, INotificationService service)
    {
        Console.WriteLine($"Đăng ký user: {contact}");
        service.SendNotification($"Chào mừng {contact}!");
    }

    // LỢI ÍCH CỦA DEPENDENCY INJECTION:
    // 1. Loose Coupling - Giảm phụ thuộc giữa classes
    // 2. Testability - Dễ test (inject mock dependencies)
    // 3. Maintainability - Dễ thay đổi implementation
    // 4. Flexibility - Linh hoạt thay đổi dependencies
}

// ============================================
// CUSTOM ATTRIBUTE
// ============================================
// AttributeUsage: Chỉ định attribute áp dụng cho gì (Class, Method, Property...)
[AttributeUsage(AttributeTargets.Class)]
class TableAttribute : Attribute
{
    public string TableName { get; set; }

    public TableAttribute(string tableName)
    {
        TableName = tableName;
    }
}

[AttributeUsage(AttributeTargets.Property)]
class RequiredAttribute : Attribute
{
    // Đánh dấu property bắt buộc phải có giá trị
}

[AttributeUsage(AttributeTargets.Property)]
class MaxLengthAttribute : Attribute
{
    public int Length { get; set; }

    public MaxLengthAttribute(int length)
    {
        Length = length;
    }
}

// ============================================
// PRODUCT CLASS WITH ATTRIBUTES
// ============================================
// Sử dụng custom attributes để thêm metadata
[Table("Products")]  // Custom attribute: Chỉ định tên table trong DB
class Product
{
    [Required]  // Property bắt buộc
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]  // Độ dài tối đa
    public string Name { get; set; }

    public decimal Price { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]  // Built-in attribute: Bỏ qua khi serialize
    public string InternalCode { get; set; }

    [Obsolete("Dùng NewMethod() thay thế")]  // Built-in: Đánh dấu lỗi thời
    public void OldMethod()
    {
        Console.WriteLine("⚠️ Method này đã lỗi thời!");
    }

    public void NewMethod()
    {
        Console.WriteLine("✅ Method mới!");
    }

    // CÁCH DÙNG ATTRIBUTES:
    // - ORM (Entity Framework): Map class ↔ database table
    // - Serialization: Kiểm soát JSON/XML output
    // - Validation: Validate input data
    // - Documentation: Thêm thông tin mô tả
    // - Code Generation: Tự động sinh code
}
