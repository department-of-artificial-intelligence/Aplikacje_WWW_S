namespace Kolokwium.Model.DataModels;

public class Library
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }
    public virtual IList<Book> books { get; set; }
}