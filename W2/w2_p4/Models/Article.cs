using Azure;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace w2_p4.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Lead { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        //1 - *
        [ValidateNever]
        public virtual Author Author { get; set; } = null!; //komentarz - lub Author?
        [Required]
        public int? AuthorId { get; set; } //komentarz - dla int zawsze zostanie przypisane 0...
        //1 - *
        public virtual Category? Category { get; set; }
        public int? CategoryId { get; set; }
        //* - *
        public virtual ICollection<Tag>? Tags { get; set; }
    }
}
