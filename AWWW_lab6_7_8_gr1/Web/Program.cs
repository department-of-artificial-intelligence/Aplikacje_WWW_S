using Microsoft.EntityFrameworkCore;
using DAL;
using Services.Interfaces;
using Services.Services;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IRoomEquipmentService, RoomEquipmentService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IReservationService, ReservationService>();

builder.Services.AddAutoMapper(
    cfg => { },
    typeof(Program).Assembly,
    typeof(BaseService).Assembly);
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
    // Ta linijka wyrzuci wyjątek przy starcie, jeśli zapomniałeś zmapować (lub zignorować) jakieś pole w Profilach!
    mapper.ConfigurationProvider.AssertConfigurationIsValid();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();