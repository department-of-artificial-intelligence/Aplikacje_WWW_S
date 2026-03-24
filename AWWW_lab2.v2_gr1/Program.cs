using AWWW_lab2.v2_gr1.Models;//
using Microsoft.EntityFrameworkCore;//

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AWWW_lab2.v2_gr1.Models.AppDbContext>(options =>
    options.UseSqlServer("Server=localhost;Database=AWWW_lab2;Trusted_Connection=True;")); //

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));//

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();


//dotnet add package Microsoft.EntityFrameworkCore
//dotnet add package Microsoft.EntityFrameworkCore.SqlServer
//dotnet add package Microsoft.EntityFrameworkCore.Tools

//dotnet tool install --global dotnet-ef
//dotnet ef migrations add InitialCreate
//dotnet ef database update


