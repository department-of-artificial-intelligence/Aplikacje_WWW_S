using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab2_gr1.Models 
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {}

        public DbSet<Address> Addresses {get;set;}
        public DbSet<Category> Categories {get;set;}
        public DbSet<Customer> Customers {get; set;}
        public DbSet<CustomerProfile> CustomerProfiles {get;set;}
        public DbSet<Order> Orders {get;set;}
        public DbSet<OrderItem> OrderItems {get;set;}
        public DbSet<Product> Products {get;set;}
        public DbSet<Review> Reviews {get;set;}
        public DbSet<Tag> Tags {get;set;} 
    }
}
