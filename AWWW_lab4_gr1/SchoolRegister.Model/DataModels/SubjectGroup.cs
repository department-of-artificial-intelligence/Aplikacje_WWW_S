using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace SchoolRegister.Model.DataModels{

public class SubjectGroup
{
    public virtual Subject Subject { get; set; }

    public required int SubjectId { get; set; }

    public virtual Group Group { get; set; }

    public required int GroupId { get; set; }
}
}