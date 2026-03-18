namespace AWWW_lab2_gr1.Models;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
