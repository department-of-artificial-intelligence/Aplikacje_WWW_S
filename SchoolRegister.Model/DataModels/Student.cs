using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Student
    {
        public int GroupId { get; set; }
        public Group Group { get; set; } = null!;
        public IList<Grade>? Grades { get; set; }
        public int ParentId { get; set; }
        public Parent Parent { get; set; } = null!;
        public double AverageGrade { get; set; }
        // public IDictionary<string, double> AverageGradePerSubject {
        //     // logika obliczająca średnią z każdego przedmiotu            
        // }
        // public IDictionary<string, IList<GradeScale>> GradesPerSubject {
        //     // logika zwracająca oceny z każdego przedmiotu
        // }
    }
}