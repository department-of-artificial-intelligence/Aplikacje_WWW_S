using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 


namespace SchoolRegister.Model.DataModels
{
    public class Parent: User
    {
        public virtual IList<Student>? Students { get; set; }
        
    }
}