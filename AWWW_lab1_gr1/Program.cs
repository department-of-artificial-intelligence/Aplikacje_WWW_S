using AWWW_lab1_gr1.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<LabDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<LabDbContext>();
    context.Database.EnsureCreated();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapDefaultControllerRoute();
app.Run();
