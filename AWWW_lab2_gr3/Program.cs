using Microsoft.EntityFrameworkCore;
using AWWW_lab2_gr3;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var connection = builder.Configuration.GetConnectionString("DB");
builder.Services.AddDbContext<AppDbContext>(Options => Options.UseSqlServer(connection));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();