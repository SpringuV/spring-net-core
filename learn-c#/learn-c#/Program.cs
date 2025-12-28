// ============================================
// KIẾN THỨC CƠ BẢN C#
// ============================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Linq.Expressions;

class Program
{
    static void Main(string[] args)
    {
        // Thiết lập encoding UTF-8 cho Console để hiển thị tiếng Việt
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("=== HỌC C# CƠ BẢN ===\n");

        // 1. BIẾN VÀ KIỂU DỮ LIỆU
        Variables();

        // 2. TOÁN TỬ
        Operators();

        // 3. ĐIỀU KIỆN (IF-ELSE, SWITCH)
        Conditionals();

        // 4. VÒNG LẶP (FOR, WHILE, FOREACH)
        Loops();

        // 5. MẢNG VÀ COLLECTIONS
        ArraysAndCollections();

        // 6. HÀM/METHODS
        Methods();

        // 7. LỚP VÀ ĐỐI TƯỢNG (OOP)
        ObjectOrientedProgramming();

        // 8. THAO TÁC VỚI FILE
        FileOperations();

        // 9. XỬ LÝ NGOẠI LỆ (EXCEPTION)
        ExceptionHandling();

        // 10. LAMBDA EXPRESSION
        LambdaExpressions();

        Console.WriteLine("\n=== KẾT THÚC ===");
        Console.ReadKey();
    }

    // ============================================
    // 1. BIẾN VÀ KIỂU DỮ LIỆU
    // ============================================
    static void Variables()
    {
        Console.WriteLine("\n--- 1. BIẾN VÀ KIỂU DỮ LIỆU ---");

        // Kiểu số nguyên
        int age = 25;
        long population = 7800000000L;
        short smallNumber = 100;
        byte byteValue = 255;

        // Kiểu số thực
        float height = 1.75f;
        double weight = 65.5;
        decimal price = 99.99m; // Dùng cho tiền tệ

        // Kiểu ký tự và chuỗi
        char grade = 'A';
        string name = "Nguyễn Văn A";

        // Kiểu boolean
        bool isStudent = true;

        // Var - tự suy luận kiểu
        var city = "Hà Nội";

        Console.WriteLine($"Tên: {name}, Tuổi: {age}, Thành phố: {city}");
        Console.WriteLine($"Chiều cao: {height}m, Cân nặng: {weight}kg");
        Console.WriteLine($"Giá: {price:C}, Là sinh viên: {isStudent}");
    }

    // ============================================
    // 2. TOÁN TỬ
    // ============================================
    static void Operators()
    {
        Console.WriteLine("\n--- 2. TOÁN TỬ ---");

        int a = 10, b = 3;

        // Toán tử số học
        Console.WriteLine($"Cộng: {a} + {b} = {a + b}");
        Console.WriteLine($"Trừ: {a} - {b} = {a - b}");
        Console.WriteLine($"Nhân: {a} * {b} = {a * b}");
        Console.WriteLine($"Chia: {a} / {b} = {a / b}");
        Console.WriteLine($"Chia lấy dư: {a} % {b} = {a % b}");

        // Toán tử so sánh
        Console.WriteLine($"{a} > {b}: {a > b}");
        Console.WriteLine($"{a} == {b}: {a == b}");
        Console.WriteLine($"{a} != {b}: {a != b}");

        // Toán tử logic
        bool x = true, y = false;
        Console.WriteLine($"x && y: {x && y}"); // AND
        Console.WriteLine($"x || y: {x || y}"); // OR
        Console.WriteLine($"!x: {!x}"); // NOT
    }

    // ============================================
    // 3. ĐIỀU KIỆN (IF-ELSE, SWITCH)
    // ============================================
    static void Conditionals()
    {
        Console.WriteLine("\n--- 3. ĐIỀU KIỆN ---");

        int score = 85;

        // IF-ELSE
        if (score >= 90)
        {
            Console.WriteLine("Loại A - Xuất sắc");
        }
        else if (score >= 80)
        {
            Console.WriteLine("Loại B - Giỏi");
        }
        else if (score >= 70)
        {
            Console.WriteLine("Loại C - Khá");
        }
        else
        {
            Console.WriteLine("Loại D - Trung bình");
        }

        // SWITCH
        int day = 3;
        string dayName = day switch
        {
            1 => "Thứ Hai",
            2 => "Thứ Ba",
            3 => "Thứ Tư",
            4 => "Thứ Năm",
            5 => "Thứ Sáu",
            6 => "Thứ Bảy",
            7 => "Chủ Nhật",
            _ => "Không hợp lệ"
        };
        Console.WriteLine($"Ngày {day} là: {dayName}");

        // Toán tử ba ngôi (Ternary)
        string result = (score >= 50) ? "Đậu" : "Rớt";
        Console.WriteLine($"Kết quả: {result}");
    }

    // ============================================
    // 4. VÒNG LẶP
    // ============================================
    static void Loops()
    {
        Console.WriteLine("\n--- 4. VÒNG LẶP ---");

        // FOR LOOP
        Console.Write("FOR: ");
        for (int i = 1; i <= 5; i++)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine();

        // WHILE LOOP
        Console.Write("WHILE: ");
        int count = 1;
        while (count <= 5)
        {
            Console.Write($"{count} ");
            count++;
        }
        Console.WriteLine();

        // DO-WHILE LOOP
        Console.Write("DO-WHILE: ");
        int num = 1;
        do
        {
            Console.Write($"{num} ");
            num++;
        } while (num <= 5);
        Console.WriteLine();

        // FOREACH LOOP
        string[] fruits = { "Táo", "Cam", "Xoài", "Chuối" };
        Console.Write("FOREACH: ");
        foreach (string fruit in fruits)
        {
            Console.Write($"{fruit} ");
        }
        Console.WriteLine();
    }

    // ============================================
    // 5. MẢNG VÀ COLLECTIONS
    // ============================================
    static void ArraysAndCollections()
    {
        Console.WriteLine("\n--- 5. MẢNG VÀ COLLECTIONS ---");

        // ===== MẢNG 1 CHIỀU (Array) =====
        Console.WriteLine("\n• MẢNG 1 CHIỀU:");
        int[] numbers = { 1, 2, 3, 4, 5 };
        Console.WriteLine($"  Mảng: [{string.Join(", ", numbers)}]");
        Console.WriteLine($"  Phần tử đầu: {numbers[0]}, Phần tử cuối: {numbers[^1]}");
        Console.WriteLine($"  Độ dài: {numbers.Length}");

        // Duyệt mảng
        Console.Write("  Duyệt mảng: ");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write($"{numbers[i]} ");
        }
        Console.WriteLine();

        // ===== MẢNG 2 CHIỀU (2D Array) =====
        Console.WriteLine("\n• MẢNG 2 CHIỀU (Ma trận):");

        // Cách 1: Khai báo và khởi tạo trực tiếp
        int[,] matrix = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        Console.WriteLine("  Ma trận 3x3:");
        for (int i = 0; i < matrix.GetLength(0); i++) // Số hàng
        {
            Console.Write("  ");
            for (int j = 0; j < matrix.GetLength(1); j++) // Số cột
            {
                Console.Write($"{matrix[i, j],3} ");
            }
            Console.WriteLine();
        }

