namespace TodoModule.Context;

public class Todo
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}

public record TodoRequest(string Title, bool IsCompleted);