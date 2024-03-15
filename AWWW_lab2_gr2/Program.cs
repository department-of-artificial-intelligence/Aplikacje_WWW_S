using Microsoft.EntityFrameworkCore;
using AWWW_lab2_gr2.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("MyConnection");
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseHttpsRedirection();
app.MapDefaultControllerRoute();

// app.MapGet("/", () => "Hello World!");

app.Run();
