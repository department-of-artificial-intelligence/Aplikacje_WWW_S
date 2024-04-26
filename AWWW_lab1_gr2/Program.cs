using AWWW_lab1_gr2;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("MyConnection");
builder.Services.AddDbContext<MyDbContext>(x => x.UseSqlServer(connectionString));

var app = builder.Build();

app.UseHttpsRedirection(); 
app.UseStaticFiles();   
app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();