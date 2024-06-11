using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Servicies.Interfaces;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Web.Controllers
{
    public class GradeController : BaseController
    {
        private readonly IGradeService _gradeService;
        private readonly UserManager<User> _userManager;
        public GradeController(ILogger logger, IMapper mapper, IStringLocalizer localizer, IGradeService gradeService, UserManager<User> userManager)
            : base(logger, mapper, localizer)
        {
            _gradeService = gradeService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(User).Result;
            if (user == null)
            {
                return View("Error");
            }
            IList<GradesReportVm> reportVms = [];

            if (_userManager.IsInRoleAsync(user, "Student").Result && user is Student student)
            {
                var getGradeReportVm = new GetGradesReportVm
                {
                    StudentId = student.Id,
                    GetterUserId = student.Id
                };
                reportVms.Add(_gradeService.GetGradesReportForStudent(getGradeReportVm).Result);
            }
            else if (_userManager.IsInRoleAsync(user, "Parent").Result && user is Parent parent)
            {
                foreach (var studentP in parent.Students)
                {
                    var getGradeReportVm = new GetGradesReportVm
                    {
                        StudentId = studentP.Id,
                        GetterUserId = parent.Id
                    };
                    reportVms.Add((_gradeService.GetGradesReportForStudent(getGradeReportVm)).Result);
                }
            }
            else
            {
                return View("Error");
            }
            return View(reportVms);
        }

    }
}
