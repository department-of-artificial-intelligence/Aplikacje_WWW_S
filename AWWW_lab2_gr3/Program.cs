using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AWWW_lab2_gr3.Models; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OskiDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OskiDBContext")));

builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute(); 
app.Run();