using AWWW_lab1_gr1.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<MyDBContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("MyDBContext")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

app.MapDefaultControllerRoute();
app.Run();

