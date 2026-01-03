using System.Text;
using Stack_TrungTo_HauTo_2;

// Kiểm tra xem token có phải là số hay không.
// Sử dụng double.TryParse để chấp nhận các số nguyên và số thực (có dấu chấm thập phân).
// Trả về true nếu token có thể parse thành double.
static bool IsNumber(string token)
{
    return double.TryParse(token, out _); // out _ là bỏ qua giá trị trả về, nếu dùng out var value thì value sẽ chứa giá trị số
}

static bool IsOperator(string token)
{
    return token == "+" || token == "-" || token == "*" || token == "/" || token == "^";
}

static int GetRank(string op)
{
    return op switch
    {
        "+" or "-" => 1,
        "*" or "/" => 2,
        "^" => 3,
        _ => 0
    };
}


static List<string> parseInput(string input)
{
    List<string> tokens = new List<string>();
    StringBuilder cur = new StringBuilder();

    // Helper: kiểm tra ký tự là toán tử hay ngoặc
    bool IsOp(char c) => c=='+'|| c=='-'||c=='*'||c=='/'||c=='^';
    bool IsParen(char c) => c=='('||c==')';

    for (int i = 0; i < (input ?? "").Length; i++)
    {
        char c = input[i];

        // Nếu gặp khoảng trắng: hoàn tất token hiện tại (nếu có) rồi tiếp tục
        if (char.IsWhiteSpace(c))
        {
            if (cur.Length > 0)
            {
                tokens.Add(cur.ToString());
                cur.Clear();
            }
            continue;
        }

        // Nếu là chữ số hoặc dấu chấm: đang xây dựng một số (hoặc phần thập phân)
        if (char.IsDigit(c) || c=='.')
        {
            // Nếu đã có dấu '.' trong cur và gặp '.' nữa => lỗi định dạng số
            if (c=='.' && cur.ToString().Contains('.')) throw new FormatException("Invalid number.");
            cur.Append(c);
            continue;
        }

        // Xử lý dấu âm đơn (unary minus):
        // - Chỉ khi cur rỗng (không đang xây token), và dấu '-' xuất hiện ở đầu biểu thức
        //   hoặc ngay sau một toán tử hoặc '(';
        // - Đồng thời ký tự tiếp theo phải là số hoặc '.' để hiểu là số âm, ví dụ: -5 hoặc (-3.2)
        if (c=='-' && cur.Length==0)
        {
            bool atStart = tokens.Count==0; // '-' ở đầu chuỗi
            // Kiểm tra token trước đó là toán tử hoặc '(' để suy luận đây là unary minus
            bool afterOpOrLPar = tokens.Count>0 && (IsOp(tokens[tokens.Count-1][0]) || tokens[tokens.Count-1]=="(");
            bool nextIsNum = (i+1 < input.Length) && (char.IsDigit(input[i+1]) || input[i+1]=='.');
            if ((atStart || afterOpOrLPar) && nextIsNum)
            {
                cur.Append('-');
                continue;
            }
        }

        // Nếu tới đây và cur có nội dung => kết thúc token hiện tại trước khi xử lý ký tự mới
        if (cur.Length > 0)
        {
            tokens.Add(cur.ToString());
            cur.Clear();
        }

        // Nếu ký tự là toán tử hoặc ngoặc, thêm như 1 token riêng
        if (IsOp(c) || IsParen(c))
        {
            tokens.Add(c.ToString());
        }
        else throw new FormatException($"Unrecognized char '{c}'.");
    }

    // Nếu có token chưa được đóng ở cuối chuỗi thì thêm nó vào danh sách
    if (cur.Length>0) tokens.Add(cur.ToString());
    return tokens;
}

static List<string> InfixToSuffix(List<string> tokens)
{
    List<string> output = new List<string>();
    StackCustom<string> stack = new StackCustom<string>(tokens.Count);
    foreach (var token in tokens)
    {
        if (IsNumber(token))
        {
            output.Add(token);
        }
        // Nếu là toán tử: xử lý dựa trên precedence và associativity
        if (IsOperator(token))
        {
            while(GetRank(token)> 0 && !stack.IsEmpty() && IsOperator(stack.Peek()) &&
                  (GetRank(token) <= GetRank(stack.Peek()) || 
                   (GetRank(token) == GetRank(stack.Peek()) && token != "^"))) // nếu token là dấu ^ thì nó là toán tử phải kết hợp nên không pop
            {
                // pop toán tử từ stack sang output nếu độ ưu tiên của toán tử trên đỉnh stack lớn hơn hoặc bằng toán tử hiện tại
                output.Add(stack.Pop());
            }
            // nếu không thỏa điều kiện trên thì push toán tử hiện tại vào stack
            stack.Push(token);
        }
        else if (token == "(")
        {
            // '(' luôn được push vào stack để đánh dấu bắt đầu 1 nhóm
            stack.Push(token);
        }
        else if (token == ")")
        {
            // Khi gặp ')', pop đến '('
            while(stack.Count() > 0 && stack.Peek() != "(")
            {
                output.Add(stack.Pop());
            }
            // Nếu không có '(' tương ứng -> lỗi ngoặc không khớp
            if (stack.Count() == 0)
            {
                throw new InvalidOperationException("Mismatched parentheses: no matching '(' for ')'");
            }
            stack.Pop(); // pop the '('
        }
    }
    // Sau khi duyệt hết token, pop các toán tử còn lại lên output
    while (stack.Count() > 0)
    {
        string top = stack.Pop();
        if (top == "(" || top == ")")
        {
            // Nếu vẫn còn ngoặc trong stack nghĩa là có mismatched parentheses
            throw new InvalidOperationException("Mismatched parentheses in expression");
        }
        output.Add(top);
    }
    
    return output;
}

static double Caculate(double a, double b, string symbol)
{
    return symbol switch
    {
        "+" => a + b,
        "-" => a - b,
        "*" => a * b,
        "/" => a / b,
        "^" => Math.Pow(a, b),
        _ => throw new InvalidOperationException($"Invalid operator {symbol}")
    };
}

static double EvaluateSuffix(List<string> tokens)
{
    StackCustom<double> stack = new StackCustom<double>(tokens.Count);
    foreach (string token in tokens)
    {
        if (IsNumber(token))
        {
            stack.Push(double.Parse(token));
        } else if (IsOperator(token))
        {
            double n1 = stack.Pop();
            double n2 = stack.Pop();
            stack.Push(Caculate(n2, n1, token));
        }
    }
    return stack.Pop();
}

Console.WriteLine("Nhập mảng biểu thức trung tố: " );
string input = Console.ReadLine();
Console.WriteLine("Input: " + input);
List<string> tokens = parseInput(input);
Console.WriteLine("Tokens after praseInput: " + string.Join(" ", tokens));
Console.WriteLine("Chuyển sang biểu thức hậu tố:");
List<string> suffixTokens = InfixToSuffix(tokens);
Console.WriteLine("Output: " + string.Join(" ", suffixTokens));
Console.WriteLine("Kết quả tính toán biểu thức hậu tố:");
double result = EvaluateSuffix(suffixTokens);
Console.WriteLine("Result: " + result);
