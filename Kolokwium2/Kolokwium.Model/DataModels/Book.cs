using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium.Model.DataModels;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Desctiption { get; set; }
    [ForeignKey("AuthorId")]
    public int AuthorId { get; set; }
    public virtual Author Author { get; set; }
    public virtual IList<Library> libraries { get; set; }
}