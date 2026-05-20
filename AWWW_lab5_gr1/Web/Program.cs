using AutoMapper;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using Services.Services;
using Services.Interfaces;
using System;

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
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                    .UseLazyLoadingProxies());

            builder.Services.AddAutoMapper(
                _ => { },
                typeof(Program).Assembly,
                typeof(BaseService).Assembly);

            builder.Services.AddScoped<IBuildingService, BuildingService>();
            builder.Services.AddScoped<IRoomService, RoomService>();
            builder.Services.AddScoped<IEventTypeService, EventTypeService>();
            builder.Services.AddScoped<IEquipmentService, EquipmentService>();

            var app = builder.Build();

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

            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}
