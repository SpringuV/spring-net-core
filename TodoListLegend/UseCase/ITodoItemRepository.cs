namespace UseCase;
using Entities;
public interface ITodoItemRepository
{
    IEnumerable<TodoItem> GetAllItems();
    void AddItem(TodoItem item);
    bool UpdateItem(TodoItem item);
    void DeleteItem(int id);
    TodoItem? GetItemById(int id);
}