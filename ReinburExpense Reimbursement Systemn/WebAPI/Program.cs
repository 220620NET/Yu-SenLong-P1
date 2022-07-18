using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc;
using UserService;
using AuthService;
using TicketService;
using userModels;
using ConnectionFactory;
using Controllers;
using TickeData;
using UserData;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//dependency injection
builder.Services.AddSingleton<ConnectionFactoryClass>(ctx => ConnectionFactoryClass.GetInstance(builder.Configuration.GetConnectionString("ERS")));
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<TicketServices>();
builder.Services.AddScoped<TicketRepository>();
builder.Services.AddScoped<AuthController>();
builder.Services.AddScoped<AuthServices>();
builder.Services.AddScoped<UserController>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

app.MapGet("/greet/{name}", (string name) => {return $"Hi {name}!";}); //Verb(route)

app.MapGet
    (
        "/greet", (string name) => {return $"Hello {name}!";} //greet?name=xyz
    );

app.MapGet
    (
        "/users", () => 
        {
            var scope = app.Services.CreateScope();
            UserController controller = scope.ServiceProvider.GetRequiredService<UserController>();
            return controller.GetAllUsers();
        }
    );

app.MapPost
    (
        "/register", (User NewUser, AuthController AController) => 
        {
            return AController.Register(NewUser);
        }
    );

app.MapGet
    (
        "/login", (string username, string password, AuthController AController) => 
        {
            return AController.Login(username, password);
        }
    );

app.MapGet
    (
        "/username", (string name) => 
        {
            var scope = app.Services.CreateScope();
            UserController controller = scope.ServiceProvider.GetRequiredService<UserController>();
            return controller.GetUser(name);
        }
    );

app.MapGet
    (
        "/userid", (int id) => 
        {
            var scope = app.Services.CreateScope();
            UserController controller = scope.ServiceProvider.GetRequiredService<UserController>();
            return controller.GetUser(id);
        }
    );

app.Run();
