var builder = WebApplication.CreateBuilder(args);
// add Service to the container

var app = builder.Build();

// Config the HTTP request pipeline

app.MapGet("/", () => "Hello World!");

app.Run();
