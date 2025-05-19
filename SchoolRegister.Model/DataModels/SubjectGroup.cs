using Microsoft.AspNetCore.Identify;
using system;
namespace SchoolRegister.Model.DataModels;

public class SubjectGroup : Subject
{
    public Subject Subject { get; set; };

    public int SubjectId { get; set; };

    public Group Group { get; set; };

    public int GroupId { get; set; };

    public SubjectGroup();
}

