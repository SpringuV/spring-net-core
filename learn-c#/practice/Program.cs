// ============================================
// BÀI TẬP LUYỆN TẬP COLLECTIONS C#
// ============================================

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("+--------------------------------------------------------+");
        Console.WriteLine("|     BÀI TẬP LUYỆN TẬP COLLECTIONS & LINQ - C#         |");
        Console.WriteLine("+--------------------------------------------------------+\n");

        // Uncomment từng bài để làm
        Bai1_ArrayBasic();
        Bai2_ListBasic();
        Bai3_DictionaryBasic();
        Bai4_LinqWhere();
        Bai5_LinqSelect();
        Bai6_LinqOrderBy();
        Bai7_LinqGroupBy();
        Bai8_LinqAggregate();
        Bai9_LinqComplex();
        Bai10_RealWorldProblem();

        Console.WriteLine("\n📚 Hướng dẫn: Uncomment từng bài để làm!");
        Console.ReadKey();
    }

    // ============================================
    // BÀI 1: MẢNG CƠ BẢN (ARRAY)
    // ============================================
    static void Bai1_ArrayBasic()
    {
        Console.WriteLine("\n════════════════════════════════════════════");
        Console.WriteLine("│ BÀI 1: MẢNG CƠ BẢN (ARRAY)");
        Console.WriteLine("════════════════════════════════════════════\n");

        // TODO 1.1: Tạo mảng số nguyên từ 1 đến 10
        Console.WriteLine("📝 Câu 1: Tạo mảng numbers chứa số từ 1 đến 10");
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; // TODO: Viết code ở đây
        Console.WriteLine($"Mảng: [{string.Join(", ", numbers)}]");

        // TODO 1.2: Tìm số lớn nhất trong mảng
        Console.WriteLine("\n📝 Câu 2: Tìm số lớn nhất trong mảng");
        int max = 0; // TODO: Viết code tìm max
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }
        Console.WriteLine($"Số lớn nhất: {max}");

        // TODO 1.3: Tính tổng các số chẵn trong mảng
        Console.WriteLine("\n📝 Câu 3: Tính tổng các số chẵn");
        int sumEven = numbers.Where(n => n % 2 == 0).Sum(); // TODO: Viết code tính tổng
        Console.WriteLine($"Tổng số chẵn: {sumEven}");

        // TODO 1.4: Đảo ngược mảng
        Console.WriteLine("\n📝 Câu 4: Đảo ngược mảng");
        // TODO: Viết code đảo ngược
        int[] numberReverse = numbers.Reverse().ToArray();
        Console.WriteLine($"Mảng đảo ngược: [{string.Join(", ", numberReverse)}]");

        // TODO 1.5: Tạo mảng 2 chiều 3x3 và tính tổng các phần tử
        Console.WriteLine("\n📝 Câu 5: Tạo ma trận 3x3 và tính tổng");
        int[,] matrix =
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 },
        };
        int sumMatrix = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sumMatrix += matrix[i, j];
            }
        }
        // TODO: Tính tổng
        Console.WriteLine($"Tổng ma trận: {sumMatrix}");

        Console.WriteLine("\n✅ Hoàn thành Bài 1!");
    }

    // ============================================
    // BÀI 2: DANH SÁCH (LIST)
    // ============================================
    static void Bai2_ListBasic()
    {
        Console.WriteLine("\n════════════════════════════════════════════");
        Console.WriteLine("│ BÀI 2: DANH SÁCH (LIST)");
        Console.WriteLine("════════════════════════════════════════════\n");

        // TODO 2.1: Tạo List tên học sinh
        Console.WriteLine("📝 Câu 1: Tạo List chứa 5 tên học sinh");
        List<string> students = new List<string> { "Bình", "An", "Thảo", "Anh", "Tuấn" }; // TODO: Viết code
        Console.WriteLine($"Danh sách: {string.Join(", ", students)}");

        // TODO 2.2: Thêm 2 học sinh mới vào cuối List
        Console.WriteLine("\n📝 Câu 2: Thêm 2 học sinh mới");
        // TODO: Viết code thêm
        students.Add("Huy");
        students.Add("Lan");
        Console.WriteLine($"Sau khi thêm: {string.Join(", ", students)}");

        // TODO 2.3: Xóa học sinh đầu tiên
        Console.WriteLine("\n📝 Câu 3: Xóa học sinh đầu tiên");
        // TODO: Viết code xóa
        students.RemoveAt(0);
        Console.WriteLine($"Sau khi xóa: {string.Join(", ", students)}");

        // TODO 2.4: Kiểm tra xem có học sinh tên "An" không
        Console.WriteLine("\n📝 Câu 4: Kiểm tra có học sinh tên 'An'");
        bool hasAn = students.Any(s => s == "An"); // TODO: Viết code kiểm tra
        Console.WriteLine($"Có tên An không?: {(hasAn ? "Có" : "Không")}");

        // TODO 2.5: Tạo List điểm số và tìm điểm trung bình
        Console.WriteLine("\n📝 Câu 5: Tính điểm trung bình");
        List<double> scores = new List<double> { 8.5, 7.0, 9.0, 6.5, 8.0 };
        double average = scores.Average(); // TODO: Tính trung bình
        Console.WriteLine($"Điểm trung bình: {average:F2}");

        Console.WriteLine("\n✅ Hoàn thành Bài 2!");
    }

    // ============================================
    // BÀI 3: TỪ ĐIỂN (DICTIONARY)
    // ============================================
    static void Bai3_DictionaryBasic()
    {
        Console.WriteLine("\n════════════════════════════════════════════");
        Console.WriteLine("│ BÀI 3: TỪ ĐIỂN (DICTIONARY)");
        Console.WriteLine("════════════════════════════════════════════\n");

        // TODO 3.1: Tạo Dictionary lưu tên và tuổi
        Console.WriteLine("📝 Câu 1: Tạo Dictionary<string, int> lưu tên và tuổi của 5 người");
        Dictionary<string, int> ages = new Dictionary<string, int> { { "An", 12 }, { "Bình", 14 }, { "Thành", 25 }, { "Tuấn", 32 }, { "Huyền", 23 } }; // TODO: Viết code
        foreach (var obj in ages)
        {
            Console.WriteLine($"{obj.Key}: {obj.Value} tuổi");
        }

        // TODO 3.2: Thêm 2 người mới
        Console.WriteLine("\n📝 Câu 2: Thêm 2 người mới vào Dictionary");
        ages.Add("Lan", 22);
        ages.Add("Phúc", 28);
        // TODO: Viết code thêm

        // TODO 3.3: Lấy tuổi của một người cụ thể
        Console.WriteLine("\n📝 Câu 3: Lấy tuổi của 'An'");
        int ageOfAn = ages.Where(obj => obj.Key.Equals("An")).First().Value; // TODO: Viết code lấy tuổi
        Console.WriteLine($"Tuổi của An: {ageOfAn}");

        // TODO 3.4: Cập nhật tuổi của một người
        Console.WriteLine("\n📝 Câu 4: Cập nhật tuổi của 'Bình' thành 31");
        ages["Bình"] = 31;
        // TODO: Viết code cập nhật
        foreach (var obj in ages)
        {
            Console.WriteLine($"{obj.Key}: {obj.Value} tuổi");
        }

        // TODO 3.5: Tìm người có tuổi lớn nhất
        Console.WriteLine("\n📝 Câu 5: Tìm người có tuổi lớn nhất");
        int maxValue = ages.Max(obj => obj.Value);
        var oldestPerson = ages.First(obj => obj.Value == maxValue); // TODO: Viết code tìm
        Console.WriteLine($"Người lớn tuổi nhất: {oldestPerson.Key} ({oldestPerson.Value} tuổi)");

        Console.WriteLine("\n✅ Hoàn thành Bài 3!");
    }

    // ============================================
    // BÀI 4: LINQ - WHERE (LỌC DỮ LIỆU)
    // ============================================
    static void Bai4_LinqWhere()
    {
        Console.WriteLine("\n════════════════════════════════════════════");
        Console.WriteLine("│ BÀI 4: LINQ - WHERE (LỌC DỮ LIỆU)");
        Console.WriteLine("════════════════════════════════════════════\n");

        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 15, 20, 25, 30 };

        // TODO 4.1: Lọc các số lẻ
        Console.WriteLine("📝 Câu 1: Lọc các số lẻ");
        var oddNumbers = new List<int>(numbers).Where(num => num % 2 == 1); // TODO: Dùng LINQ Where
        Console.WriteLine($"Số lẻ: [{string.Join(", ", oddNumbers)}]");

        // TODO 4.2: Lọc các số lớn hơn 10
        Console.WriteLine("\n📝 Câu 2: Lọc các số > 10");
        var greaterThan10 = new List<int>(numbers).Where(num => num > 10); // TODO: Dùng LINQ Where
        Console.WriteLine($"Số > 10: [{string.Join(", ", greaterThan10)}]");

        // TODO 4.3: Lọc các số chia hết cho 5
        Console.WriteLine("\n📝 Câu 3: Lọc số chia hết cho 5");
        var divisibleBy5 = new List<int>(numbers).Where(num => num % 5 == 0); // TODO: Dùng LINQ Where
        Console.WriteLine($"Chia hết 5: [{string.Join(", ", divisibleBy5)}]");

        // TODO 4.4: Lọc sinh viên điểm >= 8.0
        Console.WriteLine("\n📝 Câu 4: Lọc sinh viên điểm >= 8.0");
        var students = CreateStudentList();
        var topStudents = new List<StudentModel>(students).Where(stu => stu.Score >= 8.0); // TODO: Dùng LINQ Where
        foreach (var s in topStudents)
            Console.WriteLine($"{s.Name}: {s.Score}");

        // TODO 4.5: Lọc sinh viên tuổi 20-22
        Console.WriteLine("\n📝 Câu 5: Lọc sinh viên tuổi từ 20-22");
        var youngStudents = new List<StudentModel>(students).Where(stu => stu.Age >= 20 && stu.Age <= 22); // TODO: Dùng LINQ Where
        foreach (var s in youngStudents)
            Console.WriteLine($"{s.Name}: {s.Age} tuổi");

        Console.WriteLine("\n✅ Hoàn thành Bài 4!");
    }

    // ============================================
    // BÀI 5: LINQ - SELECT (BIẾN ĐỔI DỮ LIỆU)
    // ============================================
    static void Bai5_LinqSelect()
    {
        Console.WriteLine("\n════════════════════════════════════════════");
        Console.WriteLine("│ BÀI 5: LINQ - SELECT (BIẾN ĐỔI)");
        Console.WriteLine("════════════════════════════════════════════\n");

        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
        var students = CreateStudentList();

        // TODO 5.1: Lấy bình phương của các số
        Console.WriteLine("📝 Câu 1: Tạo List bình phương các số");
        var squared = new List<int>(numbers).Select(num => num * num); // TODO: Dùng LINQ Select
        Console.WriteLine($"Bình phương: [{string.Join(", ", squared)}]");

        // TODO 5.2: Lấy danh sách tên sinh viên
        Console.WriteLine("\n📝 Câu 2: Lấy danh sách tên sinh viên");
        var names = new List<string>(students.Select(stu => stu.Name)); // TODO: Dùng LINQ Select
        Console.WriteLine($"Tên: {string.Join(", ", names)}");

        // TODO 5.3: Tạo object mới với tên và xếp loại
        Console.WriteLine("\n📝 Câu 3: Tạo object mới {Name, Grade}");
        // Grade: >= 8.5: "A", >= 8.0: "B", >= 7.0: "C", còn lại: "D"
        var studentGrades = new List<object>(students.Select(stu => new
        {
            stu.Name,
            Grade = stu.Score >= 8.5 ? "A" : stu.Score >= 8.0 ? "B" : stu.Score >= 7.0 ? "C" : "D"
        }
        )); // TODO: Dùng LINQ Select với anonymous type
        foreach (var sg in studentGrades)
            Console.WriteLine(sg);

        // TODO 5.4: Chuyển số thành chuỗi có định dạng
        Console.WriteLine("\n📝 Câu 4: Chuyển số thành 'Số: X'");
        var numberStrings = numbers.Select(n => $"Số: {n}").ToList(); // TODO: Dùng LINQ Select
        Console.WriteLine(string.Join(", ", numberStrings));

        // TODO 5.5: Tính điểm thưởng (điểm gốc + 0.5)
        Console.WriteLine("\n📝 Câu 5: Tính điểm thưởng cho sinh viên");
        var bonusScores = new List<double>(students.Select(stu => stu.Score + 0.5)); // TODO: Dùng LINQ Select
        Console.WriteLine($"Điểm thưởng: [{string.Join(", ", bonusScores)}]");

        Console.WriteLine("\n✅ Hoàn thành Bài 5!");
    }

    // ============================================
    // BÀI 6: LINQ - ORDERBY (SẮP XẾP)
    // ============================================
    static void Bai6_LinqOrderBy()
    {
        Console.WriteLine("\n════════════════════════════════════════════");
        Console.WriteLine("│ BÀI 6: LINQ - ORDERBY (SẮP XẾP)");
        Console.WriteLine("════════════════════════════════════════════\n");

        List<int> numbers = new List<int> { 5, 2, 8, 1, 9, 3, 7, 4, 6 };
        var students = CreateStudentList();

        // TODO 6.1: Sắp xếp số tăng dần
        Console.WriteLine("📝 Câu 1: Sắp xếp số tăng dần");
        var ascending = new List<int>(numbers).OrderBy(num => num); // TODO: Dùng LINQ OrderBy
        Console.WriteLine($"Tăng dần: [{string.Join(", ", ascending)}]");

        // TODO 6.2: Sắp xếp số giảm dần
        Console.WriteLine("\n📝 Câu 2: Sắp xếp số giảm dần");
        var descending = new List<int>(numbers).OrderByDescending(num => num); // TODO: Dùng LINQ OrderByDescending
        Console.WriteLine($"Giảm dần: [{string.Join(", ", descending)}]");

        // TODO 6.3: Sắp xếp sinh viên theo điểm giảm dần
        Console.WriteLine("\n📝 Câu 3: Sắp xếp sinh viên theo điểm giảm");
        var sortedByScore = new List<StudentModel>(students.OrderByDescending(stu => stu.Score)); // TODO: Dùng LINQ OrderByDescending
        foreach (var s in sortedByScore)
            Console.WriteLine($"{s.Name}: {s.Score}");

        // TODO 6.4: Sắp xếp sinh viên theo tên (A-Z)
        Console.WriteLine("\n📝 Câu 4: Sắp xếp theo tên A-Z");
        var sortedByName = new List<StudentModel>(students.OrderBy(stu => stu.Name)); // TODO: Dùng LINQ OrderBy
        foreach (var s in sortedByName)
            Console.WriteLine($"{s.Name}: {s.Score}");

        // TODO 6.5: Sắp xếp theo tuổi tăng, nếu bằng tuổi thì theo điểm giảm
        Console.WriteLine("\n📝 Câu 5: Sắp xếp theo tuổi tăng, điểm giảm");
        var multiSort = new List<StudentModel>(students.OrderBy(stu => stu.Age).ThenByDescending(stu => stu.Score)); // TODO: Dùng OrderBy và ThenByDescending
        foreach (var s in multiSort)
            Console.WriteLine($"{s.Name} - Tuổi: {s.Age}, Điểm: {s.Score}");

        Console.WriteLine("\n✅ Hoàn thành Bài 6!");
    }

    // ============================================
    // BÀI 7: LINQ - GROUPBY (NHÓM DỮ LIỆU)
    // ============================================
    static void Bai7_LinqGroupBy()
    {
        Console.WriteLine("\n════════════════════════════════════════════");
        Console.WriteLine("│ BÀI 7: LINQ - GROUPBY (NHÓM)");
        Console.WriteLine("════════════════════════════════════════════\n");

        var students = CreateStudentList();

        // TODO 7.1: Nhóm sinh viên theo tuổi
        Console.WriteLine("📝 Câu 1: Nhóm sinh viên theo tuổi");
        var grouped = students.GroupBy(s => s.Age); // TODO: Dùng LINQ GroupBy
        foreach (var group in grouped)
            Console.WriteLine($"Tuổi {group.Key}: {string.Join(", ", group.Select(s => s.Name))}");

        // TODO 7.2: Nhóm theo xếp loại (>= 8: Giỏi, >= 6.5: Khá, còn lại: TB)
        Console.WriteLine("\n📝 Câu 2: Nhóm theo xếp loại");
        var groupedByGrade = students.GroupBy(stu => stu.Score >= 8 ? "Giỏi" : stu.Score >= 6.5 ? "Khá" : "TB");// TODO: Dùng LINQ GroupBy với logic phân loại
        foreach (var group in groupedByGrade)
            Console.WriteLine($"{group.Key}: {string.Join(", ", group.Select(s => s.Name))}");

        // TODO 7.3: Đếm số sinh viên mỗi tuổi
        Console.WriteLine("\n📝 Câu 3: Đếm số sinh viên mỗi tuổi");
        var countByAge = students.OrderBy(s => s.Age).GroupBy(s => s.Age);// TODO: Dùng GroupBy và Count
        foreach (var group in countByAge)
            Console.WriteLine($"Tuổi {group.Key}: {group.Count()} sinh viên");

        // TODO 7.4: Tính điểm trung bình mỗi nhóm tuổi
        Console.WriteLine("\n📝 Câu 4: Điểm TB mỗi nhóm tuổi");
        var avgByAge = students.OrderBy(s => s.Age).GroupBy(s => s.Age);// TODO: Dùng GroupBy và Average
        foreach (var group in avgByAge)
            Console.WriteLine($"Tuổi {group.Key}: {group.Average(s => s.Score):F2}");

        // TODO 7.5: Tìm sinh viên có điểm cao nhất mỗi tuổi
        Console.WriteLine("\n📝 Câu 5: Sinh viên điểm cao nhất mỗi tuổi");
        var topByAge = students.OrderBy(s => s.Age).GroupBy(s => s.Age);// TODO: Dùng GroupBy và Max
        foreach (var group in topByAge)
        {
            var top = group.OrderByDescending(s => s.Score).First();
            Console.WriteLine($"Tuổi {group.Key}: {top.Name} - {top.Score}");
        }

        Console.WriteLine("\n✅ Hoàn thành Bài 7!");
    }

    // ============================================
    // BÀI 8: LINQ - AGGREGATE (HÀM TỔNG HỢP)
    // ============================================
    static void Bai8_LinqAggregate()
    {
        Console.WriteLine("\n════════════════════════════════════════════");
        Console.WriteLine("│ BÀI 8: LINQ - AGGREGATE (TỔNG HỢP)");
        Console.WriteLine("════════════════════════════════════════════\n");

        List<int> numbers = new List<int> { 10, 20, 30, 40, 50 };
        var students = CreateStudentList();

        // TODO 8.1: Tính tổng các số
        Console.WriteLine("📝 Câu 1: Tính tổng các số");
        int sum = numbers.Sum(); // TODO: Dùng LINQ Sum()
        Console.WriteLine($"Tổng: {sum}");

        // TODO 8.2: Tính trung bình điểm
        Console.WriteLine("\n📝 Câu 2: Tính điểm trung bình");
        double average = numbers.Average(); // TODO: Dùng LINQ Average()
        Console.WriteLine($"Điểm TB: {average:F2}");

        // TODO 8.3: Đếm số sinh viên điểm >= 8.0
        Console.WriteLine("\n📝 Câu 3: Đếm sinh viên điểm >= 8.0");
        int count = students.Count(stu => stu.Score >= 8.0); // TODO: Dùng LINQ Count()
        Console.WriteLine($"Số lượng: {count}");

        // TODO 8.4: Tìm điểm cao nhất và thấp nhất
        Console.WriteLine("\n📝 Câu 4: Tìm điểm cao nhất và thấp nhất");
        double maxScore = students.Max(stu => stu.Score); // TODO: Dùng LINQ Max()
        double minScore = students.Min(stu => stu.Score); // TODO: Dùng LINQ Min()
        Console.WriteLine($"Cao nhất: {maxScore}, Thấp nhất: {minScore}");

        // TODO 8.5: Kiểm tra có sinh viên nào >= 9.5 không
        Console.WriteLine("\n📝 Câu 5: Có sinh viên nào >= 9.5?");
        bool hasTopScore = students.Any(s => s.Score >= 9.5); // TODO: Dùng LINQ Any()
        Console.WriteLine($"Có sinh viên >= 9.5: {hasTopScore}");

        // TODO 8.6: Kiểm tra tất cả sinh viên đều >= 5.0
        Console.WriteLine("\n📝 Câu 6: Tất cả đều >= 5.0?");
        bool allPassed = students.All(s => s.Score >= 5.0); // TODO: Dùng LINQ All()
        Console.WriteLine($"Tất cả >= 5.0: {allPassed}");

        Console.WriteLine("\n✅ Hoàn thành Bài 8!");
    }

    // ============================================
    // BÀI 9: LINQ - PHỨC TẠP (KẾT HỢP)
    // ============================================
    static void Bai9_LinqComplex()
    {
        Console.WriteLine("\n════════════════════════════════════════════");
        Console.WriteLine("│ BÀI 9: LINQ - PHỨC TẠP (KẾT HỢP)");
        Console.WriteLine("════════════════════════════════════════════\n");

        var students = CreateStudentList();
        Console.WriteLine("Mảng Ban Đầu: ");
        foreach (var s in students)
            Console.WriteLine($"{s.Name}: Điểm: {s.Score} | Tuổi: {s.Age}");

        // TODO 9.1: Lấy top 3 sinh viên có điểm cao nhất
        Console.WriteLine("📝 Câu 1: Top 3 sinh viên điểm cao nhất");
        var top3 = new List<StudentModel>(students.OrderByDescending(s => s.Score).Take(3)); // TODO: OrderByDescending + Take
        foreach (var s in top3)
            Console.WriteLine($"{s.Name}: {s.Score}");

        // TODO 9.2: Lấy sinh viên từ vị trí 3-5 (phân trang)
        Console.WriteLine("\n📝 Câu 2: Sinh viên từ vị trí 3-5");
        var page = new List<StudentModel>(students.Skip(2).Take(3)); // TODO: Skip + Take
        foreach (var s in page)
            Console.WriteLine($"{s.Name}: {s.Score}");

        // TODO 9.3: Lọc, sắp xếp và chọn
        Console.WriteLine("\n📝 Câu 3: Lọc điểm >= 7, sắp xếp giảm, lấy tên");
        var result = new List<string>(students.Where(n => n.Score >= 7).OrderByDescending(n => n.Score).Select(n => n.Name)); // TODO: Where + OrderByDescending + Select
        Console.WriteLine($"Kết quả: {string.Join(", ", result)}");

        // TODO 9.4: Tìm sinh viên tuổi 20 có điểm cao nhất
        Console.WriteLine("\n📝 Câu 4: SV tuổi 20 có điểm cao nhất");
        StudentModel topAt20 = students.Where(s => s.Age == 20).OrderByDescending(s => s.Score).FirstOrDefault(); // TODO: Where + OrderByDescending + FirstOrDefault
        if (topAt20 != null)
            Console.WriteLine($"{topAt20.Name}: {topAt20.Score}");
        else
            Console.WriteLine("Không có sinh viên nào 20 tuổi.");
        // TODO 9.5: Loại bỏ trùng lặp tuổi và sắp xếp
        Console.WriteLine("\n📝 Câu 5: Danh sách tuổi không trùng, sắp xếp");
        var uniqueAges = new List<int>(students.Select(s => s.Age).Distinct().OrderBy(s => s)); // TODO: Select + Distinct + OrderBy
        Console.WriteLine($"Tuổi: {string.Join(", ", uniqueAges)}");

        Console.WriteLine("\n✅ Hoàn thành Bài 9!");
    }

    // ============================================
    // BÀI 10: BÀI TOÁN THỰC TẾ
    // ============================================
    static void Bai10_RealWorldProblem()
    {
        Console.WriteLine("\n════════════════════════════════════════════");
        Console.WriteLine("│ BÀI 10: BÀI TOÁN THỰC TẾ");
        Console.WriteLine("════════════════════════════════════════════\n");

        Console.WriteLine("📋 Đề bài: Quản lý danh sách sản phẩm\n");

        var products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop Dell", Price = 15000000, Category = "Laptop", Stock = 5 },
            new Product { Id = 2, Name = "Laptop HP", Price = 12000000, Category = "Laptop", Stock = 3 },
            new Product { Id = 3, Name = "iPhone 15", Price = 25000000, Category = "Phone", Stock = 10 },
            new Product { Id = 4, Name = "Samsung S24", Price = 20000000, Category = "Phone", Stock = 8 },
            new Product { Id = 5, Name = "iPad Pro", Price = 18000000, Category = "Tablet", Stock = 0 },
            new Product { Id = 6, Name = "MacBook Pro", Price = 35000000, Category = "Laptop", Stock = 2 },
            new Product { Id = 7, Name = "AirPods Pro", Price = 5000000, Category = "Accessory", Stock = 15 }
        };

        // TODO 10.1: Lọc sản phẩm còn hàng (Stock > 0)
        Console.WriteLine("📝 Câu 1: Lọc sản phẩm còn hàng");
        var inStock = new List<Product>(products.Where(p => p.Stock > 0)); // TODO: Viết code
        foreach (var p in inStock)
            Console.WriteLine($"{p.Name} - Còn: {p.Stock}");

        // TODO 10.2: Tìm sản phẩm đắt nhất và rẻ nhất
        Console.WriteLine("\n📝 Câu 2: Sản phẩm đắt nhất và rẻ nhất");
        Product mostExpensive = products.MaxBy(p => p.Price); // TODO: Viết code
        Product cheapest = products.MinBy(p => p.Price); // TODO: Viết code

        if (mostExpensive != null && cheapest != null)
        {
            Console.WriteLine($"Đắt nhất: {mostExpensive.Name} - {mostExpensive.Price:N0} đ");
            Console.WriteLine($"Rẻ nhất: {cheapest.Name} - {cheapest.Price:N0} đ");
        }

        // TODO 10.3: Nhóm sản phẩm theo danh mục và đếm số lượng
        Console.WriteLine("\n📝 Câu 3: Nhóm theo danh mục");
        var groupedByCategory = products.OrderBy(p => p.Category).GroupBy(p => p.Category);// TODO: GroupBy và Count
        foreach (var group in groupedByCategory)
            Console.WriteLine($"{group.Key}: {group.Count()} sản phẩm");

        // TODO 10.4: Tính tổng giá trị kho (Price * Stock)
        Console.WriteLine("\n📝 Câu 4: Tổng giá trị kho");
        long totalValue = products.Sum(p => p.Price * p.Stock); // TODO: Sum(p => p.Price * p.Stock)
        Console.WriteLine($"Tổng giá trị: {totalValue:N0} đ");

        // TODO 10.5: Tìm top 3 sản phẩm giá cao, còn hàng, sắp xếp theo giá giảm
        Console.WriteLine("\n📝 Câu 5: Top 3 sản phẩm giá cao còn hàng");
        var top3Products = new List<Product>(products.Where(p => p.Stock > 0).OrderByDescending(p => p.Price).Take(3)); // TODO: Where + OrderByDescending + Take
        foreach (var p in top3Products)
            Console.WriteLine($"{p.Name} - {p.Price:N0} đ - Còn: {p.Stock}");

        // TODO 10.6: Tạo báo cáo: {Category, AvgPrice, TotalStock}
        Console.WriteLine("\n📝 Câu 6: Báo cáo theo danh mục");
        var categoryReport = products.OrderBy(p=>p.Category).GroupBy(p=>p.Category).Select(p=> new
        {
            Category = p.Key,
            AvgPrice = p.Average(x=>x.Price),
            TotalStock = p.Sum(x=>x.Stock)
        });// TODO: GroupBy + Select với anonymous type
         foreach (var report in categoryReport)
            Console.WriteLine($"{report.Category}: Giá TB {report.AvgPrice:N0} đ, Tồn: {report.TotalStock}");

        Console.WriteLine("\n✅ Hoàn thành Bài 10!");
    }

    // ============================================
    // HELPER METHODS
    // ============================================
    static List<StudentModel> CreateStudentList()
    {
        return new List<StudentModel>
        {
            new StudentModel { Id = 1, Name = "An", Age = 20, Score = 8.5 },
            new StudentModel { Id = 2, Name = "Bình", Age = 22, Score = 7.0 },
         new StudentModel { Id = 3, Name = "Chi", Age = 19, Score = 9.0 },
            new StudentModel { Id = 4, Name = "Dũng", Age = 21, Score = 6.5 },
         new StudentModel { Id = 5, Name = "Em", Age = 20, Score = 8.0 },
            new StudentModel { Id = 6, Name = "Phong", Age = 22, Score = 7.5 },
            new StudentModel { Id = 7, Name = "Giang", Age = 20, Score = 9.5 }
        };
    }
}

// ============================================
// MODELS
// ============================================
class StudentModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public double Score { get; set; }
}

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public long Price { get; set; }
    public string Category { get; set; }
    public int Stock { get; set; }
}
