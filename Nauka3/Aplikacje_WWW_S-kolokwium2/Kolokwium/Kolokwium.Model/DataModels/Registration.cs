using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Model.DataModels
{
    public class Registration
    {
       public  int Id { get; set; }
       public  string DocumentNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public int CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}
