using System;
using System.Collections.Generic;
using System.Text;
using SchoolRegister.ViewModels.DTOs;
using SchoolRegister.ViewModels.VMs;

namespace SchoolRegister.Services.Interfaces
{
    public interface IGradeService
    {
        GradeVm AddGradeToStudent(AddGradeToStudentDto addGradeToStudentDto);
        GradesReportVm GetGradesReportForStudent(GetGradesDto getGradesDto);

    }
}

