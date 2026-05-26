using DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options
        .UseLazyLoadingProxies()
        .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

<<<<<<< HEAD
builder.Services.AddScoped<IBuildingService,BuildingService>();
builder.Services.AddScoped<IRoomService , RoomService>();
var app = builder.Build();

app.useExceptionHandler("/Home/Error");
=======
builder.Services.AddAutoMapper(
    _ => { },
    typeof(Program).Assembly,
    typeof(Services.Mapping.BuildingProfile).Assembly);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var mapper = scope.ServiceProvider.GetRequiredService<AutoMapper.IMapper>();
    mapper.ConfigurationProvider.AssertConfigurationIsValid();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
>>>>>>> 02af4d800bb64676bcb7897f5f6cb43395edc3dd

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

<<<<<<< HEAD
app.MapDefaultControllerRoute();
=======
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

>>>>>>> 02af4d800bb64676bcb7897f5f6cb43395edc3dd

app.Run();
