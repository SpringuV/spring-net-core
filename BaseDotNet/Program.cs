// Bài tập: Tính giá trị biểu thức hậu tố (Postfix Expression) sử dụng Stack
// Biểu thức: A B C - / D E F + * +
// Với A = 5, B = 7, C = 3, D = 2, E = 1, F = 5

using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("=== TÍNH GIÁ TRỊ BIỂU THỨC HẬU TỐ SỬ DỤNG STACK ===\n");
        
        // Định nghĩa biểu thức hậu tố dưới dạng mảng các token
        string[] postfixExpression = { "A", "B", "C", "-", "/",
            "D", "E", "F", "+", "*", "+" };
        
        // Định nghĩa giá trị các biến
        Dictionary<string, double> variables = new Dictionary<string, double>
        {
            { "A", 5 },
            { "B", 7 },
            { "C", 3 },
            { "D", 2 },
            { "E", 1 },
            { "F", 5 }
        };
        
        Console.WriteLine("Biểu thức hậu tố: " + string.Join(" ", postfixExpression));
        Console.WriteLine("\nGiá trị các biến:");
        foreach (var variable in variables)
        {
            Console.WriteLine($"  {variable.Key} = {variable.Value}");
        }
        
        // Tính giá trị biểu thức
        double result = EvaluatePostfixExpression(postfixExpression, variables);
        
        Console.WriteLine($"\n=== KẾT QUẢ: {result} ===");
        
        // Giải thích chi tiết các bước tính toán
        Console.WriteLine("\n\n=== GIẢI THÍCH CHI TIẾT CÁC BƯỚC TÍNH TOÁN ===");
        EvaluatePostfixExpressionWithSteps(postfixExpression, variables);
    }
    
    /// <summary>
    /// Hàm tính giá trị biểu thức hậu tố sử dụng Stack
    /// </summary>
    /// <param name="postfixExpression">Mảng các token của biểu thức hậu tố</param>
    /// <param name="variables">Dictionary chứa giá trị các biến</param>
    /// <returns>Giá trị của biểu thức</returns>
    static double EvaluatePostfixExpression(string[] postfixExpression, Dictionary<string, double> variables)
    {
        // Khởi tạo Stack để lưu trữ các toán hạng (operands)
        Stack<double> stack = new Stack<double>();
        
        // Duyệt qua từng token trong biểu thức hậu tố
        foreach (string token in postfixExpression)
        {
            // Kiểm tra xem token có phải là toán tử không
            if (IsOperator(token))
            {
                // Nếu là toán tử, lấy 2 toán hạng từ stack
                // Lưu ý: phải lấy ngược thứ tự (operand2 trước, operand1 sau)
                double operand2 = stack.Pop(); // Toán hạng thứ 2 (bên phải)
                double operand1 = stack.Pop(); // Toán hạng thứ 1 (bên trái)
                
                // Thực hiện phép tính dựa trên toán tử
                double result = PerformOperation(operand1, operand2, token);
                
                // Đẩy kết quả vào stack
                stack.Push(result);
            }
            else
            {
                // Nếu là toán hạng (biến hoặc số), lấy giá trị và đẩy vào stack
                double value = variables.ContainsKey(token) ? variables[token] : double.Parse(token);
                stack.Push(value);
            }
        }
        
        // Sau khi duyệt hết biểu thức, stack chỉ còn 1 phần tử là kết quả cuối cùng
        return stack.Pop();
    }
    
    /// <summary>
    /// Hàm tính giá trị biểu thức hậu tố với hiển thị chi tiết từng bước
    /// </summary>
    static void EvaluatePostfixExpressionWithSteps(string[] postfixExpression, Dictionary<string, double> variables)
    {
        // Khởi tạo Stack
        Stack<double> stack = new Stack<double>();
        int stepNumber = 1;
        
        // Duyệt qua từng token
        foreach (string token in postfixExpression)
        {
            Console.WriteLine($"\nBước {stepNumber}: Xử lý token '{token}'");
            
            if (IsOperator(token))
            {
                // Token là toán tử
                double operand2 = stack.Pop();
                double operand1 = stack.Pop();
                
                Console.WriteLine($"  - Lấy 2 toán hạng từ stack: {operand1} và {operand2}");
                
                double result = PerformOperation(operand1, operand2, token);
                
                Console.WriteLine($"  - Thực hiện phép tính: {operand1} {token} {operand2} = {result}");
                
                stack.Push(result);
                
                Console.WriteLine($"  - Đẩy kết quả {result} vào stack");
            }
            else
            {
                // Token là toán hạng
                double value = variables.ContainsKey(token) ? variables[token] : double.Parse(token);
                
                Console.WriteLine($"  - '{token}' là biến, giá trị = {value}");
                
                stack.Push(value);
                
                Console.WriteLine($"  - Đẩy giá trị {value} vào stack");
            }
            
            // Hiển thị trạng thái stack hiện tại
            Console.WriteLine($"  - Stack hiện tại: [{string.Join(", ", stack.Reverse())}]");
            
            stepNumber++;
        }
        
        Console.WriteLine($"\n==> Kết quả cuối cùng trong stack: {stack.Peek()}");
    }
    
    /// <summary>
    /// Kiểm tra xem một token có phải là toán tử không
    /// </summary>
    /// <param name="token">Token cần kiểm tra</param>
    /// <returns>True nếu là toán tử, False nếu không phải</returns>
    static bool IsOperator(string token)
    {
        // Danh sách các toán tử được hỗ trợ: +, -, *, /
        return token == "+" || token == "-" || token == "*" || token == "/";
    }
    
    /// <summary>
    /// Thực hiện phép tính toán dựa trên toán tử
    /// </summary>
    /// <param name="operand1">Toán hạng thứ nhất (bên trái)</param>
    /// <param name="operand2">Toán hạng thứ hai (bên phải)</param>
    /// <param name="operatorSymbol">Toán tử</param>
    /// <returns>Kết quả của phép tính</returns>
    static double PerformOperation(double t1, double t2, string symbol)
    {
        // Dựa vào toán tử, thực hiện phép tính tương ứng
        switch (symbol)
        {
            case "+":
                return t1 + t2; // Phép cộng
            case "-":
                return t1 - t2; // Phép trừ
            case "*":
                return t1 * t2; // Phép nhân
            case "/":
                // Kiểm tra chia cho 0
                if (t2 == 0)
                {
                    throw new DivideByZeroException("Không thể chia cho 0!");
                }
                return t1 / t2; // Phép chia
            default:
                throw new ArgumentException($"Toán tử không hợp lệ: {symbol}");
        }
    }
}

