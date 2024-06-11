using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoMapper;
using Microsoft.Extensions.Localization;
using Kolokwium.ViewModel.VM;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.Interfaces;

namespace Kolokwium.Web.Controllers
{
    public class UserController : BaseController
    {

        IUserService _userService;

        public UserController(ILogger logger, IMapper mapper, IStringLocalizer localizer, IUserService userService)
            : base(logger, mapper, localizer)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            var users = _userService.GetUsers();

            return View(users);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                // add user to database
                return RedirectToAction("Index");
            }
            return View(user);
        }



    }
}