        // Cách 2: Khai báo sau đó gán giá trị
        int[,] scores = new int[3, 4]; // 3 hàng, 4 cột
        scores[0, 0] = 85;
        scores[0, 1] = 90;
        scores[1, 0] = 78;
        Console.WriteLine($"\n  Điểm [0,0] = {scores[0, 0]}");
        Console.WriteLine($"  Kích thước: {scores.GetLength(0)} hàng x {scores.GetLength(1)} cột");

        // ===== MẢNG JAGGED (Mảng răng cưa) =====
        Console.WriteLine("\n• MẢNG JAGGED (Mảng của mảng):");
        int[][] jagged = new int[3][];
        jagged[0] = new int[] { 1, 2 };
        jagged[1] = new int[] { 3, 4, 5, 6 };
        jagged[2] = new int[] { 7, 8, 9 };

        Console.WriteLine("  Mảng jagged:");
        for (int i = 0; i < jagged.Length; i++)
        {
            Console.Write($"  Hàng {i}: ");
            foreach (int num in jagged[i])
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
        }

        // ===== LIST (Danh sách động) =====
        Console.WriteLine("\n• LIST (Danh sách động):");
        List<string> cities = new List<string> { "Hà Nội", "Sài Gòn", "Đà Nẵng" };
        cities.Add("Huế");
        cities.Add("Cần Thơ");
        cities.Remove("Đà Nẵng");
        Console.WriteLine($"  List: [{string.Join(", ", cities)}]");
        Console.WriteLine($"  Số phần tử: {cities.Count}");
        Console.WriteLine($"  Có chứa 'Huế': {cities.Contains("Huế")}");

        // ===== DICTIONARY (Từ điển) =====
        Console.WriteLine("\n• DICTIONARY (Từ điển - Key/Value):");
        Dictionary<string, int> ages = new Dictionary<string, int>
        {
          { "An", 25 },
    { "Bình", 30 },
            { "Chi", 28 }
        };
        Console.WriteLine($"  Tuổi của Bình: {ages["Bình"]}");
        Console.WriteLine("  Danh sách:");
        foreach (var kvp in ages)
        {
            Console.WriteLine($"    {kvp.Key}: {kvp.Value} tuổi");
        }

