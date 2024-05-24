using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SchoolRegister.Model.DataModels
{
    public class SubjectGroup
    {
        public required virtual Subject Subject {get; set;}
        [ForeignKey("Subject")]
        public int SubjectId {get; set;}
        public required virtual Group Group {get; set;}
        [ForeignKey("Group")]
        public int GroupId {get; set;}
        
    }
}