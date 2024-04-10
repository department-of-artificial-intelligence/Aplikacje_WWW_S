using AWWW_lab1_gr2.Models; 
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); 

// dodanie loggera
builder.Services.AddTransient<ILogger, Logger<Program>>();

var connectionString = builder.Configuration.GetConnectionString("MyConnection"); 

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection(); 
app.UseStaticFiles(); 
app.UseRouting(); 

app.MapDefaultControllerRoute(); 

app.Run();
