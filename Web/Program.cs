using DAL;
using Microsoft.EntityFrameworkCore;
using Services.ActualServices;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>( options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    .UseLazyLoadingProxies() 
);

builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IBuildingService, BuildingService>();

builder.Services.AddAutoMapper(
    _ => { },
    typeof(Program).Assembly,
    typeof(BaseService).Assembly);

var app = builder.Build();

app.UseExceptionHandler("/Error/Error");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
