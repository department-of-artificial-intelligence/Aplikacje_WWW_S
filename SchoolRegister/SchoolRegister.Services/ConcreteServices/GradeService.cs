using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
using Microsoft.AspNetCore.Identity;
namespace SchoolRegister.Services.ConcreteServices
{
    public class GradeService: BaseService, IGradeService
    {
        private readonly UserManager<User> _userManager;

        public GradeService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger, UserManager<User> userManager)
                            :base(dbContext, mapper, logger) {
                                _userManager = userManager;
        }



        public GradeVm AddGradeToStudent(AddGradeToStudentVm addGradeToStudentVm)
        {
            throw new NotImplementedException();
        }
        public GradesReportVm GetGradesReportForStudent(GetGradesReportVm getGradesVm)
        {
            throw new NotImplementedException();
        }
    }
}