        // ===== LINQ - LÝ THUYẾT VÀ THỰC HÀNH =====
        LinqExamples();
    }

    // ============================================
    // LINQ - LANGUAGE INTEGRATED QUERY
    // ============================================
    static void LinqExamples()
    {
        Console.WriteLine("\n--- LINQ - TRUY VẤN DỮ LIỆU ---");

        Console.WriteLine("\n📚 LINQ LÀ GÌ?");
        Console.WriteLine("  - Language Integrated Query (Truy vấn tích hợp ngôn ngữ)");
        Console.WriteLine("  - Cho phép truy vấn dữ liệu từ Collections, Arrays, XML, Database...");
        Console.WriteLine("  - Cú pháp giống SQL nhưng viết trong C#");
        Console.WriteLine("  - Có 2 cú pháp: Method Syntax và Query Syntax");

        // Dữ liệu mẫu
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        List<Student2> students = new List<Student2>
        {
            new Student2 { Id = 1, Name = "An", Age = 20, Score = 8.5 },
            new Student2 { Id = 2, Name = "Bình", Age = 22, Score = 7.0 },
            new Student2 { Id = 3, Name = "Chi", Age = 19, Score = 9.0 },
            new Student2 { Id = 4, Name = "Dũng", Age = 21, Score = 6.5 },
            new Student2 { Id = 5, Name = "Em", Age = 20, Score = 8.0 }
        };

        // ===== 1. WHERE - LỌC DỮ LIỆU =====
        Console.WriteLine("\n1️⃣ WHERE - Lọc dữ liệu:");
        var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
        Console.WriteLine($"   Số chẵn: [{string.Join(", ", evenNumbers)}]");

        var topStudents = students.Where(s => s.Score >= 8.0).ToList();
        Console.WriteLine("   Sinh viên điểm >= 8.0:");
        foreach (var s in topStudents)
        {
            Console.WriteLine($"     {s.Name}: {s.Score}");
        }

        // ===== 2. SELECT - CHỌN/BIẾN ĐỔI DỮ LIỆU =====
        Console.WriteLine("\n2️⃣ SELECT - Chọn/Biến đổi:");
        var studentNames = students.Select(s => s.Name).ToList();
        Console.WriteLine($"   Tên sinh viên: [{string.Join(", ", studentNames)}]");

        var squaredNumbers = numbers.Select(n => n * n).ToList();
        Console.WriteLine($"   Bình phương: [{string.Join(", ", squaredNumbers)}]");

        // Select object mới
        var studentInfo = students.Select(s => new
        {
            TenSV = s.Name,
            DiemTB = s.Score,
            XepLoai = s.Score >= 8 ? "Giỏi" : (s.Score >= 6.5 ? "Khá" : "Trung bình")
        }).ToList();
        Console.WriteLine("   Thông tin chi tiết:");
        foreach (var info in studentInfo)
        {
            Console.WriteLine($"  {info.TenSV}: {info.DiemTB} - {info.XepLoai}");
        }

        // ===== 3. ORDERBY - SẮP XẾP =====
        Console.WriteLine("\n3️⃣ ORDERBY - Sắp xếp:");
        var sortedAsc = numbers.OrderBy(n => n).Take(5).ToList();
        Console.WriteLine($"   5 số đầu tăng dần: [{string.Join(", ", sortedAsc)}]");

        var sortedDesc = students.OrderByDescending(s => s.Score).ToList();
        Console.WriteLine("   Sinh viên theo điểm giảm dần:");
        foreach (var s in sortedDesc)
        {
            Console.WriteLine($"     {s.Name}: {s.Score}");
        }

        // Sắp xếp nhiều tiêu chí
        var multiSort = students.OrderBy(s => s.Age).ThenByDescending(s => s.Score).ToList();
        Console.WriteLine("   Sắp xếp theo tuổi tăng, điểm giảm:");
        foreach (var s in multiSort)
        {
            Console.WriteLine($"     {s.Name} - Tuổi: {s.Age}, Điểm: {s.Score}");
        }

        // ===== 4. GROUPBY - NHÓM DỮ LIỆU =====
        Console.WriteLine("\n4️. GROUPBY - Nhóm dữ liệu:");
        var groupByAge = students.GroupBy(s => s.Age);
        Console.WriteLine("   Nhóm theo tuổi:");
        foreach (var group in groupByAge)
        {
            Console.WriteLine($"     Tuổi {group.Key}: {string.Join(", ", group.Select(s => s.Name))}");
        }

        // ===== 5. AGGREGATE - HÀM TỔNG HỢP =====
        Console.WriteLine("\n5️⃣ AGGREGATE - Hàm tổng hợp:");
        Console.WriteLine($"   Count (Đếm): {students.Count()} sinh viên");
        Console.WriteLine($"   Sum (Tổng): {numbers.Sum()}");
        Console.WriteLine($"   Average (Trung bình): {students.Average(s => s.Score):F2}");
        Console.WriteLine($"   Min (Nhỏ nhất): {numbers.Min()}");
        Console.WriteLine($"   Max (Lớn nhất): {numbers.Max()}");
        Console.WriteLine($"   Max điểm: {students.Max(s => s.Score)}");

        // ===== 6. FIRST, LAST, SINGLE =====
        Console.WriteLine("\n6️⃣ FIRST, LAST, SINGLE:");
        var firstStudent = students.First();
        Console.WriteLine($"   First: {firstStudent.Name}");

        var firstTopStudent = students.FirstOrDefault(s => s.Score >= 9.0);
        Console.WriteLine($"   FirstOrDefault (điểm >= 9): {firstTopStudent?.Name ?? "Không có"}");

        var lastStudent = students.Last();
        Console.WriteLine($"   Last: {lastStudent.Name}");

        // ===== 7. ANY, ALL =====
        Console.WriteLine("\n7️⃣ ANY, ALL - Kiểm tra điều kiện:");
        bool hasTopStudent = students.Any(s => s.Score >= 9.0);
        Console.WriteLine($"   Any (Có sinh viên >= 9.0): {hasTopStudent}");

        bool allPassed = students.All(s => s.Score >= 5.0);
        Console.WriteLine($"   All (Tất cả >= 5.0): {allPassed}");

        // ===== 8. TAKE, SKIP =====
        Console.WriteLine("\n8️⃣ TAKE, SKIP - Phân trang:");
        var top3 = students.OrderByDescending(s => s.Score).Take(3).ToList();
        Console.WriteLine($"   Top 3 sinh viên: {string.Join(", ", top3.Select(s => s.Name))}");

        var skip2 = students.Skip(2).Take(2).ToList();
        Console.WriteLine($"   Skip 2, Take 2: {string.Join(", ", skip2.Select(s => s.Name))}");

        // ===== 9. DISTINCT - LỌC TRÙNG =====
        Console.WriteLine("\n9️⃣ DISTINCT - Loại bỏ trùng:");
        int[] duplicates = { 1, 2, 2, 3, 3, 3, 4, 5, 5 };
        var unique = duplicates.Distinct().ToList();
        Console.WriteLine($"Mảng gốc: [{string.Join(", ", duplicates)}]");
        Console.WriteLine($"   Sau Distinct: [{string.Join(", ", unique)}]");

        // ===== 10. JOIN - KẾT HỢP DỮ LIỆU =====
        Console.WriteLine("\n🔟 JOIN - Kết hợp dữ liệu:");
        List<Course> courses = new List<Course>
      {
        new Course { StudentId = 1, CourseName = "C#" },
            new Course { StudentId = 2, CourseName = "Java" },
          new Course { StudentId = 3, CourseName = "Python" },
            new Course { StudentId = 1, CourseName = "SQL" }
    };

        var studentCourses = students.Join(
     courses,
        student => student.Id,
       course => course.StudentId,
     (student, course) => new { student.Name, course.CourseName }
        );

        Console.WriteLine("   Sinh viên và khóa học:");
        foreach (var sc in studentCourses)
        {
            Console.WriteLine($"     {sc.Name} học {sc.CourseName}");
        }

        // ===== 11. QUERY SYNTAX (Cú pháp truy vấn) =====
        Console.WriteLine("\n1️⃣1️⃣ QUERY SYNTAX - Cú pháp SQL-like:");
        var querySyntax = from s in students
                          where s.Score >= 8.0
                          orderby s.Score descending
                          select new { s.Name, s.Score };

        Console.WriteLine("   Sinh viên điểm >= 8.0 (Query Syntax):");
        foreach (var s in querySyntax)
        {
            Console.WriteLine($"     {s.Name}: {s.Score}");
        }

        // ===== 12. COMPLEX LINQ - TỔNG HỢP =====
        Console.WriteLine("\n1️⃣2️⃣ COMPLEX LINQ - Truy vấn phức tạp:");
        var complexQuery = students
            .Where(s => s.Age >= 20)
                  .OrderByDescending(s => s.Score)
                        .Take(3)
                        .Select(s => new
                        {
                            s.Name,
                            s.Score,
                            Grade = s.Score >= 8.5 ? "A" :
                                s.Score >= 8.0 ? "B+" :
                                s.Score >= 7.0 ? "B" : "C"
                        }
            );
        Console.WriteLine("   Top 3 sinh viên >= 20 tuổi:");
        foreach (var s in complexQuery)
        {
            Console.WriteLine($"     {s.Name}: {s.Score} (Hạng {s.Grade})");
        }

        Console.WriteLine("\n✅ LINQ GIÚP CODE NGẮN GỌN, DỄ ĐỌC VÀ BẢO TRÌ!");
    }

    // ============================================
    // 6. HÀM/METHODS
    // ============================================
    static void Methods()
    {
        Console.WriteLine("\n--- 6. HÀM/METHODS ---");

        // Gọi hàm không trả về giá trị
        SayHello("Nguyễn Văn A");

        // Gọi hàm có trả về giá trị
        int sum = Add(10, 20);
        Console.WriteLine($"10 + 20 = {sum}");

        // Hàm với tham số mặc định
        PrintInfo("Trần Thị B");
        PrintInfo("Lê Văn C", 28);

        // Hàm với params
        int total = SumAll(1, 2, 3, 4, 5);
        Console.WriteLine($"Tổng: {total}");

        // Hàm với out parameter
        int quotient, remainder;
        Divide(10, 3, out quotient, out remainder);
        Console.WriteLine($"10 / 3 = {quotient} dư {remainder}");
    }

    static void SayHello(string name)
    {
        Console.WriteLine($"Xin chào, {name}!");
    }

    static int Add(int a, int b)
    {
        return a + b;
    }

    static void PrintInfo(string name, int age = 25)
    {
        Console.WriteLine($"Tên: {name}, Tuổi: {age}");
    }

    static int SumAll(params int[] numbers)
    {
        return numbers.Sum();
    }

    static void Divide(int dividend, int divisor, out int quotient, out int remainder)
    {
        quotient = dividend / divisor;
        remainder = dividend % divisor;
    }

    // ============================================
    // 7. LỚP VÀ ĐỐI TƯỢNG (OOP)
    // ============================================
    static void ObjectOrientedProgramming()
    {
        Console.WriteLine("\n--- 7. LỚP VÀ ĐỐI TƯỢNG (OOP) ---");

        // Tạo đối tượng
        Person person1 = new Person("Nguyễn Văn A", 25);
        person1.Introduce();

        // Sử dụng property
        person1.Age = 26;
        Console.WriteLine($"Tuổi mới: {person1.Age}");

        // Kế thừa
        Student student1 = new Student("Trần Thị B", 20, "SV001");
        student1.Introduce();
        student1.Study();

        // Interface
        IVehicle car = new Car();
        car.Start();
        car.Stop();
    }

    // ============================================
    // 8. THAO TÁC VỚI FILE
    // ============================================
    static void FileOperations()
    {
        Console.WriteLine("\n--- 8. THAO TÁC VỚI FILE ---");

        string fileName = "test.txt";
        string folderName = "MyFolder";
        string fileInFolder = Path.Combine(folderName, "data.txt");

        try
        {
            // ===== 1. GHI FILE - WRITE FILE =====
            Console.WriteLine("\n1️⃣ GHI FILE (Write):");

            // Cách 1: Ghi đè toàn bộ file
            File.WriteAllText(fileName, "Xin chào C#!\n");
            Console.WriteLine($"   ✓ Đã ghi file: {fileName}");

            // Cách 2: Ghi thêm vào cuối file
            File.AppendAllText(fileName, "Dòng thứ hai\n");
            File.AppendAllText(fileName, "Dòng thứ ba\n");
            Console.WriteLine("   ✓ Đã thêm nội dung vào file");

            // Cách 3: Ghi nhiều dòng
            string[] lines = { "Dòng 1", "Dòng 2", "Dòng 3" };
            File.WriteAllLines("lines.txt", lines);
            Console.WriteLine("   ✓ Đã ghi file lines.txt");

            // ===== 2. ĐỌC FILE - READ FILE =====
            Console.WriteLine("\n2️⃣ ĐỌC FILE (Read):");

            // Cách 1: Đọc toàn bộ file thành string
            string content = File.ReadAllText(fileName);
            Console.WriteLine($"   Nội dung file:\n{content}");

            // Cách 2: Đọc từng dòng
            string[] allLines = File.ReadAllLines("lines.txt");
            Console.WriteLine("   Đọc từng dòng:");
            foreach (string line in allLines)
            {
                Console.WriteLine($"     - {line}");
            }

            // Cách 3: Đọc từng dòng với StreamReader
            Console.WriteLine("\n   Đọc với StreamReader:");
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                int lineNumber = 1;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine($"     Dòng {lineNumber}: {line}");
                    lineNumber++;
                }
            }

            // ===== 3. KIỂM TRA FILE/FOLDER TỒN TẠI =====
            Console.WriteLine("\n3️⃣ KIỂM TRA TỒN TẠI:");
            Console.WriteLine($"   File '{fileName}' tồn tại: {File.Exists(fileName)}");
            Console.WriteLine($"   Folder '{folderName}' tồn tại: {Directory.Exists(folderName)}");

            // ===== 4. TẠO/XÓA FOLDER =====
            Console.WriteLine("\n4️⃣ THAO TÁC VỚI FOLDER:");

            // Tạo folder
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
                Console.WriteLine($"   ✓ Đã tạo folder: {folderName}");
            }

            // Ghi file vào folder
            File.WriteAllText(fileInFolder, "Dữ liệu trong folder");
            Console.WriteLine($"   ✓ Đã tạo file: {fileInFolder}");

            // Liệt kê file trong folder
            string[] filesInFolder = Directory.GetFiles(folderName);
            Console.WriteLine($"   Files trong '{folderName}':");
            foreach (string file in filesInFolder)
            {
                Console.WriteLine($"     - {Path.GetFileName(file)}");
            }

            // ===== 5. SAO CHÉP FILE =====
            Console.WriteLine("\n5️⃣ SAO CHÉP FILE:");
            string copyFileName = "test_copy.txt";
            File.Copy(fileName, copyFileName, true); // true = overwrite nếu đã tồn tại
            Console.WriteLine($"   ✓ Đã sao chép {fileName} → {copyFileName}");

            // ===== 6. DI CHUYỂN/ĐỔI TÊN FILE =====
            Console.WriteLine("\n6️⃣ DI CHUYỂN/ĐỔI TÊN FILE:");
            string newFileName = "test_renamed.txt";
            if (File.Exists(copyFileName))
            {
                if (File.Exists(newFileName))
                    File.Delete(newFileName);

                File.Move(copyFileName, newFileName);
                Console.WriteLine($"   ✓ Đã đổi tên {copyFileName} → {newFileName}");
            }

            // ===== 7. THÔNG TIN FILE =====
            Console.WriteLine("\n7️⃣ THÔNG TIN FILE:");
            FileInfo fileInfo = new FileInfo(fileName);
            Console.WriteLine($"   Tên file: {fileInfo.Name}");
            Console.WriteLine($"   Đường dẫn đầy đủ: {fileInfo.FullName}");
            Console.WriteLine($"   Kích thước: {fileInfo.Length} bytes");
            Console.WriteLine($"   Ngày tạo: {fileInfo.CreationTime}");
            Console.WriteLine($"   Ngày sửa cuối: {fileInfo.LastWriteTime}");
            Console.WriteLine($"   Chỉ đọc: {fileInfo.IsReadOnly}");

            // ===== 8. GHI/ĐỌC FILE BINARY =====
            Console.WriteLine("\n8️⃣ GHI/ĐỌC FILE BINARY:");
            string binaryFile = "data.bin";

            // Ghi binary
            using (BinaryWriter bw = new BinaryWriter(File.Open(binaryFile, FileMode.Create)))
            {
                bw.Write(123);
                bw.Write(45.67);
                bw.Write("Xin chào");
                bw.Write(true);
            }
            Console.WriteLine($"   ✓ Đã ghi file binary: {binaryFile}");

            // Đọc binary
            using (BinaryReader br = new BinaryReader(File.Open(binaryFile, FileMode.Open)))
            {
                int intValue = br.ReadInt32();
                double doubleValue = br.ReadDouble();
                string stringValue = br.ReadString();
                bool boolValue = br.ReadBoolean();

                Console.WriteLine($"   Đọc từ binary: {intValue}, {doubleValue}, {stringValue}, {boolValue}");
            }

            // ===== 9. LÀM VIỆC VỚI PATH =====
            Console.WriteLine("\n9️⃣ LÀM VIỆC VỚI PATH:");
            string fullPath = Path.Combine("C:", "Users", "Documents", "file.txt");
            Console.WriteLine($"   Path kết hợp: {fullPath}");
            Console.WriteLine($"   Tên file: {Path.GetFileName(fullPath)}");
            Console.WriteLine($"   Phần mở rộng: {Path.GetExtension(fullPath)}");
            Console.WriteLine($"   Tên không có extension: {Path.GetFileNameWithoutExtension(fullPath)}");
            Console.WriteLine($"   Thư mục: {Path.GetDirectoryName(fullPath)}");
            Console.WriteLine($"   Thư mục hiện tại: {Directory.GetCurrentDirectory()}");

            // ===== 10. XÓA FILE/FOLDER =====
            Console.WriteLine("\n🔟 XÓA FILE/FOLDER:");

            // Xóa file
            if (File.Exists(newFileName))
            {
                File.Delete(newFileName);
                Console.WriteLine($"   ✓ Đã xóa file: {newFileName}");
            }

            if (File.Exists(binaryFile))
            {
                File.Delete(binaryFile);
                Console.WriteLine($"   ✓ Đã xóa file: {binaryFile}");
            }

            if (File.Exists("lines.txt"))
            {
                File.Delete("lines.txt");
                Console.WriteLine($"   ✓ Đã xóa file: lines.txt");
            }

            // Xóa folder (phải rỗng hoặc dùng recursive = true)
            if (Directory.Exists(folderName))
            {
                Directory.Delete(folderName, true); // true = xóa cả nội dung bên trong
                Console.WriteLine($"   ✓ Đã xóa folder: {folderName}");
            }

            // ===== 11. GHI/ĐỌC FILE JSON (Bonus) =====
            Console.WriteLine("\n1️⃣1️⃣ GHI/ĐỌC FILE JSON:");
            string jsonFile = "person.json";

            // Tạo object
            var person = new { Name = "Nguyễn Văn A", Age = 25, City = "Hà Nội" };

            // Ghi JSON (cần using System.Text.Json)
            string jsonString = System.Text.Json.JsonSerializer.Serialize(person,
    new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonFile, jsonString);
            Console.WriteLine($"   ✓ Đã ghi JSON: {jsonFile}");
            Console.WriteLine($"   Nội dung:\n{jsonString}");

            // Đọc JSON
            string jsonRead = File.ReadAllText(jsonFile);
            Console.WriteLine($"   ✓ Đã đọc JSON từ file");

            // Xóa file json
            if (File.Exists(jsonFile))
            {
                File.Delete(jsonFile);
            }

            // ===== 12. XỬ LÝ FILE LỚN =====
            Console.WriteLine("\n1️⃣2️⃣ XỬ LÝ FILE LỚN (Stream):");
            string largeFile = "large.txt";

            // Ghi file lớn từng dòng
            using (StreamWriter sw = new StreamWriter(largeFile))
            {
                for (int i = 1; i <= 100; i++)
                {
                    sw.WriteLine($"Dòng số {i}");
                }
            }
            Console.WriteLine($"   ✓ Đã tạo file lớn với 100 dòng");

            // Đọc file lớn từng dòng (không load hết vào RAM)
            int lineCount = 0;
            using (StreamReader sr = new StreamReader(largeFile))
            {
                while (sr.ReadLine() != null)
                {
                    lineCount++;
                }
            }
            Console.WriteLine($"   ✓ Đã đếm: {lineCount} dòng");

            // Xóa file test
            if (File.Exists(largeFile))
            {
                File.Delete(largeFile);
            }

            Console.WriteLine("\n✅ CÁC THAO TÁC VỚI FILE CƠ BẢN HOÀN TẤT!");
            Console.WriteLine("💡 Lưu ý: Luôn sử dụng try-catch khi làm việc với file!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n❌ Lỗi: {ex.Message}");
        }
        finally
        {
            // Dọn dẹp file test còn sót lại
            try
            {
                if (File.Exists(fileName)) File.Delete(fileName);
            }
            catch { }
        }
    }

    // ============================================
    // 9. XỬ LÝ NGOẠI LỆ (EXCEPTION HANDLING)
    // ============================================
    static void ExceptionHandling()
    {
        Console.WriteLine("\n--- 9. XỬ LÝ NGOẠI LỆ (EXCEPTION) ---");

        Console.WriteLine("\n📚 EXCEPTION LÀ GÌ?");
        Console.WriteLine("  - Ngoại lệ là lỗi xảy ra trong quá trình chạy chương trình");
        Console.WriteLine("  - Sử dụng try-catch-finally để xử lý lỗi");
        Console.WriteLine("  - Giúp chương trình không bị crash và xử lý lỗi một cách ổn định\n");

        // ===== 1. TRY-CATCH CƠ BẢN =====
        Console.WriteLine("\n1️⃣ TRY-CATCH CƠ BẢN:");
        try
        {
            int[] numbers = { 1, 2, 3 };
            Console.WriteLine($"   Phần tử [5]: {numbers[5]}"); // Lỗi: Index ngoài phạm vi
        }
        catch (Exception ex)
        {
            Console.WriteLine($"   ❌ Lỗi: {ex.Message}");
            Console.WriteLine($"   ✓ Chương trình vẫn chạy tiếp!");
        }

        // ===== 2. NHIỀU CATCH BLOCKS =====
        Console.WriteLine("\n2️⃣ NHIỀU CATCH BLOCKS (Xử lý từng loại lỗi):");
        try
        {
            Console.Write("   Nhập số (test nhập chữ để thấy lỗi): ");
            // Tự động nhập "abc" để demo
            string input = "abc";
            Console.WriteLine(input);
            int number = int.Parse(input);
            int divResult = 100 / number; // Đổi tên biến
            Console.WriteLine($"   Kết quả: {divResult}");
        }
        catch (FormatException)
        {
            Console.WriteLine("   ❌ Lỗi: Phải nhập số, không được nhập chữ!");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("   ❌ Lỗi: Không thể chia cho 0!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"   ❌ Lỗi khác: {ex.Message}");
        }

        // ===== 3. TRY-CATCH-FINALLY =====
        Console.WriteLine("\n3️⃣ TRY-CATCH-FINALLY:");
        StreamReader reader = null;
        try
        {
            reader = new StreamReader("khong_ton_tai.txt");
            Console.WriteLine(reader.ReadToEnd());
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("   ❌ Lỗi: File không tồn tại!");
        }
        finally
        {
            // Finally luôn chạy dù có lỗi hay không
            reader?.Close();
            Console.WriteLine("   ✓ Finally: Đã đóng file (nếu có)");
        }

        // ===== 4. CÁC LOẠI EXCEPTION THƯỜNG GẶP =====
        Console.WriteLine("\n4️⃣ CÁC LOẠI EXCEPTION THƯỜNG GẶP:");

        // 4.1. NullReferenceException
        Console.WriteLine("\n   • NullReferenceException:");
        try
        {
            string text = null;
            int textLength = text.Length; // Lỗi: text là null (đổi tên biến)
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("     ❌ Lỗi: Đối tượng null, không thể truy cập thuộc tính!");
        }

        // 4.2. IndexOutOfRangeException
        Console.WriteLine("\n   • IndexOutOfRangeException:");
        try
        {
            int[] arr = { 1, 2, 3 };
            int value = arr[10]; // Lỗi: Index ngoài phạm vi
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("  ❌ Lỗi: Index vượt quá kích thước mảng!");
        }

        // 4.3. InvalidOperationException
        Console.WriteLine("\n   • InvalidOperationException:");
        try
        {
            List<int> emptyList = new List<int>();
            int first = emptyList.First(); // Lỗi: List rỗng
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("     ❌ Lỗi: Không thể lấy phần tử từ danh sách rỗng!");
        }

        // 4.4. ArgumentException
        Console.WriteLine("\n   • ArgumentException:");
        try
        {
            ThrowArgumentException(-5); // Gọi hàm với tham số không hợp lệ
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"     ❌ Lỗi: {ex.Message}");
        }

        // 4.5. OverflowException
        Console.WriteLine("\n   • OverflowException:");
        try
        {
            checked // Bật kiểm tra overflow
            {
                int max = int.MaxValue;
                int overflow = max + 1; // Lỗi: Vượt giá trị tối đa
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("     ❌ Lỗi: Số quá lớn, vượt giới hạn kiểu dữ liệu!");
        }

        // ===== 5. THROW - NÉM EXCEPTION =====
        Console.WriteLine("\n5️⃣ THROW - NÉM EXCEPTION:");
        try
        {
            CheckAge(15); // Gọi hàm kiểm tra tuổi
        }
        catch (Exception ex)
        {
            Console.WriteLine($"   ❌ {ex.Message}");
        }

        // ===== 6. TẠO CUSTOM EXCEPTION =====
        Console.WriteLine("\n6️⃣ CUSTOM EXCEPTION (Tự tạo Exception):");
        try
        {
            ValidateScore(105); // Điểm không hợp lệ
        }
        catch (InvalidScoreException ex)
        {
            Console.WriteLine($"   ❌ {ex.Message}");
            Console.WriteLine($"   Chi tiết: Điểm nhập vào = {ex.InvalidScore}");
        }

        // ===== 7. USING STATEMENT (Tự động dispose) =====
        Console.WriteLine("\n7️⃣ USING STATEMENT (Tự động dọn dẹp):");
        try
        {
            // using tự động gọi Dispose() khi kết thúc
            using (StreamWriter writer = new StreamWriter("test_exception.txt"))
            {
                writer.WriteLine("Test exception handling");
                Console.WriteLine("   ✓ Đã ghi file với using statement");
            } // Tự động đóng file ở đây

            // Xóa file test
            if (File.Exists("test_exception.txt"))
                File.Delete("test_exception.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine($" ❌ Lỗi: {ex.Message}");
        }

        // ===== 8. TRY-CATCH TRONG METHOD =====
        Console.WriteLine("\n8️⃣ XỬ LÝ EXCEPTION TRONG METHOD:");
        int result = SafeDivide(10, 2);
        Console.WriteLine($"   10 / 2 = {result}");

        result = SafeDivide(10, 0);
        Console.WriteLine($"   10 / 0 = {result}");

        // ===== 9. KIỂM TRA NULL VỚI ? VÀ ?? =====
        Console.WriteLine("\n9️⃣ TRÁNH NULL VỚI ? VÀ ?? OPERATORS:");

        string nullString = null;
        // ? (Null-conditional): Trả về null nếu object là null
        int? length = nullString?.Length;
        Console.WriteLine($"   Length với '?': {length ?? -1}");

        // ?? (Null-coalescing): Trả về giá trị mặc định nếu null
        string name = nullString ?? "Không có tên";
        Console.WriteLine($" Name với '??': {name}");

        // ===== 10. TRY-PARSE (TRÁNH EXCEPTION KHI PARSE) =====
        Console.WriteLine("\n🔟 TRY-PARSE (An toàn hơn Parse):");

        string validNumber = "123";
        string invalidNumber = "abc";

        // Parse: Throw exception nếu lỗi
        Console.WriteLine(" • Dùng Parse (có thể lỗi):");
        try
        {
            int num1 = int.Parse(validNumber);
            Console.WriteLine($"     Parse '{validNumber}': {num1}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  Lỗi: {ex.Message}");
        }

        // TryParse: Trả về bool, không throw exception
        Console.WriteLine("\n   • Dùng TryParse (an toàn):");
        if (int.TryParse(validNumber, out int num2))
        {
            Console.WriteLine($"     TryParse '{validNumber}': {num2} ✓");
        }

        if (int.TryParse(invalidNumber, out int num3))
        {
            Console.WriteLine($"  TryParse '{invalidNumber}': {num3}");
        }
        else
        {
            Console.WriteLine($"     TryParse '{invalidNumber}': Không hợp lệ ❌");
        }

        // ===== 11. BẢNG TỔNG KẾT CÁC EXCEPTION =====
        Console.WriteLine("\n1️⃣1️⃣ BẢNG CÁC EXCEPTION THƯỜNG GẶP:");
        Console.WriteLine("┌─────────────────────────────┬────────────────────────────────────┐");
        Console.WriteLine("│ Exception                   │ Nguyên nhân                        │");
        Console.WriteLine("├─────────────────────────────┼────────────────────────────────────┤");
        Console.WriteLine("│ NullReferenceException      │ Truy cập object null               │");
        Console.WriteLine("│ IndexOutOfRangeException    │ Index vượt quá mảng                │");
        Console.WriteLine("│ DivideByZeroException       │ Chia cho 0                         │");
        Console.WriteLine("│ FormatException             │ Parse sai định dạng                │");
        Console.WriteLine("│ FileNotFoundException       │ File không tồn tại                 │");
        Console.WriteLine("│ InvalidOperationException   │ Thao tác không hợp lệ              │");
        Console.WriteLine("│ ArgumentException           │ Tham số không hợp lệ               │");
        Console.WriteLine("│ OverflowException           │ Vượt giới hạn kiểu dữ liệu         │");
        Console.WriteLine("└─────────────────────────────┴────────────────────────────────────┘");

        Console.WriteLine("\n✅ BEST PRACTICES:");
        Console.WriteLine("   1. Luôn xử lý exception có thể xảy ra");
        Console.WriteLine("   2. Catch exception cụ thể trước, Exception chung sau");
        Console.WriteLine("   3. Dùng finally để dọn dẹp resources");
        Console.WriteLine("   4. Dùng using statement cho IDisposable objects");
        Console.WriteLine("   5. Dùng TryParse thay vì Parse khi có thể");
        Console.WriteLine("   6. Dùng ?. và ?? để tránh NullReferenceException");
        Console.WriteLine("   7. Throw exception khi phát hiện lỗi logic");
    }

    // Helper methods cho Exception examples
    static void ThrowArgumentException(int age)
    {
        if (age < 0)
        {
            throw new ArgumentException("Tuổi không được âm!", nameof(age));
        }
    }

    static void CheckAge(int age)
    {
        if (age < 18)
        {
            throw new Exception("Tuổi phải >= 18!");
        }
        Console.WriteLine($"   ✓ Tuổi hợp lệ: {age}");
    }

    static void ValidateScore(double score)
    {
        if (score < 0 || score > 10)
        {
            throw new InvalidScoreException(score);
        }
        Console.WriteLine($"   ✓ Điểm hợp lệ: {score}");
    }

    static int SafeDivide(int a, int b)
    {
        try
        {
            return a / b;
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("   ⚠️ Cảnh báo: Chia cho 0, trả về 0");
            return 0;
        }
    }

    // ============================================
    // 10. LAMBDA EXPRESSION (BIỂU THỨC LAMBDA)
    // ============================================
    static void LambdaExpressions()
    {
        Console.WriteLine("\n--- 10. LAMBDA EXPRESSION ---");

        Console.WriteLine("\n📚 LAMBDA LÀ GÌ?");
        Console.WriteLine("  - Biểu thức Lambda là cách viết hàm ngắn gọn (anonymous function)");
        Console.WriteLine("  - Cú pháp: (tham_số) => biểu_thức_hoặc_khối_lệnh");
        Console.WriteLine("  - Thường dùng với LINQ, Delegate, Event");
        Console.WriteLine("  - Giúp code ngắn gọn và dễ đọc hơn\n");

        // ===== 1. LAMBDA CƠ BẢN =====
        Console.WriteLine("\n1️⃣ LAMBDA CƠ BẢN:");

        // Lambda không tham số, Tham số cuối cùng của Func luôn là kiểu trả về.
        // Func = dùng khi lambda trả về một giá trị (giống như method thông thường có return).
        Func<string> sayHello = () => "Xin chào!";
        Console.WriteLine($"   Lambda không tham số: {sayHello()}");

        // Lambda 1 tham số (có thể bỏ dấu ngoặc)
        Func<int, int> square = x => x * x;
        Console.WriteLine($"   Bình phương của 5: {square(5)}");

        // Lambda nhiều tham số
        Func<int, int, int> add = (a, b) => a + b;
        Console.WriteLine($"   10 + 20 = {add(10, 20)}");

        // Lambda với statement body (nhiều dòng)
        Func<int, int, string> compare = (a, b) =>
              {
                  if (a > b) return $"{a} lớn hơn {b}";
                  if (a < b) return $"{a} nhỏ hơn {b}";
                  return $"{a} bằng {b}";
              };
        Console.WriteLine($"   So sánh 10 và 20: {compare(10, 20)}");

        // ===== 2. LAMBDA VỚI ACTION =====
        Console.WriteLine("\n2️⃣ LAMBDA VỚI ACTION (không return):");

        // Action không tham số, hàm không trả về gì, chỉ có thể in, hoặc thực hiện hành động nào đó
        // Action = dùng khi bạn chỉ muốn thực hiện hành động (side effect) mà không cần giá trị trả về.
        Action greet = () => Console.WriteLine("   Chào bạn!");
        greet();

        // Action 1 tham số
        Action<string> printName = name => Console.WriteLine($"   Tên: {name}");
        printName("Nguyễn Văn A");

        // Action nhiều tham số
        Action<string, int> printInfo = (name, age) =>
                  Console.WriteLine($"   {name}, {age} tuổi");
        printInfo("Trần Thị B", 25);

        // ===== 3. LAMBDA VỚI FUNC =====
        Console.WriteLine("\n3️⃣ LAMBDA VỚI FUNC (có return):");

        // Func<TResult> - không tham số, có return
        Func<int> getRandomNumber = () => new Random().Next(1, 100);
        Console.WriteLine($"   Số ngẫu nhiên: {getRandomNumber()}");

        // Func<T, TResult> - 1 tham số
        Func<int, bool> isEven = n => n % 2 == 0;
        Console.WriteLine($"   10 là số chẵn: {isEven(10)}");

        // Func<T1, T2, TResult> - nhiều tham số
        Func<double, double, double> calculateArea = (width, height) => width * height;
        Console.WriteLine($"   Diện tích (5 x 3): {calculateArea(5, 3)}");

        // Func<T1, T2, T3, TResult> - 3 tham số
        Func<int, int, int, double> average = (a, b, c) => (a + b + c) / 3.0;
        Console.WriteLine($"   Trung bình (10, 20, 30): {average(10, 20, 30):F2}");

        // ===== 4. LAMBDA VỚI LINQ =====
        Console.WriteLine("\n4️⃣ LAMBDA VỚI LINQ:");

        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Where với lambda
        var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
        Console.WriteLine($"   Số chẵn: [{string.Join(", ", evenNumbers)}]");

        // Select với lambda
        var squared = numbers.Select(n => n * n).ToList();
        Console.WriteLine($"   Bình phương: [{string.Join(", ", squared)}]");

        // OrderBy với lambda
        var descending = numbers.OrderByDescending(n => n).Take(3).ToList();
        Console.WriteLine($"   Top 3 lớn nhất: [{string.Join(", ", descending)}]");

        // Any với lambda
        bool hasGreaterThan5 = numbers.Any(n => n > 5);
        Console.WriteLine($"   Có số > 5: {hasGreaterThan5}");

        // All với lambda
        bool allPositive = numbers.All(n => n > 0);
        Console.WriteLine($"   Tất cả > 0: {allPositive}");

        // ===== 5. LAMBDA VỚI LIST =====
        Console.WriteLine("\n5️⃣ LAMBDA VỚI LIST METHODS:");

        List<string> names = new List<string> { "An", "Bình", "Chi", "Dũng", "Em" };

        // Find - tìm phần tử đầu tiên thỏa điều kiện
        string foundName = names.Find(n => n.StartsWith("C"));
        Console.WriteLine($"   Tên bắt đầu bằng 'C': {foundName}");

        // FindAll - tìm tất cả thỏa điều kiện
        var shortNames = names.FindAll(n => n.Length <= 3);
        Console.WriteLine($"   Tên <= 3 ký tự: [{string.Join(", ", shortNames)}]");

        // Exists - kiểm tra tồn tại
        bool exists = names.Exists(n => n == "Bình");
        Console.WriteLine($"   Có tên 'Bình': {exists}");

        // ForEach - thực hiện action cho mỗi phần tử
        Console.Write("   In tất cả tên: ");
        names.ForEach(n => Console.Write($"{n} "));
        Console.WriteLine();

        // RemoveAll - xóa tất cả thỏa điều kiện
        List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
        nums.RemoveAll(n => n % 2 == 0); // Xóa số chẵn
        Console.WriteLine($"   Sau khi xóa số chẵn: [{string.Join(", ", nums)}]");

        // ===== 6. LAMBDA VỚI OBJECT =====
        Console.WriteLine("\n6️⃣ LAMBDA VỚI OBJECT:");

        List<Student2> students = new List<Student2>
        {
            new Student2 { Id = 1, Name = "An", Age = 20, Score = 8.5 },
            new Student2 { Id = 2, Name = "Bình", Age = 22, Score = 7.0 },
            new Student2 { Id = 3, Name = "Chi", Age = 19, Score = 9.0 },
            new Student2 { Id = 4, Name = "Dũng", Age = 21, Score = 6.5 },
            new Student2 { Id = 5, Name = "Em", Age = 20, Score = 8.0 }
        };

        // Lọc sinh viên điểm >= 8
        var topStudents = students.Where(s => s.Score >= 8.0).ToList();
        Console.WriteLine("   Sinh viên giỏi:");
        topStudents.ForEach(s => Console.WriteLine($"     {s.Name}: {s.Score}"));

        // Sắp xếp theo tuổi
        var sortedByAge = students.OrderBy(s => s.Age).ThenByDescending(s => s.Score).ToList();
        Console.WriteLine("\n   Sắp xếp theo tuổi, điểm:");
        sortedByAge.ForEach(s => Console.WriteLine($"     {s.Name} - {s.Age} tuổi, {s.Score} điểm"));

        // Tính điểm trung bình
        double averageScore = students.Average(s => s.Score);
        Console.WriteLine($"\n   Điểm trung bình: {averageScore:F2}");

        // Tìm sinh viên điểm cao nhất
        var topStudent = students.OrderByDescending(s => s.Score).First();
        Console.WriteLine($"   Sinh viên điểm cao nhất: {topStudent.Name} - {topStudent.Score}");

        // ===== 7. LAMBDA VỚI PREDICATE =====
        Console.WriteLine("\n7️⃣ LAMBDA VỚI PREDICATE:");

        // Predicate<T> - delegate trả về bool, hàm kiểm tra điều kiện (trả về bool)
        // Dùng khi bạn muốn kiểm tra điều kiện đúng/sai (đặc biệt trong LINQ hoặc List methods).
        // Predicate<T> = Func<T, bool> — nhưng dùng để lọc, kiểm tra điều kiện.
        Predicate<int> isPositive = n => n > 0;
        Predicate<string> isLongName = name => name.Length > 5;

        Console.WriteLine($"   10 là số dương: {isPositive(10)}");
        Console.WriteLine($"   'Nguyễn Văn A' là tên dài: {isLongName("Nguyễn Văn A")}");

        // Dùng với List.FindAll
        List<int> mixedNumbers = new List<int> { -5, 3, -2, 7, -8, 10 };
        var positives = mixedNumbers.FindAll(isPositive);
        Console.WriteLine($"   Số dương: [{string.Join(", ", positives)}]");

        // ===== 8. CLOSURE - LAMBDA CAPTURE BIẾN =====
        Console.WriteLine("\n8️⃣ CLOSURE (Lambda bắt biến ngoài):");

        int multiplier = 10;
        Func<int, int> multiply = x => x * multiplier;
        Console.WriteLine($"   5 * {multiplier} = {multiply(5)}");

        multiplier = 20; // Thay đổi biến ngoài
        Console.WriteLine($"   5 * {multiplier} = {multiply(5)}"); // Lambda dùng giá trị mới

        // Ví dụ closure phức tạp
        Func<int, Func<int, int>> createMultiplier = factor => x => x * factor;
        var multiplyBy3 = createMultiplier(3);
        var multiplyBy5 = createMultiplier(5);
        Console.WriteLine($"   10 * 3 = {multiplyBy3(10)}");
        Console.WriteLine($"   10 * 5 = {multiplyBy5(10)}");

        // ===== 9. LAMBDA VỚI EVENT =====
        Console.WriteLine("\n9️⃣ LAMBDA VỚI EVENT:");

        var button = new Button();

        // Subscribe event với lambda
        button.Clicked += () => Console.WriteLine("   Button clicked!");
        button.Clicked += () => Console.WriteLine("   Đã nhấn nút!");

        button.Click(); // Trigger event

        // ===== 10. LAMBDA VS NORMAL METHOD =====
        Console.WriteLine("\n🔟 SO SÁNH LAMBDA VS NORMAL METHOD:");

        List<int> testNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Cách 1: Dùng method thông thường
        Console.WriteLine("\n   • Cách 1: Dùng method thông thường:");
        var evenMethod = testNumbers.Where(IsEvenNumber).ToList();
        Console.WriteLine($"     Số chẵn: [{string.Join(", ", evenMethod)}]");

        // Cách 2: Dùng lambda (ngắn gọn hơn)
        Console.WriteLine("\n   • Cách 2: Dùng lambda:");
        var evenLambda = testNumbers.Where(n => n % 2 == 0).ToList();
        Console.WriteLine($"     Số chẵn: [{string.Join(", ", evenLambda)}]");

        // ===== 11. EXPRESSION TREE =====
        Console.WriteLine("\n1️⃣1️⃣ EXPRESSION TREE:");

        // Lambda thường
        Func<int, int, int> addFunc = (a, b) => a + b;
        Console.WriteLine($"   Lambda thường: 5 + 3 = {addFunc(5, 3)}");

        // Expression tree (dùng cho LINQ to SQL, EF)
        Expression<Func<int, int, int>> addExpr = (a, b) => a + b;
        var compiled = addExpr.Compile();
        Console.WriteLine($"   Expression tree: 5 + 3 = {compiled(5, 3)}");
        Console.WriteLine($"   Biểu thức: {addExpr}");

        // ===== 12. BEST PRACTICES =====
        Console.WriteLine("\n1️⃣2️⃣ BEST PRACTICES:");
        Console.WriteLine("   ✅ Dùng lambda cho logic đơn giản (1-2 dòng)");
        Console.WriteLine("   ✅ Dùng method riêng cho logic phức tạp");
        Console.WriteLine("   ✅ Tên biến lambda nên ngắn gọn (x, n, s...)");
        Console.WriteLine("   ✅ Tránh lambda quá dài, khó đọc");
        Console.WriteLine("   ✅ Ưu tiên lambda với LINQ");
        Console.WriteLine("   ✅ Cẩn thận với closure (biến ngoài)");
        Console.WriteLine("   ✅ Dùng Expression Tree khi cần phân tích code");

        // ===== 13. CÚ PHÁP LAMBDA =====
        Console.WriteLine("\n1️⃣3️⃣ TỔNG KẾT CÚ PHÁP:");
        Console.WriteLine("   • Không tham số:        () => biểu_thức");
        Console.WriteLine("   • 1 tham số:  x => biểu_thức");
        Console.WriteLine("   • Nhiều tham số:        (x, y) => biểu_thức");
        Console.WriteLine("   • Statement body:  (x) => { lệnh1; lệnh2; return kết_quả; }");
        Console.WriteLine("   • Rõ ràng kiểu:         (int x, int y) => x + y");
        Console.WriteLine("   • Discard parameter:(_, y) => y * 2");

        Console.WriteLine("\n✅ LAMBDA LÀ CÔNG CỤ MẠNH MẼ, GIÚP CODE NGẮN GỌN VÀ LINH HOẠT!");
    }

    // Helper method để so sánh với lambda
    static bool IsEvenNumber(int n)
    {
        return n % 2 == 0;
    }
}

// ============================================
// CLASS HỖ TRỢ CHO LAMBDA EVENT
// ============================================
class Button
{
    public event Action Clicked;

    public void Click()
    {
        Clicked?.Invoke();
    }
}

// ============================================
// CUSTOM EXCEPTION CLASS
// ============================================
class InvalidScoreException : Exception
{
    public double InvalidScore { get; }

    public InvalidScoreException(double score)
    : base($"Điểm không hợp lệ! Điểm phải từ 0-10, nhận được: {score}")
    {
        InvalidScore = score;
    }
}

// ============================================
// CLASS - LỚP CƠ BẢN
// ============================================
class Person
{
    // Fields (Trường)
    private string name;
    private int age;

    // Constructor (Hàm khởi tạo)
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    // Properties (Thuộc tính)
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value >= 0 ? value : 0; }
    }

    // Method (Phương thức)
    public void Introduce()
    {
        Console.WriteLine($"Tôi là {name}, {age} tuổi.");
    }
}

// ============================================
// INHERITANCE - KẾ THỪA
// ============================================
class Student : Person
{
    public string StudentId { get; set; }

    public Student(string name, int age, string studentId) : base(name, age)
    {
        StudentId = studentId;
    }

    public void Study()
    {
        Console.WriteLine($"Sinh viên {Name} (ID: {StudentId}) đang học bài.");
    }
}

// ============================================
// CLASS HỖ TRỢ CHO LINQ
// ============================================
class Student2
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public double Score { get; set; }
}

class Course
{
    public int StudentId { get; set; }
    public string CourseName { get; set; }
}

// ============================================
// INTERFACE
// ============================================
interface IVehicle
{
    void Start();
    void Stop();
}

class Car : IVehicle
{
    public void Start()
    {
        Console.WriteLine("Xe ô tô đã khởi động.");
    }

    public void Stop()
    {
        Console.WriteLine("Xe ô tô đã dừng lại.");
    }
}
