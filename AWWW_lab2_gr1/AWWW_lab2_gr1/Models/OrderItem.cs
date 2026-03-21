using Microsoft.EntityFrameworkCore;

namespace AWWW_lab2_gr1.Models
{
    public class OrderItem //Encja posrednia miedzy zamowieniem a produktem, dlatego relacja N:M; jedno zamówienie może mieć wiele produktów; jeden produkt może być w wielu zamówieniach
    {
        public int Id { get; set; }
        public int OrderId { get; set; } //FK
        public int ProductId { get; set; } //FK 

        public int Quantity { get; set; }

        [Precision(18, 4)]
        public decimal UnitPrice { get; set; }  

        public Order Order { get; set; } // do 1 zamowienia
        public Product Product { get; set; } //do 1 produktu
    }
}
