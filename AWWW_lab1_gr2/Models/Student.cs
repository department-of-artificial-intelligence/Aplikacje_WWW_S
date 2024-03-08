using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace AWWW_lab1_gr2.Models
{
    public class Student
    {
        public int Id {get;set;}
        public string FirstName {get;set;}=null!;
        public string LastName {get;set;}=null!;
        public int IndexNr {get;set;}
        public DateTime DateOfBirth{get;set;}
        public string FieldOfStudy{get;set;}=null!;
    }
}