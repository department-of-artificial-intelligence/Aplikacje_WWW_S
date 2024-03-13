var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// app.MapGet("/", () => "Hello World!");

// app.MapDefaultControllerRoute();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Article}/{action=Index}/{id?}");

app.Run();
