using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.OpenApi.Models;
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

app.UseRateLimiter(new RateLimiterOptions()
{
    RejectionStatusCode = 429
}.AddFixedWindowLimiter("FixedWindowLimiter", options =>
{
    options.PermitLimit = 1;
    options.Window = TimeSpan.FromSeconds(2); // no more than 1 request per 2 seconds
}));

app.MapGet("/unlimited", () => "Unlimited");
app.MapGet("/limited", () => "Limited").RequireRateLimiting("FixedWindowLimiter");

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
    })
    .WithOpenApi(operation =>
    {
        operation.OperationId = "Get Orders";
        operation.Description = "Get all orders";
        operation.Summary = "[Summary] - Gets all orders";
        operation.Tags = new List<OpenApiTag>
        {
            new() { Name = "Orders" },
            new() { Name = "Get" },
        };

        return operation;
    });

mobileApiGroup.MapGet("/rewards", () => "Secret discounts");

app.MapGet("/survey", ([AsParameters]SurveyResults results) =>
{
    return "Thank You!";
});

app.MapPost("/upload", async (IFormFile file) =>
{
    await using var stream = File.OpenWrite("upload.jpg");
    await file.CopyToAsync(stream);
});

app.Run();