using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolRegister.BLL.Entities;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.DTOs;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace SchoolRegister.Web.Controllers
{
    [Authorize(Roles = "Teacher, Admin, Student, Parent")]
    public class SubjectController : BaseController<SubjectController>
    {
        private readonly ISubjectService _subjectService;
        private readonly ITeacherService _teacherService;
        private readonly UserManager<User> _userManager;
        public SubjectController(ISubjectService subjectService, ITeacherService teacherService, UserManager<User> userManager,
            IStringLocalizer<SubjectController> localizer, ILoggerFactory loggerFactory) : base(localizer, loggerFactory)
        {
            _subjectService = subjectService;
            _teacherService = teacherService;
            _userManager = userManager;
        }
                
        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(User).Result;
            if (_userManager.IsInRoleAsync(user, "Admin").Result)
            {
                return View(_subjectService.GetSubjects());
            }
            else if (_userManager.IsInRoleAsync(user, "Teacher").Result)
            {
                var teacher = _userManager.GetUserAsync(User).Result as Teacher;
                return View(_subjectService.GetSubjects(x => x.TeacherId == teacher.Id));
            }
            else if (_userManager.IsInRoleAsync(user, "Student").Result)
            {
                return RedirectToAction("Details", "Student", new { studentId = user.Id });
            }
            else
            {
                return View("Error");
            }

        }
        public IActionResult Details(int id)
        {
            var subjectVm = _subjectService.GetSubject(x => x.Id == id);
            return View(subjectVm);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddOrEditSubject(int? id = null)
        {
            var teachersVm = _teacherService.GetTeachers();            
            ViewBag.TeachersSelectList = new SelectList(teachersVm.Select(t => new
            {
                Text = $"{t.FirstName} {t.LastName}",
                Value = t.Id
            })
                , "Value", "Text");

            if (id.HasValue)
            {
                var subjectVm = _subjectService.GetSubject(x => x.Id == id);
                ViewBag.ActionType = _localizer["Edit"];
                return View(Mapper.Map<AddOrUpdateSubjectDto>(subjectVm));
            }

            ViewBag.ActionType = _localizer["Add"];
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEditSubject(AddOrUpdateSubjectDto addOrUpdateSubjectDto)
        {
            if (ModelState.IsValid)
            {
                _subjectService.AddOrUpdate(addOrUpdateSubjectDto);
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}