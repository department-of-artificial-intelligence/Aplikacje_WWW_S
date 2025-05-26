using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.ConcreteServices
{
    public class GradeService : BaseService, IGradeService
    {
        protected UserManager<User> _userManager;

        public GradeService(
            ApplicationDbContext dbContext,
            IMapper mapper,
            ILogger logger,
            UserManager<User> userManager
        )
            : base(dbContext, mapper, logger)
        {
            _userManager = userManager;
        }

        public GradeVm AddGradeToStudent(AddGradeToStudentVm addGradeToStudentVm)
        {
            try
            {
                var studentEntity = DbContext
                    .Users.OfType<Student>()
                    .FirstOrDefault(p => p.Id == addGradeToStudentVm.StudentId);
                var gradeEntity = DbContext.Grades.FirstOrDefault(g =>
                    g.Id == addGradeToStudentVm.GradeId
                );
                studentEntity.Grades.Add(gradeEntity);
                var gradeVm = Mapper.Map<GradeVm>(gradeEntity);
                return gradeVm;
            }
            catch (Exception ex)
            {
                Log.LogError(ex, ex.Message);
                throw;
            }
        }

        public GradesReportVm GetGradesReportForStudent(GetGradesReportVm getGradesVm) { }
    }
}
