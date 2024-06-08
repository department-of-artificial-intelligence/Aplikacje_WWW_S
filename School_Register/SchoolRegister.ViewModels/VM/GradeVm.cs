using SchoolRegister.Model.DataModels; 
namespace SchoolRegister.ViewModels.VM; 

public class GradeVm {
        public DateTime DateOfIssue {get; set;} 
        public GradeScale GradeValue {get; set;}
        public string SubjectName {get; set;}
        // [ForeignKey("Subject")]
        public int SubjectId {get; set;}
        // [ForeignKey("Student")]
        public int StudentId {get; set;}
        public string StudentName {get; set;}
}