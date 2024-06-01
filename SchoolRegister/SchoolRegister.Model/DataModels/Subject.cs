using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Subject
    {
        public int Id {get;set;}
        public string Name {get;set;} = null!;
        public string Description {get;set;} = null!;
        public virtual IList<SubjectGroup>? SubjectGroups {get;set;}
        public virtual Teacher Teacher {get;set;} = null!;
        [ForeignKey("Teacher")]
        public int TeacherId {get;set;}
        public virtual IList<Grade>? Grades {get;set;}
    }
}