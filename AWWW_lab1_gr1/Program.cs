using Microsoft.EntityFrameworkCore;
using AWWW_lab1_gr1.Models;
using AWWW_lab1_gr1.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
// added
var connectionString = builder.Configuration.GetConnectionString("MyConnection");
builder.Services.AddDbContext<MyDBContext>(x => x.UseSqlServer(connectionString));
//

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// app.MapGet("/", () => "Hello World!");

app.MapDefaultControllerRoute();


// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Article}/{action=Index}/{id?}");

app.Run();
