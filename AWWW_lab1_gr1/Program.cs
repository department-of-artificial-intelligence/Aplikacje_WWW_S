using AWWW_lab1_gr1;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//var cs = builder.Configuration["ConnectionStrings:Conn"];
//var cs2 = builder.Configuration.GetConnectionString("Conn");
builder.Services.AddDbContext<MeBdContext>(options =>
{
var cs = "Server=(localdb)\\mssqllocaldb;Database=Leonid_FabishevskyiAppDb;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=True;TrustServerCertificate=True";//builder.Configuration.GetConnectionString("DefaultConnection");
   
    options.UseSqlServer(cs);
});

builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();
