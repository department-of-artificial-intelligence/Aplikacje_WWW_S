namespace AWWW_lab2_gr1.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    
    public class Order_Item
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal UnitPrice { get; set; }
    }
}
