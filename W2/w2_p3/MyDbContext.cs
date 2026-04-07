using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using w2_p3.Models;

namespace w2_p3
{
    public class MyDbContext : DbContext
    {
        public virtual DbSet<Article> Articles { get; set; } = null!;

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

    }
}
