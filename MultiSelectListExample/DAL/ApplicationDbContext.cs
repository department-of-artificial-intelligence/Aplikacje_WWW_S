using Microsoft.EntityFrameworkCore;
using MultiSelectListExample.Models;

namespace MultiSelectListExample.DAL
{
	public class ApplicationDbContext : DbContext
	{
		public required DbSet<Article> Articles { get; set; }
        public required DbSet<Tag> Tags { get; set; }
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
	}
}
