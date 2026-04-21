using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace AWWW_lab2_gr1.Models
{
    public class Product
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        [Precision(18, 4)]
        public decimal Price { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; } //Referencja do Category

        public List<OrderItem> OrderItems { get; set; } //1:N 1 produkt, wiele zamowien
        public List<Review> Reviews { get; set; } //1:N 1 produkt, wiele recenzji

        public List<Tag> Tags { get; set; } //N:N, wiele produktow wiele tagow; nie wymaga klucza obcego
    }
}
