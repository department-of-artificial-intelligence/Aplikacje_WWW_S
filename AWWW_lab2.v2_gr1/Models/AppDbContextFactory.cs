using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using AWWW_lab2.v2_gr1.Models;

namespace AWWW_lab2.v2_gr1.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=AWWW_lab2;Trusted_Connection=True;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}