using System;
using System.Dynamic;

namespace SchoolRegister.Model.Lab2Models
{
    public class Article
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Lead { get; set; }
        public string? Content { get; set; }
        public DateTime CreationDate { get; set; }
    }

}