public class Category {
    public int Id { get; set; }

    public required string Name { get; set; }
    
    public List<Article>? Articles { get; set; }
}