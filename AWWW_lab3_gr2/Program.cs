using Microsoft.EntityFrameworkCore;
using AWWW_lab3_gr2;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MyConnection");
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();



var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseHttpsRedirection();
app.MapDefaultControllerRoute();

// app.MapGet("/", () => "Hello World!");
app.Run();
