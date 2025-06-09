using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using NuGet.Protocol.Plugins;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.ConcreteServices;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Web.Controllers;
[Authorize (Roles = "Admin, Teacher, Student, Parent")]
public class GradeController : BaseController
{
    private readonly IGradeService _gradeService;
    private readonly ISubjectService _subjectService;
    private readonly IStudentService _studentService;
    private readonly ITeacherService _teacherService;
    
    private readonly UserManager<User> _userManager;

    public GradeController(IGradeService gradeService, ISubjectService subjectService, IStudentService studentService, ITeacherService teacherService, UserManager<User> userManager, ILogger logger, IMapper mapper, IStringLocalizer localizer) : base(logger, mapper, localizer)
    {
        _gradeService = gradeService;
        _subjectService = subjectService;
        _studentService = studentService;
        _teacherService = teacherService;
        _userManager = userManager;
    }

    [Authorize (Roles = "Admin, Teacher, Student, Parent")]
    public IActionResult Index()
    {
        var user = _userManager.GetUserAsync(User).Result;
        if(_userManager.IsInRoleAsync(user, "Admin").Result)
            return View(_studentService.GetStudents());
        else if(_userManager.IsInRoleAsync(user, "Teacher").Result && user is Teacher teacher)
        {
            var getTeachersGroupsVm = Mapper.Map<TeachersGroupsVm>(teacher);
            var teacherGroups = _teacherService.GetTeachersGroups(getTeachersGroupsVm);
            
            var teacherGroupsIds = teacherGroups.Select(g => g.Id).ToList();

            return View(_studentService.GetStudents(s => teacherGroupsIds.Contains(s.Group.Id)));
        }
        else if(_userManager.IsInRoleAsync(user, "Student").Result)
            return RedirectToAction("Details", new {id = user.Id});
        else if(_userManager.IsInRoleAsync(user, "Parent").Result && user is Parent parent)
            return View(_studentService.GetStudents(s => s.ParentId == parent.Id));
        
        return View("Error");
    }

    [HttpGet]
    [Authorize (Roles = "Teacher")]
    public IActionResult AddGradeToStudent(int id)
    {
        var studentId = id;

        var user = _userManager.GetUserAsync(User).Result;
        var teacher = user as Teacher;
        var subjects = _subjectService.GetSubjects(s => s.TeacherId == teacher.Id);

        ViewBag.SubjectsSelectList = new SelectList(subjects.Select(s => new{
            Text = s.Name,
            Value = s.Id
        }), "Value", "Text");

        var addGradeToStudentVm = new AddGradeToStudentVm
        {
            StudentId = studentId,
            TeacherId = teacher.Id,
        };
        return View(addGradeToStudentVm);
    }

    public async Task<IActionResult> Details(int id)
    {
        var user = _userManager.GetUserAsync(User).Result;
        var getGradesReportVm = new GetGradesReportVm
        {
            StudentId = id,
            GetterUserId = user.Id
        };

        var gradesReportVm = await _gradeService.GetGradesReportForStudent(getGradesReportVm);
        return View(gradesReportVm);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize (Roles = "Teacher")]
    public async Task<IActionResult> AddGradeToStudent(AddGradeToStudentVm addGradeToStudentVm)
    {
        if(!ModelState.IsValid)
            return View("Error");
        
        await _gradeService.AddGradeToStudent(addGradeToStudentVm);
        return RedirectToAction("Index");
    }
}