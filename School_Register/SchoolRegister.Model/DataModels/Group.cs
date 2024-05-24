using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SchoolRegister.Model.DataModels
{
    public class Group
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public virtual IList<Student>? Students { get; set; }
        public virtual IList<SubjectGroup>? SubjectGroups { get; set; }
        
    }
}