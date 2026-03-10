using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab1_gr1.Models
{
    public class Student
    {
        public int Id {get;set;}
        public String FirstName {get;set;}
        public String LastName {get;set;}
        public String IndexNr {get;set;}

        public DateTime DateOfBirth {get;set;}
        public String FieldOfStudy {get;set;}

        public String FullName{ get{return FirstName + " " + LastName;}}
    }
}