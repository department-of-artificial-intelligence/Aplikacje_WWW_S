using Microsoft.AspNetCore.Identity;
using System;

namespace SchoolRegister.Model.DataModels{
    public class Article{
        public int Id;
        public string Title;
        public string Lead;
        public string Content;
        public DateTime CreationDate;
        
    }
}