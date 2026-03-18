using Microsoft.EntityFrameworkCore;
using AWWW_lab2_gr1.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    .UseLazyLoadingProxies()
);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();