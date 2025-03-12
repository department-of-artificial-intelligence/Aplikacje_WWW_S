using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AWWW_lab2_gr3.Models; 

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbContext")));


builder.Services.AddControllersWithViews();

var app = builder.Build();


app.MapGet("/", () => "Hello World!");
app.MapControllers(); 

app.Run();
