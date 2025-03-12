using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Model.DataModels
{
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Level { get; set; }
    }
}
