namespace AWWW_lab4_gr1.Models
{
    public class OrderStatusHistory
    {
        public int Id {get; set;}
        public int OrderId {get; set;} //foreign key
        public int OrderStatusId {get; set;} //foreign key
        public DateTime ChangedAt {get; set;}
    }
}
