using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using w2_p4.Models;

namespace w2_p4
{
    public class MyDbContext : DbContext
    {
        public virtual DbSet<Article> Articles { get; set; } //przy lazy loading w starszych wersjach EF - virtual
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
