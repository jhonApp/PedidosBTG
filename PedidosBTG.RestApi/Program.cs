using Microsoft.EntityFrameworkCore;
using PedidosBTG.Core.Interface;
using PedidosBTG.Core.Service;
using PedidosBTG.Data;
using PedidosBTG.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();

builder.Services.AddSingleton(configuration);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("PedidosAWS")));

// Add services to the container.
builder.Services.AddScoped<PedidoService>();
builder.Services.AddScoped<IPedidoItem, PedidoItemRepository>();
builder.Services.AddScoped<IPedido, PedidosRepository>();


builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
