var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();
var connectionString = builder.Configuration.GetConnectionString("MyConnection");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapDefaultControllerRoute();

//app.MapGet("/", () => "Hello World!");

app.Run();
