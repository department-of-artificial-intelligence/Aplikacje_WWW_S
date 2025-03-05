using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class SubjectGroup
    {
        Group Group { get; set; }
        int GroupId { get; set; }
        Subject Subject { get; set; }
        int SubjectId { get; set;}
    }
}