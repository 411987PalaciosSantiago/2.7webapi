using _2._7Back.Data.Models;
using _2._7Back.Repository;
using _2._7Back.Service;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
//
//

//
//



// Add services to the container.
builder.Services.AddDbContext<TurnosdbContext>(options => 
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConection")));

builder.Services.AddScoped<IServicioRepository, ServcioRepository>();
builder.Services.AddScoped<IServiceServicio, ServiceServicio>();






///



//


//
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
