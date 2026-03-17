using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Models
{
  public class Customer
{
    [Key]
    public int Id { get; private set; }
    [Required]
    public string Name { get; private set; }

    public CustomerProfile CustomerProfile { get; set; }
    public List<Address> Addresses { get; set; } = new();
    public List<Order> Orders { get; set; } = new();
    public List<Review> Reviews { get; set; } = new();


    public Customer()
    {
    }

    public Customer(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
    
}