using Microsoft.EntityFrameworkCore;
using AWWW_lab2_gr2.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("MyConnection");
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));
var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();


app.Run();
