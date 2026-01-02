// See https://aka.ms/new-console-template for more information

using Stack_TrungTo_HauTo;

static bool IsOperator(string token)
{
    return token == "+" || token == "-" || token == "*" || token == "/";
}

static bool IsOperand(string token)
{
    return !IsOperator(token) && token != "(" && token != ")";
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

static int Precedence(string op)
{
    if (op == "+" || op == "-")
        return 1;
    if (op == "*" || op == "/")
        return 2;
    return 0;
}

static List<string> ConvertInfixToSuffix(List<string> tokensInfix)
{
    List<string> suffix = new List<string>();
    StackCustom<string> stack = new StackCustom<string>(tokensInfix.Count);
    foreach (var token  in tokensInfix)
    {
        if (string.IsNullOrEmpty(token)) continue;
        if (IsOperand(token))
        {
            suffix.Add(token);
        }
        else if (IsOperator(token))
        {
            // so sanh độ ưu tiên của toán tử trên đỉnh stack với toán tử hiện tại
            while (stack.Count() > 0 && IsOperator(stack.Peek()) && Precedence(stack.Peek()) >= Precedence(token))
            {
                suffix.Add(stack.Pop());
            }
            // push toán tử hiện tại
            stack.Push(token);
        }
        else if (token == "(")
        {
            stack.Push(token);
        }
        // nếu token là dấu đóng ngoặc thì pop các toán tử từ stack đến khi gặp dấu mở ngoặc
        else if (token == ")")
        {
            while (stack.Count() > 0 && stack.Peek() != "(")
            {
                suffix.Add(stack.Pop());
            }
            if (stack.Count() == 0)
            {
                throw new InvalidOperationException("Mismatched parentheses: no matching '(' for ')'");
            }
            stack.Pop(); // pop the '('
        }
    }
    
    // pop remaining operators from the stack (AFTER processing all tokens)
    while (stack.Count() > 0)
    {
        string top = stack.Pop();
        if (top == "(" || top == ")")
        {
            throw new InvalidOperationException("Mismatched parentheses in expression");
        }
        suffix.Add(top);
    }
    
    return suffix;
}

static List<string> ParseInput(string input)
{
    List<string> tokens = new List<string>();
    foreach (char character in input)
    {
        if (char.IsDigit(character) || character.Equals('(') || character.Equals(')') || char.IsAsciiLetter(character) || IsOperator(character.ToString()))
        {
            tokens.Add(character.ToString());
        }
    }
    return tokens;
}

static double EvaluateExperssion(List<string> tokensInfix, Dictionary<string, double> variables)
{
    StackCustom<double> stack = new StackCustom<double>(tokensInfix.Count);
    foreach (string token in tokensInfix)
    {
        if (IsOperator(token))
        {
            if (stack.Count() < 2)
            {
                throw new InvalidOperationException("Insufficient values in the expression");
            }

            double rightOperand = stack.Pop();  // toán hạng bên phải
            double leftOperand = stack.Pop();   // toán hạng bên trái
            double result = Calculate(leftOperand, rightOperand, token);
            // day ket qua vao stack
            stack.Push(result);
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
    return stack.Pop();
}

Console.OutputEncoding = System.Text.Encoding.UTF8;
Dictionary<string, double> variables = new Dictionary<string, double>()
{
    { "A", 5 },
    { "B", 7 },
    { "C", 3 },
    { "D", 2 },
    { "E", 1 },
    { "F", 5 },
    {"G", 4}
};
List<string> suffixTokens = new List<string>();
Console.WriteLine("Nhập biểu thức trung tố (infix): ");
string infixExpression = Console.ReadLine();
Console.WriteLine("Bạn đã nhập: " + infixExpression);
Console.WriteLine("Parse Input...");
List<string> tokensInfixList = ParseInput(infixExpression);
Console.WriteLine("Các token trung tố (infix): " + string.Join(" ", tokensInfixList));
suffixTokens = ConvertInfixToSuffix(tokensInfixList);
Console.WriteLine("Biểu thức hậu tố (suffix): " + string.Join(" ", suffixTokens));
Console.WriteLine("Tính toán biểu thức hậu tố...");
double result = EvaluateExperssion(suffixTokens, variables);
Console.WriteLine("Kết quả: " + result);


