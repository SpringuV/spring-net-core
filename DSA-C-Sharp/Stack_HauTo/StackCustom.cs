namespace Stack_HauTo;

public class StackCustom<T>
{
    private T[] _items;
    private int _top;
    private int capacity;

    public StackCustom(int capacity)
    {
        if(capacity <= 0) throw new ArgumentOutOfRangeException(nameof(capacity));
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
        return _top == capacity - 1;
    }

    public void Push(T item)
    {
        if (IsFull())
        {
            throw new InvalidOperationException("Stack overflow");
        }
        _items[++_top] = item;
    }

    public T Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack underflow");
        }
        T value = _items[_top--];    // return current top, then decrement
        _items[_top + 1] = default!; // clear slot
        return value;
    }
    
    // xem phan tu tren cung cua stack
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