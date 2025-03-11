namespace AWWW_lab2_gr3.Models;

public class Tag{
    public int Id { get; set;}
    public string Name { get; set;}

    public ICollection<Article> Article { get; set; }
}