using AWWW_lab1_gr1;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyDbContext>(options =>
{
 var cs = builder.Configuration.GetConnectionString("DefaultConnection");
options.UseSqlServer(cs);
});



builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.MapDefaultControllerRoute();

app.Run();