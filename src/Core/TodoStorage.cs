namespace TodoModule.Core;

using TodoModule.Context;

public class TodoStorage
{
    private List<Todo> _todoStorage = new();
    private int _nextId = 1;

    public Todo AddTodo(TodoRequest request)
    {
        var todo = new Todo
        (
            _nextId++,
            request.Title,
            request.IsCompleted
        );

        _todoStorage.Add(todo);
        return todo;
    }

    public void RemoveTodoById(int Id)
    {
        var todo = _todoStorage.Find(t => t.Id == Id);
        if (todo == null) throw new Exception("NOT CORRECT ID"); 
        _todoStorage.Remove(todo);    
    }

    public List<Todo> GetAllTodos() => _todoStorage;

    public Todo? GetTodoById(int Id)
        => _todoStorage.Find(t => t.Id == Id);

    public void UpdateTodo(TodoRequest updatedTodo, int Id)
    {
        var todo = _todoStorage.FindIndex(t => t.Id == Id);
        if (todo == -1) throw new KeyNotFoundException();

        var newTodo = new Todo(Id, updatedTodo.Title, updatedTodo.IsCompleted);
        _todoStorage[todo] = newTodo;
    }
}