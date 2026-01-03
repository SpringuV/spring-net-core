namespace Stack_TrungTo_HauTo_2;

public class StackCustom<T>
{
    private T[] _items;
    private int _top;
    private int capacity;

    public StackCustom(int capacity)
    {
        _items = new T[capacity];
        _top = -1;
        this.capacity = capacity;
    }

    public bool IsEmpty()
    {
        return _top == -1;
    }

    public bool IsFull()
    {
        return _top == capacity-1;
    }
    public void Push(T item)
    {
        if (IsFull())
        {
            throw new InvalidOperationException("Stack is full");
        }
        _items[++_top] = item;
    }

    public T Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty");
        }
        T value = _items[_top--];
        _items[_top+1] = default!; // clear slot, dấu chấm than để bỏ qua cảnh báo null,
                    // Dấu ! ở đây gọi là null-forgiving operator.
                    // chỉ ảnh hưởng trong thời gian biên dịch (compile time)
                    // không tạo ra giá trị nào trong thời gian chạy (run time)
                    // không kiểm tra null tại runtime
        return value;
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack underflow");
        }
        return _items[_top];
    }
    
    public int Count()
    {
        return _top + 1;
    }
}