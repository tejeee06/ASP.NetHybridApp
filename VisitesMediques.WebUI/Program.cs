using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using VisitesMediques.Application.Services;
using VisitesMediques.Domain.Interfaces;
using VisitesMediques.Infrastructure.SQLServer.Context;
using VisitesMediques.Infrastructure.SQLServer.Repositories;
using VisitesMediques.Infrastructure.MySQL.Context;
using VisitesMediques.Infrastructure.MySQL.Repositories;
using VisitesMediques.Infrastructure.MongoDb.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// // OPCIÓN 1: SQL SERVER (Activa por defecto)
// builder.Services.AddDbContext<SqlServerDbContext>(options =>
// options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VisitasMedicasDB;Trusted_Connection=True;MultipleActiveResultSets=true"));
// builder.Services.AddScoped<IVisitaMedicaRepository, SqlServerVisitaMedicaRepository>();

// OPCIÓN 2: MYSQL (Para usarla, comenta la Opción 1 y descomenta esta)
//  var mySqlConnectionString = "Server=localhost;Database=VisitasMedicasDB;User=root;Password=root;";
//  builder.Services.AddDbContext<MySqlDbContext>(options => 
// options.UseMySql(mySqlConnectionString, ServerVersion.AutoDetect(mySqlConnectionString)));
//  builder.Services.AddScoped<IVisitaMedicaRepository, MySqlVisitaMedicaRepository>();

// OPCIÓN 3: MONGODB 
builder.Services.AddSingleton<IMongoClient>(new MongoClient("mongodb://localhost:27017"));
builder.Services.AddScoped<IVisitaMedicaRepository, MongoDbVisitaMedicaRepository>();

builder.Services.AddScoped<IVisitaMedicaService, VisitaMedicaService>();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=VisitaMedica}/{action=Index}/{id?}");

app.Run();