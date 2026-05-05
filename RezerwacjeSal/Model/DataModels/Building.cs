using System.ComponentModel.DataAnnotations;

namespace Model.DataModels
{
    public class Building
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
