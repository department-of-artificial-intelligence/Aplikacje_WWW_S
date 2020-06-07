using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VMs;

namespace SchoolRegister.Web.Controllers
{
    [Authorize]
    public class ChatController : BaseController<ChatController>
    {
        private IStudentService _studentService;
        private IGroupService _groupService;
        public ChatController(IStringLocalizer<ChatController> localizer, ILoggerFactory loggerFactory, IStudentService studentService, IGroupService groupService)
            : base(localizer, loggerFactory)
        {
            _studentService = studentService;
            _groupService = groupService;
        }
        public IActionResult Index()
        {
            var students = _studentService.GetStudents().ToList();
            students.Add(new StudentVm()
            {
                UserName = "All"
            });
            var chatGroups = _groupService.GetGroups();
            var studentsListItems = Mapper.Map<IEnumerable<SelectListItem>>(students);
            var chatGroupListItems = Mapper.Map<IEnumerable<SelectListItem>>(chatGroups);
            return View(new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>(studentsListItems, chatGroupListItems));
        }
    }
}