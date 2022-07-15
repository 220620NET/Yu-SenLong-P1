using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc;
using UserServices;
using AuthServices;
using TicketServices;
using ConnectionFactory;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//dependency injection
builder.Services.AddSingleton<ConnectionFactoryClass>(ctx => ConnectionFactoryClass.GetInstance(builder.Configuration.GetConnectionString("ERS")));

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

app.MapGet("/greet/{name}", (string name) => {return $"Hi {name}!";}); //Verb(route)

app.MapGet
    (
        "/greet", (string name) => {return $"Hello {name}!";} //greet?name=xyz
    );

app.Run();