/* 
 * GIẢI THÍCH THUẬT TOÁN:
 * 
 * Biểu thức hậu tố (Postfix/RPN - Reverse Polish Notation):
 * - Toán tử đứng sau các toán hạng
 * - Ví dụ: A + B được viết thành A B +
 * - Ưu điểm: Không cần dấu ngoặc, dễ dàng tính toán bằng Stack
 * 
 * Thuật toán tính giá trị biểu thức hậu tố:
 * 1. Khởi tạo một Stack rỗng
 * 2. Duyệt qua từng token (phần tử) trong biểu thức từ trái sang phải:
 *    a. Nếu token là toán hạng (số hoặc biến):
 *       - Đẩy giá trị của nó vào Stack
 *    b. Nếu token là toán tử:
 *       - Lấy 2 giá trị từ đỉnh Stack (Pop 2 lần)
 *       - Thực hiện phép tính với 2 giá trị đó
 *       - Đẩy kết quả vào Stack
 * 3. Sau khi duyệt hết biểu thức, Stack chỉ còn 1 phần tử là kết quả cuối cùng
 * 
 * TÍNH TOÁN CHO BÀI TẬP:
 * Biểu thức: A B C - / D E F + * +
 * Với A=5, B=7, C=3, D=2, E=1, F=5
 * 
 * Các bước tính:
 * 1. Đọc A → Push 5 → Stack: [5]
 * 2. Đọc B → Push 7 → Stack: [5, 7]
 * 3. Đọc C → Push 3 → Stack: [5, 7, 3]
 * 4. Đọc - → Pop 3, Pop 7 → Tính 7-3=4 → Push 4 → Stack: [5, 4]
 * 5. Đọc / → Pop 4, Pop 5 → Tính 5/4=1.25 → Push 1.25 → Stack: [1.25]
 * 6. Đọc D → Push 2 → Stack: [1.25, 2]
 * 7. Đọc E → Push 1 → Stack: [1.25, 2, 1]
 * 8. Đọc F → Push 5 → Stack: [1.25, 2, 1, 5]
 * 9. Đọc + → Pop 5, Pop 1 → Tính 1+5=6 → Push 6 → Stack: [1.25, 2, 6]
 * 10. Đọc * → Pop 6, Pop 2 → Tính 2*6=12 → Push 12 → Stack: [1.25, 12]
 * 11. Đọc + → Pop 12, Pop 1.25 → Tính 1.25+12=13.25 → Push 13.25 → Stack: [13.25]
 * 
 * KẾT QUẢ: 13.25
 * 
 * KIẾN THỨC SỬ DỤNG:
 * - Collection: Stack<T> - Cấu trúc dữ liệu LIFO (Last In First Out)
 * - Dictionary<TKey, TValue> - Lưu trữ cặp key-value
 * - LINQ: Reverse() để hiển thị stack theo thứ tự
 * - Lambda: Sử dụng trong LINQ và các hàm xử lý
 */
