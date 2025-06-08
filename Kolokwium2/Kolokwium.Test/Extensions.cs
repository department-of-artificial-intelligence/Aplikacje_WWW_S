using Kolokwium.DAL;
using Kolokwium.Model.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Kolokwium.Test;
public static class Extensions
{
    // Create sample data
    public static async void SeedData(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();

        // add seed data here

        await dbContext.SaveChangesAsync();
    }
}