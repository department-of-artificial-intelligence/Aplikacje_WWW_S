using System.ComponentModel.DataAnnotations.Schema; /// to use ForeignKey attribute

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime PublishedDate { get; set; }
    [ForeignKey("AuthorId")] // specify foreign key for Author
    public int AuthorId { get; set; }
    public virtual Author Author { get; set; }
    public virtual IList<Library> Libraries { get; set; }

}
