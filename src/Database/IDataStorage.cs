using TodoModule.Context;

namespace TodoModule.Database;

public interface IDataStorage
{
    public Todo AddTodo(TodoRequest request);
    public void RemoveTodoById(int Id);
    public List<Todo> GetAllTodos();
    public void UpdateTodo(TodoRequest updatedTodo, int Id);
    public Todo? GetTodoById(int Id);
}