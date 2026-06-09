namespace TodoModule.Context;

public record Todo(int Id, string Title, bool IsCompleted);

public record TodoRequest(string Title, bool IsCompleted);