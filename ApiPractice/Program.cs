using ApiPractice.Data;
using ApiPractice.Interfaces;
using ApiPractice.Repositories;
using ApiPractice.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Leer la cadena de conexión del appsettings.json
//var connectionString = builder.Configuration.GetConnectionString("\"Server=REVENANTMAU\\\\SQLEXPRESS;Database=apiPractice;User Id=REVENANTMAU\\\\imauv;Password=;TrustServerCertificate=True;");
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Registrar tu DbContext en el contenedor de dependencias
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IClientsService, ClientsServices>();
builder.Services.AddScoped<IRepositoryiClients, ClientsRepository>();
builder.Services.AddScoped<IRepositoryInvoice, InvoiceRepository>();

builder.Services.AddControllers();
// ... otras configuraciones ...

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Esto genera la interfaz gráfica en /swagger
}

//app.UseHttpsRedirection();
//app.UseAuthorization();
app.MapControllers();


app.Run();