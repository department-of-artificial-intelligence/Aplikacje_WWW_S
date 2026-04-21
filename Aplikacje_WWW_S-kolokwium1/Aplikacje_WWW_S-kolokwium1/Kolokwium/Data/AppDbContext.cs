using Microsoft.EntityFrameworkCore;
using Kolokwium.Models;

namespace Kolokwium.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Client> Clients { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Product> Products { get; set; }

	}
}
