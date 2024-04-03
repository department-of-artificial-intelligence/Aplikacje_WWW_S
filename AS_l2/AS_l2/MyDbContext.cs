using Microsoft.EntityFrameworkCore;
using AS_l2.Models;

namespace AS_l2
{
    public class MyDbContext:DbContext
    {
        public virtual DbSet<Article> Articles { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }
        
    }
}
