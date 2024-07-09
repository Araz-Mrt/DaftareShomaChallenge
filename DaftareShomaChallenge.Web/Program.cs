using DaftareShomaChallenge.Application;
using DaftareShomaChallenge.Application.Contracts.Filters;
using DaftareShomaChallenge.Application.Contracts.Interfaces;
using DaftareShomaChallenge.Infrastructure.Persistence.Initializers;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices(builder.Configuration);
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
    await initializer.InitializeAsync();
    await initializer.SeedAsync(scope.ServiceProvider);
}

app.UseHttpsRedirection();

app.MapGet("/products", async (IProductService productService) =>
    {
        var result = await productService.GetProductsAsync();
        return (result);
    })
    .WithName("GetProducts")
    .WithOpenApi();

app.MapGet("/report/productsale", async ([AsParameters]GetProductSaleCountReportFilter filter,[FromServices] IApplicationProductSaleReportService productSaleReportService) =>
    {
        var result = await productSaleReportService.GetProductSalesCountReportAsync(filter);
        return (result);
    })
    .WithName("GetSoldProductCountReport")
    .WithOpenApi();



app.Run();

