namespace Kolokwium.Model.DataModels;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public virtual IList<Book> books { get; set; }
}