using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolRegister.BLL.Entities;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.DTOs;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace SchoolRegister.Web.Controllers
{

    [Authorize(Roles = "Teacher, Admin")]

    public class GroupController : BaseController<GroupController>
    {
        private readonly IGroupService _groupService;
        private readonly ISubjectService _subjectService;
        private readonly UserManager<User> _userManager;
        private readonly ITeacherService _teacherService;

        public GroupController(IGroupService groupService, ISubjectService subjectService, UserManager<User> userManager, ITeacherService teacherService,
            IStringLocalizer<GroupController> localizer, ILoggerFactory loggerFactory) : base(localizer, loggerFactory)
        {
            _groupService = groupService;
            _subjectService = subjectService;
            _userManager = userManager;
            _teacherService = teacherService;
        }

        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(User).Result;
            if (!_userManager.IsInRoleAsync(user, "Teacher").Result)
                return _userManager.IsInRoleAsync(user, "Admin").Result
                    ? View(_groupService.GetGroups())
                    : View("Error");
            var getTeacherGroupsDto = new GetTeachersGroupsDto()
            {
                TeacherId = user.Id
            };
            return View(_teacherService.GetTeachersGroups(getTeacherGroupsDto));
        }

        public IActionResult Details(int id)
        {
            var group = _groupService.GetGroup(g => g.Id == id);
            return View(group);
        }

        [Authorize(Roles = "Teacher, Admin")]
        public IActionResult AddOrEditGroup(int? id = null)
        {
            if (id.HasValue)
            {
                var group = _groupService.GetGroup(g => g.Id == id.Value);
                ViewBag.ActionType = _localizer["Edit"];
                var groupDto = Mapper.Map<AddOrUpdateGroupDto>(group);
                return View(groupDto);
            }
            ViewBag.ActionType = _localizer["Add"];
            return View();
        }

        [Authorize(Roles = "Teacher, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEditGroup(AddOrUpdateGroupDto addOrUpdateGroupDto)
        {
            if (ModelState.IsValid)
            {
                _groupService.AddOrUpdateGroup(addOrUpdateGroupDto);
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize(Roles = "Teacher, Admin")]
        public IActionResult AttachSubjectToGroup(int subjectId)
        {
            return AttachDetachSubjectToGroupGetView(subjectId);
        }

        [Authorize(Roles = "Teacher, Admin")]
        public IActionResult DetachSubjectToGroup(int subjectId)
        {
            return AttachDetachSubjectToGroupGetView(subjectId);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AttachSubjectToGroup(AttachDetachSubjectGroupDto attachDetachSubjectGroupDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                _groupService.AttachSubjectToGroup(attachDetachSubjectGroupDto);
                return RedirectToAction("Index", "Subject");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return AttachDetachSubjectToGroupGetView();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DetachSubjectToGroup(AttachDetachSubjectGroupDto attachDetachSubjectGroupDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(ModelState);
                }

                _groupService.DetachSubjectFromGroup(attachDetachSubjectGroupDto);
                return RedirectToAction("Index", "Subject");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return AttachDetachSubjectToGroupGetView();
            }
        }

        [Authorize(Roles = "Teacher, Admin")]
        private IActionResult AttachDetachSubjectToGroupGetView(int? subjectId = null)
        {
            ViewBag.PostAction = ControllerContext.ActionDescriptor.ActionName;
            if (ControllerContext.ActionDescriptor.ActionName.StartsWith("Detach"))
            {
                ViewBag.ActionType = _localizer["Detach"];
            }
            else if (ControllerContext.ActionDescriptor.ActionName.StartsWith("Attach"))
            {
                ViewBag.ActionType = _localizer["Attach"];
            }
            else
            {
                return View("Error");
            }
            var subjects = _subjectService.GetSubjects();
            var groups = _groupService.GetGroups();
            var currentSubject = subjects.FirstOrDefault(x => x.Id == subjectId);
            ViewBag.SubjectList = new SelectList(subjects.Select(s => new
            {
                Text = s.Name,
                Value = s.Id,
                Selected = s.Id == currentSubject?.Id
            }), "Value", "Text");
            ViewBag.GroupList = new SelectList(groups.Select(s => new
            {
                Text = s.Name,
                Value = s.Id
            }), "Value", "Text");
            return View("AttachDetachSubjectToGroup");
        }
    }
}