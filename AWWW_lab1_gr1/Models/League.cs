namespace AWWW_lab1_gr1.Models
{
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;
        public int Level { get; set; }

        public ICollection<Team>? Teams { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Country: {Country}, " +
                $"Level: {Level}";
        }
    }
}
