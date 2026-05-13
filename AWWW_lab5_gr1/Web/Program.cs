using AutoMapper;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using Services.Services;
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

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
                mapper.ConfigurationProvider.AssertConfigurationIsValid();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
