using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolRegister.DAL.EF; // Dla ApplicationDbContext
using SchoolRegister.Model.DataModels; // Dla User, Role

var builder = WebApplication.CreateBuilder(args);

// Pobranie connection stringa
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Rejestracja DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
    // UseLazyLoadingProxies jest już w ApplicationDbContext.OnConfiguring
});

// Dodanie filtra wyjątków dla deweloperów bazy danych
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Rejestracja usług ASP.NET Core Identity (zgodnie z Lab 5, str. 10)
builder.Services.AddDefaultIdentity<User>(options => {
        options.SignIn.RequireConfirmedAccount = false; // Zgodnie z Lab 5
    })
    .AddRoles<Role>() // Dodaje obsługę ról z niestandardową klasą Role
    .AddRoleManager<RoleManager<Role>>() // Zgodnie z Lab 5
    .AddUserManager<UserManager<User>>()   // Zgodnie z Lab 5
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders(); // Ważne dla funkcji jak reset hasła

// Rejestracja kontrolerów z widokami i Razor Runtime Compilation
var mvcBuilder = builder.Services.AddControllersWithViews();

if (builder.Environment.IsDevelopment())
{
    // Dodaj pakiet NuGet: Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
    mvcBuilder.AddRazorRuntimeCompilation();
}

// Rejestracja Razor Pages (potrzebne dla domyślnego UI Identity i innych Razor Pages)
builder.Services.AddRazorPages();


// Budowanie aplikacji
var app = builder.Build();

// Konfiguracja potoku HTTP
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint(); // Ułatwia migracje
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// WAŻNE: Kolejność middleware dla Identity
app.UseAuthentication(); // Włącza uwierzytelnianie
app.UseAuthorization();  // Włącza autoryzację

// Mapowanie tras
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages(); // Dla stron Identity i innych Razor Pages

app.Run();