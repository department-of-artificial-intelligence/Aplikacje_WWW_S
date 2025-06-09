using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.ConcreteServices;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Web.Controllers;

[Authorize (Roles = "Admin, Teacher, Student")]
public class GroupController : BaseController
{
    private readonly IGroupService _groupService;
    private readonly IStudentService _studentService;
    private readonly ISubjectService _subjectService;
    private readonly UserManager<User> _userManager;

    public GroupController(IGroupService groupService, IStudentService studentService, ISubjectService subjectService, UserManager<User> userManager, ILogger logger, IMapper mapper, IStringLocalizer localizer) : base(logger, mapper, localizer)
    {
        _groupService = groupService;
        _studentService = studentService;
        _userManager = userManager;
        _subjectService = subjectService;
    }

    public IActionResult Index()
    {
        var user = _userManager.GetUserAsync (User).Result;
        if(_userManager.IsInRoleAsync (user, "Admin").Result)
            return View(_groupService.GetGroups());
        else if(_userManager.IsInRoleAsync (user, "Teacher").Result && user is Teacher teacher)
            return View(_groupService.GetGroups(x => x.SubjectGroups.Any(y => y.Subject.TeacherId == teacher.Id)));
        else if(_userManager.IsInRoleAsync (user, "Student").Result && user is Student student)
            return RedirectToAction("Detalis", new {id = student.GroupId});
        else
            return View("Error");
    }

    [HttpGet]
    [Authorize (Roles = "Admin, Teacher")]
    public IActionResult AttachSubjectToGroup(int? subjectId = null, int? groupId = null)
    {
        if(groupId.HasValue)
        {
            var subjects = _subjectService.GetSubjects();
            ViewBag.ActionType = "GroupId";
            ViewBag.SubjectsSelectList = new SelectList(subjects.Select(s => new {
                Text = s.Name,
                Value = s.Id
            }), "Value", "Text");

            var groupVm = _groupService.GetGroup(g => g.Id == groupId);
            return View(Mapper.Map<AttachDetachSubjectGroupVm>(groupVm));

        }else if(subjectId.HasValue)
        {
            var groups = _groupService.GetGroups();
            var subjectVm = _subjectService.GetSubject(s => s.Id == subjectId);

            var usedGroupsIds = subjectVm.Groups.Select(g => g.Id).ToList();
            var availableGroups = groups.Where(g => !usedGroupsIds.Contains(g.Id)).ToList();

            if (!availableGroups.Any())
            {
                TempData["Info"] = "There are no groups avaliable for this subject";
                return RedirectToAction("Index", "Subject");
            }

            ViewBag.ActionType = "SubjectId";
            ViewBag.GroupsSelectList = new SelectList(availableGroups.Select(g => new {
                Text = g.Name,
                Value = g.Id
            }), "Value", "Text");
            
            
            return View(Mapper.Map<AttachDetachSubjectGroupVm>(subjectVm));
        }else
            return View("Error");
    }

    [HttpGet]
    [Authorize (Roles = "Admin, Teacher")]
    public IActionResult DetachSubjectFromGroup(int? groupId = null, int? subjectId = null)
    {
        if(groupId.HasValue)
        {
            var groupVm = _groupService.GetGroup(g => g.Id == groupId);
            var subjects = groupVm.Subjects;

            if(!subjects.Any())
            {
                TempData["Info"] = $"There are no any subjects in '{groupVm.Name}' group";
                return RedirectToAction("Index");
            }

            ViewBag.ActionType = "GroupId";
            ViewBag.SubjectsSelectList = new SelectList(subjects.Select(s => new{
                Text = s.Name,
                Value = s.Id
            }), "Value", "Text");

            return View(Mapper.Map<AttachDetachSubjectGroupVm>(groupVm));

        }else if(subjectId.HasValue)
        {
            var subjectVm = _subjectService.GetSubject(s => s.Id == subjectId);
            var groups = subjectVm.Groups;
            
            if(!groups.Any())
            {
                TempData["Info"] = $"Subject '{subjectVm.Name}' doesn't belong to any group";
                return RedirectToAction("Index", "Subject");
            }

            ViewBag.ActionType = "SubjectId";
            ViewBag.GroupsSelectList = new SelectList(groups.Select(g => new{
                Text = g.Name,
                Value = g.Id
            }), "Value", "Text");

            return View(Mapper.Map<AttachDetachSubjectGroupVm>(subjectVm));
        }

        return View("Error");
    }

    public IActionResult Details(int id)
    {
        var groupVm = _groupService.GetGroup(g => g.Id == id);
        return View(groupVm);
    }

    [HttpGet]
    [Authorize (Roles = "Admin, Teacher")]
    public IActionResult AddOrUpdateGroup(int? id, string name)
    {
        if(id.HasValue)
        {
            ViewBag.ActionType = "Edit";
            var groupVm = _groupService.GetGroup(g => g.Id == id);

            return View(Mapper.Map<AddOrUpdateGroupVm>(groupVm));
        }
        ViewBag.ActionType = "Add";
        return View();
    }

    public IActionResult AttachStudentToGroup(int id)
    {
        var studetns = _studentService.GetStudents(s => s.GroupId != id);
        ViewBag.StudentsSelectList = new SelectList(studetns.Select(s => new{
            Text = $"{s.FirstName} {s.LastName}",
            Value = s.Id
        }), "Value", "Text");

        var attachDetachStudentToGroupVm = new AttachDetachStudentToGroupVm
        {
            GroupId = id
        };

        return View(attachDetachStudentToGroupVm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize (Roles = "Admin, Teacher")]
    public IActionResult AttachSubjectToGroup(AttachDetachSubjectGroupVm attachDetachSubjectGroupVm)
    {
        if (!ModelState.IsValid)
            return View("Error");

        _groupService.AttachSubjectToGroup(attachDetachSubjectGroupVm);
        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize (Roles = "Admin, Teacher")]
    public IActionResult DetachSubjectFromGroup(AttachDetachSubjectGroupVm attachDetachSubjectGroupVm)
    {
        if(!ModelState.IsValid)
            return View("Error");
        
        _groupService.DetachSubjectFromGroup(attachDetachSubjectGroupVm);
        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize (Roles = "Admin, Teacher")]
    public IActionResult AddOrUpdateGroup(AddOrUpdateGroupVm addOrUpdateGroupVm)
    {
        if(!ModelState.IsValid)
            return View("Error");

        _groupService.AddOrUpdateGroup(addOrUpdateGroupVm);
        return RedirectToAction("Index"); 
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize (Roles = "Admin, Teacher")]
    public async Task<IActionResult> AttachStudentToGroup(AttachDetachStudentToGroupVm attachDetachStudentToGroupVm)
    {
        if(!ModelState.IsValid)
            return View("Error");
        
        await _groupService.AttachStudentToGroup(attachDetachStudentToGroupVm);
        return  RedirectToAction("Index");
    }
}