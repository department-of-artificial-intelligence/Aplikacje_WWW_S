using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); 

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlite("Filename=:memory:"));


var app = builder.Build();

app.UseHttpsRedirection(); 
app.UseStaticFiles(); 
app.UseRouting(); 

app.MapDefaultControllerRoute(); 

app.Run();
