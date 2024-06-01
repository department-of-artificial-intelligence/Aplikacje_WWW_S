using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.Model.DataModels
{
    public class SubjectGroup
    {
        public int SubjectId {get;set;}
        public int GroupId {get;set;}
        public virtual Subject Subject {get;set;} = null!;
        public virtual Group Group {get;set;} = null!;
    }
}