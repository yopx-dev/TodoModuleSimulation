namespace TodoModule.Controller;

using Microsoft.AspNetCore.Mvc;
using TodoModule.Context;
using TodoModule.Database;

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
        
        if (!IsValidTitle(task.Title))
            return BadRequest("Title cannot be empty!");

        var todo = _todoStorage.AddTodo(task);  
        return Ok(todo);
    }

    private bool IsValidTitle(string Title)
    {
        return !((Title == null) || (Title.Trim().Length == 0));
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
        catch (KeyNotFoundException)
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
        if (!IsValidTitle(request.Title))
            return BadRequest("Title cannot be empty!");

        try 
        {
            _todoStorage.UpdateTodo(request, Id);
            return Ok();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}