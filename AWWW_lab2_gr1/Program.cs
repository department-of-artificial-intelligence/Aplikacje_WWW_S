using Microsoft.EntityFrameworkCore;
using AWWW_lab2_gr1.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Dodajemy obsługę Kontrolerów i Widoków (MVC)
builder.Services.AddControllersWithViews();

// 2. Rejestrujemy naszą bazę danych (DbContext)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Konfiguracja potoku HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 3. Ustawiamy domyślny routing (ścieżki) dla naszych kontrolerów
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();