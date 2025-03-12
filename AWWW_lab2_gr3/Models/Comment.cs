public class Comment 
{
    public int Id { get; set;}
    public string Title { get; set;}
    public string Content { get; set;}

    public virtual Article article{ get; set;} 
}