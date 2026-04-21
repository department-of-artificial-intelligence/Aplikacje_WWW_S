namespace MultiSelectListExample.Models
{
	public class Article
	{
		public int Id { get; set; }
		public required string Title { get; set; }
		public required string Content { get; set; }
        public IList<Tag>? Tags { get; set; }
	}
}
