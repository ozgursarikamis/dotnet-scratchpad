using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
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

app.MapGet("/rewards", () => "Secret discounts")
    .AddEndpointFilter(async (context, next) =>
    {
        context.HttpContext.Request.Headers.TryGetValue("x-device-type", out var deviceType);
        if (deviceType != "mobile")
        {
            return Results.BadRequest();
        }
        var result = await next(context);
        Debug.WriteLine("After");
        return result;
    });

app.Run();