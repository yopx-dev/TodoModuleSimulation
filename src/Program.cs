var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<string> todoList = new();

app.MapPost("/list", (string task) =>
{
    Console.WriteLine("/list post");
    todoList.Add(task);
    return $"Succesfull task \"{task}\" added!";
});

app.MapGet("/list", () =>
{
    Console.WriteLine("/list get");
    return todoList;
});

app.Run();