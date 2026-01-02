// 1.Xây dựng giải thuật sử dụng cấu trúc Stack để tính giá trị của một biểu thức dưới dạng hậu tố.
// Ứng dụng giải thuật trên để tính giá trị của biểu thức sau  A B C - / D E F + * +
// Với A = 5, B = 7, C = 3 , D = 2, E =1, F =5.

using Stack_HauTo;

class StackExercise
{

    static bool IsOperator(string token)
    {
        return token == "+" || token == "-" || token == "*" || token == "/";
    }

    static double Calculate(double n1, double n2, string token)
    {
        switch (token)
        {
            case "*":
                return n1 * n2;
            case "-":
                return n1 - n2;
            case "+":
                return n1 + n2;
            case "/":
                if (n2 == 0)
                {
                    throw new ArgumentException("Không thể chia cho 0");
                }
                return n1 / n2;
            default:
                throw new ArgumentException("Invalid token");
        }
    }
    
    static double EvaluateExpression(string[] expression, Dictionary<string, double> variables)
    {
        StackCustom<double> stack = new StackCustom<double>(expression.Length+1);
        
        foreach (var token in expression)
        {
            if (IsOperator(token))
            {
                double number1 = stack.Pop(); // lấy, và xóa số phần tử trên đỉnh stack 
                double number2 = stack.Pop(); 
                double result = Calculate(number2, number1, token);
                // sau khi tinh toán xong thì đẩy kết quả vào stack
                stack.Push(result); // đẩy kết quả vào stack
            }
            else
            {
                // nếu token là biến thì lấy giá trị từ dictionary
                if (variables.ContainsKey(token))
                {
                    stack.Push(variables[token]);
                }
                else
                {
                    throw new ArgumentException($"Undefined variable: {token}");
                }
            }
        }
        
        // stack cuối cùng chỉ còn một phần tử là kết quả của biểu thức
        return stack.Pop();
    }

    static string[] ParseInput(string input)
    {
        // tách chuỗi đầu vào thành các token
        // sử dụng khoảng trắng làm dấu phân cách
        // loại bỏ các phần tử rỗng
        return input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }

    static void Run()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Nhập biểu thức hậu tố và các biến: ");
        string inputValue = Console.ReadLine();
        Console.WriteLine("Bạn đã nhập: " + inputValue);
        string[] expression = ParseInput(inputValue);
        Dictionary<string, double> variables = new Dictionary<string, double>
        {
            { "A", 5 },
            { "B", 7 },
            { "C", 3 },
            { "D", 2 },
            { "E", 1 },
            { "F", 5 }
        };
        
        // tính toán kết quả biển thức hậu tố
        double result = EvaluateExpression(expression, variables);
        Console.WriteLine($"Kết quả của biểu thức hậu tố là: {result}");
    }
    
    static void Main(string[] args)
    {
        // try
        {
            Run();
        }
        // catch (Exception ex)
        // {
        //     Console.WriteLine($"LOI: {ex.Message}" );
        // }
        //
        // Console.WriteLine("Nhan Enter de thoat...");
        // Console.ReadLine();
    }
    
    
}