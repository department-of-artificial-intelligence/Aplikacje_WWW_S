using AWWW_lab2_gr3;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connection = builder.Configuration.GetConnectionString("MyConnection");
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(connection));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();
