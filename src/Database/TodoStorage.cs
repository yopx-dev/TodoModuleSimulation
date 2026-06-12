namespace TodoModule.Database;

using TodoModule.Context;
using Microsoft.EntityFrameworkCore;

public class TodoStorage : IDataStorage
{
    private readonly AppDbContext _context;

    public TodoStorage(AppDbContext context)
    {
        _context = context;    
    }

    public Todo AddTodo(TodoRequest request)
    {
        var todo = new Todo
        {
            Title = request.Title,
            IsCompleted = request.IsCompleted
        };

        _context.Todos.Add(todo);
        _context.SaveChanges();
        return todo;
    }

    public void RemoveTodoById(int id)
    {
        var todo = FindTodoById(id);
        _context.Todos.Remove(todo);
        _context.SaveChanges();
    }

    public List<Todo> GetAllTodos()
        => _context.Todos.ToList();
    
    public void UpdateTodo(TodoRequest request, int id)
    {
        var todo = FindTodoById(id);
        todo.Title = request.Title;
        todo.IsCompleted = request.IsCompleted;
        _context.SaveChanges();
    }

    public Todo GetTodoById(int id)
        => FindTodoById(id);

    private Todo FindTodoById(int id)
    {
        var todo = _context.Todos.Find(id);
        if (todo == null) throw new KeyNotFoundException($"Todo with id {id} not found!");
        return todo;
    }
}