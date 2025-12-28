namespace UseCase;
using Entities;

public class TodoListManager
{
    private readonly ITodoItemRepository _repository;
    public TodoListManager(ITodoItemRepository repository)
    {
        _repository = repository;
    }
    
    public IEnumerable<TodoItem> GetAllItems()
    {
        return _repository.GetAllItems();
    }

    public TodoItem? GetItemById(int id)
    {
        return _repository.GetItemById(id);
    }
    
    public void AddItem(TodoItem item)
    {
        _repository.AddItem(item);
    }
    
    public bool UpdateItem(TodoItem item)
    {
        return _repository.UpdateItem(item);
    }
    
    public void DeleteItem(int id)
    {
        _repository.DeleteItem(id);
    }
    
    public void MarkItemComplete(int id)
    {
        TodoItem? item = _repository.GetItemById(id);
        if (item == null)
        {
            throw new ArgumentException("Item not found");
        }

        if (item.isComplete)
        {
            item.isComplete = false;
        } else {
            item.isComplete = true;
        }
        _repository.UpdateItem(item);
    }
}