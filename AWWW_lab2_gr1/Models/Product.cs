using System.Formats.Asn1;
using Microsoft.EntityFrameworkCore;
namespace AWWW_lab2_gr1.Models;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    [Precision(18, 4)]
    public decimal Price { get; set; }
    public int CategoryId { get; set; }

    public Category Category { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
    public ICollection<Review> Reviews { get; set; }

    public ICollection<Tag> Tags { get; set; }
}