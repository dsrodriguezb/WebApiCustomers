using Microsoft.EntityFrameworkCore;
using WebApiCustomers.Context;
using WebApiCustomers.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Crear variable para la cadena de conexion
var connectionString = builder.Configuration.GetConnectionString("Connection");
// Configurar DbContext para utilizar SQL Server
builder.Services.AddDbContext<AppDbContext>
    (options =>options.UseSqlServer(connectionString)
);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//REGISTRANDO EL REPOSITORIO
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

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
