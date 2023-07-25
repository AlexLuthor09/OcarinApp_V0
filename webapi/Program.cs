using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OcarinAPI.Data;
using OcarinAPI.Models;


var builder = WebApplication.CreateBuilder(args);
//Connection to the DB
builder.Services.AddDbContext<OcarinAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OcarinApp") ?? throw new InvalidOperationException("Connection string 'OcarinApp' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// initialize the DB
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
