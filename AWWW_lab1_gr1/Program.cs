using AWWW_lab1_gr1.Data;
using AWWW_lab1_gr1.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CompanyDbContext>(options =>
	options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var db = scope.ServiceProvider.GetRequiredService<CompanyDbContext>();
	db.Database.Migrate();

	if (!db.Customers.Any())
	{
		db.Customers.AddRange(
			new Customer { Name = "Jan Kowalski" },
			new Customer { Name = "Anna Nowak" },
			new Customer { Name = "Piotr Wisniewski" });
		db.SaveChanges();
	}
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();
