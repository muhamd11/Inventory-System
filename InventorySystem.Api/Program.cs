using App.Core.Repositories;
using App.EF.Repositories;
using InventorySystem.EF.Data;
using Microsoft.EntityFrameworkCore;
using App.Core;
using AutoMapper;
using App.EF;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
    ));

//builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));

builder.Services.AddAutoMapper(typeof(Program));






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
