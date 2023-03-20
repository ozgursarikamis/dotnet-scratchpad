using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using WebApp.Models;
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

var mobileApiGroup = app.MapGroup("/api")
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

app.MapGet("/", () => "Hello World!");
app.MapGet("/ordersByIds", (IOrderService orderService, int[] orderIds) =>
{
    return Results.Ok(orderService.GetOrders().Where(x => orderIds.Contains(x.Id)));
});

app.MapGet("/orders", ([FromServices] IOrderService service)
        => Results.Ok(service.GetOrders()))
    .AddEndpointFilter(async (context, next) =>
    {
        Console.WriteLine("Before");
        var endpointResult = await next(context);
        Console.WriteLine("After");

        return endpointResult;
    });

mobileApiGroup.MapGet("/rewards", () => "Secret discounts");

mobileApiGroup.MapPost("survey", (SurveyResults results) =>
{
    return "Thank You!";
});

app.MapPost("/upload", async (IFormFile file) =>
{
    await using var stream = File.OpenWrite("upload.jpg");
    await file.CopyToAsync(stream);
});

app.Run();