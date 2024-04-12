using AWWW_lab1_gr1;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MeBdContext>(options =>
{
var cs = "Server=(localdb)\\mssqllocaldb;Database=Leonid_FabishevskyiAppDb;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=True;TrustServerCertificate=True";//builder.Configuration.GetConnectionString("DefaultConnection");
 //   var cs = builder.Configuration["ConnectionStrings:Conn"];
    options.UseSqlServer(cs);
});

builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();
