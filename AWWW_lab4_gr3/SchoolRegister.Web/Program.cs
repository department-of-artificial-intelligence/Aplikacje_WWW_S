using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolRegister.DAL; 
using SchoolRegister.Model.DataModels; 

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)); 

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddDefaultIdentity<User>(options => { 
        options.SignIn.RequireConfirmedAccount = true;
        
    })
    .AddRoles<Role>() 
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint(); 
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages(); 

app.Run();