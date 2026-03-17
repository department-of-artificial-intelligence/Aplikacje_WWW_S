using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab2.Models
{
    public class Category
    {
     private int Id {get; set;}   
     private string Name {get; set;}

    public Category()
    {
    }

    public Category(int id, string name)
    {
        Id = id;
        Name = name;
    }
    }
}