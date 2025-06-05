var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
//// Uncomment the line below to enable Razor Pages
var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
///
app.MapDefaultControllerRoute();

app.Run();

