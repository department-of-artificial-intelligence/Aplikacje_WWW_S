using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab2_gr1.Models 
{
    public class MyDBContext : DbContext
    {
        public DbSet<Customer> Customers {get; set;}
    }
}