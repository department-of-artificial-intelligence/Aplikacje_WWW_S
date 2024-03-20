namespace AWWW_lab1_gr5.Models
{
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Level { get; set; }
        public virtual ICollection<Team> Teams { get; set; }


    }
}