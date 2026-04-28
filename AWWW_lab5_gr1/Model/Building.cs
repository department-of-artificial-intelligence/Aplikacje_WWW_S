namespace Model
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}