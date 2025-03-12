using System.Diagnostics.Contracts;

namespace SchoolRegister.Model.DataModels{

    public class SubjectGroup{


        public Group Group {get; set;}
        public int GroupId {get; set;}
        public Subject Subject {get; set;}
        public ContractOptionAttribute SubjectId {get; set;}

    }


}