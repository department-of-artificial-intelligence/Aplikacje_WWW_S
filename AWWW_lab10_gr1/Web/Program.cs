using AutoMapper;
using DAL;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Services.Services;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();







                builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // potrzebne do migracji

                builder.Services.AddAutoMapper(
                 //   _ => { },
                    typeof(Program).Assembly,
                    typeof(BaseService).Assembly);

            builder.Services.AddScoped<IBuildingService, BuildingService>(); // wa¿ne do wyœwietlania


            var app = builder.Build();

                using (var scope = app.Services.CreateScope())
                {
                    var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
                    mapper.ConfigurationProvider.AssertConfigurationIsValid();
                }

                using (var scope = app.Services.CreateScope())
                {
                    var serviceProvider = scope.ServiceProvider;

                    var mapper = serviceProvider.GetRequiredService<IMapper>();
                    mapper.ConfigurationProvider.AssertConfigurationIsValid();

                }

            app.UseExceptionHandler("/Home/Error");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}
