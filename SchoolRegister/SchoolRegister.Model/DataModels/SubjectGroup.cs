using System.Text.RegularExpressions;

public class SubjectGroup{
    public required Subject Subject{get; set;}
    public int SubjectId{get; set;}
    public required Group Group{get; set;}
    public int GroupId {get; set;}
   
}