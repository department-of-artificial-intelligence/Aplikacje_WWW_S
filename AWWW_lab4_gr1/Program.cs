using Microsoft.EntityFrameworkCore;
using AWWW_lab4_gr1.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // potrzebne do migracji

var app = builder.Build();

//app.MapGet("/", () => "Hello World!"); bez tego nie działa pusty projekt
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();
