namespace Entities;

public class TodoItem
{
    public int id { get; set; }
    public required string description { get; set; } = string.Empty;
    public bool isComplete { get; set; }
}