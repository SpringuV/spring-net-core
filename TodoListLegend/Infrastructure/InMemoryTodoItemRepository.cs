using System.Collections.Generic;
using Entities;
using UseCase;

namespace Infrastructure;

public class InMemoryTodoItemRepository: ITodoItemRepository
{
    private List<TodoItem> _items;

    public InMemoryTodoItemRepository()
    {
        _items = new List<TodoItem>();
    }
    
    public IEnumerable<TodoItem> GetAllItems()
    {
        return _items;
    }

    public void AddItem(TodoItem item)
    {
        _items.Add(item);
    }

    public bool UpdateItem(TodoItem item)
    {
        TodoItem? todoItemFromDb = _items.Find(itemInDb => itemInDb.id == item.id);
        if (todoItemFromDb == null)
        {
            // Not found -> indicate failure instead of throwing so callers can handle it
            return false;
        }
        // Replace the existing item (keep list order)
        int idx = _items.IndexOf(todoItemFromDb);
        if (idx >= 0)
        {
            _items[idx] = item;
        }
        else
        {
            // Fallback: remove/add
            _items.Remove(todoItemFromDb);
            _items.Add(item);
        }
        return true;
    }

    public void DeleteItem(int id)
    {
        TodoItem? todoItemFromDb = _items.Find(itemInDb => itemInDb.id == id);
        if (todoItemFromDb == null)
        {
            // If not found, nothing to do (interface expects void). Keep silent or throw depending on desired semantics.
            return;
        }
        _items.Remove(todoItemFromDb);
    }

    public TodoItem? GetItemById(int id)
    {
        return _items.Find(item => item.id == id);
    }
}