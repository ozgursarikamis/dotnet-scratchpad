using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGet("/", () => "Hello World!");
app.MapGet("/orders", ([FromServices] IOrderService service)
        => Results.Ok(service.GetOrders()))
    .AddEndpointFilter(async (context, next) =>
    {
        Console.WriteLine("Before");
        var endpointResult = await next(context);
        Console.WriteLine("After");

        return endpointResult;
    });
app.Run();