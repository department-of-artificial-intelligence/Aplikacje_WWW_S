using Microsoft.EntityFrameworkCore;
using AWWW_lab2_gr1.Data;


namespace AWWW_lab2_gr1
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(
					builder.Configuration.GetConnectionString("DefaultConnection")
				)
			);

            var app = builder.Build();

			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
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
		}
	}
}
