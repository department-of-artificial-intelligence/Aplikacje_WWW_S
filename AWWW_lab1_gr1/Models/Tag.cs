
public class Tag{
    public int ID{get; set;}
    public required string Name{get;set;}
    public List<Article>? Articles { get; set; }
}