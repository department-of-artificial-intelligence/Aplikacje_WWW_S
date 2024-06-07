using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SchoolRegister.Model.DataModels
{
    public class Subject
    {
        public int Id {get;set;}
        [Required]
        public string Name {get; set;} = null!;
        public string Description {get; set;} = null!;

        public virtual IList<SubjectGroup>? SubjectGroups {get;set;}
        public int TeacherId {get;set;}
        public virtual Teacher? Teacher {get;set;}
        public virtual IList<Grade>? Grades {get;set;}

        //Subject()


    }
}