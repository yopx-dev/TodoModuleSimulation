namespace TodoModule.Controller;

using Microsoft.AspNetCore.Mvc;
using TodoModule.Context;
using TodoModule.Core;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly TodoStorage _todoStorage;

    public TodoController(TodoStorage todoStorage)
    {
        _todoStorage = todoStorage;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<Todo> Create(TodoRequest task)
    {
        
        if (task.Title == null || task.Title.Trim().Length == 0)
            return BadRequest("Title cannot be empty!");

        var todo = _todoStorage.AddTodo(task);  
        return Ok(todo);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var todos = _todoStorage.GetAllTodos();
        return Ok(todos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetTodoById(int id)
    {
        var todo = _todoStorage.GetTodoById(id);
        if (todo != null) return Ok(todo);
        else return NotFound();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteTodoById(int Id)
    {
        try 
        {
            _todoStorage.RemoveTodoById(Id);
            return NoContent();
        }
        catch (Exception)
        {
            return NotFound();
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult PutTodoById(int Id, TodoRequest request)
    {
        if (request.Title == null || request.Title.Trim().Length == 0)
            return BadRequest("Title cannot be empty!");

        try 
        {
            _todoStorage.UpdateTodo(request, Id);
            return Ok();
        }
        catch (Exception)
        {
            return NotFound();
        }
    }
}