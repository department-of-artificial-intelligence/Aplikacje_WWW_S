namespace SchoolRegister.Model.DataModels{

    public class Grade{

        public DateTime DateOfIssue {get; set;}
        public GradeScale GradeValue {get; set;}

        public Student Student { get; set;}

        public int StudenId { get; set;}

        public Subject Subject { get; set;}

        public int SubjectId { get; set;}
        

    }


}